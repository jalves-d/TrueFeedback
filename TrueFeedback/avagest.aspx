<%@ Page Title="" Language="C#" MasterPageFile="~/TrueFeedback.Master" AutoEventWireup="true" CodeBehind="avagest.aspx.cs" Inherits="TrueFeedback.avagest" %>
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
                                    <h4>Gestão de Avaliadores</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="img/escolha.png" width="150px"/>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>TP do Avaliador</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="TP do Avaliador"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Nome do Avaliador :</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Nome Avaliador"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Password :</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox4" TextMode="Password" runat="server" placeholder="Password"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Consola</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control mr-1" ID="TextBox7" runat="server" placeholder="Login"></asp:TextBox>
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
                                <asp:Button class="btn nav-link btn-block btn-primary text-white" OnClick="Button1_Click" Style="background-color: #00008B" ID="Button1" runat="server" Text="Consultar" BorderColor="White" />
                                <asp:Button class="btn nav-link btn-block btn-primary text-white" OnClick="Button2_Click" Style="background-color: #3CB371" ID="Button2" runat="server" Text="Adicionar" BorderColor="White" />
                                <asp:Button class="btn nav-link btn-block btn-primary text-white" OnClick="Button3_Click" Style="background-color: #eed202" ID="Button3" runat="server" Text="Modificar" BorderColor="White" />
                                <asp:Button class="btn nav-link btn-block btn-primary text-white" OnClick="Button4_Click" Style="background-color: #e62020" ID="Button4" runat="server" Text="Apagar" BorderColor="White" />
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
                                    <h4>Lista de Avaliadores</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TrueFeedbackConnectionString %>" SelectCommand="SELECT [tp], [name], [consola] FROM [master_ava_tbl]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="tp" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="container-fluid">
                                                    <div class="row">
                                                        <div class="col-lg-12">
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    TP Avaliador :
                                                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("tp") %>' Font-Bold="True"></asp:Label>
                                                                    &nbsp;| Nome :
                                                                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Eval("name") %>'></asp:Label>
                                                                    &nbsp;| Consola :
                                                                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("consola") %>'></asp:Label>
                                                                    &nbsp;</div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <div class="row">
                                    <div class="btn-group" role="group">
                                        <asp:Button class="btn nav-link btn-block btn-primary text-white" OnClick="Download" Style="background-color: #00008B" ID="Button5" runat="server" Text="Download" BorderColor="White" />
                                    </div>
                                </div>
                                <asp:Label ID="newtest" Visible="false" runat="server"><h2></h2><h1><center>Lista de Feedbacks</center></h1><h2></h2></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
