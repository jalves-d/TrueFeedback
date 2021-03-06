using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace TrueFeedback
{
    public partial class tmar : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["feedb"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
            if (Convert.ToString(Session["role"]).Equals("Agente"))
            {
                Button2.Visible = false;
                Button4.Visible = false;
                Button3.Visible = false;
                TextBox1.Text = Session["tp"].ToString();
                TextBox1.ReadOnly = true;
            }
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
        protected void Download(object sender, EventArgs e)
        {
            GridView1.AllowPaging = false;
            GridView1.DataBind();
            PrintGrid();
            GridView1.AllowPaging = true;
        }
        void PrintGrid()
        {
            HtmlForm form = new HtmlForm();
            Response.ClearContent();
            Response.AddHeader("content-disposition", string.Format("attachment; filename=Registos.html"));
            Response.Charset = "";
            Response.ContentType = "text/html";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            form.Attributes["runat"] = "server";
            newtest.Visible = true;
            form.Controls.Add(Header);
            form.Controls.Add(newtest);
            form.Controls.Add(GridView1);
            this.Controls.Add(form);
            Form.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.Flush();
            Response.End();
            newtest.Visible = false;
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

                SqlCommand cmd = new SqlCommand("DELETE from master_tmar_tbl WHERE tp_agente='" + TextBox1.Text.Trim()
                    + "' AND tp_avaliador='" + TextBox4.Text.Trim() + "' AND day='" + TextBox5.Text.Trim()
                    + "' AND month='" + TextBox6.Text.Trim() + "' AND year='" + TextBox8.Text.Trim() + "'   AND dados_cont='" + TextBox9.Text.Trim() + "'", feedb);

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

                SqlCommand cmd = new SqlCommand("UPDATE master_tmar_tbl SET dur_ch=@dur_ch,nota=@nota,cex=@cex,tipologia=@tipologia,p_fort=@p_fort,p_frac=@p_frac WHERE tp_agente='" + TextBox1.Text.Trim()
                    + "' AND day='" + TextBox5.Text.Trim() + "' AND month='" + TextBox6.Text.Trim() + "' AND year='" + TextBox8.Text.Trim() + "' AND dados_cont='" + TextBox9.Text.Trim() + "'", feedb);

                cmd.Parameters.AddWithValue("@dur_ch", TextBox11.Text.Trim());
                cmd.Parameters.AddWithValue("@nota", TextBox12.Text.Trim());
                cmd.Parameters.AddWithValue("@cex", TextBox13.Text.Trim());
                cmd.Parameters.AddWithValue("@tipologia", DropDownList1.SelectedValue);
                cmd.Parameters.AddWithValue("@p_fort", TextBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@p_frac", TextBox3.Text.Trim());

                cmd.ExecuteNonQuery();
                feedb.Close();
                Response.Write("<script>alert('Monitorização atualizada !');</script>");
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
            TextBox9.Text = "";
            TextBox10.Text = "";
            TextBox11.Text = "";
            TextBox12.Text = "";
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
                (!string.IsNullOrEmpty(TextBox1.Text) ? $"tp_agente = '{TextBox1.Text}'" : ""),
                (!string.IsNullOrEmpty(TextBox4.Text) ? $"tp_avaliador = '{TextBox4.Text}'" : ""),
                (!string.IsNullOrEmpty(TextBox5.Text) ? $"day = '{TextBox5.Text}'" : ""),
                (!string.IsNullOrEmpty(TextBox6.Text) ? $"month = '{TextBox6.Text}'" : ""),
                (!string.IsNullOrEmpty(TextBox8.Text) ? $"year = '{TextBox8.Text}'" : ""),
                }.Where((e) => { return !string.IsNullOrEmpty(e); });


                var queryQuery = string.Join(" AND ", t);
                SqlCommand cmd = new SqlCommand($"SELECT tp,name,consola,tp_agente,tp_avaliador,day,month,year,dados_cont,dur_ch,nota,cex,tipologia,p_fort,p_frac FROM TrueFeedback.dbo.master_agent_tbl, TrueFeedback.dbo.master_tmar_tbl WHERE TrueFeedback.dbo.master_agent_tbl.tp = TrueFeedback.dbo.master_tmar_tbl.tp_agente AND {queryQuery}", feedb);
                SqlDataReader read = cmd.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        SqlDataSource1.SelectCommand = $"SELECT tp,name,consola,tp_agente,tp_avaliador,day,month,year,dados_cont,dur_ch,nota,cex,tipologia,p_fort,p_frac FROM TrueFeedback.dbo.master_agent_tbl, TrueFeedback.dbo.master_tmar_tbl WHERE TrueFeedback.dbo.master_agent_tbl.tp = TrueFeedback.dbo.master_tmar_tbl.tp_agente AND {queryQuery}";
                        TextBox1.Text = read.GetValue(0).ToString();
                        TextBox2.Text = read.GetValue(1).ToString();
                        TextBox7.Text = read.GetValue(2).ToString();
                        TextBox4.Text = read.GetValue(4).ToString();
                        TextBox5.Text = read.GetValue(5).ToString();
                        TextBox6.Text = read.GetValue(6).ToString();
                        TextBox8.Text = read.GetValue(7).ToString();
                        TextBox9.Text = read.GetValue(8).ToString();
                        TextBox11.Text = read.GetValue(9).ToString();
                        TextBox12.Text = read.GetValue(10).ToString();
                        DropDownList1.SelectedValue = read.GetValue(11).ToString();
                        TextBox10.Text = read.GetValue(12).ToString();
                        TextBox3.Text = read.GetValue(12).ToString();
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
                SqlCommand cmd = new SqlCommand("INSERT INTO master_tmar_tbl(tp_agente,tp_avaliador,day,month,year,dados_cont,dur_ch,nota,cex,tipologia,p_fort,p_frac) values(@tp_agente,@tp_avaliador,@day,@month,@year,@dados_cont,@dur_ch,@nota,@cex,@tipologia,@p_fort,@p_frac)", feedb);
                cmd.Parameters.AddWithValue("@tp_agente", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@tp_avaliador", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@day", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@month", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@year", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@dados_cont", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@dur_ch", TextBox11.Text.Trim());
                cmd.Parameters.AddWithValue("@nota", TextBox12.Text.Trim());
                cmd.Parameters.AddWithValue("@cex", TextBox13.Text.Trim());
                cmd.Parameters.AddWithValue("@tipologia", DropDownList1.SelectedValue);
                cmd.Parameters.AddWithValue("@p_fort", TextBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@p_frac", TextBox3.Text.Trim());
                cmd.ExecuteNonQuery();
                feedb.Close();
                Response.Write("<script>alert('Monitorização 2MARES adicionada com sucesso !');</script>");
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