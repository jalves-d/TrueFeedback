<%@ Page Title="" Language="C#" MasterPageFile="~/TrueFeedback.Master" AutoEventWireup="true" CodeBehind="agentgest.aspx.cs" Inherits="TrueFeedback.agentgest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-4">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Gestão de Agentes</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="img/customer-service-agent.png" width="100px" />
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
                                <label>TP do Agente</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="TP do Agente"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Nome do Agente</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Nome do Agente"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Email</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" mode="multiline" ID="TextBox4" runat="server" placeholder="Email"></asp:TextBox>
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
                            <div class="col-md-6">
                                <label>Contacto</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" mode="multiline" ID="TextBox3" runat="server" placeholder="Contacto"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Classificação</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" mode="multiline" ID="DropDownList1" runat="server" placeholder="Classificação">
                                        <asp:ListItem Text="Bom" Value="Bom" />
                                        <asp:ListItem Text="Razoável Mais" Value="Razoável Mais" />
                                        <asp:ListItem Text="Razoável Menos" Value="Razoável Menos" />
                                        <asp:ListItem Text="Mau" Value="Mau" />
                                    </asp:DropDownList>
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
                                <asp:Button class="btn btn-block btn-sucess btn-primary text-white" OnClick="Button1_Click" Style="background-color: #00008B" ID="Button1" runat="server" Text="Consultar" BorderColor="White" />
                                <asp:Button class="btn btn-block btn-sucess btn-primary text-white" OnClick="Button2_Click" Style="background-color: #3CB371" ID="Button2" runat="server" Text="Adicionar" BorderColor="White" />
                                <asp:Button class="btn btn-block btn-sucess btn-primary text-white" OnClick="Button3_Click" Style="background-color: #eed202" ID="Button3" runat="server" Text="Modificar" BorderColor="White" />
                                <asp:Button class="btn nav-link btn-block btn-sucess btn-primary text-white" OnClick="Button4_Click" Style="background-color: #e62020" ID="Button4" runat="server" Text="Apagar" BorderColor="White" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-8">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Lista de Agentes</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:feedb %>" SelectCommand="SELECT * FROM [master_agent_tbl]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="tp" DataSourceID="SqlDataSource1" Font-Bold="False">
                                    <Columns>
                                        <asp:BoundField DataField="tp" HeaderText="TP do Agente :" ReadOnly="True" SortExpression="tp" >
                                        <ControlStyle Font-Bold="True" />
                                        <HeaderStyle Font-Bold="False" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="container-fluid">
                                                    <div class="row">
                                                        <div class="col-lg-12">
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    Nome :
                                                                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Eval("name") %>'></asp:Label>
                                                                    &nbsp;| Consola :
                                                                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Text='<%# Eval("consola") %>'></asp:Label>
                                                                    &nbsp;| Classificação :
                                                                    <asp:Label ID="Label11" runat="server" Font-Bold="True" Text='<%# Eval("class") %>'></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    Email :
                                                                    <asp:Label ID="Label8" runat="server" Font-Bold="True" Text='<%# Eval("email") %>'></asp:Label>
                                                                    &nbsp;| Contacto :
                                                                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("contacto") %>'></asp:Label>
                                                                    &nbsp;
                                                                </div>
                                                            </div>
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
