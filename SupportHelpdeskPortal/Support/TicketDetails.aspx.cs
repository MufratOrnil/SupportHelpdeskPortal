using System;
using System.Data;
using System.Data.SqlClient;


namespace SupportHelpdeskPortal.Support
{
    public partial class TicketDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadTicket();
        }

        private void LoadTicket()
        {
            int ticketId;
            if (!int.TryParse(Request.QueryString["id"], out ticketId))
                return;

            SqlParameter p = new SqlParameter("@TicketId", ticketId);

            DataTable dt = DbHelper.ExecuteDataTable("sp_GetTicketById", p);

            dvTicket.DataSource = dt;
            dvTicket.DataBind();
        }
    }
}

