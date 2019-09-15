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
                Ugv.DataSource = FeedData.FeedDataTable();
                Ugv.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.CellSelect;
              var DtSumm = new DataSummarizer.Summarizer(Ugv, btn);

            //var Teste = new List<DataSummarizer.ColsOperations>()
            //{
            //    new DataSummarizer.ColsOperations("Y/N", "System.Boolean",
            //        new List<DataSummarizer.Summarizer.Operations>(){
            //                DataSummarizer.Summarizer.Operations.True,
            //                DataSummarizer.Summarizer.Operations.False,
            //                DataSummarizer.Summarizer.Operations.count,
            //                DataSummarizer.Summarizer.Operations.NonNull}),

            //    new DataSummarizer.ColsOperations("Boolean", "System.Boolean",
            //        new List<DataSummarizer.Summarizer.Operations>(){
            //                DataSummarizer.Summarizer.Operations.True,
            //                DataSummarizer.Summarizer.Operations.count})
            //};
            //var DtSumm = new DataSummarizer.Summarizer(Ugv, btn, Teste);


            //var Teste = new List<DataSummarizer.ColsOperations>()
            //{
            //    new DataSummarizer.ColsOperations("Y/N", "System.Boolean",
            //        new List<DataSummarizer.Summarizer.Operations>(){
            //                DataSummarizer.Summarizer.Operations.False,
            //                DataSummarizer.Summarizer.Operations.NonNull}),

            //    new DataSummarizer.ColsOperations("Boolean", "System.Boolean",
            //        new List<DataSummarizer.Summarizer.Operations>(){
            //                DataSummarizer.Summarizer.Operations.True,
            //                DataSummarizer.Summarizer.Operations.count})
            //};
            //var DtSumm = new DataSummarizer.Summarizer(Ugv, btn, Teste);


            //var DtSumm = new DataSummarizer.Summarizer(Ugv, btn, GetAllColumns(),
            //new List<DataSummarizer.Summarizer.Operations> 
            //{ DataSummarizer.Summarizer.Operations.False, 
            //DataSummarizer.Summarizer.Operations.True });


            //var DtSumm = new DataSummarizer.Summarizer(Ugv, btn, new List<string>()
            //    { "Nome", "Qtd"}, new List<DataSummarizer.Summarizer.Operations>
            //    { DataSummarizer.Summarizer.Operations.NonNull});

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