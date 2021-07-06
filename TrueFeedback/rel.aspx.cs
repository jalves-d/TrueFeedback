using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrueFeedback
{
    public partial class rel : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["feedb"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            checkReg();
            check2Mar();
            checkAgent();
        }
        void checkReg()
        {
            try
            {
                SqlConnection feedb = new SqlConnection(strcon);
                if (feedb.State == ConnectionState.Closed)
                {
                    feedb.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT tp,name,consola,tp_agente,tp_avaliador,day,month,year,tmo,num_gest,tr_vend,tr_imp,cb_imp FROM TrueFeedback.dbo.master_agent_tbl, TrueFeedback.dbo.master_regdia_tbl WHERE TrueFeedback.dbo.master_agent_tbl.tp = TrueFeedback.dbo.master_regdia_tbl.tp_agente", feedb);
                SqlDataAdapter mydb = new SqlDataAdapter(cmd);
                DataTable dbtbl = new DataTable();
                mydb.Fill(dbtbl);
                int rtmo = 0;
                int rnum_gest = 0;
                int rtr_vend = 0;
                int rtr_imp = 0;
                int rcb_imp = 0;
                foreach (DataRow row in dbtbl.Rows)
                {
                    rtmo += Int32.Parse(row["tmo"].ToString());
                    rnum_gest += Int32.Parse(row["num_gest"].ToString());
                    rtr_vend += Int32.Parse(row["tr_vend"].ToString());
                    rtr_imp += Int32.Parse(row["tr_imp"].ToString());
                    rcb_imp += Int32.Parse(row["cb_imp"].ToString());
                }
                TextBox11.Text = (rtmo /= dbtbl.Rows.Count).ToString();
                TextBox5.Text = (rnum_gest /= dbtbl.Rows.Count).ToString();
                TextBox6.Text = (rtr_vend /= dbtbl.Rows.Count).ToString();
                TextBox8.Text = (rtr_imp /= dbtbl.Rows.Count).ToString();
                TextBox27.Text = (rcb_imp /= dbtbl.Rows.Count).ToString();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void check2Mar()
        {
            try
            {
                SqlConnection feedb = new SqlConnection(strcon);
                if (feedb.State == ConnectionState.Closed)
                {
                    feedb.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT tp,name,consola,tp_agente,tp_avaliador,day,month,year,dados_cont,dur_ch,nota,cex,tipologia,p_fort,p_frac FROM TrueFeedback.dbo.master_agent_tbl, TrueFeedback.dbo.master_tmar_tbl WHERE TrueFeedback.dbo.master_agent_tbl.tp = TrueFeedback.dbo.master_tmar_tbl.tp_agente", feedb);
                SqlDataAdapter mydb = new SqlDataAdapter(cmd);
                DataTable dbtbl = new DataTable();
                mydb.Fill(dbtbl);
                int rnota = 0;
                int rcex = 0;
                foreach (DataRow row in dbtbl.Rows)
                {
                    rnota += Int32.Parse(row["nota"].ToString());
                    rcex += Int32.Parse(row["cex"].ToString());
                }
                TextBox12.Text = (rnota /= dbtbl.Rows.Count).ToString();
                TextBox13.Text = (rcex /= dbtbl.Rows.Count).ToString();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void checkAgent()
        {
            try
            {
                SqlConnection feedb = new SqlConnection(strcon);
                if (feedb.State == ConnectionState.Closed)
                {
                    feedb.Open();

                }
                SqlCommand cmd = new SqlCommand($"SELECT * FROM master_agent_tbl where tp='" + TextBox1.Text.Trim() + "'", feedb);
                SqlDataReader read = cmd.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        TextBox2.Text = read.GetValue(1).ToString();
                        TextBox7.Text = read.GetValue(2).ToString();
                        TextBox4.Text = read.GetValue(4).ToString();
                        TextBox9.Text = read.GetValue(3).ToString();
                        TextBox28.Text = read.GetValue(5).ToString();
                    }

                }
                else
                {
                    Response.Write("<script>alert('Dados Inválidos !');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}