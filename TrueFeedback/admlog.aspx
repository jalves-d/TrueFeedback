<%@ Page Title="" Language="C#" MasterPageFile="~/TrueFeedback.Master" AutoEventWireup="true" CodeBehind="admlog.aspx.cs" Inherits="TrueFeedback.admlog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto">
                <div class="card bg-transparent">
                    <div class="card-body">
                        <div class="row">
                            <div class="col m-2">
                                <center>
                                    <img src="img/supervisor.png" widht="250" height="125"/>
                                </center>
                            </div>
                        </div>
                        <h2></h2>
                        <div class="row">
                            <div class="col text-white">
                                <center>
                                    <h3>Admin Login</h3>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" placeholder="TP"></asp:TextBox>
                                    <h2></h2>
                                    <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                    <h2></h2>
                                    <asp:HyperLink class="btn-sm" ID="HyperLink1" href="#" runat="server">Change Password</asp:HyperLink>
                                    <h2></h2>
                                    <div class="btn-group" role="group">
                                        <asp:Button class="btn nav-link btn-block btn-primary text-white" OnClick="Button1_Click" style="background-color: #00008B" ID="Button1" runat="server" Text="Login" />
                                    </div>
                               </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
