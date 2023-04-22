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
    public partial class MemberManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            gvMemberList.DataBind();
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            getmemberbyid();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            updatememberstatusbyid("active");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            updatememberstatusbyid("pending");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            updatememberstatusbyid("deactive");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            deletememberbyid();
        }
        void deletememberbyid()
        {
            if (chechifmemberexist())
            {
                try
                {
                    SqlConnection objconn = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryManagementConnectionString"].ConnectionString);
                    if (objconn.State == ConnectionState.Closed)
                    {
                        objconn.Open();
                    }
                    SqlCommand cmd = new SqlCommand("Delete FROM member_master_tbl WHERE member_id='" + MemberId.Text.Trim() + "'", objconn);
                    cmd.ExecuteNonQuery();
                    objconn.Close();
                    Response.Write("<script>alert('member Deleted successful.')</script>");
                    clearform();
                    gvMemberList.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('invalid author id');</script>");
            }
        }
        void getmemberbyid()
        {
            try
            {
                SqlConnection objconn = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryManagementConnectionString"].ConnectionString);
                if (objconn.State == ConnectionState.Closed)
                {
                    objconn.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from member_master_tbl where member_id='"+MemberId.Text.Trim()+"'",objconn);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        FullName.Text = dr.GetValue(0).ToString();
                        AccountStatus.Text = dr.GetValue(10).ToString();
                        DateOfBirth.Text = dr.GetValue(1).ToString();
                        ContactNo.Text = dr.GetValue(2).ToString();
                        EmailId.Text = dr.GetValue(3).ToString();
                        State.Text = dr.GetValue(4).ToString();
                        City.Text = dr.GetValue(5).ToString();
                        Pincode.Text = dr.GetValue(6).ToString();
                        FullAddress.Text = dr.GetValue(7).ToString();
                    }
                    
                }
                
                objconn.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void updatememberstatusbyid(string status)
        {
            if (chechifmemberexist())
            {
                try
                {
                    SqlConnection objconn = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryManagementConnectionString"].ConnectionString);
                    if (objconn.State == ConnectionState.Closed)
                    {
                        objconn.Open();
                    }
                    SqlCommand cmd = new SqlCommand("UPDATE member_master_tbl SET account_status='" + status + "' WHERE member_id='" + MemberId.Text.Trim() + "'", objconn);
                    cmd.ExecuteNonQuery();
                    objconn.Close();
                    gvMemberList.DataBind();
                    Response.Write("<script>alert('member status updated');</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('invalid member id');</script>");
            }
           
        }
        void clearform()
        {
            MemberId.Text = "";
            FullName.Text = "";
            AccountStatus.Text = "";
            DateOfBirth.Text = "";
            ContactNo.Text = "";
            EmailId.Text = "";
            State.Text = "";
            City.Text = "";
            Pincode.Text ="" ;
            FullAddress.Text = "";
        }
        bool chechifmemberexist()
        {
            try
            {
                SqlConnection objconn = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryManagementConnectionString"].ConnectionString);
                if (objconn.State == ConnectionState.Closed)
                {
                    objconn.Open();

                }
                SqlCommand cmd = new SqlCommand("SELECT * from member_master_tbl where member_id='" + MemberId.Text.Trim() + "';", objconn);
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
    }
}