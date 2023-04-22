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
    public partial class BookIssue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            gvIssuedBookList.DataBind();
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            getmemberandbookbyid();
        }

        protected void btnIssue_Click(object sender, EventArgs e)
        {
            if (checkifbookexists() && checkifmemberexists())
            {
                if (checkifissueentryexist())
                {
                    Response.Write("<script>alert('this member alerady has this book');</script>");
                }
                else
                {
                    issuebook();
                }
                
            }
            else
            {
                Response.Write("<script>alert('invalid book or member');</script>");
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            if (checkifbookexists() && checkifmemberexists())
            {
                if (checkifissueentryexist())
                {
                    returnbook();
                }
                else
                {
                    Response.Write("<script>alert('this entry does not exists');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('invalid book or member');</script>");
            }
        }

        void returnbook()
        {
            try
            {
                SqlConnection objconn = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryManagementConnectionString"].ConnectionString);
                if (objconn.State == ConnectionState.Closed)
                {
                    objconn.Open();
                }
                SqlCommand cmd = new SqlCommand("DELETE from book_issue_tbl WHERE book_id='"+BookId.Text.Trim()+"' AND member_id='"+MemberId.Text.Trim()+"'", objconn);
                int result = cmd.ExecuteNonQuery();
                if (result > 0) { 
                cmd = new SqlCommand("UPDATE book_master_tbl SET current_stock=current_stock+1 WHERE book_id='" + BookId.Text.Trim() + "';", objconn);
                cmd.ExecuteNonQuery();
                objconn.Close();
                Response.Write("<script>alert('book returned successfully');</script>");
                gvIssuedBookList.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('Erro- invalid entry');</script>");   
                }
            }
            catch (Exception ex)
            {
                lblmessage.Text = ex.Message;
            }
        }
        void issuebook()
        {
            try
            {
                SqlConnection objconn = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryManagementConnectionString"].ConnectionString);
                if (objconn.State == ConnectionState.Closed)
                {
                    objconn.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO book_issue_tbl (member_id,member_name,book_id,book_name,issue_date,due_date) VALUES(@member_id,@member_name,@book_id,@book_name,@issue_date,@due_date)", objconn);
                cmd.Parameters.AddWithValue("@member_id", MemberId.Text.Trim());
                cmd.Parameters.AddWithValue("@member_name", MemberName.Text.Trim());
                cmd.Parameters.AddWithValue("@book_id", BookId.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", BookName.Text.Trim());
                cmd.Parameters.AddWithValue("@issue_date", IssueDate.Text.Trim());
                cmd.Parameters.AddWithValue("@due_date", DueDate.Text.Trim());
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("UPDATE book_master_tbl SET current_stock=current_stock-1 WHERE book_id='" + BookId.Text.Trim() + "';", objconn);
                cmd.ExecuteNonQuery();
                objconn.Close();
                Response.Write("<script>alert('book issued successfully');</script>");
                gvIssuedBookList.DataBind();
            }
            catch (Exception ex)
            {
                lblmessage.Text = ex.Message;
            }
        }
        bool checkifbookexists()
        {
            try
            {
                SqlConnection objconn = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryManagementConnectionString"].ConnectionString);
                if (objconn.State == ConnectionState.Closed)
                {
                    objconn.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from book_master_tbl WHERE book_id='" + BookId.Text.Trim() + "'AND current_stock >0", objconn);
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
                objconn.Close();
            }
            catch (Exception ex)
            {
                
                return false;
            }
        }
        bool checkifmemberexists()
        {
            try
            {
                SqlConnection objconn = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryManagementConnectionString"].ConnectionString);
                if (objconn.State == ConnectionState.Closed)
                {
                    objconn.Open();
                }
                SqlCommand cmd = new SqlCommand("select full_name from member_master_tbl WHERE member_id='" + MemberId.Text.Trim() + "'", objconn);
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
                objconn.Close();
            }
            catch (Exception ex)
            {
                
                return false;
            }
            
        }
        void getmemberandbookbyid()
        {
            try
            {
                SqlConnection objconn = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryManagementConnectionString"].ConnectionString);
                if (objconn.State == ConnectionState.Closed)
                {
                    objconn.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT book_name FROM book_master_tbl WHERE book_id='"+BookId.Text.Trim()+"';", objconn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                objconn.Close();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    BookName.Text = dt.Rows[0]["book_name"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Wrong Book ID');</script>");
                }
                cmd = new SqlCommand("SELECT full_name FROM member_master_tbl WHERE member_id='" + MemberId.Text.Trim() + "';", objconn);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    MemberName.Text = dt.Rows[0]["full_name"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Wrong Member ID');</script>");
                }
            }
            catch (Exception ex)
            {
                lblmessage.Text = ex.Message;
            }
        }
        bool checkifissueentryexist()
        {
            try
            {
                SqlConnection objconn = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryManagementConnectionString"].ConnectionString);
                if (objconn.State == ConnectionState.Closed)
                {
                    objconn.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from book_issue_tbl WHERE member_id='" + MemberId.Text.Trim() + "' AND book_id='"+BookId.Text.Trim()+"'", objconn);
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
                objconn.Close();
            }
            catch (Exception ex)
            {
                lblmessage.Text = ex.Message;
                return false;
            }
        }

        protected void gvIssuedBookList_RowDataBound(object sender, GridViewRowEventArgs e)
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