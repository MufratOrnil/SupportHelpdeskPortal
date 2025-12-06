using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;
using SupportHelpdeskPortal;

namespace SupportHelpdeskPortal.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblMsg.Text = "Username and password are required.";
                return;
            }

            SqlParameter[] p =
            {
                new SqlParameter("@Username", username),
                new SqlParameter("@Password", password)
            };

            // stored procedure spAuthenticateUser must exist in HelpdeskDB
            DataTable dt = DbHelper.ExecuteDataTable("spAuthenticateUser", p);

            if (dt.Rows.Count == 1)
            {
                int userId = Convert.ToInt32(dt.Rows[0]["UserId"]);
                string role = dt.Rows[0]["RoleName"].ToString();

                // store in session
                Session["UserId"] = userId;
                Session["Role"] = role;

                // issue auth cookie so LoginView shows Profile/Logout
                FormsAuthentication.SetAuthCookie(username, false);

                // respect ReturnUrl if present
                string returnUrl = Request.QueryString["ReturnUrl"];
                if (!string.IsNullOrEmpty(returnUrl))
                {
                    Response.Redirect(returnUrl);
                    return;
                }

                // role-based landing page
                if (role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                    Response.Redirect("~/Admin/Dashboard.aspx");
                else
                    Response.Redirect("~/Support/TicketList.aspx");
            }
            else
            {
                lblMsg.Text = "Invalid username or password.";
            }
        }
    }
}

