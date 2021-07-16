using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrueFeedback
{
    public partial class TrueFeedback : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       try
                       {
                           if (Convert.ToString(Session["role"]).Equals("Avaliador"))
                           {
                               LinkButton1.Visible = true; // HomePage
                               LinkButton3.Visible = true; // Agentes
                               LinkButton4.Visible = true; // Feedbacks
                               LinkButton15.Text = Session["tp"].ToString();
                               LinkButton15.Visible = true;
                               LinkButton5.Visible = true; // Monitorizações
                               LinkButton6.Visible = true; // 2Mares
                               LinkButton7.Visible = false; // Registo Diário
                               LinkButton8.Visible = true; // Logout
                               LinkButton9.Visible = false; // Registo 2 Mares
                               LinkButton10.Visible = false; // Admin Login
                               LinkButton11.Visible = true; // Relatório Agente/Equipa
                               LinkButton12.Visible = false; // Relatório Avaliadores
                           }
                           else if (Convert.ToString(Session["role"]).Equals("admin"))
                           {
                               LinkButton1.Visible = false; // HomePage
                               LinkButton3.Visible = true; // Agentes
                               LinkButton4.Visible = true; // Feedbacks
                               LinkButton15.Text = Session["tp"].ToString();
                               LinkButton15.Visible = true;
                               LinkButton5.Visible = true; // Monitorizações
                               LinkButton6.Visible = true; // 2Mares
                               LinkButton7.Visible = true; // Registo Diário
                               LinkButton8.Visible = true; // Logout
                               LinkButton9.Visible = true; // Registo 2 Mares
                               LinkButton10.Visible = false; // Admin Login
                               LinkButton11.Visible = true; // Relatório Agente/Equipa
                               LinkButton12.Visible = true; // Relatório Avaliadores
                           }
                           else if (Convert.ToString(Session["role"]).Equals("Agente"))
                           {
                               LinkButton1.Visible = true; // HomePage
                               LinkButton3.Visible = false; // Agentes
                               LinkButton4.Visible = true; // Feedbacks
                               LinkButton15.Text = Session["tp"].ToString();
                               LinkButton15.Visible = true;
                               LinkButton5.Visible = true; // Monitorizações
                               LinkButton6.Visible = true; // 2Mares
                               LinkButton7.Visible = false; // Registo Diário
                               LinkButton8.Visible = true; // Logout
                               LinkButton9.Visible = false; // Registo 2 Mares
                               LinkButton10.Visible = false; // Admin Login
                               LinkButton11.Visible = false; // Relatório Agente/Equipa
                               LinkButton12.Visible = false; // Relatório Avaliadores
                           }
                       }
                       catch (Exception ex)
                       {

                       }
        }
        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Session["tp"] = "";
            Session["role"] = "";
            LinkButton1.Visible = false; // HomePage
            LinkButton3.Visible = false; // Agentes
            LinkButton4.Visible = false; // Feedbacks
            LinkButton15.Visible = false;
            LinkButton5.Visible = false; // Monitorizações
            LinkButton6.Visible = false; // 2Mares
            LinkButton7.Visible = false; // Registo Diário
            LinkButton8.Visible = false; // Logout
            LinkButton9.Visible = false; // Registo 2 Mares
            LinkButton10.Visible = true; // Admin Login
            LinkButton11.Visible = false; // Relatório Agente/Equipa
            LinkButton12.Visible = false; // Relatório Avaliadores
            Response.Redirect("HomeLogin.aspx");
        }
    }
}