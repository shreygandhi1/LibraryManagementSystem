<%@ Page Title="" Language="C#" MasterPageFile="~/libraryManagement.Master" AutoEventWireup="true" CodeBehind="MemberManagement.aspx.cs" Inherits="LibraryManagement.MemberManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
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
                                <h4>Member Details</h4>
                                 </center>
                            </div>
                        </div>
                         <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100px" src="imgs/generaluser.png" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                           <div class="col-md-3">
                               <label>Member ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                    <asp:TextBox CssClass="form-control" placeholder="MemberID" ID="MemberId" runat="server"></asp:TextBox>
                                    <asp:Button ID="btnGo" runat="server" Text="Go" CssClass="btn btn-primary" OnClick="btnGo_Click" />
                                        </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                               <label>Full Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" placeholder="FullName" ID="FullName" runat="server"></asp:TextBox>
                                </div>
                            </div>
                              <div class="col-md-5">
                               <label>Account Status</label>
                                <div class="form-group">
                                    <div class="input-group">
                                    <asp:TextBox CssClass="form-control mr-1" placeholder="Account Status" ID="AccountStatus" runat="server" ReadOnly="true"></asp:TextBox>
                                        <asp:Linkbutton ID="Button1" runat="server" Text="s" CssClass="btn btn-success mr-1" OnClick="Button1_Click"><i class="fas fa-check-circle"></i></asp:Linkbutton>
                                        <asp:Linkbutton ID="Button2" runat="server" Text="p" CssClass="btn btn-warning mr-1" OnClick="Button2_Click"><i class="far fa-pause-circle"></i></asp:Linkbutton>
                                        <asp:Linkbutton ID="Button3" runat="server" Text="d" CssClass="btn btn-danger" OnClick="Button3_Click"><i class="fas fa-times-circle"></i></asp:Linkbutton>
                                        </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                           <div class="col-md-3">
                               <label>DOB</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" placeholder="DOB" ID="DateOfBirth" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                               <label>Contact No</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" placeholder="ContactNo" ID="ContactNo" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                             <div class="col-md-5">
                               <label>Email ID</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" placeholder="Email ID" ID="EmailId" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                         <div class="row">
                           <div class="col-md-4">
                               <label>State</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" placeholder="State " ID="State" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                               <label>City</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" placeholder="City" ID="City" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                             <div class="col-md-4">
                               <label>Pincode</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" placeholder="Pincode" ID="Pincode" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-12">
                                <label>Full Address</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="FullAddress" runat="server" placeholder="Full Address" ReadOnly="true" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-8 mx-auto">
                                <asp:Button ID="btnDelete" runat="server" Text="Delete User permanently" CssClass="btn btn-block btn-lg btn-danger" OnClick="btnDelete_Click" />
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
                                    <h4>Member List</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>
                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LibraryManagementConnectionString1 %>" SelectCommand="SELECT * FROM [member_master_tbl]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView CssClass="table table-striped table-bordered" ID="gvMemberList" runat="server" AutoGenerateColumns="False" DataKeyNames="member_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="member_id" HeaderText="member ID" ReadOnly="True" SortExpression="member_id" />
                                        <asp:BoundField DataField="full_name" HeaderText="Name" SortExpression="full_name" />
                                        <asp:BoundField DataField="account_status" HeaderText="account_status" SortExpression="account_status" />
                                        <asp:BoundField DataField="contact_no" HeaderText="Contact No" SortExpression="contact_no" />
                                        <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
                                        <asp:BoundField DataField="state" HeaderText="state" SortExpression="state" />
                                        <asp:BoundField DataField="city" HeaderText="city" SortExpression="city" />
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
