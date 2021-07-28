<%@ Page Title="" Language="C#" MasterPageFile="~/TrueFeedback.Master" AutoEventWireup="true" CodeBehind="relag.aspx.cs" Inherits="TrueFeedback.relag" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-2">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="TP do Agente"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="NIF"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" mode="multiline" ID="DropDownList1" runat="server" placeholder="Equipa">
                                        <asp:ListItem Text="Equipa" Value="Equipa" />
                                        <asp:ListItem Text="Rookie 1" Value="Rookie 1" />
                                        <asp:ListItem Text="Rookie 2" Value="Rookie 2" />
                                        <asp:ListItem Text="Junior" Value="Junior" />
                                        <asp:ListItem Text="Pré Sênior" Value="Pré Sênior" />
                                        <asp:ListItem Text="Sênior" Value="Sênior" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-1">
                                <div class="form-group">
                                    <input class="form-control datepicker" type="text" id="from" name="from">
                                </div>
                            </div>
                            <div class="col-md-1">
                                <div class="form-group">
                                    <input class="form-control datepicker" type="text" id="to" name="to">
                                </div>
                            </div>
                            <div class="col-md-1">
                                <asp:Button class="btn btn-block btn-sucess btn-primary text-white" Style="background-color: #00008B" OnClick="Button1Click" ID="Button1" runat="server" Text="Relatório" BorderColor="White" />
                            </div>
                            <div class="col-md-1">
                                <asp:Button class="btn btn-block btn-sucess btn-primary text-white" Style="background-color: #00008B" ID="Button2" runat="server" Text="Evolução Mês" BorderColor="White" />
                            </div>
                            <div class="col-md-1">
                                <asp:Button class="btn btn-block btn-sucess btn-primary text-white" Style="background-color: #00008B" ID="Button4" runat="server" Text="Evolução Sem" BorderColor="White" />
                            </div>
                            <div class="col-md-1">
                                <asp:Button class="btn btn-block btn-sucess btn-primary text-white" Style="background-color: #00008B" ID="Button3" runat="server" Text="Evolução Dia" BorderColor="White" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-6">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Relatório</h4>
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
                                <asp:GridView class="table table-striped table-bordered" AllowPaging="False" ID="GridView1" PageSize="3" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
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
                                <div class="row">
                                    <div class="btn-group" role="group">
                                        <asp:Button class="btn nav-link btn-block btn-primary text-white" Style="background-color: #00008B" ID="Button5" runat="server" Text="Download" BorderColor="White" />
                                    </div>
                                </div>
                                <asp:Label ID="newtest" Visible="false" runat="server"><h2></h2><h1><center>Lista de Avaliaçoes</center></h1><h2></h2></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
             <div class="col-md-6">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="chart-container" style="position: relative; height:35vh; width:20vw";>
                            <canvas id="myChart" width="200" height="150"></canvas>
                            <script>
                                var ctx = document.getElementById('myChart');

                                var myChart = new Chart(ctx, {
                                    type: 'bar',
                                    data: {
                                        labels: <%=MonthtoLabels()%>,
                                        datasets: [{
                                            label: 'TMO',
                                            data: <%=CalculateMonthTMO()%>,
                                            backgroundColor: [
                                                'rgba(255, 99, 132, 0.2)',
                                                'rgba(54, 162, 235, 0.2)',
                                                'rgba(255, 206, 86, 0.2)',
                                                'rgba(75, 192, 192, 0.2)',
                                                'rgba(153, 102, 255, 0.2)',
                                                'rgba(255, 159, 64, 0.2)'
                                            ],
                                            borderColor: [
                                                'rgba(255, 99, 132, 1)',
                                                'rgba(54, 162, 235, 1)',
                                                'rgba(255, 206, 86, 1)',
                                                'rgba(75, 192, 192, 1)',
                                                'rgba(153, 102, 255, 1)',
                                                'rgba(255, 159, 64, 1)'
                                            ],
                                            borderWidth: 1
                                        }]
                                    },
                                    options: {
                                        scales: {
                                            y: {
                                                beginAtZero: true
                                            }
                                        }
                                    }
                                });
                            </script>
                           </div>
                        </div>
                  <div class="row">
                            <div class="col-md-12">
                            <div class="chart-container" style="position: relative; height:35vh; width:45vw";>
                            <canvas id="myChartT" width="400" height="145"></canvas>
                            <script>
                                var ctx = document.getElementById('myChartT');
                                const data = <%=SecChartMonth()%>;
                                var myChartT = new Chart(ctx, {
                                    type: 'bar',
                                    data: {
                                        labels: ['Jan', 'Feb'],
                                        datasets: [{
                                            label: 'Gestões Corretas',
                                            data: data,
                                            backgroundColor: ['rgba(0, 0, 255)'],
                                            borderWidth: 1,
                                            parsing: {
                                                yAxisKey: 'gc'
                                            }
                                        }, {
                                            label: 'Transferências Improcedentes',
                                            data: data,
                                            backgroundColor: ['rgba(250, 250, 0)'],
                                            borderWidth: 1,
                                            parsing: {
                                                yAxisKey: 'tim'
                                            }
                                        }, {
                                            label: 'Callbacks Improcedentes',
                                            data: data,
                                            backgroundColor: ['rgba(255, 0, 0)'],
                                            borderWidth: 1,
                                            parsing: {
                                                yAxisKey: 'cbi'
                                            }
                                        }, {
                                            label: 'Transferência Vendas',
                                            data: data,
                                            backgroundColor: ['rgba(0, 255, 0)'],
                                            borderWidth: 1,
                                            parsing: {
                                                yAxisKey: 'trv'
                                            }
                                        }],
                                    },
                                });
                            </script>
                            </div>
                        </div>
                 </div>
                 </div>
            </div>
        </div>
    </div>
</asp:Content>
