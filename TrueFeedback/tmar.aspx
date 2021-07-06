<%@ Page Title="" Language="C#" MasterPageFile="~/TrueFeedback.Master" AutoEventWireup="true" CodeBehind="tmar.aspx.cs" Inherits="TrueFeedback.tmar" %>
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
                                    <h4>Avaliações 2Mares</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h2></h2>
                                    <img src="img/telefone-fixo.png" width="100px" />
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
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Nome do Agente" ReadOnly="true"></asp:TextBox>
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
                            <div class="col-md-3">
                                <label>TP do Avaliador : </label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="TP do Avaliador"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>Dia :</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Dia"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>Mês :</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="Mês"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>Ano :</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="Ano"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <label>
                                    NIF/REF/REC :
                                </label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" mode="multiline" ID="TextBox9" runat="server" placeholder=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <label>Duração da Chamada :</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" mode="multiline" ID="TextBox11" runat="server" placeholder=""></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Nota :</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" mode="multiline" ID="TextBox12" runat="server" placeholder=""></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>CEX :</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" mode="multiline" ID="TextBox13" runat="server" placeholder=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <label>Tipologia :</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" mode="multiline" ID="DropDownList1" runat="server" placeholder="Tipologia">
                                        <asp:ListItem Text="Bom" Value="Bom" />
                                        <asp:ListItem Text="Razoável Mais" Value="Razoável Mais" />
                                        <asp:ListItem Text="Razoável Menos" Value="Razoável Menos" />
                                        <asp:ListItem Text="Mau" Value="Mau" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <label>Pontos Fortes :</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" mode="multiline" ID="TextBox10" runat="server" placeholder=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <label>Pontos Fracos :</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" mode="multiline" ID="TextBox3" runat="server" placeholder=""></asp:TextBox>
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
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TrueFeedbackConnectionString %>" SelectCommand="SELECT [tp]
      ,[name]
      ,[consola]
      ,[tp_agente]
      ,[tp_avaliador]
      ,[day]
      ,[month]
      ,[year]
      ,[dados_cont]
      ,[dur_ch]
      ,[nota]
      ,[cex]
      ,[tipologia]
      ,[p_fort]
      ,[p_frac]
  FROM [TrueFeedback].[dbo].[master_agent_tbl], [TrueFeedback].[dbo].[master_tmar_tbl]
  WHERE TrueFeedback.dbo.master_agent_tbl.tp = TrueFeedback.dbo.master_tmar_tbl.tp_agente"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" AllowPaging="False" ID="GridView1" PageSize="3" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                                    <PagerSettings Mode="Numeric"></PagerSettings>
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="container-fluid">
                                                    <div class="row">
                                                        <div class="col-lg-12">
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    TP Agente :
                                                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("tp") %>' Font-Bold="True"></asp:Label>
                                                                    &nbsp;| Nome :
                                                                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Eval("name") %>'></asp:Label>
                                                                    &nbsp;| Consola :
                                                                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("consola") %>'></asp:Label>
                                                                    &nbsp;
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    TP Avaliador :
                                                                    <asp:Label ID="Label12" runat="server" Font-Bold="True" Text='<%# Eval("tp_avaliador") %>'></asp:Label>
                                                                    | Data do Registo :
                                                                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Text='<%# Eval("day") %>'></asp:Label>
                                                                    /<asp:Label ID="Label5" runat="server" Font-Bold="True" Text='<%# Eval("month") %>'></asp:Label>
                                                                    /<asp:Label ID="Label6" runat="server" Font-Bold="True" Text='<%# Eval("year") %>'></asp:Label>
                                                                    | NIF/REF/REC :
                                                                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Text='<%# Eval("dados_cont") %>'></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    Duração da Chamada :
                                                                    <asp:Label ID="Label10" runat="server" Font-Bold="True" Text='<%# Eval("dur_ch") %>'></asp:Label>
                                                                    | Nota :
                                                                    <asp:Label ID="Label11" runat="server" Font-Bold="True" Text='<%# Eval("nota") %>'></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    CEX :
                                                                    <asp:Label ID="Label8" runat="server" Font-Bold="True" Text='<%# Eval("cex") %>'></asp:Label>
                                                                    &nbsp;| Tipologia :
                                                                    <asp:Label ID="Label9" runat="server" Font-Bold="True" Text='<%# Eval("tipologia") %>'></asp:Label>
                                                                    &nbsp;
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    Pontos Fortes :
                                                                    <asp:Label ID="Label13" runat="server" Font-Bold="True" Text='<%# Eval("p_fort") %>'></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    Pontos Fracos :
                                                                    <asp:Label ID="Label14" runat="server" Font-Bold="True" Text='<%# Eval("p_frac") %>'></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
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
