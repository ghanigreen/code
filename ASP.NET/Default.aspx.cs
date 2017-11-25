using Services;
using System;
using System.Web.UI.WebControls;

namespace ASP.NET
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindUserDropDownList();
                BindGrid();
            }
        }

        protected void BindGrid()
        {
            SecurityService serviceObj = new SecurityService();
            var userData = serviceObj.GetAllUsers();
            if (userData.Count > 0)
            {
                grdUser.DataSource = userData;
                grdUser.DataBind();
            }

        }

        protected void BindGrid(Int32 userId)
        {
            SecurityService serviceObj = new SecurityService();
            var userData = serviceObj.GetUserByID(userId);
            if (userData.Count > 0)
            {
                grdUser.DataSource = userData;
                grdUser.DataBind();
            }

        }
        protected void BindUserDropDownList()
        {
            SecurityService serviceObj = new SecurityService();
               var userData = serviceObj.GetAllUsers();
               if (userData.Count > 0)
               {
                   ddlUser.DataSource = userData;
                   ddlUser.DataTextField = "UserName";
                   ddlUser.DataValueField = "UserID";
                   ddlUser.DataBind();
               }

               ListItem li = new ListItem("All", "0");
               ddlUser.Items.Insert(0, li);
        }

        protected void ddlUser_SelectedIndexChanged(object sender, EventArgs e)
        {            
            if (ddlUser.SelectedValue == "0")
            {
                BindGrid();
            }
            else
            {
                BindGrid(Convert.ToInt32(ddlUser.SelectedValue));
            }
        }
    }
}