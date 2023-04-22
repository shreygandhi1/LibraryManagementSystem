<%@ Page Title="" Language="C#" MasterPageFile="~/libraryManagement.Master" AutoEventWireup="true" CodeBehind="BookIssue.aspx.cs" Inherits="LibraryManagement.BookIssue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        })
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
                                <h4>Book Issuing</h4>
                                 </center>
                            </div>
                        </div>
                         <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100px" src="imgs/books.png" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                           
                            <div class="col-md-6">
                               <label>Member ID</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" placeholder="Member ID" ID="MemberId" runat="server"></asp:TextBox>
                                </div>
                            </div>
                             <div class="col-md-6">
                               <label>Book ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                    <asp:TextBox CssClass="form-control" placeholder="BookID" ID="BookId" runat="server"></asp:TextBox>
                                    <asp:Button ID="btnGo" runat="server" Text="Go" CssClass="btn btn-primary" OnClick="btnGo_Click" />
                                        </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                           
                            <div class="col-md-6">
                               <label>Member Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" placeholder="Member Name" ID="MemberName" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                             <div class="col-md-6">
                               <label>Book Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" placeholder="Book Name" ID="BookName" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                         <div class="row">
                           
                            <div class="col-md-6">
                               <label>Issue Date</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" placeholder="Start Date" ID="IssueDate" runat="server" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                             <div class="col-md-6">
                               <label>Due Date</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" placeholder="End Date" ID="DueDate" runat="server" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-6">
                                <asp:Button ID="btnIssue" runat="server" Text="Issue" CssClass="btn btn-block btn-lg btn-primary" OnClick="btnIssue_Click" />
                            </div>
                            <div class="col-6">
                                <asp:Button ID="btnReturn" runat="server" Text="Return" CssClass="btn btn-block btn-lg btn-success" OnClick="btnReturn_Click" />
                            </div>
                            
                        </div>   
                </div>
            </div>

                <a href="homepage.aspx"><< back to home</a><br /><br />
        </div>
            
            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Issued Book List</h4>
                                    <asp:Label ID="lblmessage" runat="server"></asp:Label>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>
                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LibraryManagementConnectionString1 %>" SelectCommand="SELECT * FROM [book_issue_tbl]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView CssClass="table table-striped table-bordered" ID="gvIssuedBookList" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnRowDataBound="gvIssuedBookList_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="member_id" HeaderText="member ID" SortExpression="member_id" />
                                        <asp:BoundField DataField="member_name" HeaderText="member Name" SortExpression="member_name" />
                                        <asp:BoundField DataField="book_id" HeaderText="Book ID" SortExpression="book_id" />
                                        <asp:BoundField DataField="book_name" HeaderText="Book Name" SortExpression="book_name" />
                                        <asp:BoundField DataField="issue_date" HeaderText="Issue Date" SortExpression="issue_date" />
                                        <asp:BoundField DataField="due_date" HeaderText="Due Date" SortExpression="due_date" />
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
