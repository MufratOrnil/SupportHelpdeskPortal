using System;
using System.Data;
using SupportHelpdeskPortal;


namespace SupportHelpdeskPortal.Admin
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadStats();
        }

        private void LoadStats()
        {
            DataTable t1 = DbHelper.ExecuteSql(
                "SELECT COUNT(*) AS Total FROM Tickets");
            DataTable t2 = DbHelper.ExecuteSql(
                "SELECT COUNT(*) AS Total FROM Tickets WHERE Status='Open'");
            DataTable t3 = DbHelper.ExecuteSql(
                "SELECT COUNT(*) AS Total FROM Users");

            lblTotalTickets.Text = t1.Rows[0]["Total"].ToString();
            lblOpenTickets.Text = t2.Rows[0]["Total"].ToString();
            lblUsers.Text = t3.Rows[0]["Total"].ToString();
        }
    }
}

