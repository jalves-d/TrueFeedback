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
    public partial class mongest : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["feedb"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            conMonit();
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            addMonit();
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            updateMonit();
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            delMonit();
        }

        void delMonit()
        {
            try
            {
                SqlConnection feedb = new SqlConnection(strcon);
                if (feedb.State == ConnectionState.Closed)
                {
                    feedb.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE from master_monit_tbl WHERE tp_agente='" + TextBox1.Text.Trim()
                    + "' AND nome_agent='" + TextBox2.Text.Trim() + "' AND dados_contrato='" + TextBox7.Text.Trim()
                    + "' AND tp_avaliador='" + TextBox4.Text.Trim() + "' AND day='" + TextBox5.Text.Trim()
                    + "' AND month='" + TextBox6.Text.Trim() + "' AND year='" + TextBox8.Text.Trim() + "' AND observ='"
                    + TextBox3.Text.Trim() + "'", feedb);

                cmd.ExecuteNonQuery();
                feedb.Close();
                Response.Write("<script>alert('Monitorização foi deletada !');</script>");
                clearBox();
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void updateMonit()
        {
            try
            {
                SqlConnection feedb = new SqlConnection(strcon);
                if (feedb.State == ConnectionState.Closed)
                {
                    feedb.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE master_monit_tbl SET observ=@observ,comun=@comun,procedimento=@procedimento,alarme=@alarme WHERE tp_agente='" + TextBox1.Text.Trim()
                    + "' AND dados_contrato='" + TextBox7.Text.Trim()
                    + "' AND tp_avaliador='" + TextBox4.Text.Trim() + "' AND day='" + TextBox5.Text.Trim()
                    + "' AND month='" + TextBox6.Text.Trim() + "' AND year='" + TextBox8.Text.Trim() + "'", feedb);

                cmd.Parameters.AddWithValue("@observ", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@comun", DropDownList3.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@procedimento", DropDownList4.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@alarme", DropDownList5.SelectedItem.Value);

                cmd.ExecuteNonQuery();
                feedb.Close();
                Response.Write("<script>alert('Monitorização atualizado !');</script>");
                clearBox();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void clearBox()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox7.Text = "";
            TextBox4.Text = "";
            TextBox3.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox8.Text = "";
        }
        void conMonit()
        {
            try
            {
                SqlConnection feedb = new SqlConnection(strcon);
                if (feedb.State == ConnectionState.Closed)
                {
                    feedb.Open();

                }
                var t = new string[]{
                (!string.IsNullOrEmpty(TextBox2.Text) ? $"nome_agent='{TextBox2.Text}'" : ""),
                (!string.IsNullOrEmpty(TextBox1.Text) ? $"tp_agente = '{TextBox1.Text}'" : ""),
                (!string.IsNullOrEmpty(TextBox7.Text) ? $"dados_contrato = '{TextBox7.Text}'" : ""),
                (!string.IsNullOrEmpty(TextBox4.Text) ? $"tp_avaliador = '{TextBox4.Text}'" : ""),
                (!string.IsNullOrEmpty(TextBox5.Text) ? $"day = '{TextBox5.Text}'" : ""),
                (!string.IsNullOrEmpty(TextBox6.Text) ? $"month = '{TextBox6.Text}'" : ""),
                (!string.IsNullOrEmpty(TextBox8.Text) ? $"year = '{TextBox8.Text}'" : ""),
                (!string.IsNullOrEmpty(TextBox3.Text) ? $"observ = '{TextBox3.Text}'" : ""),
                }.Where((e) => { return !string.IsNullOrEmpty(e); });


                var queryQuery = string.Join(" AND ", t);
                SqlCommand cmd = new SqlCommand($"SELECT * FROM master_monit_tbl where {queryQuery}", feedb);
                SqlDataReader read = cmd.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        SqlDataSource1.SelectCommand = $"SELECT * FROM master_monit_tbl where {queryQuery}";
                        TextBox1.Text = read.GetValue(0).ToString();
                        TextBox2.Text = read.GetValue(1).ToString();
                        TextBox7.Text = read.GetValue(2).ToString();
                        TextBox4.Text = read.GetValue(3).ToString();
                        TextBox5.Text = read.GetValue(4).ToString();
                        TextBox6.Text = read.GetValue(5).ToString();
                        TextBox8.Text = read.GetValue(6).ToString();
                        TextBox3.Text = read.GetValue(7).ToString();
                        DropDownList3.SelectedValue = read.GetValue(8).ToString();
                        DropDownList4.SelectedValue = read.GetValue(9).ToString();
                        DropDownList5.SelectedValue = read.GetValue(10).ToString();
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
        void addMonit()
        {
            try
            {
                SqlConnection feedb = new SqlConnection(strcon);
                if (feedb.State == ConnectionState.Closed)
                {
                    feedb.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO master_monit_tbl(tp_agente,nome_agent,dados_contrato,tp_avaliador,day,month,year,observ,comun,procedimento,alarme) values(@tp_agente,@nome_agent,@dados_contrato,@tp_avaliador,@day,@month,@year,@observ,@comun,@procedimento,@alarme)", feedb);
                cmd.Parameters.AddWithValue("@tp_agente", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@nome_agent", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@dados_contrato", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@tp_avaliador", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@day", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@month", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@year", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@observ", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@comun", DropDownList3.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@procedimento", DropDownList4.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@alarme", DropDownList5.SelectedItem.Value);
                cmd.ExecuteNonQuery();
                feedb.Close();
                Response.Write("<script>alert('Monitorização adicionado com sucesso !');</script>");
                clearBox();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}