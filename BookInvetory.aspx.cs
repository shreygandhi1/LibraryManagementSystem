using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace LibraryManagement
{
    public partial class BookInvetory : System.Web.UI.Page
    {
        static String global_filepath;
        static int global_actual_stock, global_current_stock, global_issued_book;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillauthorpublishervalue();
            }
            gvBookInventoryList.DataBind();
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            getbookbyid();
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            if (CheckIfBookExists())
            {
                Response.Write("<script>alert('Book already present in book list')</script>");
            }
            else
            {
                addnewbook();
            }
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            if (CheckIfBookExists())
            {
                updatebookbyid();
            }
            else
            {
                Response.Write("<script>alert('book with this id do not exist')</script>");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (CheckIfBookExists())
            {
                deletebookbyid();
            }
            else
            {
                Response.Write("<script>alert('book with this id do not exists');</script>");
            }
        }

        void deletebookbyid()
        {
            try
            {
                SqlConnection objconn = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryManagementConnectionString"].ConnectionString);
                if (objconn.State == ConnectionState.Closed)
                {
                    objconn.Open();
                }
                SqlCommand cmd = new SqlCommand("DELETE FROM book_master_tbl WHERE book_id='"+BookId.Text.Trim()+"'",objconn);
                cmd.ExecuteNonQuery();
                objconn.Close();
                gvBookInventoryList.DataBind();
                Response.Write("<script>alert('book deleted successfully');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void updatebookbyid()
        {
            try
            {
                if (CheckIfBookExists())
                {
                    int actual_stock = Convert.ToInt32(ActualStock.Text.Trim());
                    int current_stock = Convert.ToInt32(CurrentStock.Text.Trim());
                    if(global_actual_stock == actual_stock)
                    {
                        
                    }
                    else
                    {
                        if(actual_stock<global_issued_book)
                        {
                            Response.Write("<script>alert('actual stock cannot be lees than issued books');</script>");
                            return;
                        }
                        else
                        {
                            current_stock = actual_stock - global_issued_book;
                            CurrentStock.Text= ""+ current_stock;
                        }
                    }
                    String gener = "";
                    foreach(int i in LBGener.GetSelectedIndices())
                    {
                        gener = gener + LBGener.Items[i] + ",";
                    }
                    gener = gener.Remove(gener.Length-1);

                    String filepath = "~/book_inventory/books1";
                    String filename = Path.GetFileName(fuBookDetails.PostedFile.FileName);
                    if(filename == "" || filename == null)
                    {
                        filepath = global_filepath;
                    }
                    else
                    {
                        fuBookDetails.SaveAs(Server.MapPath("~/book_inventory/"+ filename));
                        filepath = "~/book_inventory/" + filename;
                    }
                    SqlConnection objconn = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryManagementConnectionString"].ConnectionString);
                    if (objconn.State == ConnectionState.Closed)
                    {
                        objconn.Open();
                    }
                    SqlCommand cmd = new SqlCommand("UPDATE book_master_tbl SET book_name=@book_name, gener=@gener, author_name=@author_name, publisher_name=@publisher_name, publish_date=@publish_date, language=@language, edition=@edition, book_cost=@book_cost, no_of_pages=@no_of_pages, book_description=@book_description, actual_stock=@actual_stock, current_stock=@current_stock, book_img_link=@book_img_link WHERE book_id='"+BookId.Text.Trim()+"';", objconn);
                    cmd.Parameters.AddWithValue("@book_name", BookName.Text.Trim());
                    cmd.Parameters.AddWithValue("@gener", gener);
                    cmd.Parameters.AddWithValue("@author_name", ddlAuthorName.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@publisher_name",DDLpublisherName.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@publish_date", PublisherDate.Text.Trim());
                    cmd.Parameters.AddWithValue("@language",DDLlanguage.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@edition", edition.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_cost", bookCost.Text.Trim());
                    cmd.Parameters.AddWithValue("@no_of_pages", pages.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_description", BookDescription.Text.Trim());
                    cmd.Parameters.AddWithValue("@actual_stock", actual_stock.ToString());
                    cmd.Parameters.AddWithValue("@current_stock", current_stock.ToString());
                    cmd.Parameters.AddWithValue("@book_img_link", filepath);
                    cmd.ExecuteNonQuery();
                    objconn.Close();
                    gvBookInventoryList.DataBind();
                    Response.Write("<script>alert('book information updated successfully');</script>");
                }
                else 
                {
                    Response.Write("<script>alert('invalid book ID');</script>");
                }

            }
            catch (Exception ex)
            {
                lblmessage.Text = ex.Message;
            }
        }
        void getbookbyid()
        {
            try
            {
                SqlConnection objconn = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryManagementConnectionString"].ConnectionString);
                if (objconn.State == ConnectionState.Closed)
                {
                    objconn.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from book_master_tbl where book_id = '"+BookId.Text.Trim()+"';", objconn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    BookName.Text = dt.Rows[0]["book_name"].ToString();
                    DDLlanguage.SelectedValue = dt.Rows[0]["language"].ToString();
                    ddlAuthorName.SelectedValue = dt.Rows[0]["author_name"].ToString();
                    DDLpublisherName.SelectedValue = dt.Rows[0]["publisher_name"].ToString();
                    PublisherDate.Text = dt.Rows[0]["publish_date"].ToString();
                    edition.Text = dt.Rows[0]["edition"].ToString();
                    bookCost.Text = dt.Rows[0]["book_cost"].ToString().Trim();
                    pages.Text = dt.Rows[0]["no_of_pages"].ToString().Trim();
                    ActualStock.Text = dt.Rows[0]["actual_stock"].ToString().Trim();
                    CurrentStock.Text = dt.Rows[0]["current_stock"].ToString().Trim();
                    IssuedBook.Text = "" + (Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString()) - Convert.ToInt32(dt.Rows[0]["current_stock"].ToString()));
                    BookDescription.Text = dt.Rows[0]["book_description"].ToString();
                    LBGener.ClearSelection();
                    String[] gener = dt.Rows[0]["gener"].ToString().Trim().Split(',');
                    for (int i = 0; i < gener.Length; i++)
                    {
                        for (int j = 0; j < LBGener.Items.Count; j++)
                        {
                            if (LBGener.Items[j].ToString() == gener[i])
                            {
                                LBGener.Items[j].Selected = true;
                            }

                        }
                    }
                    global_actual_stock = Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString());
                    global_current_stock = Convert.ToInt32(dt.Rows[0]["current_stock"].ToString());
                    global_issued_book = global_actual_stock - global_current_stock;
                    global_filepath = dt.Rows[0]["book_img_link"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('invalid book id')</script>");
                }
                objconn.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        void fillauthorpublishervalue()
        {
            try
            {
                SqlConnection objconn = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryManagementConnectionString"].ConnectionString);
                if (objconn.State == ConnectionState.Closed)
                {
                    objconn.Open();

                }
                SqlCommand cmd = new SqlCommand("SELECT author_name from author_master_tbl;", objconn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                ddlAuthorName.DataSource = dt;
                ddlAuthorName.DataValueField = "author_name";
                ddlAuthorName.DataBind();

                cmd = new SqlCommand("SELECT publisher_name from publisher_master_tbl;", objconn);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                DDLpublisherName.DataSource = dt;
                DDLpublisherName.DataValueField = "publisher_name";
                DDLpublisherName.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        bool CheckIfBookExists()
        {
            try
            {
                SqlConnection objconn = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryManagementConnectionString"].ConnectionString);
                if (objconn.State == ConnectionState.Closed)
                {
                    objconn.Open();

                }
                SqlCommand cmd = new SqlCommand("SELECT * from book_master_tbl where book_id='" + BookId.Text.Trim() + "'OR book_name='"+BookName.Text.Trim()+"';", objconn);
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
        void addnewbook()
        {
            try
            {
                String gener = "";
                foreach (int i in LBGener.GetSelectedIndices())
                {
                    gener = gener + LBGener.Items[i] + ",";
                }
                gener = gener.Remove(gener.Length - 1);

                String filepath = "~/book_inventory/books1.jpg";
                String filename = Path.GetFileName(fuBookDetails.PostedFile.FileName);
                fuBookDetails.SaveAs(Server.MapPath("~/book_inventory/" + filename));
                filepath = "~/book_inventory/" + filename;
                SqlConnection objconn = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryManagementConnectionString"].ConnectionString);
                if (objconn.State == ConnectionState.Closed)
                {
                    objconn.Open();

                }
                SqlCommand cmd = new SqlCommand("INSERT INTO book_master_tbl(book_id,book_name,gener,author_name,publisher_name,publish_date,language,edition,book_cost,no_of_pages,book_description,actual_stock,current_stock,book_img_link) Values(@book_id,@book_name,@gener,@author_name,@publisher_name,@publish_date,@language,@edition,@book_cost,@no_of_pages,@book_description,@actual_stock,@current_stock,@book_img_link)", objconn);
                cmd.Parameters.AddWithValue("@book_id", BookId.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", BookName.Text.Trim());
                cmd.Parameters.AddWithValue("@gener", gener);
                cmd.Parameters.AddWithValue("@author_name", ddlAuthorName.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publisher_name", DDLpublisherName.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publish_date", PublisherDate.Text.Trim());
                cmd.Parameters.AddWithValue("@language", DDLlanguage.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@edition", edition.Text.Trim());
                cmd.Parameters.AddWithValue("@book_cost", bookCost.Text.Trim());
                cmd.Parameters.AddWithValue("@no_of_pages", pages.Text.Trim());
                cmd.Parameters.AddWithValue("@book_description", BookDescription.Text.Trim());
                cmd.Parameters.AddWithValue("@actual_stock", ActualStock.Text.Trim());
                cmd.Parameters.AddWithValue("@current_stock", ActualStock.Text.Trim());
                cmd.Parameters.AddWithValue("@book_img_link", filepath);
                cmd.ExecuteNonQuery();
                objconn.Close();
                Response.Write("<script>alert('book added successfully');</script>");
                gvBookInventoryList.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

    }
}