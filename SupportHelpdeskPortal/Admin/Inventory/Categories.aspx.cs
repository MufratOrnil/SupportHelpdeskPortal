using System;
using System.Data;
using System.Data.SqlClient;
using SupportHelpdeskPortal;

namespace SupportHelpdeskPortal.Admin.Inventory
{
    public partial class Categories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindCategories();
        }

        private void BindCategories()
        {
            DataTable dt = DbHelper.ExecuteDataTable("sp_GetCategories");
            gvCategories.DataSource = dt;
            gvCategories.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int categoryId;
            int.TryParse(hfCategoryId.Value, out categoryId);

            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                lblMsg.Text = "Category name is required.";
                return;
            }

            if (categoryId == 0)
            {
                SqlParameter p = new SqlParameter("@CategoryName",
                    txtCategoryName.Text.Trim());
                DbHelper.ExecuteDataTable("sp_InsertCategory", p);
            }
            else
            {
                SqlParameter[] param =
                {
                    new SqlParameter("@CategoryId", categoryId),
                    new SqlParameter("@CategoryName", txtCategoryName.Text.Trim())
                };
                DbHelper.ExecuteDataTable("sp_UpdateCategory", param);
            }

            hfCategoryId.Value = "0";
            txtCategoryName.Text = "";
            lblMsg.Text = "";
            BindCategories();
        }

        protected void gvCategories_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "EditRow")
            {
                SqlParameter p = new SqlParameter("@CategoryId", id);
                DataTable dt = DbHelper.ExecuteDataTable("sp_GetCategoryById", p);
                if (dt.Rows.Count == 1)
                {
                    hfCategoryId.Value = dt.Rows[0]["CategoryId"].ToString();
                    txtCategoryName.Text = dt.Rows[0]["CategoryName"].ToString();
                }
            }
            else if (e.CommandName == "DeleteRow")
            {
                SqlParameter p = new SqlParameter("@CategoryId", id);
                DbHelper.ExecuteDataTable("sp_DeleteCategory", p);
                BindCategories();
            }
        }
    }
}

