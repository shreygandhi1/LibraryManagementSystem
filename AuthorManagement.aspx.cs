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
    public partial class AuthorManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            gvAuthorList.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (CheckIfAuthorExists())
            {
                Response.Write("<script>alert('Author with this ID alerady exists you cannont add another author with the same ID');</script>");
            }
            else
            {
                addnewauthor();
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (CheckIfAuthorExists())
            {
                updateauthor();
            }
            else
            {
                Response.Write("<script>alert('Author does not exists');</script>");
                
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (CheckIfAuthorExists())
            {
                deleteauthor();
            }
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            getauthorbyid();
        }
        void getauthorbyid()
        {
            try
            {
                SqlConnection objconn = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryManagementConnectionString"].ConnectionString);
                if (objconn.State == ConnectionState.Closed)
                {
                    objconn.Open();

                }
                SqlCommand cmd = new SqlCommand("SELECT * from author_master_tbl where author_id='" + AuthorId.Text.Trim() + "';", objconn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    AuthorName.Text = dt.Rows[0][1].ToString();
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
        void deleteauthor()
        {
            try
            {
                SqlConnection objconn = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryManagementConnectionString"].ConnectionString);
                if (objconn.State == ConnectionState.Closed)
                {
                    objconn.Open();
                }
                SqlCommand cmd = new SqlCommand("Delete FROM author_master_tbl WHERE author_id='" + AuthorId.Text.Trim() + "'", objconn);

                

                cmd.ExecuteNonQuery();
                objconn.Close();
                Response.Write("<script>alert('author Deleted successful.')</script>");
                gvAuthorList.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void updateauthor()
        {
            try
            {
                SqlConnection objconn = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryManagementConnectionString"].ConnectionString);
                if (objconn.State == ConnectionState.Closed)
                {
                    objconn.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE author_master_tbl SET author_name=@author_name WHERE author_id='"+AuthorId.Text.Trim()+"'", objconn);
               
                cmd.Parameters.AddWithValue("@author_name", AuthorName.Text.Trim());

                cmd.ExecuteNonQuery();
                objconn.Close();
                Response.Write("<script>alert('author Updated successful.')</script>");
                gvAuthorList.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void addnewauthor()
        {
            try
            {
                SqlConnection objconn = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryManagementConnectionString"].ConnectionString);
                if (objconn.State == ConnectionState.Closed)
                {
                    objconn.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO author_master_tbl(author_id,author_name) Values(@author_id,@author_name)", objconn);
                cmd.Parameters.AddWithValue("@author_id", AuthorId.Text.Trim());
                cmd.Parameters.AddWithValue("@author_name", AuthorName.Text.Trim());
                
                cmd.ExecuteNonQuery();
                objconn.Close();
                Response.Write("<script>alert('author added successful.')</script>");
                gvAuthorList.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        bool CheckIfAuthorExists()
        {
            try
            {
                SqlConnection objconn = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryManagementConnectionString"].ConnectionString);
                if (objconn.State == ConnectionState.Closed)
                {
                    objconn.Open();

                }
                SqlCommand cmd = new SqlCommand("SELECT * from author_master_tbl where author_id='" + AuthorId.Text.Trim() + "';", objconn);
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
            AuthorId.Text = "";
            AuthorName.Text = "";
        }
    }
}