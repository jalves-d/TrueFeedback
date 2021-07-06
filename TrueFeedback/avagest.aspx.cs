using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrueFeedback
{
    public partial class avagest : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["feedb"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            conAva();
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkAva())
            {
                Response.Write("<script>alert('Avaliador já cadastrado !');</script>");
            }
            else
            {
                addAva();
            }
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            updateAva();
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            delAva();
        }
        bool checkAva()
        {
            try
            {
                SqlConnection feedb = new SqlConnection(strcon);
                if (feedb.State == ConnectionState.Closed)
                {
                    feedb.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from master_ava_tbl where tp='" + TextBox1.Text.Trim() + "';", feedb);
                SqlDataAdapter mydb = new SqlDataAdapter(cmd);
                DataTable dbtbl = new DataTable();
                mydb.Fill(dbtbl);

                if (dbtbl.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }
        void updateAva()
        {
            try
            {
                SqlConnection feedb = new SqlConnection(strcon);
                if (feedb.State == ConnectionState.Closed)
                {
                    feedb.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE master_ava_tbl SET name=@name,consola=@consola WHERE tp='" + TextBox1.Text.Trim() + "'", feedb);

                cmd.Parameters.AddWithValue("@name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@consola", TextBox7.Text.Trim());

                cmd.ExecuteNonQuery();
                feedb.Close();
                Response.Write("<script>alert('Agente atualizado !');</script>");
                clearBox();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void delAva()
        {
            if (checkAva())
            {
                try
                {
                    SqlConnection feedb = new SqlConnection(strcon);
                    if (feedb.State == ConnectionState.Closed)
                    {
                        feedb.Open();
                    }

                    SqlCommand cmd = new SqlCommand("DELETE from master_ava_tbl WHERE tp='" + TextBox1.Text.Trim() + "'", feedb);

                    cmd.ExecuteNonQuery();
                    feedb.Close();
                    Response.Write("<script>alert('Cadastro do Agente foi deletado !');</script>");
                    clearBox();
                    GridView1.DataBind();

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('TP Inválido');</script>");
            }
        }
        void clearBox()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox7.Text = "";
        }
        void conAva()
        {
            try
            {
                SqlConnection feedb = new SqlConnection(strcon);
                if (feedb.State == ConnectionState.Closed)
                {
                    feedb.Open();

                }
                var t = new string[]{
                (!string.IsNullOrEmpty(TextBox2.Text) ? $"name='{TextBox2.Text}'" : ""),
                (!string.IsNullOrEmpty(TextBox1.Text) ? $"tp = '{TextBox1.Text}'" : "")}.Where((e) => { return !string.IsNullOrEmpty(e); });


                var queryQuery = string.Join(" AND ", t);
                SqlCommand cmd = new SqlCommand($"SELECT * FROM master_ava_tbl where {queryQuery}", feedb);
                SqlDataReader read = cmd.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        SqlDataSource1.SelectCommand = $"SELECT * FROM master_ava_tbl where {queryQuery}";
                        TextBox1.Text = read.GetValue(0).ToString();
                        TextBox2.Text = read.GetValue(1).ToString();
                        TextBox7.Text = read.GetValue(2).ToString();
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
        void addAva()
        {
            try
            {
                SqlConnection feedb = new SqlConnection(strcon);
                if (feedb.State == ConnectionState.Closed)
                {
                    feedb.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO master_ava_tbl(tp,name,consola) values(@tp,@name,@consola)", feedb);
                cmd.Parameters.AddWithValue("@tp", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@consola", TextBox7.Text.Trim());
                cmd.ExecuteNonQuery();
                feedb.Close();
                Response.Write("<script>alert('Avaliador adicionado com sucesso !');</script>");
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