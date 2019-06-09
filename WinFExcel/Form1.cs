using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;

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

        }

        private void SelecionOfCells()
        {
            if (Ugv.Selected.Cells.Count > 1)
            {
                var CellSelecionadas = Ugv.Selected.Cells.All.ToList();
                Type TipoRegente = ((UltraGridCell)CellSelecionadas[0]).Column.DataType;
                Boolean TiposIguais = CellSelecionadas.All(C => ((UltraGridCell)C).Column.DataType == TipoRegente);

                if (TiposIguais)
                {
                    TakeFieldsVisible();
                    CalcByDataType(CellSelecionadas);
                    label1.Visible = true;
                    btnMore.Visible = true;
                }
            }
            else
            {
                label1.Visible = false;
                btnMore.Visible = false;
            }

        }

        private void CalcByDataType(List<object> CellsCollection)
        {
            switch (((UltraGridCell)CellsCollection[0]).Column.DataType.ToString())
            {

                case "System.Decimal":
                    OperationsNumerico(CellsCollection);
                    break;


                case "System.String":
                    OperationString(CellsCollection);
                    break;


                case "System.Int32":
                    OperationsNumerico(CellsCollection);
                    break;


                case "System.Boolean":
                    OperationBoolean(CellsCollection);
                    break;


                case "System.DateTime":
                    OperationDate(CellsCollection);
                    break;

            }
        }

        private void Ugv_MouseUp(object sender, MouseEventArgs e)
        {
            SelecionOfCells();
        }

        private void TakeFieldsVisible()
        {
            MnAvg.Visible = true;

            MnSoma.Visible = true;

            MnMax.Visible = true;

            MnMin.Visible = true;

            MnCont.Visible = true;
        }



        public double Average(List<double> ValuesCollection)
        {
            double FinalAvg = 0;

            foreach (double cell in ValuesCollection)
            {
                FinalAvg += cell;
            }

            return Math.Round((FinalAvg)/ ValuesCollection.Count, 2);
        }

        public double Sum(List<double> ValuesCollection)
        {
            double FinalSum = 0;

            foreach (double cell in ValuesCollection)
            {
                FinalSum += cell;
            }

            return FinalSum;
        }

        public double Max(List<double> ValuesCollection)
        {
            double MaxValue = ValuesCollection[0];

            foreach (double cell in ValuesCollection)
            {
                if (Math.Abs(cell) > MaxValue)
                {
                    MaxValue = Math.Abs(cell);
                }
            }

            return MaxValue;
        }

        public double Min(List<double> ValuesCollection)
        {
            double MinValue = ValuesCollection[0];

            foreach (double cell in ValuesCollection)
            {
                if (Math.Abs(cell) < MinValue)
                {
                    MinValue = Math.Abs(cell);
                }
            }

            return MinValue;
        }

        public DateTime MaxDate(List<DateTime> ValuesCollection)
        {
            DateTime SumVl = ValuesCollection[0];

            for (int i = 1; i < ValuesCollection.Count; i++)
            {
                if (SumVl.Ticks < ValuesCollection[i].Ticks)
                {
                    SumVl = ValuesCollection[i];
                }
            }

            return SumVl;
        }

        public DateTime MinDate(List<DateTime> ValuesCollection)
        {
            DateTime SumVl = ValuesCollection[0];

            for (int i = 1; i < ValuesCollection.Count; i++)
            {
                if (SumVl.Ticks > ValuesCollection[i].Ticks)
                {
                    SumVl = ValuesCollection[i];
                }
            }

            return SumVl;
        }



        public void OperationsNumerico(List<object> CellsCollection)
        {
            MnAvg.Text = "Avg: " + Average((from Values in CellsCollection
                                            select double.Parse(((UltraGridCell)Values).Text)).ToList()).ToString();

            MnSoma.Text = "Sum: " + Sum((from Values in CellsCollection
                                         select double.Parse(((UltraGridCell)Values).Text)).ToList()).ToString();

            MnMax.Text = "Max: " + Max((from Values in CellsCollection
                                        select double.Parse(((UltraGridCell)Values).Text)).ToList()).ToString();

            MnMin.Text = "Min: " + Min((from Values in CellsCollection
                                        select double.Parse(((UltraGridCell)Values).Text)).ToList()).ToString();

            MnCont.Text = "Count: " + CellsCollection.Count();

            label1.Text = MnSoma.Text;

        }

        public void OperationString(List<object> CellsCollection)
        {
            MnAvg.Visible = false;

            MnSoma.Visible = false;

            MnMax.Visible = false;

            MnMin.Visible = false;

            MnCont.Text = "Count: " + CellsCollection.Count();

            label1.Text = MnCont.Text;

        }

        public void OperationBoolean(List<object> CellsCollection)
        {
            var VlSum = Sum((from Values in CellsCollection
                             select bool.Parse(((UltraGridCell)Values).Text) == true ? 1.0 : 0).ToList());

            MnAvg.Text = "True: " + VlSum;

            MnSoma.Text = "False: " + Math.Abs(CellsCollection.Count() - VlSum);

            MnCont.Text = "Count: " + CellsCollection.Count();

            MnMax.Visible = false;

            MnMin.Visible = false;

            label1.Text = MnCont.Text;

        }

        public void OperationDate(List<object> CellsCollection)
        {
            var LDates = new List<DateTime>();
            foreach (UltraGridCell cell in CellsCollection)
            {
                LDates.Add(DateTime.Parse(cell.Text));
            }

            MnAvg.Visible = false;

            MnSoma.Visible = false;

            MnCont.Text = "Count: " + CellsCollection.Count();

            MnMax.Text = "Max: " + MaxDate(LDates).ToShortDateString();

            MnMin.Text = "Min: " + MinDate(LDates).ToShortDateString();

            label1.Text = MnCont.Text;

        }

    }
}