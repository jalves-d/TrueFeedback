using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Web.UI;
using System.Web;
using iTextSharp.tool.xml;
using PuppeteerSharp;
using System.Threading.Tasks;

namespace TrueFeedback
{
    public partial class feedbackcgest : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["feedb"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            conFeedback();
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            addFeedback();
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            delFeedback();
        }
        void delFeedback()
        {
                try
                {
                    SqlConnection feedb = new SqlConnection(strcon);
                    if (feedb.State == ConnectionState.Closed)
                    {
                        feedb.Open();
                    }

                    SqlCommand cmd = new SqlCommand("DELETE from master_feedback_tbl WHERE tp_agent='" + TextBox1.Text.Trim() 
                        + "' AND dados_contrato='" + TextBox7.Text.Trim() 
                        + "' AND tp_avaliador='" + TextBox4.Text.Trim() + "' AND day='"+ TextBox5.Text.Trim() 
                        + "' AND month='" + TextBox6.Text.Trim() + "' AND year='" + TextBox8.Text.Trim() + "' AND observ='" 
                        + TextBox3.Text.Trim() + "'", feedb);

                    cmd.ExecuteNonQuery();
                    feedb.Close();
                    Response.Write("<script>alert('Feedback foi deletado !');</script>");
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


        void conFeedback()
        {
            try
            {
                SqlConnection feedb = new SqlConnection(strcon);
                if (feedb.State == ConnectionState.Closed)
                {
                    feedb.Open();

                }
                var t = new string[]{
                (!string.IsNullOrEmpty(TextBox1.Text) ? $"tp_agent = '{TextBox1.Text}'" : ""),
                (!string.IsNullOrEmpty(TextBox7.Text) ? $"dados_contrato = '{TextBox7.Text}'" : ""),
                (!string.IsNullOrEmpty(TextBox4.Text) ? $"tp_avaliador = '{TextBox4.Text}'" : ""),
                (!string.IsNullOrEmpty(TextBox5.Text) ? $"day = '{TextBox5.Text}'" : ""),
                (!string.IsNullOrEmpty(TextBox6.Text) ? $"month = '{TextBox6.Text}'" : ""),
                (!string.IsNullOrEmpty(TextBox8.Text) ? $"year = '{TextBox8.Text}'" : ""),
                }.Where((e) => { return !string.IsNullOrEmpty(e); });


                var queryQuery = string.Join(" AND ", t);
                SqlCommand cmd = new SqlCommand($"SELECT tp,name,tp_agent,dados_contrato,tp_avaliador,day,month,year,observ,meio_comun,tipologia FROM TrueFeedback.dbo.master_feedback_tbl,TrueFeedback.dbo.master_agent_tbl WHERE TrueFeedback.dbo.master_agent_tbl.tp = TrueFeedback.dbo.master_feedback_tbl.tp_agent AND {queryQuery}", feedb);
                SqlDataReader read = cmd.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        SqlDataSource1.SelectCommand = $"SELECT tp,name,tp_agent,dados_contrato,tp_avaliador,day,month,year,observ,meio_comun,tipologia FROM TrueFeedback.dbo.master_feedback_tbl,TrueFeedback.dbo.master_agent_tbl WHERE TrueFeedback.dbo.master_agent_tbl.tp = TrueFeedback.dbo.master_feedback_tbl.tp_agent AND {queryQuery}";
                        TextBox1.Text = read.GetValue(0).ToString();
                        TextBox2.Text = read.GetValue(1).ToString();
                        TextBox7.Text = read.GetValue(3).ToString();
                        TextBox4.Text = read.GetValue(4).ToString();
                        TextBox5.Text = read.GetValue(5).ToString();
                        TextBox6.Text = read.GetValue(6).ToString();
                        TextBox8.Text = read.GetValue(7).ToString();
                        TextBox3.Text = read.GetValue(8).ToString();
                        DropDownList1.SelectedValue = read.GetValue(9).ToString();
                        DropDownList2.SelectedValue = read.GetValue(10).ToString();
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
        void addFeedback()
        {
            try
            {
                SqlConnection feedb = new SqlConnection(strcon);
                if (feedb.State == ConnectionState.Closed)
                {
                    feedb.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO master_feedback_tbl(tp_agent,dados_contrato,tp_avaliador,day,month,year,observ,meio_comun,tipologia) values(@tp_agent,@dados_contrato,@tp_avaliador,@day,@month,@year,@observ,@meio_comun,@tipologia)", feedb);
                cmd.Parameters.AddWithValue("@tp_agent", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@dados_contrato", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@tp_avaliador", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@day", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@month", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@year", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@observ", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@meio_comun", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@tipologia", DropDownList2.SelectedItem.Value);
                cmd.ExecuteNonQuery();
                feedb.Close();
                Response.Write("<script>alert('Feedback adicionado com sucesso !');</script>");
                clearBox();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}