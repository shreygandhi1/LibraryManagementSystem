﻿<%@ Page Title="" Language="C#" MasterPageFile="~/libraryManagement.Master" AutoEventWireup="true" CodeBehind="adminlogin.aspx.cs" Inherits="LibraryManagement.adminlogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center><img width="150px" src="imgs/adminuser.png" /></center>
                            </div>
                        </div>
                         <div class="row">
                            <div class="col">
                                <center><h3>Admin Login</h3></center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" placeholder="Member ID" ID="MemberId" runat="server"></asp:TextBox>
                                </div>
                                <div class="row">
                            <div class="col">
                                
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" placeholder="Password" ID="MemberPassword" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-success btn-block btn-lg" OnClick="btnLogin_Click" />
                                </div>
                                
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

                <a href="homepage.aspx"><< back to home</a><br /><br />
        </div>
    </div>
        </div>
</asp:Content>
