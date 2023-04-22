<%@ Page Title="" Language="C#" MasterPageFile="~/libraryManagement.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="LibraryManagement.UserProfle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        })
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fulid">
        <div class="row">
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center><img width="100px" src="imgs/generaluser.png" /></center>
                            </div>
                        </div>
                         <div class="row">
                            <div class="col">
                                <center><h4>Your Profile</h4>
                                <span>Account Status - </span>
                                <asp:Label ID="lblStatus" class="badge badge-pill badge-info" runat="server" Text="Label"></asp:Label>
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
                               <label>FullName</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" placeholder="FullName" ID="Fullname" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                               <label>Date of Birth</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" placeholder="Password" ID="Dateofbirth" runat="server" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                               <label>Contact No</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" placeholder="Contact No" ID="Contactno" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                               <label>Email ID</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" placeholder="EmailID" ID="Emailid" runat="server" TextMode="Email" ></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                               <label>State</label>
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control" ID="DDLstate" runat="server">
                                        <asp:ListItem Text="Select" Value="select" />
                                        <asp:ListItem Text="Andhra Pradesh" Value="Andhra Pradesh" />
                              <asp:ListItem Text="Arunachal Pradesh" Value="Arunachal Pradesh" />
                              <asp:ListItem Text="Assam" Value="Assam" />
                              <asp:ListItem Text="Bihar" Value="Bihar" />
                              <asp:ListItem Text="Chhattisgarh" Value="Chhattisgarh" />
                              <asp:ListItem Text="Rajasthan" Value="Rajasthan" />
                              <asp:ListItem Text="Goa" Value="Goa" />
                              <asp:ListItem Text="Gujarat" Value="Gujarat" />
                              <asp:ListItem Text="Haryana" Value="Haryana" />
                              <asp:ListItem Text="Himachal Pradesh" Value="Himachal Pradesh" />
                              <asp:ListItem Text="Jammu and Kashmir" Value="Jammu and Kashmir" />
                              <asp:ListItem Text="Jharkhand" Value="Jharkhand" />
                              <asp:ListItem Text="Karnataka" Value="Karnataka" />
                              <asp:ListItem Text="Kerala" Value="Kerala" />
                              <asp:ListItem Text="Madhya Pradesh" Value="Madhya Pradesh" />
                              <asp:ListItem Text="Maharashtra" Value="Maharashtra" />
                              <asp:ListItem Text="Manipur" Value="Manipur" />
                              <asp:ListItem Text="Meghalaya" Value="Meghalaya" />
                              <asp:ListItem Text="Mizoram" Value="Mizoram" />
                              <asp:ListItem Text="Nagaland" Value="Nagaland" />
                              <asp:ListItem Text="Odisha" Value="Odisha" />
                              <asp:ListItem Text="Punjab" Value="Punjab" />
                              <asp:ListItem Text="Rajasthan" Value="Rajasthan" />
                              <asp:ListItem Text="Sikkim" Value="Sikkim" />
                              <asp:ListItem Text="Tamil Nadu" Value="Tamil Nadu" />
                              <asp:ListItem Text="Telangana" Value="Telangana" />
                              <asp:ListItem Text="Tripura" Value="Tripura" />
                              <asp:ListItem Text="Uttar Pradesh" Value="Uttar Pradesh" />
                              <asp:ListItem Text="Uttarakhand" Value="Uttarakhand" />
                              <asp:ListItem Text="West Bengal" Value="West Bengal" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-4">
                               <label>City</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" placeholder="City" ID="City" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                               <label>PinCode</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" placeholder="PinCode" ID="Pincode" runat="server" TextMode="Number" ></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                               <label>Full Adress</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" placeholder="Full Adress" ID="Fulladress" runat="server" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                </div>
                            </div>
                            
                        </div>
                         <div class="row">
                             
                            <div class="col">
                                <center>
                                <div class="form-group">
                                   <span class="badge badge-pill badge-info">Login Credentials</span>
                                    </div>
                                    </center>
                                
                                </div>
                             </div>

                        <div class="row">
                            <div class="col-md-4">
                               <label>User ID</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" placeholder="Member ID" ID="MemberId" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                               <label> old Password</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" placeholder="OldPassword" ID="OldPassword" runat="server"  ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                               <label> New Password</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" placeholder="NewPassword" ID="Newpassword" runat="server" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                
                                <div class="row">
                            <div class="col-8 mx-auto">
                                <center>
                                <div class="form-group">
                                    <asp:Button ID="Update" runat="server" Text="Update" CssClass="btn btn-block btn-primary  btn-lg" OnClick="Update_Click" />
                                </div>
                                    </center>
                                </div>
                            </div>
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
                                <center><img width="100px" src="imgs/books1.png" /></center>
                            </div>
                        </div>
                         <div class="row">
                            <div class="col">
                                <center><h4>Your issued books</h4>
                                
                                <asp:Label ID="Label1" CssClass="badge badge-pill badge-info" runat="server" Text="Your books info"></asp:Label>
                                    </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblmessage" runat="server" />
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <asp:GridView ID="GVissuedbooks" CssClass="table table-striped table-bordered" runat="server" OnRowDataBound="GVissuedbooks_RowDataBound"></asp:GridView>
                            </div>
                        </div>

                        
                </div>
            </div>

                <a href="homepage.aspx"><< back to home</a><br /><br />
        
            </div>
 </div> 
        </div>
</asp:Content>
