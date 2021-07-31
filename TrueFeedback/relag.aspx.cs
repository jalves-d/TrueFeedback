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
            CalculateDaysTMO();
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

        // ERROR RATE CHARTS
        public int[,] LabelsSecByMonth()
        {
            var t = new string[]{
                (!string.IsNullOrEmpty(TextBox1.Text) ? $"tp = '{TextBox1.Text}'" : ""),
                (!string.IsNullOrEmpty(TextBox2.Text) ? $"nif = '{TextBox2.Text}'" : ""),
                }.Where((e) => { return !string.IsNullOrEmpty(e); });
            int[,] teste = new int[4, 12];
            var ony = new DateTime(DateTime.Now.Year - 1, DateTime.Now.Month, DateTime.Now.Day);
            var queryQuery = string.Join(" AND ", t);
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
            int s;
            int contmonthsread = 0;
            int lastmonth = 0;
            foreach (DataRow row in dbtbl.Rows)
            {
                if (int.TryParse(row["dia"].ToString().Substring(1, 1), out _))
                    s = 2;
                else
                    s = 1;
                if (lastmonth == 0)
                    lastmonth = Int32.Parse(row["dia"].ToString().Substring(0, s));
                if (lastmonth != Int32.Parse(row["dia"].ToString().Substring(0, s)))
                    contmonthsread++;
                if (contmonthsread < 12)
                {
                    teste[0, (Int32.Parse(row["dia"].ToString().Substring(0, s))) - 1] += (Int32.Parse(row["num_gest"].ToString()) - Int32.Parse(row["tr_imp"].ToString()) - Int32.Parse(row["cb_imp"].ToString()));
                    teste[1, (Int32.Parse(row["dia"].ToString().Substring(0, s))) - 1] += Int32.Parse(row["tr_imp"].ToString());
                    teste[2, (Int32.Parse(row["dia"].ToString().Substring(0, s))) - 1] += Int32.Parse(row["cb_imp"].ToString());
                    teste[3, (Int32.Parse(row["dia"].ToString().Substring(0, s))) - 1] += Int32.Parse(row["tr_vend"].ToString());
                }
                else
                    return teste;
            }
            contmonthsread++;
            while(contmonthsread < 12)
            {
                teste[0, contmonthsread] = 0;
                teste[1, contmonthsread] = 0;
                teste[2, contmonthsread] = 0;
                teste[3, contmonthsread] = 0;
                contmonthsread++;
            }
            return teste;
        }
        public string SecChartMonth()
        {            
            int[] contmon = new int[12];
            int[,] label = new int[4, 12];
            string chartdata = "[";
            int j = DateTime.Now.Month;

            for (int i = 0; i < 12; i++)
            {
                if (j == 0)
                    j = 12;
                contmon[i] = j;
                j--;
            }
            label = LabelsSecByMonth();
            for (int i = 11; i >= 0; i--) 
            {
                if (i != 0)
                    chartdata += "{ x : '" + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(contmon[i]).Substring(0, 3) + "', gc: "+ label[0, i].ToString() +", tim: " + label[1, i].ToString() + ", cbi: " + label[2,i].ToString() + ", trv: " + label[3, i].ToString() + " },";
                else
                    chartdata += "{ x : '" + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(contmon[i]).Substring(0, 3) + "', gc: " + label[0, i].ToString() + ", tim: " + label[1, i].ToString() + ", cbi: " + label[2, i].ToString() + ", trv: " + label[3, i].ToString() + " }]";
            }
            return chartdata;
        }

        public int[,] LabelsSecByWeek()
        {
            var t = new string[]{
                (!string.IsNullOrEmpty(TextBox1.Text) ? $"tp = '{TextBox1.Text}'" : ""),
                (!string.IsNullOrEmpty(TextBox2.Text) ? $"nif = '{TextBox2.Text}'" : ""),
                }.Where((e) => { return !string.IsNullOrEmpty(e); });
            int[,] labels = new int[5, 12];
            var ony = new DateTime(DateTime.Now.Year - 1, DateTime.Now.Month, DateTime.Now.Day);
            var queryQuery = string.Join(" AND ", t);
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
            int contweekread = 0;
            int lastweekread = cal.GetWeekOfYear(hoje, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
            DateTime dia;
            int s = 2;
            foreach (DataRow row in dbtbl.Rows)
            {
                if (Int32.TryParse(row["dia"].ToString().Substring(1, 1), out _))
                    s = 2;
                else
                    s = 1;
                dia = new DateTime(Int32.Parse(row["dia"].ToString().Substring(4 + s, 4)), Int32.Parse(row["dia"].ToString().Substring(0, s)),
                    Int32.Parse(row["dia"].ToString().Substring(1 + s, 2)));
                if (lastweekread != cal.GetWeekOfYear(dia, dfi.CalendarWeekRule, dfi.FirstDayOfWeek))
                    contweekread++;
                if (contweekread < 12)
                {
                    labels[0, contweekread] = cal.GetWeekOfYear(dia, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
                    labels[1, contweekread] += (Int32.Parse(row["num_gest"].ToString()) - Int32.Parse(row["tr_imp"].ToString()) - Int32.Parse(row["cb_imp"].ToString()));
                    labels[2, contweekread] += Int32.Parse(row["tr_imp"].ToString());
                    labels[3, contweekread] += Int32.Parse(row["cb_imp"].ToString());
                    labels[4, contweekread] += Int32.Parse(row["tr_vend"].ToString());
                    lastweekread = cal.GetWeekOfYear(dia, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
                }
                else
                    return labels;
            }
            contweekread++;
            while (contweekread < 12)
            {
                labels[0, contweekread] = 0;
                labels[1, contweekread] = 0;
                labels[2, contweekread] = 0;
                labels[3, contweekread] = 0;
                labels[3, contweekread] = 0;
                contweekread++;
            }
            return labels;
        }
        public string SecChartWeek()
        {
            int[,] label = new int[5, 12];
            string chartdata = "[";

            label = LabelsSecByWeek();
            for (int i = 0; i < 12; i++)
            {
                if (i != 0)
                    chartdata += "{ x : '" + label[0, i].ToString() + "', gc: " + label[1, i].ToString() + ", tim: " + label[2, i].ToString() + ", cbi: " + label[3, i].ToString() + ", trv: " + label[4, i].ToString() + " },";
                else
                    chartdata += "{ x : '" + label[0, i].ToString() + "', gc: " + label[1, i].ToString() + ", tim: " + label[2, i].ToString() + ", cbi: " + label[3, i].ToString() + ", trv: " + label[4, i].ToString() + " }]";
            }
            return chartdata;
        }

        public string LabelsSecByDay()
        {
            var t = new string[]{
                (!string.IsNullOrEmpty(TextBox1.Text) ? $"tp = '{TextBox1.Text}'" : ""),
                (!string.IsNullOrEmpty(TextBox2.Text) ? $"nif = '{TextBox2.Text}'" : ""),
                }.Where((e) => { return !string.IsNullOrEmpty(e); });

            var ony = new DateTime(DateTime.Now.Year - 1, DateTime.Now.Month, DateTime.Now.Day);
            var queryQuery = string.Join(" AND ", t);
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
            int[,] label = new int[4, 12];
            int s;
            foreach (DataRow row in dbtbl.Rows)
            {
                if (Int32.TryParse(row["dia"].ToString().Substring(1, 1), out _))
                    s = 2;
                else
                    s = 1;
                if (contdaysread != 0)
                {
                    if (lastday != new DateTime(Int32.Parse(row["dia"].ToString().Substring(4 + s, 4)), Int32.Parse(row["dia"].ToString().Substring(0, s)),
                    Int32.Parse(row["dia"].ToString().Substring(1 + s, 2))))
                    {
                        tmoret += "{ x: '" + lastday.Day.ToString() + "/" + lastday.Month.ToString() + "', gc: " + label[0, contdaysread].ToString() + ", tim: " + label[1, contdaysread].ToString() + ", cbi: " + label[2, contdaysread].ToString() + ", trv: " + label[3, contdaysread].ToString() + " },";
                        contdaysread++;
                        if (contdaysread != 12)
                            tmoret +=  ",";
                        else
                            return tmoret +  "]";
                    }
                }
                else
                {
                    lastday = new DateTime(Int32.Parse(row["dia"].ToString().Substring(4 + s, 4)), Int32.Parse(row["dia"].ToString().Substring(0, s)),
                        Int32.Parse(row["dia"].ToString().Substring(1 + s, 2)));
                }
                label[0, contdaysread] += (Int32.Parse(row["num_gest"].ToString()) - Int32.Parse(row["tr_imp"].ToString()) - Int32.Parse(row["cb_imp"].ToString()));
                label[1, contdaysread] += Int32.Parse(row["tr_imp"].ToString());
                label[2, contdaysread] += Int32.Parse(row["cb_imp"].ToString());
                label[3, contdaysread] += Int32.Parse(row["tr_vend"].ToString());
            }
            while (contdaysread < 11)
            {
                tmoret += "{ x: 'No Data', gc: 0, tim: 0, cbi: 0, trv: 0},";
            }
            return tmoret + "{ x: 'No Data', gc: 0, tim: 0, cbi: 0, trv: 0}]";
        }
        //TMO CHARTS
        public string CalculateMonthTMO()
        {
            var t = new string[]{
                (!string.IsNullOrEmpty(TextBox1.Text) ? $"tp = '{TextBox1.Text}'" : ""),
                (!string.IsNullOrEmpty(TextBox2.Text) ? $"nif = '{TextBox2.Text}'" : ""),
                }.Where((e) => { return !string.IsNullOrEmpty(e); });

            var ony = new DateTime(DateTime.Now.Year - 1, DateTime.Now.Month, DateTime.Now.Day);
            var queryQuery = string.Join(" AND ", t);
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
                if (contmo[i] != 0)
                    contmo[i] = contmo[i] / contotalcalls[i];
                i++;
            }
            return "[1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 13]";
        }
        public void CalculateWeeksTMO()
        {
            var t = new string[]{
                (!string.IsNullOrEmpty(TextBox1.Text) ? $"tp = '{TextBox1.Text}'" : ""),
                (!string.IsNullOrEmpty(TextBox2.Text) ? $"nif = '{TextBox2.Text}'" : ""),
                }.Where((e) => { return !string.IsNullOrEmpty(e); });

            var ony = new DateTime(DateTime.Now.Year - 1, DateTime.Now.Month, DateTime.Now.Day);
            var queryQuery = string.Join(" AND ", t);
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
            int i = 0;
            foreach (DataRow row in dbtbl.Rows)
            {
                if (Int32.TryParse(row["dia"].ToString().Substring(1, 1), out _))
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
                    while (i < 12)
                    {
                        if (conttmo[i] != 0)
                            conttmo[i] = conttmo[i] / conttotalcalls[i];
                        i++;
                    }
                }
            }
            while (i < 12)
            {
                if (conttmo[i] != 0)
                    conttmo[i] = conttmo[i] / conttotalcalls[i];
                i++;
            }
        }
        public string CalculateDaysTMO()
        {
            var t = new string[]{
                (!string.IsNullOrEmpty(TextBox1.Text) ? $"tp = '{TextBox1.Text}'" : ""),
                (!string.IsNullOrEmpty(TextBox2.Text) ? $"nif = '{TextBox2.Text}'" : ""),
                }.Where((e) => { return !string.IsNullOrEmpty(e); });

            var ony = new DateTime(DateTime.Now.Year - 1, DateTime.Now.Month, DateTime.Now.Day);
            var queryQuery = string.Join(" AND ", t);
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
            var conttmo = new int[12];
            var contcalls = new int[12];
            int s;
            foreach (DataRow row in dbtbl.Rows)
            {
                if (Int32.TryParse(row["dia"].ToString().Substring(1, 1), out _))
                    s = 2;
                else
                    s = 1;
                if (contdaysread != 0)
                {
                    if (lastday != new DateTime(Int32.Parse(row["dia"].ToString().Substring(4 + s, 4)), Int32.Parse(row["dia"].ToString().Substring(0, s)),
                    Int32.Parse(row["dia"].ToString().Substring(1 + s, 2))))
                    {
                            
                        contdaysread++;
                        if (contdaysread != 12)
                            tmoret += (conttmo[contdaysread - 1] / contcalls[contdaysread - 1]).ToString() + ",";
                        else
                            return tmoret + (conttmo[contdaysread - 1] / contcalls[contdaysread - 1]).ToString() + "]";
                    }
                }
                else
                {
                    lastday = new DateTime(Int32.Parse(row["dia"].ToString().Substring(4 + s, 4)), Int32.Parse(row["dia"].ToString().Substring(0, s)), 
                        Int32.Parse(row["dia"].ToString().Substring(1 + s, 2)));
                }
                conttmo[contdaysread] += Int32.Parse(row["temp_dia"].ToString());
                contcalls[contdaysread] += Int32.Parse(row["total_calls"].ToString());
            }
            while (contdaysread < 11)
            {
                tmoret += (0).ToString() + ",";
            }
            return tmoret + (0).ToString() + "]";
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
    }
}