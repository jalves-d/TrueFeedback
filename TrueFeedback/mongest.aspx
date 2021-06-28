<%@ Page Title="" Language="C#" MasterPageFile="~/TrueFeedback.Master" AutoEventWireup="true" CodeBehind="mongest.aspx.cs" Inherits="TrueFeedback.mongest" %>
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
                                    <h4>Gestão de Monitorizações</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h2></h2>
                                    <img src="img/telefone-fixo.png" width="100px"/>
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
                            <div class="col-md-3">
                                <label>TP do Agente</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="TP do Agente"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Nome do Agente :</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Nome do Agente"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-5">
                                <label>NIF/ Ref. do Contrato/ Reclamação</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control mr-1" ID="TextBox7" runat="server" placeholder="Dados"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>TP do Avaliador</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="TP do Avaliador"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>Dia</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Dia"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>Mês</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="Mês"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>Ano</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="Ano"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <label>Observações</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" mode="multiline" ID="TextBox3" runat="server" placeholder=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <label>
                                    Comunicação
                                </label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="DropDownList3" runat="server">
                                        <asp:ListItem Text="Bom" Value="Bom" />
                                        <asp:ListItem Text="Razoável Mais" Value="Razoável Mais" />
                                        <asp:ListItem Text="Razoável Menos" Value="Razoável Menos" />
                                        <asp:ListItem Text="Mau" Value="Mau" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Procedimento</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="DropDownList4" runat="server">
                                        <asp:ListItem Text="Cumpriu" Value="Cumpriu" />
                                        <asp:ListItem Text="Não Cumpriu" Value="Não Cumpriu" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Alarme</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="DropDownList5" runat="server">
                                        <asp:ListItem Text="Sim" Value="Sim" />
                                        <asp:ListItem Text="Não" Value="Não" />
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
                                    <h4>Lista de Monitorizações</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TrueFeedbackConnectionString %>" SelectCommand="SELECT * FROM [master_monit_tbl]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" AllowPaging="true" ID="GridView1" PageSize="3" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="container-fluid">
                                                    <div class="row">
                                                        <div class="col-lg-12">
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    TP Agente :
                                                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("tp_agente") %>' Font-Bold="True"></asp:Label>
                                                                    &nbsp;| TP Avaliador :
                                                                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Eval("tp_avaliador") %>'></asp:Label>
                                                                    &nbsp;| NIF/ REF/RECL :
                                                                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("dados_contrato") %>'></asp:Label>
                                                                    &nbsp;</div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    Data da Monitorização :
                                                                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Text='<%# Eval("day") %>'></asp:Label>
                                                                    /<asp:Label ID="Label5" runat="server" Font-Bold="True" Text='<%# Eval("month") %>'></asp:Label>
                                                                    /<asp:Label ID="Label6" runat="server" Font-Bold="True" Text='<%# Eval("year") %>'></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    Observações :
                                                                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Text='<%# Eval("observ") %>'></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    Meio de Comunicação :
                                                                    <asp:Label ID="Label8" runat="server" Font-Bold="True" Text='<%# Eval("comun") %>'></asp:Label>
                                                                    &nbsp;| Procedimento :
                                                                    <asp:Label ID="Label9" runat="server" Font-Bold="True" Text='<%# Eval("procedimento") %>'></asp:Label>
                                                                    &nbsp;| Alarme :
                                                                    <asp:Label ID="Label10" runat="server" Font-Bold="True" Text='<%# Eval("alarme") %>'></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerSettings Mode="Numeric"></PagerSettings>
                                    <PagerStyle ForeColor="#0026ff" HorizontalAlign="Left" CssClass="pagination pagination-lg" />
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
