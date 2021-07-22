using Newtonsoft.Json;
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
    public partial class HomeLogin : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["feedb"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                var table = DropDownList1.SelectedValue.Equals("Agente") ? "master_agent_tbl" : "master_ava_tbl";
                SqlCommand cmd = new SqlCommand("select * from " + table + " where tp='" + TextBox1.Text.Trim() + "' AND password='" + TextBox2.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Response.Write("<script>alert('Login realizado com sucesso !');</script>");
                        Session["tp"] = dr.GetValue(0).ToString();
                        Session["role"] = DropDownList1.SelectedValue;
                        Session["name"] = dr.GetValue(2).ToString();
                        //Session["status"] = dr.GetValue(10).ToString();
                    }
                    Response.Redirect("mongest.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Credenciais Inválidas');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}