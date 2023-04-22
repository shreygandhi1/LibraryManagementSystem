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
    public partial class PublisherManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            gvPublisherList.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (checkifpublisherexist())
            {
                Response.Write("<script>alert('publisher with this ID already exists. you cannont add another publisher with same ID')</script>");
            }
            else
            {
                addnewpublisher();
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (checkifpublisherexist())
            {
                updatepublisher();
            }
            else
            {
                Response.Write("<script>alert('publisher does not exists');</script>");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (checkifpublisherexist())
            {
                deletepublisher();
            }
            else
            {
                Response.Write("<script>alert('publisher does not exists');</script>");
            }
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            getpublisherbyid();
        }
        void getpublisherbyid()
        {
            try
            {
                SqlConnection objconn = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryManagementConnectionString"].ConnectionString);
                if (objconn.State == ConnectionState.Closed)
                {
                    objconn.Open();

                }
                SqlCommand cmd = new SqlCommand("SELECT * from publisher_master_tbl where publisher_id='" + PublisherId.Text.Trim() + "';", objconn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                   PublisherName.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    Response.Write("<script>alert('invalid author ID')</script>");
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }
        void deletepublisher()
        {
            try
            {
                SqlConnection objconn = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryManagementConnectionString"].ConnectionString);
                if (objconn.State == ConnectionState.Closed)
                {
                    objconn.Open();
                }
                SqlCommand cmd = new SqlCommand("DELETE FROM publisher_master_tbl WHERE publisher_id='" + PublisherId.Text.Trim() + "'", objconn);
                
                cmd.ExecuteNonQuery();
                objconn.Close();
                Response.Write("<script>alert('publisher Deleted successfully')</script>");
                clearform();
                gvPublisherList.DataBind();

            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('"+ex.Message+"')</script>");
            }
            
        }
        void updatepublisher()
        {
            try
            {
                SqlConnection objconn = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryManagementConnectionString"].ConnectionString);
                if (objconn.State == ConnectionState.Closed)
                {
                    objconn.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE publisher_master_tbl SET publisher_name=@publisher_name WHERE publisher_id='" + PublisherId.Text.Trim() + "'", objconn);

                cmd.Parameters.AddWithValue("@publisher_name", PublisherName.Text.Trim());

                cmd.ExecuteNonQuery();
                objconn.Close();
                Response.Write("<script>alert('publisher Updated successful.')</script>");
                clearform();
                gvPublisherList.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

        }
        void addnewpublisher()
        {
            try
            {
                SqlConnection objconn = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryManagementConnectionString"].ConnectionString);
                if (objconn.State == ConnectionState.Closed)
                {
                    objconn.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO publisher_master_tbl(publisher_id,publisher_name) Values(@publisher_id,@publisher_name)", objconn);
                cmd.Parameters.AddWithValue("publisher_id", PublisherId.Text.Trim());
                cmd.Parameters.AddWithValue("publisher_name", PublisherName.Text.Trim());
                cmd.ExecuteNonQuery();
                objconn.Close();
                Response.Write("<script>alert('publisher added sucessfull')</script>");
                clearform();
                gvPublisherList.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }
        bool checkifpublisherexist()
        {
            try
            {
                SqlConnection objconn = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryManagementConnectionString"].ConnectionString);
                if (objconn.State == ConnectionState.Closed)
                {
                    objconn.Open();

                }
                SqlCommand cmd = new SqlCommand("SELECT * from publisher_master_tbl where publisher_id='" + PublisherId.Text.Trim()+ "';", objconn);
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
        void clearform()
        {
            PublisherId.Text = "";
            PublisherName.Text = "";
        }

    }
}