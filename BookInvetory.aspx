<%@ Page Title="" Language="C#" MasterPageFile="~/libraryManagement.Master" AutoEventWireup="true" CodeBehind="BookInvetory.aspx.cs" Inherits="LibraryManagement.BookInvetory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });

        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#imgview').attr('src', e.target.result);
                };
                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                <h4>Books Details</h4>
                                 </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img id="imgview" height="150px" width="100px" src="book_inventory/books1.png" />
                                </center>
                            </div>
                        </div>
                        &nbsp;
                        <div class="row">
                            <div class="col">
                                <asp:FileUpload ID="fuBookDetails" runat="server" CssClass="form-control" onchange="readURL(this);" />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-3">
                                <label>Book ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" placeholder="BookID" ID="BookId" runat="server"></asp:TextBox>
                                        <asp:Button ID="btnGo" runat="server" Text="Go" CssClass="btn btn-primary" OnClick="btnGo_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-9">
                                <label>Book Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" placeholder="BookName" ID="BookName" runat="server"></asp:TextBox>
                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label>Language</label>
                                <div class="form-group">
                                    <asp:DropDownList ID="DDLlanguage" runat="server" CssClass="form-control">
                                        <asp:ListItem Text="English" Value="English" />
                                        <asp:ListItem Text="Hindi" Value="Hindi" />
                                        <asp:ListItem Text="Marthi" Value="Marthi" />
                                        <asp:ListItem Text="French" Value="French" />
                                        <asp:ListItem Text="German" Value="German" />
                                        <asp:ListItem Text="Urdu" Value="Urdu" />
                                    </asp:DropDownList>
                                </div>
                                <label>Publisher Name</label>
                                <div class="form-group">
                                    <asp:DropDownList ID="DDLpublisherName" runat="server" CssClass="form-control">
                                        <asp:ListItem Text="Publisher 1" Value="Publisher 1" />
                                        <asp:ListItem Text="Publisher 2" Value="Publisher 2" />

                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Author Name</label>
                                <div class="form-group">
                                    <asp:DropDownList ID="ddlAuthorName" runat="server" CssClass="form-control">
                                        <asp:listitem text="a1" value="a1" />
                                        <asp:listitem text="a2" value="a2" />
                                    </asp:DropDownList>
                                </div>
                                <label>Publisher Date</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" placeholder="Publisher Date" ID="PublisherDate" runat="server" TextMode="Date" />
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Gener</label>
                                <div class="form-group">
                                    <asp:ListBox ID="LBGener" runat="server" SelectionMode="Multiple" Rows="5" CssClass="form-control">
                                        <asp:ListItem Text="Action" Value="Action" />
                              <asp:ListItem Text="Adventure" Value="Adventure" />
                              <asp:ListItem Text="Comic Book" Value="Comic Book" />
                              <asp:ListItem Text="Self Help" Value="Self Help" />
                              <asp:ListItem Text="Motivation" Value="Motivation" />
                              <asp:ListItem Text="Healthy Living" Value="Healthy Living" />
                              <asp:ListItem Text="Wellness" Value="Wellness" />
                              <asp:ListItem Text="Crime" Value="Crime" />
                              <asp:ListItem Text="Drama" Value="Drama" />
                              <asp:ListItem Text="Fantasy" Value="Fantasy" />
                              <asp:ListItem Text="Horror" Value="Horror" />
                              <asp:ListItem Text="Poetry" Value="Poetry" />
                              <asp:ListItem Text="Personal Development" Value="Personal Development" />
                              <asp:ListItem Text="Romance" Value="Romance" />
                              <asp:ListItem Text="Science Fiction" Value="Science Fiction" />
                              <asp:ListItem Text="Suspense" Value="Suspense" />
                              <asp:ListItem Text="Thriller" Value="Thriller" />
                              <asp:ListItem Text="Art" Value="Art" />
                              <asp:ListItem Text="Autobiography" Value="Autobiography" />
                              <asp:ListItem Text="Encyclopedia" Value="Encyclopedia" />
                              <asp:ListItem Text="Health" Value="Health" />
                              <asp:ListItem Text="History" Value="History" />
                              <asp:ListItem Text="Math" Value="Math" />
                              <asp:ListItem Text="Textbook" Value="Textbook" />
                              <asp:ListItem Text="Science" Value="Science" />
                              <asp:ListItem Text="Travel" Value="Travel" />
                                    </asp:ListBox>
                                </div>
                            </div>
                        </div>

                         <div class="row">
                            <div class="col-md-4">
                                <label>Edition</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" placeholder="Edition" ID="edition" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Book Cost(per unit)</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" placeholder="Book Cost" ID="bookCost" runat="server" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Pages</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" placeholder="Pages" ID="pages" runat="server" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label>Actual Stock</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" placeholder="ActualStock" ID="ActualStock" runat="server" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Current Stock</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" placeholder="Current Stock" ID="CurrentStock" runat="server" ReadOnly="true" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Issued Book</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" placeholder="Issued Book" ID="IssuedBook" runat="server" ReadOnly="true" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-12">
                                <label>Book Description</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="BookDescription" runat="server" placeholder="Book Description" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-4">
                                <asp:Button ID="Add" runat="server" Text="Add" CssClass="btn btn-block btn-lg btn-success" OnClick="Add_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button ID="Update" runat="server" Text="Update" CssClass="btn btn-block btn-lg btn-warning" OnClick="Update_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-block btn-lg btn-danger" OnClick="btnDelete_Click" />
                            </div>
                        </div>
                    </div>
                </div>

                <a href="homepage.aspx"><< back to home</a><br />
                <br />
            </div>
           <div class="col-md-7">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Book Inventory List</h4>
                                    <asp:Label ID="lblmessage" runat="server" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>
                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LibraryManagementConnectionString1 %>" SelectCommand="SELECT * FROM [book_master_tbl]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView CssClass="table table-striped table-bordered" ID="gvBookInventoryList" runat="server" AutoGenerateColumns="False" DataKeyNames="book_id" DataSourceID="SqlDataSource1" >
                                    <Columns>
                                        <asp:BoundField DataField="book_id" HeaderText="ID" ReadOnly="True" SortExpression="book_id" >
                                        <ItemStyle Font-Bold="True" />
                                        </asp:BoundField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                               <div class="container-fluid">
                                                   <div class="row">
                                                       <div class="col-lg-10">
                                                           <div class="row">
                                                               <div class="col-12">
                                                                   <asp:Label ID="lblbooktitle" runat="server" Text='<%#Eval("book_name") %>' Font-Bold="True" Font-Size="X-Large"></asp:Label>
                                                               </div>
                                                           </div>
                                                           <div class="row">
                                                               <div class="col-12 p-2">
                                                                   Author-<asp:Label ID="lblauthor"  runat="server" Text='<%#Eval("author_name") %>' Font-Bold="True"></asp:Label> | Gener-<asp:Label ID="lblgener" runat="server" Text='<%#Eval("gener") %>' Font-Bold="true"></asp:Label> | Language-<asp:Label ID="lbllanguage" runat="server" Text='<%#Eval("language") %>' Font-Bold="true"></asp:Label>
                                                               </div>
                                                           </div>
                                                           <div class="row">
                                                               <div class="col-12 p-2">
                                                                   Publisher-<asp:Label ID="lblpublisher"  runat="server" Text='<%#Eval("publisher_name") %>' Font-Bold="true"></asp:Label> | publish Date-<asp:Label ID="lblpublishdate" runat="server" Text='<%#Eval("publish_date") %>' Font-Bold="false"></asp:Label> | Edition-<asp:Label ID="lbledition" runat="server" Text='<%#Eval("edition") %>' Font-Bold="true"></asp:Label>
                                                               </div>
                                                           </div>
                                                           <div class="row">
                                                               <div class="col-12 p-2">
                                                                   Cost-<asp:Label ID="lblcost" runat="server" Text='<%#Eval("book_cost") %>' Font-Bold="true"></asp:Label> | Actual Stock-<asp:Label ID="lblactualstock" runat="server" Text='<%#Eval("actual_stock") %>' Font-Bold="false"></asp:Label> | Available-<asp:Label ID="lblavailable" runat="server" Text='<%#Eval("current_stock") %>' Font-Bold="true"></asp:Label>
                                                               </div>
                                                           </div>
                                                           <div class="row">
                                                               <div class="col-12">
                                                                   Book description-<asp:Label ID="lblbookdescription" runat="server" Text='<%#Eval("book_description") %>' Font-Bold="true"></asp:Label>
                                                               </div>
                                                           </div>
                                                       </div>
                                                       <div class="col-lg-2">
                                                           <asp:Image ID="imggride" runat="server" CssClass="img-fluid" ImageUrl='<%#Eval("book_img_link") %>' />
                                                       </div>
                                                   </div>
                                               </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
