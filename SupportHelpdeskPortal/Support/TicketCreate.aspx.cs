using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using SupportHelpdeskPortal;

namespace SupportHelpdeskPortal.Support
{
    public partial class TicketCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindAssignTo();
        }

        private void BindAssignTo()
        {
            DataTable dt = DbHelper.ExecuteDataTable("sp_GetUsersForAssign");

            ddlAssignTo.DataSource = dt;
            ddlAssignTo.DataTextField = "Username";
            ddlAssignTo.DataValueField = "UserId";
            ddlAssignTo.DataBind();
            ddlAssignTo.Items.Insert(0,
                new System.Web.UI.WebControls.ListItem("-- Not Assigned --", ""));
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                lblMessage.Text = "Session expired. Please login again.";
                return;
            }

            int createdBy = Convert.ToInt32(Session["UserId"]);
            int? assignedTo = null;

            if (!string.IsNullOrEmpty(ddlAssignTo.SelectedValue))
                assignedTo = Convert.ToInt32(ddlAssignTo.SelectedValue);

            string attachmentPath = null;

            if (fuAttachment.HasFile)
            {
                string uploads = Server.MapPath("~/Uploads");
                if (!Directory.Exists(uploads))
                    Directory.CreateDirectory(uploads);

                string fileName = DateTime.Now.ToString("yyyyMMddHHmmss_") +
                                  Path.GetFileName(fuAttachment.FileName);
                string fullPath = Path.Combine(uploads, fileName);
                fuAttachment.SaveAs(fullPath);

                attachmentPath = "~/Uploads/" + fileName;
            }

            SqlParameter[] param =
            {
                new SqlParameter("@Title", txtTitle.Text.Trim()),
                new SqlParameter("@Description", txtDescription.Text.Trim()),
                new SqlParameter("@Status", ddlStatus.SelectedValue),
                new SqlParameter("@CreatedBy", createdBy),
                new SqlParameter("@AssignedTo", (object)assignedTo ?? DBNull.Value),
                new SqlParameter("@Attachment", (object)attachmentPath ?? DBNull.Value)
            };

            DbHelper.ExecuteDataTable("sp_InsertTicket", param);

            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = "Ticket created successfully.";

            txtTitle.Text = "";
            txtDescription.Text = "";
            ddlStatus.SelectedValue = "Open";
            ddlAssignTo.SelectedIndex = 0;
        }
    }
}
