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
using System.Runtime;

namespace TrueFeedback
{
    public partial class relag : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["feedb"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        public void Button1Click(object sender, EventArgs e)
        {
            CalculateDays();
        }
        public string MonthtoLabels()
        {
            string datas = "[";
            int j = DateTime.Now.Month;
            for(int i = 12; i > 0; i--) 
            {
                if (j == 0)
                    j = 12;
                if (i == 1)
                    datas = datas + "'" + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(j).Substring(0, 3) + "'";
                else
                    datas = datas + "'" + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(j).Substring(0, 3) + "'" + ", ";
                j--;
            }
            return datas + "]";
        }
        public string CalculateMonthTMO()
        {
            var t = new string[]{
                (!string.IsNullOrEmpty(TextBox1.Text) ? $"tp = '{TextBox1.Text}'" : ""),
                (!string.IsNullOrEmpty(TextBox2.Text) ? $"nif = '{TextBox2.Text}'" : ""),
                }.Where((e) => { return !string.IsNullOrEmpty(e); });

            var ony = new DateTime(DateTime.Now.Year - 1, DateTime.Now.Month, DateTime.Now.Day);
            var queryQuery = string.Join(" AND ", t);
            try
            {
                SqlConnection feedb = new SqlConnection(strcon);
                if (feedb.State == ConnectionState.Closed)
                {
                    feedb.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT nif,tmo,num_gest,tr_vend,tr_imp,cb_imp,temp_dia,total_calls,dia FROM " +
                    "TrueFeedback.dbo.master_regdia_tbl WHERE " +
                    "TrueFeedback.dbo.master_regdia_tbl.dia BETWEEN '"+ ony.ToString("yyyy/MM/d") + "'" +
                    "AND '" + DateTime.Now.ToString("yyyy/MM/d") + "'", feedb);
                SqlDataAdapter mydb = new SqlDataAdapter(cmd);
                DataTable dbtbl = new DataTable();
                mydb.Fill(dbtbl);
                int[] contmo = new int[12] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                int[] contotalcalls = new int[12] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                int s;
                foreach (DataRow row in dbtbl.Rows)
                {
                    if (int.TryParse(row["dia"].ToString().Substring(1, 1), out _))
                        s = 2;
                    else
                        s = 1;
                    contmo[(Int32.Parse(row["dia"].ToString().Substring(0, s))) - 1] += Int32.Parse(row["temp_dia"].ToString());
                    contotalcalls[(Int32.Parse(row["dia"].ToString().Substring(0, s))) - 1] += Int32.Parse(row["total_calls"].ToString());
                }
                int i = 0;
                while (i < 12)
                {
                    if(contmo[i] != 0)
                        contmo[i] = contmo[i] / contotalcalls[i];
                    i++;
                }
                return "[1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 13]";
            }
            catch (Exception ex)
            {
                return "[1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12]";
            }
        }
        public string TesteFunc()
        {            
            int[] contmon = new int[12];
            int[] gcvar = new int[12];
            int[] tim = new int[12];
            int[] cbi = new int[12];
            int[] trv = new int[12];
            string chartdata = "[";
            int j = DateTime.Now.Month;

            for (int i = 0; i < 12; i++)
            {
                if (j == 0)
                    j = 12;
                contmon[i] = j;
                j--;
            }
            for (int i = 11; i != 0; i--) 
            {
                if (i != 1)
                    chartdata += "{ x : '" + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(contmon[i]).Substring(0, 3) + "', gc: "+ gcvar[i] +", tim: " + tim[i] + ", cbi: " + cbi[i] + ", trv: " + trv[i] + " },";
                else
                    chartdata += "{ x : '" + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(contmon[i]).Substring(0, 3) + "', gc: " + gcvar[i] + ", tim: " + tim[i] + ", cbi: " + cbi[i] + ", trv: " + trv[i] + " }]";
            }
            //return querry;

            return "[{ x: 'Jan', gc: 100, tim: 50, cbi: 50, trv: 100 }, { x: 'Feb', gc: 120, tim: 55, cbi: 75, trv: 100 }, " +
                "{ x: 'Mar', gc: 120, tim: 55, cbi: 75, trv: 100 }, { x: 'Abr', gc: 120, tim: 55, cbi: 75, trv: 100 }," +
                "{ x: 'Mai', gc: 120, tim: 55, cbi: 75, trv: 100 }, { x: 'Jun', gc: 120, tim: 55, cbi: 75, trv: 100 }," +
                "{ x: 'Jul', gc: 120, tim: 55, cbi: 75, trv: 100 }, { x: 'Ago', gc: 120, tim: 55, cbi: 75, trv: 100 }," +
                "{ x: 'Set', gc: 120, tim: 55, cbi: 75, trv: 100 }, { x: 'Out', gc: 120, tim: 55, cbi: 75, trv: 100 }," +
                "{ x: 'Nov', gc: 120, tim: 55, cbi: 75, trv: 100 }, { x: 'Dez', gc: 120, tim: 55, cbi: 75, trv: 100 }]";
        }
        public void CalculateWeeks()
        {
            var t = new string[]{
                (!string.IsNullOrEmpty(TextBox1.Text) ? $"tp = '{TextBox1.Text}'" : ""),
                (!string.IsNullOrEmpty(TextBox2.Text) ? $"nif = '{TextBox2.Text}'" : ""),
                }.Where((e) => { return !string.IsNullOrEmpty(e); });

            var ony = new DateTime(DateTime.Now.Year - 1, DateTime.Now.Month, DateTime.Now.Day);
            var queryQuery = string.Join(" AND ", t);
            try
            {
                SqlConnection feedb = new SqlConnection(strcon);
                if (feedb.State == ConnectionState.Closed)
                {
                    feedb.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT nif,tmo,num_gest,tr_vend,tr_imp,cb_imp,temp_dia,total_calls,dia FROM " +
                    "TrueFeedback.dbo.master_regdia_tbl WHERE " +
                    "TrueFeedback.dbo.master_regdia_tbl.dia BETWEEN '" + ony.ToString("yyyy/MM/d") + "'" +
                    "AND '" + DateTime.Now.ToString("yyyy/MM/d") + "'", feedb);
                SqlDataAdapter mydb = new SqlDataAdapter(cmd);
                DataTable dbtbl = new DataTable();
                mydb.Fill(dbtbl);
                DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                System.Globalization.Calendar cal = dfi.Calendar;
                var hoje = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                var contweek = new int[12];
                var conttmo = new int[12];
                var conttotalcalls = new int[12];
                int contweekread = 0;
                int lastweekread = cal.GetWeekOfYear(hoje, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
                DateTime dia;
                int s = 2;
                foreach (DataRow row in dbtbl.Rows)
                {
                    if (int.TryParse(row["dia"].ToString().Substring(1, 1), out _))
                        s = 2;
                    else
                        s = 1;
                    dia = new DateTime(Int32.Parse(row["dia"].ToString().Substring(4+s, 4)), Int32.Parse(row["dia"].ToString().Substring(0, s)), 
                        Int32.Parse(row["dia"].ToString().Substring(1 + s, 2)));
                    if (lastweekread != cal.GetWeekOfYear(dia, dfi.CalendarWeekRule, dfi.FirstDayOfWeek))
                        contweekread++;
                    if (contweekread < 12)
                    {
                        contweek[contweekread] = cal.GetWeekOfYear(dia, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
                        conttmo[contweekread] += Int32.Parse(row["temp_dia"].ToString());
                        conttotalcalls[contweekread] += Int32.Parse(row["total_calls"].ToString());
                        lastweekread = cal.GetWeekOfYear(dia, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
                    }
                    else
                    {
                        int i = 0;
                        while (i < 12)
                        {
                            if (conttmo[i] != 0)
                                conttmo[i] = conttmo[i] / conttotalcalls[i];
                            i++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }
        public void CalculateDays()
        {
            var t = new string[]{
                (!string.IsNullOrEmpty(TextBox1.Text) ? $"tp = '{TextBox1.Text}'" : ""),
                (!string.IsNullOrEmpty(TextBox2.Text) ? $"nif = '{TextBox2.Text}'" : ""),
                }.Where((e) => { return !string.IsNullOrEmpty(e); });

            var ony = new DateTime(DateTime.Now.Year - 1, DateTime.Now.Month, DateTime.Now.Day);
            var queryQuery = string.Join(" AND ", t);
            try
            {
                SqlConnection feedb = new SqlConnection(strcon);
                if (feedb.State == ConnectionState.Closed)
                {
                    feedb.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT nif,tmo,num_gest,tr_vend,tr_imp,cb_imp,temp_dia,total_calls,dia FROM " +
                    "TrueFeedback.dbo.master_regdia_tbl WHERE " +
                    "TrueFeedback.dbo.master_regdia_tbl.dia BETWEEN '" + ony.ToString("yyyy/MM/d") + "'" +
                    "AND '" + DateTime.Now.ToString("yyyy/MM/d") + "'", feedb);
                SqlDataAdapter mydb = new SqlDataAdapter(cmd);
                DataTable dbtbl = new DataTable();
                mydb.Fill(dbtbl);
                string tmoret = "[";
                int contdaysread = 0;
                DateTime lastday = DateTime.Now;
                int s;
                foreach (DataRow row in dbtbl.Rows)
                {
                    if (int.TryParse(row["dia"].ToString().Substring(1, 1), out _))
                        s = 2;
                    else
                        s = 1;
                    if (contdaysread != 0)
                    {
                        if (lastday != new DateTime(Int32.Parse(row["dia"].ToString().Substring(4 + s, 4)), Int32.Parse(row["dia"].ToString().Substring(0, s)),
                        Int32.Parse(row["dia"].ToString().Substring(1 + s, 2))))
                            contdaysread++;
                    }
                    else
                    {
                        lastday = new DateTime(Int32.Parse(row["dia"].ToString().Substring(4 + s, 4)), Int32.Parse(row["dia"].ToString().Substring(0, s)), 
                            Int32.Parse(row["dia"].ToString().Substring(1 + s, 2)));
                    }
                    if (contdaysread < 11)
                        tmoret = tmoret + row["dia"].ToString() + row["temp_dia"].ToString() + row["total_calls"].ToString() + "\n";
                    else
                    {
                        tmoret = tmoret + row["dia"].ToString() + row["temp_dia"].ToString() + row["total_calls"].ToString() + "]";
                        //return tmoret;
                    }
                    
                }
            }
            catch (Exception ex)
            {

            }
        }
        /*
        public void CalculateMonthGest()
        {
            var t = new string[]{
                (!string.IsNullOrEmpty(TextBox1.Text) ? $"tp = '{TextBox1.Text}'" : ""),
                (!string.IsNullOrEmpty(TextBox2.Text) ? $"nif = '{TextBox2.Text}'" : ""),
                }.Where((e) => { return !string.IsNullOrEmpty(e); });

            var ony = new DateTime(DateTime.Now.Year - 1, DateTime.Now.Month, DateTime.Now.Day);
            var queryQuery = string.Join(" AND ", t);
            try
            {
                SqlConnection feedb = new SqlConnection(strcon);
                if (feedb.State == ConnectionState.Closed)
                {
                    feedb.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT tp,name,consola,nif,temp_dia,total_calls,tmo,num_gest,tr_vend,tr_imp,cb_imp FROM " +
                    "TrueFeedback.dbo.master_agent_tbl, TrueFeedback.dbo.master_regdia_tbl WHERE " +
                    "TrueFeedback.dbo.master_agent_tbl.nif = TrueFeedback.dbo.master_regdia_tbl.nif AND TrueFeedback.dbo.master_regdia_tbl.dia > '" + ony.ToString("yyyy/MM/d") + "'" +
                    "AND TrueFeedback.dbo.master_regdia_tbl.year < '" + DateTime.Now.ToString("yyyy/MM/d") + "' AND " + queryQuery + "", feedb);
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
                int[] testet = new int[] { 1, 2, 3, 4, 5, 6 };
                string[] novidade = new string[] { JsonConvert.SerializeObject(testet), "['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun']" };
                return "[1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 13]";
            }
            catch (Exception ex)
            {
                string[] novidade = new string[] { "[1, 2, 3, 4, 5, 6]", "['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun']" };
                return "[1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12]";
            }
        }*/
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