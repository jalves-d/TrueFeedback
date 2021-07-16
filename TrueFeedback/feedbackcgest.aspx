<%@ Page Title="" Language="C#" MasterPageFile="~/TrueFeedback.Master" AutoEventWireup="true" CodeBehind="feedbackcgest.aspx.cs" Inherits="TrueFeedback.feedbackcgest" %>
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
                           <h4>Gestão de Feedbacks</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                            <img src="img/feedback.png" width="100px"/>
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
                           <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" ReadOnly="true" placeholder="Nome do Agente"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-5">
                        <label>NIF/ Ref. do Contrato/ Reclamação</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control mr-1" ID="TextBox7" TextMode="Number" runat="server" placeholder="Dados"></asp:TextBox>
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
                           <asp:TextBox class="form-control" mode="multiline" ID="TextBox3" runat="server" placeholder="Observações"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                   <div class="row">
                       <div class="col-md-6">
                           <label>
                               Meio de Comunicação
                           </label>
                           <div class="form-group">
                               <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                                   <asp:ListItem Text="Google Meet" Value="Google Meet" />
                                   <asp:ListItem Text="Telemóvel" Value="Telemóvel" />
                                   <asp:ListItem Text="Consola" Value="Consola" />
                                   <asp:ListItem Text="E-mail" Value="E-mail" />
                                   <asp:ListItem Text="Hangout" Value="Hangout" />
                                   <asp:ListItem Text="Presencial" Value="Presencial" />
                               </asp:DropDownList>
                           </div>
                       </div>
                       <div class="col-md-6">
                           <label>Tipologia</label>
                           <div class="form-group">
                               <asp:DropDownList class="form-control" ID="DropDownList2" runat="server">
                                   <asp:ListItem Text="Procedimento" Value="Procedimento" />
                                   <asp:ListItem Text="Comunicação" Value="Comunicação" />
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
                           <asp:Button class="btn nav-link btn-block btn-primary text-white" Style="background-color: #eed202" ID="Button3" runat="server" Text="Modificar" BorderColor="White" />
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
                           <h4>Lista de Feedbacks</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TrueFeedbackConnectionString %>" SelectCommand=""></asp:SqlDataSource>
                     <div class="col">
                        <asp:GridView class="table table-striped table-bordered" ID="GridView1" Control="ContentPlaceHolder1_GridView1" AllowPaging="True" PageSize="3" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <div class="container-fluid">
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <div class="row">
                                                        <div class="col-12">
                                                            TP Agente :
                                                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("tp_agent") %>' Font-Bold="True"></asp:Label>
                                                            &nbsp;| TP Avaliador :
                                                                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Eval("tp_avaliador") %>'></asp:Label>
                                                            &nbsp;| NIF/ REF/RECL :
                                                                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("dados_contrato") %>'></asp:Label>
                                                            &nbsp;
                                                        </div>
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
                                                                    <asp:Label ID="Label8" runat="server" Font-Bold="True" Text='<%# Eval("meio_comun") %>'></asp:Label>
                                                            &nbsp;| Procedimento :
                                                                    <asp:Label ID="Label9" runat="server" Font-Bold="True" Text='<%# Eval("tipologia") %>'></asp:Label>
                                                            &nbsp;
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