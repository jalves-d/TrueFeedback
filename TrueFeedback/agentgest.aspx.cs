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
    public partial class agentgest : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["feedb"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            conAgent();
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkAgent())
            {
                Response.Write("<script>alert('Agente já cadastrado !');</script>");
            }
            else
            {
                addAgent();
            }
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            updateAgent();
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            delAgent();
        }
        bool checkAgent()
        {
            try
            {
                SqlConnection feedb = new SqlConnection(strcon);
                if (feedb.State == ConnectionState.Closed)
                {
                    feedb.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from master_agent_tbl where tp='" + TextBox1.Text.Trim() + "';", feedb);
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
        void updateAgent()
        {
            try
            {
                SqlConnection feedb = new SqlConnection(strcon);
                if (feedb.State == ConnectionState.Closed)
                {
                    feedb.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE master_agent_tbl SET name=@name,consola=@consola,email=@email,contacto=@contacto,equipa=@equipa WHERE tp='" + TextBox1.Text.Trim() + "'", feedb);

                cmd.Parameters.AddWithValue("@name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@consola", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@email", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@contacto", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@equipa", DropDownList1.SelectedItem.Value);

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
        void delAgent()
        {
            if (checkAgent())
            {
                try
                {
                    SqlConnection feedb = new SqlConnection(strcon);
                    if (feedb.State == ConnectionState.Closed)
                    {
                        feedb.Open();
                    }

                    SqlCommand cmd = new SqlCommand("DELETE from master_agent_tbl WHERE tp='" + TextBox1.Text.Trim() + "'", feedb);

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
            TextBox4.Text = "";
            TextBox3.Text = "";
        }
        void conAgent()
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
                SqlCommand cmd = new SqlCommand($"SELECT * FROM master_agent_tbl where {queryQuery}", feedb);
                SqlDataReader read = cmd.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        SqlDataSource1.SelectCommand = $"SELECT * FROM master_agent_tbl where {queryQuery}";
                        TextBox1.Text = read.GetValue(0).ToString();
                        TextBox2.Text = read.GetValue(1).ToString();
                        TextBox7.Text = read.GetValue(2).ToString();
                        TextBox4.Text = read.GetValue(3).ToString();
                        TextBox3.Text = read.GetValue(4).ToString();
                        DropDownList1.SelectedValue = read.GetValue(5).ToString();
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
        void addAgent()
        {
            try
            {
                SqlConnection feedb = new SqlConnection(strcon);
                if (feedb.State == ConnectionState.Closed)
                {
                    feedb.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO master_agent_tbl(tp,name,consola,email,contacto,equipa) values(@tp,@name,@consola,@email,@contacto,@equipa)", feedb);
                cmd.Parameters.AddWithValue("@tp", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@consola", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@email", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@contacto", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@equipa", DropDownList1.SelectedItem.Value);
                cmd.ExecuteNonQuery();
                feedb.Close();
                Response.Write("<script>alert('Agente adicionado com sucesso !');</script>");
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