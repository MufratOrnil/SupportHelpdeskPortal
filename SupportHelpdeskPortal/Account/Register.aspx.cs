using System;
using System.Data;
using System.Data.SqlClient;
using SupportHelpdeskPortal;

namespace SupportHelpdeskPortal.Account
{
    public partial class Register : System.Web.UI.Page
    {
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string fullName = txtFullName.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblMsg.Text = "Username and password are required.";
                return;
            }

            // check if username exists
            DataTable existing = DbHelper.ExecuteSql(
                "SELECT 1 FROM Users WHERE Username = @Username",
                new SqlParameter("@Username", username));

            if (existing.Rows.Count > 0)
            {
                lblMsg.Text = "Username already exists.";
                return;
            }

            SqlParameter[] pUser =
            {
                new SqlParameter("@Username", username),
                new SqlParameter("@PasswordHash", password),
                new SqlParameter("@FullName", fullName)
            };

            DbHelper.ExecuteSql(
                "INSERT INTO Users (Username, PasswordHash, FullName) " +
                "VALUES (@Username, @PasswordHash, @FullName)", pUser);

            // optionally assign default role User (RoleId = 2)
            DbHelper.ExecuteSql(
                "INSERT INTO UserRoles (UserId, RoleId) " +
                "VALUES ((SELECT UserId FROM Users WHERE Username=@Username), 2)",
                new SqlParameter("@Username", username));

            lblMsg.ForeColor = System.Drawing.Color.Green;
            lblMsg.Text = "Registration successful. Please login.";
        }
    }
}
