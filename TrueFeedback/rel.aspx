<%@ Page Title="" Language="C#" MasterPageFile="~/TrueFeedback.Master" AutoEventWireup="true" CodeBehind="rel.aspx.cs" Inherits="TrueFeedback.rel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container-fluid">
        <div class="row">
            <div class="col-md-6">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Relatório Agente</h4>
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
                                <label>Contacto : </label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox4" ReadOnly="true" runat="server" placeholder=""></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>
                                    Email :
                                </label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" mode="multiline" ReadOnly="true" ID="TextBox9" runat="server" placeholder=""></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <label>TMO :</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" mode="multiline" ReadOnly="true" ID="TextBox11" runat="server" placeholder=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <label>Nota 2Mares:</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" mode="multiline" ReadOnly="true" ID="TextBox12" runat="server" placeholder=""></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>CEX :</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" mode="multiline" ReadOnly="true" ID="TextBox13" runat="server" placeholder=""></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Número de Gestões :</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" mode="multiline" ReadOnly="true" ID="TextBox5" runat="server" placeholder=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <label>Transferências Vendas :</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" mode="multiline" ReadOnly="true" ID="TextBox6" runat="server" placeholder=""></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Transferências Improcedentes :</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" mode="multiline" ReadOnly="true" ID="TextBox8" runat="server" placeholder=""></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Callbacks Improcedentes :</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" mode="multiline" ReadOnly="true" ID="TextBox27" runat="server" placeholder=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <label>Equipa :</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ReadOnly="true" mode="multiline" ID="TextBox28" runat="server" placeholder=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Data Inicial :</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" mode="multiline" ID="TextBox10" runat="server" placeholder=""></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Data Final :</label>
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
                                <asp:Button class="btn nav-link btn-block btn-primary text-white" Style="background-color: #3CB371" ID="Button2" runat="server" Text="Download" BorderColor="White" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Relatório Equipa</h4>
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
                                        <asp:TextBox CssClass="form-control" ID="TextBox14" runat="server" placeholder="TP do Agente"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Nome do Agente :</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox15" runat="server" placeholder="Nome do Agente" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-5">
                                <label>Consola :</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control mr-1" ID="TextBox16" runat="server" placeholder="Consola" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <label>TP do Avaliador : </label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox17" runat="server" placeholder="TP do Avaliador"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>Dia :</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox18" runat="server" placeholder="Dia"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>Mês :</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox19" runat="server" placeholder="Mês"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label>Ano :</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox20" runat="server" placeholder="Ano"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <label>
                                    NIF/REF/REC :
                                </label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" mode="multiline" ID="TextBox21" runat="server" placeholder=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <label>Duração da Chamada :</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" mode="multiline" ID="TextBox22" runat="server" placeholder=""></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Nota :</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" mode="multiline" ID="TextBox23" runat="server" placeholder=""></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>CEX :</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" mode="multiline" ID="TextBox24" runat="server" placeholder=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <label>Tipologia :</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" mode="multiline" ID="DropDownList2" runat="server" placeholder="Tipologia">
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
                                    <asp:TextBox class="form-control" mode="multiline" ID="TextBox25" runat="server" placeholder=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <label>Pontos Fracos :</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" mode="multiline" ID="TextBox26" runat="server" placeholder=""></asp:TextBox>
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
                                <asp:Button class="btn nav-link btn-block btn-primary text-white" Style="background-color: #00008B" ID="Button5" runat="server" Text="Consultar" BorderColor="White" />
                                <asp:Button class="btn nav-link btn-block btn-primary text-white" Style="background-color: #3CB371" ID="Button6" runat="server" Text="Download" BorderColor="White" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
