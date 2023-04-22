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
    public partial class Usersignup : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUserSignup_Click(object sender, EventArgs e)
        {
            if (checkexsitingmember())
            {
                Response.Write("<script>alert('member already exist with this ID')</script>");
            }
            else
            {
                signupnewmember();
            }
           
        }

        bool checkexsitingmember()
        {

            try
            {
                SqlConnection objconn = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryManagementConnectionString"].ConnectionString);
                if (objconn.State == ConnectionState.Closed)
                {
                    objconn.Open();

                }
                SqlCommand cmd = new SqlCommand("SELECT * from member_master_tbl where member_id='" + Userid.Text.Trim() + "';", objconn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }
            
             void signupnewmember()
        {
            try
            {
                SqlConnection objconn = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryManagementConnectionString"].ConnectionString);
                if (objconn.State == ConnectionState.Closed)
                {
                    objconn.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO member_master_tbl(full_name,dob,contact_no,email,state,city,pincode,full_address,member_id,password,account_status) Values(@full_name,@dob,@contact_no,@email,@state,@city,@pincode,@full_address,@member_id,@password,@account_status)", objconn);
                cmd.Parameters.AddWithValue("@full_name", Fullname.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", Dateofbirth.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_no", Contactno.Text.Trim());
                cmd.Parameters.AddWithValue("@email", Emailid.Text.Trim());
                cmd.Parameters.AddWithValue("@state", DDLstate.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@city", City.Text.Trim());
                cmd.Parameters.AddWithValue("@pincode", Pincode.Text.Trim());
                cmd.Parameters.AddWithValue("@full_address", Fulladress.Text.Trim());
                cmd.Parameters.AddWithValue("@member_id", Userid.Text.Trim());
                cmd.Parameters.AddWithValue("@password", Password.Text.Trim());
                cmd.Parameters.AddWithValue("@account_status", "pending");
                cmd.ExecuteNonQuery();
                objconn.Close();
                Response.Write("<script>alert('sign up successful.')</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        }
       
    
}