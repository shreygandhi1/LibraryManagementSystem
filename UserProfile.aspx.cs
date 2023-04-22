using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagement
{
    public partial class UserProfle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["username"].ToString() == "" || Session["username"] == null)
                {
                    Response.Write("<script>alert('Session Expired Login Again');</script>");
                    Response.Redirect("UserLogin.aspx");
                }
                else
                {
                    filluserdata();
                    if (!Page.IsPostBack)
                    {
                        getuserdetails();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Session Expired Login Again');</script>");
                Response.Redirect("UserLogin.aspx");
            }
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["username"].ToString() == "" || Session["username"] == null)
                {
                    Response.Write("<script>alert('Session Expired Login Again');</script>");
                    Response.Redirect("UserLogin.aspx");
                }
                else
                {
                    updateuserbyid();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Session Expired Login Again');</script>");
                Response.Redirect("UserLogin.aspx");
            }
        }

        void updateuserbyid()
        {
            try{
            
                String password="";
                if (Newpassword.Text.Trim() == "")
                {
                    password = OldPassword.Text.Trim();
                }
                else
                {
                    password = Newpassword.Text.Trim();
                }
                SqlConnection objconn = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryManagementConnectionString"].ConnectionString);
                if (objconn.State == ConnectionState.Closed)
                {
                    objconn.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE member_master_tbl SET full_name=@full_name, dob=@dob,contact_no=contact_no,email=@email,state=@state,city=@city,pincode=@pincode,full_address=@full_address,password=@password,account_status=@account_status WHERE member_id='" +Session["username"].ToString().Trim()+ "';", objconn);
                cmd.Parameters.AddWithValue("@full_name", Fullname.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", Dateofbirth.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_no", Contactno.Text.Trim());
                cmd.Parameters.AddWithValue("@email", Emailid.Text.Trim());
                cmd.Parameters.AddWithValue("@state", DDLstate.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@city", City.Text.Trim());
                cmd.Parameters.AddWithValue("@pincode", Pincode.Text.Trim());
                cmd.Parameters.AddWithValue("@full_address", Fulladress.Text.Trim());
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@account_status", "pending");
                cmd.ExecuteNonQuery();
                objconn.Close();
                GVissuedbooks.DataBind();
                Response.Write("<script>alert('member details updated successfully');</script>");
                getuserdetails();
            }
            catch (Exception ex)
            {
                lblmessage.Text = ex.Message;
            }
        }
        void getuserdetails()
        {
            try
            {
                SqlConnection objconn = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryManagementConnectionString"].ConnectionString);
                if (objconn.State == ConnectionState.Closed)
                {
                    objconn.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from member_master_tbl WHERE member_id='" + Session["username"].ToString() + "';", objconn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Fullname.Text = dt.Rows[0]["full_name"].ToString();
                Dateofbirth.Text = dt.Rows[0]["dob"].ToString();
                Contactno.Text = dt.Rows[0]["contact_no"].ToString();
                Emailid.Text = dt.Rows[0]["email"].ToString();
                DDLstate.SelectedValue = dt.Rows[0]["state"].ToString().Trim();
                City.Text = dt.Rows[0]["city"].ToString();
                Pincode.Text = dt.Rows[0]["pincode"].ToString();
                Fulladress.Text = dt.Rows[0]["full_address"].ToString();
                OldPassword.Text = dt.Rows[0]["password"].ToString();
                MemberId.Text = dt.Rows[0]["member_id"].ToString();

                lblStatus.Text = dt.Rows[0]["account_status"].ToString().Trim();

                if (dt.Rows[0]["account_status"].ToString().Trim() == "active")
                {
                    lblStatus.Attributes.Add("class", "badge badge-pill badge-success");
                }
                else if (dt.Rows[0]["account_status"].ToString().Trim() == "pending")
                {
                    lblStatus.Attributes.Add("class", "badge badge-pill badge-warning");
                }
                else if (dt.Rows[0]["account_status"].ToString().Trim() == "deactive")
                {
                    lblStatus.Attributes.Add("class", "badge badge-pill badge-danger");
                }
                else
                {
                    lblStatus.Attributes.Add("class", "badge badge-pill badge-info");
                }
                
            }
            catch (Exception ex)
            {
                lblmessage.Text = ex.Message;
                //Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }
        void filluserdata()
        {
            try
            {
                SqlConnection objconn = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryManagementConnectionString"].ConnectionString);
                if (objconn.State == ConnectionState.Closed)
                {
                    objconn.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from book_issue_tbl WHERE member_id='" + Session["username"].ToString() + "';", objconn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GVissuedbooks.DataSource = dt;
                GVissuedbooks.DataBind();
                objconn.Close();
            }
            catch (Exception ex)
            {
                lblmessage.Text = ex.Message;
            }
        }

        protected void GVissuedbooks_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text);
                    DateTime today = DateTime.Today;
                    if (today > dt)
                    {
                        e.Row.BackColor = System.Drawing.Color.PaleVioletRed;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}