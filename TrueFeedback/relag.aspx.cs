using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Newtonsoft.Json;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

namespace TrueFeedback
{
    public partial class relag : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["feedb"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        
        public string CalculateMonthTMO()
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
                for (int i = 12; i > 0; i--)
                {
                    contmo[i] /= contotalcalls[i];
                }
                int[] testet = new int[]{1, 2, 3, 4, 5};
                foreach int i in 
                return JsonConvert.SerializeObject(testet);
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }*/
            int[] teste = new int[] { 1, 2, 3, 4, 5 };
            CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(1);
            return "[1, 2, 3, 4, 5, 6]";
        }
        void ChartsbyWeeks()
        {
            //Serão mostrados as ultimas 12 semanas
        }
        void ChartsbyDays()
        {
            //Serão mostrados os ultimos 12 dias; 
        }
    }
}