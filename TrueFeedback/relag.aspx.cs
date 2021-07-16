using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrueFeedback
{
    public partial class relag : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["feedb"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
        void CalculateMonthTMO()
        {
            var t = new string[]{
                (!string.IsNullOrEmpty(TextBox1.Text) ? $"tp = '{TextBox1.Text}'" : ""),
                (!string.IsNullOrEmpty(TextBox4.Text) ? $"nif = '{TextBox4.Text}'" : ""),
                }.Where((e) => { return !string.IsNullOrEmpty(e); });

            var queryQuery = string.Join(" AND ", t);
            try
            {
                SqlConnection feedb = new SqlConnection(strcon);
                if (feedb.State == ConnectionState.Closed)
                {
                    feedb.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT tp,name,consola,nif,temp_dia,total_calls,day,month,year,tmo,num_gest,tr_vend,tr_imp,cb_imp FROM TrueFeedback.dbo.master_agent_tbl, TrueFeedback.dbo.master_regdia_tbl WHERE TrueFeedback.dbo.master_agent_tbl.nif = TrueFeedback.dbo.master_regdia_tbl.nif AND TrueFeedback.dbo.master_regdia_tbl.year ='" + DateTime.Now.Year + "' AND " + queryQuery +"", feedb);
                SqlDataAdapter mydb = new SqlDataAdapter(cmd);
                DataTable dbtbl = new DataTable();
                mydb.Fill(dbtbl);
                int[] contmo = new int[12];
                int[] contotalcalls = new int[12];
                foreach (DataRow row in dbtbl.Rows)
                {
                    contmo[(Int32.Parse(row["month"].ToString())) - 1] += Int32.Parse(row["temp_dia"].ToString());
                    contotalcalls[(Int32.Parse(row["month"].ToString())) - 1] += Int32.Parse(row["total_calls"].ToString());
                }
                for (int i = 0; i < 12; i++)
                {
                    contmo[i] /= contotalcalls[i];
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

        }
        void ChartsByMonth()
        {

        }
        void ChartsByDay()
        {

        }
    }
}