<%@ Page Title="" Language="C#" MasterPageFile="~/TrueFeedback.Master" AutoEventWireup="true" CodeBehind="regdia.aspx.cs" Inherits="TrueFeedback.regdia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                                    <h4>Registo Diário de Agentes</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h2></h2>
                                    <img src="img/register.png" width="120px"/>
                                    <h2></h2>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <label>Carregar Registo :</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:FileUpload class="form-control" ID="FileUpload1" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <label>TP do Agente :</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="TP do Agente"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Nome do Agente :</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Nome do Agente" ReadOnly ="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-5">
                                <label>Consola :</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control mr-1" ID="TextBox7" runat="server" placeholder="Consola" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row">
                            <div class="btn-group" role="group">
                                <asp:Button class="btn nav-link btn-block btn-primary text-white" OnClick="Button1_Click" Style="background-color: #00008B" ID="Button1" runat="server" Text="Carregar Dados" BorderColor="White" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Lista de Registos</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TrueFeedbackConnectionString %>"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" AllowPaging="true" ID="GridView1" PageSize="3" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                                    <PagerStyle ForeColor="#0026ff" HorizontalAlign="Left" CssClass="pagination pagination-lg" />
                                </asp:GridView>
                                <div class="row">
                                    <div class="btn-group" role="group">
                                        <asp:Button class="btn nav-link btn-block btn-primary text-white" OnClick="Download" Style="background-color: #00008B" ID="Button5" runat="server" Text="Download" BorderColor="White" />
                                    </div>
                                </div>
                                <asp:Label ID="newtest" Visible="false" runat="server"><h2></h2><h1><center>Lista de Registos</center></h1><h2></h2></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
