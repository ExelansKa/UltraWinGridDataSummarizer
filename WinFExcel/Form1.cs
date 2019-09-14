using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace WinFExcel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Ugv.DataSource = FeedData.FeedDataTable();

                //var DtSumm = new DataSummarizer.Summarizer(Ugv, btn);
                var DtSumm = new DataSummarizer.Summarizer(Ugv, btn, GetAllColumns(),
                    new List<DataSummarizer.Summarizer.Operations> { DataSummarizer.Summarizer.Operations.False, DataSummarizer.Summarizer.Operations.True });
                //var DtSumm = new DataSummarizer.Summarizer(Ugv, btn, new List<string>() { "Nome", "Qtd"}, new List<DataSummarizer.Summarizer.Operations> { DataSummarizer.Summarizer.Operations.NonNull});
                Ugv.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.CellSelect;
                //DtSumm.MyMenuStrip
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Ugv_AfterSelectChange(object sender, Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs e)
        {

        }

        private List<string> GetAllColumns()
        {
            var lst = new List<string>();
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn UgCol in Ugv.Rows.Band.Columns.All)
            {
                lst.Add(UgCol.Key.ToString());
            }
            return lst;
        }

    }
}