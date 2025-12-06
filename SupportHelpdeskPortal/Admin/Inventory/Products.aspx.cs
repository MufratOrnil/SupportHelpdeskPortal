using System;
using System.Data;
using System.Data.SqlClient;
using SupportHelpdeskPortal;

namespace SupportHelpdeskPortal.Admin.Inventory
{
    public partial class Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCategories();
                BindProducts();
            }
        }

        private void BindCategories()
        {
            DataTable dt = DbHelper.ExecuteDataTable("sp_GetCategories");
            ddlCategory.DataSource = dt;
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "CategoryId";
            ddlCategory.DataBind();
        }

        private void BindProducts()
        {
            DataTable dt = DbHelper.ExecuteDataTable("sp_GetProducts");
            gvProducts.DataSource = dt;
            gvProducts.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int productId;
            int.TryParse(hfProductId.Value, out productId);

            string name = txtProductName.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                lblMsg.Text = "Product name required.";
                return;
            }

            decimal price;
            int stock;
            decimal.TryParse(txtUnitPrice.Text, out price);
            int.TryParse(txtStock.Text, out stock);

            SqlParameter[] param;

            if (productId == 0)
            {
                param = new[]
                {
                    new SqlParameter("@ProductName", name),
                    new SqlParameter("@CategoryId", ddlCategory.SelectedValue),
                    new SqlParameter("@UnitPrice", price),
                    new SqlParameter("@StockQuantity", stock)
                };
                DbHelper.ExecuteDataTable("sp_InsertProduct", param);
            }
            else
            {
                param = new[]
                {
                    new SqlParameter("@ProductId", productId),
                    new SqlParameter("@ProductName", name),
                    new SqlParameter("@CategoryId", ddlCategory.SelectedValue),
                    new SqlParameter("@UnitPrice", price),
                    new SqlParameter("@StockQuantity", stock)
                };
                DbHelper.ExecuteDataTable("sp_UpdateProduct", param);
            }

            hfProductId.Value = "0";
            txtProductName.Text = "";
            txtUnitPrice.Text = "";
            txtStock.Text = "";
            lblMsg.Text = "";
            BindProducts();
        }

        protected void gvProducts_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "EditRow")
            {
                SqlParameter p = new SqlParameter("@ProductId", id);
                DataTable dt = DbHelper.ExecuteDataTable("sp_GetProductById", p);

                if (dt.Rows.Count == 1)
                {
                    hfProductId.Value = dt.Rows[0]["ProductId"].ToString();
                    txtProductName.Text = dt.Rows[0]["ProductName"].ToString();
                    ddlCategory.SelectedValue = dt.Rows[0]["CategoryId"].ToString();
                    txtUnitPrice.Text = dt.Rows[0]["UnitPrice"].ToString();
                    txtStock.Text = dt.Rows[0]["StockQuantity"].ToString();
                }
            }
            else if (e.CommandName == "DeleteRow")
            {
                SqlParameter p = new SqlParameter("@ProductId", id);
                DbHelper.ExecuteDataTable("sp_DeleteProduct", p);
                BindProducts();
            }
        }

        protected void gvProducts_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            gvProducts.PageIndex = e.NewPageIndex;
            BindProducts();
        }
    }
}
