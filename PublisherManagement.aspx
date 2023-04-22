<%@ Page Title="" Language="C#" MasterPageFile="~/libraryManagement.Master" AutoEventWireup="true" CodeBehind="PublisherManagement.aspx.cs" Inherits="LibraryManagement.PublisherManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
   </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                <h4>Publisher Details</h4>
                                 </center>
                            </div>
                        </div>
                         <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100px" src="imgs/publisher.png" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                               <label>Publisher ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                    <asp:TextBox CssClass="form-control" placeholder="PublisherID" ID="PublisherId" runat="server"></asp:TextBox>
                                    <asp:Button ID="btnGo" runat="server" Text="Go" CssClass="btn btn-primary" OnClick="btnGo_Click" />
                                        </div>
                                </div>
                            </div>
                            <div class="col-md-8">
                               <label>Publisher Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" placeholder="Publisher Name" ID="PublisherName" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-4">
                                <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-block btn-lg btn-success" OnClick="btnAdd_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button ID="btnEdit" runat="server" Text="Update" CssClass="btn btn-block btn-lg btn-warning" OnClick="btnEdit_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-block btn-lg btn-danger" OnClick="btnDelete_Click" />
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
                                    <h4>Publisher List</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>
                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LibraryManagementConnectionString1 %>" SelectCommand="SELECT * FROM [publisher_master_tbl]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView CssClass="table table-striped table-bordered" ID="gvPublisherList" runat="server" AutoGenerateColumns="False" DataKeyNames="publisher_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="publisher_id" HeaderText="publisher_id" ReadOnly="True" SortExpression="publisher_id" />
                                        <asp:BoundField DataField="publisher_name" HeaderText="publisher_name" SortExpression="publisher_name" />
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
