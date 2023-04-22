using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagement
{
    public partial class libraryManagement : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"]== null)
                {
                    UserLogin.Visible = true;
                    SignUp.Visible = true;
                    LogOut.Visible = false;
                    LinkButton1.Visible = false;
                    AdminLogin.Visible = true;
                    AuthorManagement.Visible = false;
                    PublisherManagement.Visible = false;
                    BookInvetory.Visible = false;
                    BookIssuing.Visible = false;
                    MemberManagement.Visible = false;
                }
                else if (Session["role"] == "user")
                {
                    UserLogin.Visible = false;
                    SignUp.Visible = false;
                    LogOut.Visible = true;
                    LinkButton1.Visible = true;
                    LinkButton1.Text = "hello "+Session["username"].ToString();
                    AdminLogin.Visible = true;
                    AuthorManagement.Visible = false;
                    PublisherManagement.Visible = false;
                    BookInvetory.Visible = false;
                    BookIssuing.Visible = false;
                    MemberManagement.Visible = false;
                }
                else if (Session["role"] == "admin")
                {
                    UserLogin.Visible = false;
                    SignUp.Visible = false;
                    LogOut.Visible = true;
                    LinkButton1.Visible = true;
                    LinkButton1.Text = "hello Admin";
                    AdminLogin.Visible = false;
                    AuthorManagement.Visible = true;
                    PublisherManagement.Visible = true;
                    BookInvetory.Visible = true;
                    BookIssuing.Visible = true;
                    MemberManagement.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void AdminLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminlogin.aspx");
        }

        protected void AuthorManagement_Click(object sender, EventArgs e)
        {
            Response.Redirect("AuthorManagement.aspx");
        }

        protected void PublisherManagement_Click(object sender, EventArgs e)
        {
            Response.Redirect("PublisherManagement.aspx");
        }

        protected void BookInvetory_Click(object sender, EventArgs e)
        {
            Response.Redirect("BookInvetory.aspx");
        }

        protected void BookIssuing_Click(object sender, EventArgs e)
        {
            Response.Redirect("BookIssue.aspx");
        }

        protected void MemberManagement_Click(object sender, EventArgs e)
        {
            Response.Redirect("MemberManagement.aspx");
        }

        protected void ViewBooks_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewBook.aspx");
        }

        protected void UserLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserLogin.aspx");
        }

        protected void SignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("Usersignup.aspx");
        }

        protected void LogOut_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["fullname"] = "";
            Session["role"] = "";
            Session["status"] = "";
            UserLogin.Visible=true;
            SignUp.Visible = true;
            LogOut.Visible = false;
            LinkButton1.Visible = false;
            AdminLogin.Visible = true;
            AuthorManagement.Visible = false;
            PublisherManagement.Visible = false;
            BookInvetory.Visible = false;
            BookIssuing.Visible = false;
            MemberManagement.Visible = false;
            Response.Redirect("Homepage.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserProfile.aspx");
        }

        
    }
}