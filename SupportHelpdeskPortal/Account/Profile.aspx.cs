using System;
using System.Data;
using System.Data.SqlClient;
using SupportHelpdeskPortal;

namespace SupportHelpdeskPortal.Account
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadProfile();
        }

        private void LoadProfile()
        {
            if (Session["UserId"] == null)
                return;

            int userId = Convert.ToInt32(Session["UserId"]);

            SqlParameter p = new SqlParameter("@UserId", userId);

            DataTable dt = DbHelper.ExecuteSql(@"
                SELECT U.Username, U.FullName, U.CreatedDate, R.RoleName
                FROM Users U
                JOIN UserRoles UR ON U.UserId = UR.UserId
                JOIN Roles R ON UR.RoleId = R.RoleId
                WHERE U.UserId = @UserId", p);

            dvProfile.DataSource = dt;
            dvProfile.DataBind();
        }
    }
}

