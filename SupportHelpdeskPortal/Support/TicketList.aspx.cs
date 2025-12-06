using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.UI;
using SupportHelpdeskPortal;

namespace SupportHelpdeskPortal.Support
{
    public partial class TicketList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindTickets();
        }

        private void BindTickets()
        {
            string status = string.IsNullOrEmpty(ddlFilterStatus.SelectedValue)
                ? null
                : ddlFilterStatus.SelectedValue;

            DateTime? from = null, to = null;

            if (DateTime.TryParse(txtFromDate.Text, out DateTime f))
                from = f;
            if (DateTime.TryParse(txtToDate.Text, out DateTime t))
                to = t;

            SqlParameter[] param =
            {
                new SqlParameter("@Status", (object)status ?? DBNull.Value),
                new SqlParameter("@StartDate", (object)from ?? DBNull.Value),
                new SqlParameter("@EndDate", (object)to ?? DBNull.Value)
            };

            DataTable dt = DbHelper.ExecuteDataTable("sp_SearchTickets", param);
            gvTickets.DataSource = dt;
            gvTickets.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindTickets();
        }

        protected void gvTickets_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
            {
                string status = DataBinder.Eval(e.Row.DataItem, "Status").ToString();

                if (status == "Open")
                    e.Row.BackColor = Color.LightGreen;
                else if (status == "Pending")
                    e.Row.BackColor = Color.LightYellow;
                else if (status == "Closed")
                    e.Row.BackColor = Color.LightGray;
            }
        }
    }
}

