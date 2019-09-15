using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFExcel
{
    class FeedData
    {
        public static DataTable FeedDataTable()
        {
            DataTable DtFeed = new DataTable("Counters");

            DtFeed.Columns.Add("Nome", Type.GetType("System.String"));
            DtFeed.Columns.Add("Money", Type.GetType("System.Decimal"));
            DtFeed.Columns.Add("Qtd", Type.GetType("System.Int32"));
            DtFeed.Columns.Add("Boolean", Type.GetType("System.Boolean"));
            DtFeed.Columns.Add("Y/N", Type.GetType("System.Boolean"));
            DtFeed.Columns.Add("Data", Type.GetType("System.DateTime"));

            DtFeed.Rows.Add(new object[] { "Vinicius", 150.30, 2, false, true, DateTime.Parse("2013-07-04") });
            DtFeed.Rows.Add(new object[] { "Adga", 340.98, 1, false, true,DateTime.Parse("2008-02-04") });
            DtFeed.Rows.Add(new object[] { "Rian", 50.35, 0, true, true, DateTime.Parse("2013-10-12") });
            DtFeed.Rows.Add(new object[] { "Eloah", 2047.55, 15, true, false, DateTime.Parse("2019-04-05") });
            DtFeed.Rows.Add(new object[] { "Emily", 235.87, 3, true, true, DateTime.Parse("2004-03-07") });
            DtFeed.Rows.Add(new object[] { "Adrieli", 238.47, 7, false, true, DateTime.Parse("2020-07-04") });
            DtFeed.Rows.Add(new object[] { null, null, null, null, null, null });

            return DtFeed;
        }

        public static DataTable FeedCombo()
        {
            DataTable DtCount = new DataTable("Combo");
            DtCount.Columns.Add("Operation");
            DtCount.Columns.Add("Description");

            DtCount.Rows.Add(new object[] { 1, "Sum"});
            DtCount.Rows.Add(new object[] { 2, "Avg" });
            DtCount.Rows.Add(new object[] { 3, "Max" });
            DtCount.Rows.Add(new object[] { 4, "Min" });

            return DtCount;
        }

    }
}

