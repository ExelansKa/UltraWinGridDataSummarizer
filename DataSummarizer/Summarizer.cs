using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using Infragistics.Win.UltraWinGrid;

namespace DataSummarizer
{
    public class Summarizer
    {
        public enum Operations
        {
            sum,
            max,
            min,
            avg,
            maxDt,
            minDt,
            count,
            False,
            True,
            NonNull,
            dft
        }

        public UltraGrid RelatedGrid { get; private set; }

        public Control DisplayControl { get; private set; }

        public List<ColsOperations> OperationsByCols { get; private set; }

        public ContextMenuStrip MyMenuStrip { get; set; } = new ContextMenuStrip();

        public List<Exception> exceptions { get; private set; } = new List<Exception>();



        public Summarizer(UltraGrid relatedGrid,
                          Control displayControl)
        {
            this.RelatedGrid = relatedGrid;
            this.DisplayControl = displayControl;
            AddEvent();
            this.OperationsByCols = BuildDefaultColsOperations();
        }

        public Summarizer(UltraGrid relatedGrid,
                          Control displayControl,
                          List<string> fields)
        {
            this.RelatedGrid = relatedGrid;
            this.DisplayControl = displayControl;
            AddEvent();
            this.OperationsByCols = BuildDefaultColsOperations(fields);
        }

        public Summarizer(UltraGrid relatedGrid,
                          Control displayControl,
                          List<String> fields,
                          List<Operations> nonAvaibleOperations)
        {
            this.RelatedGrid = relatedGrid;
            this.DisplayControl = displayControl;
            AddEvent();
            this.OperationsByCols = BuildDefaultColsOperations(fields, nonAvaibleOperations);
        }

        public Summarizer(UltraGrid relatedGrid,
                          Control displayControl,
                          List<ColsOperations> operationsByColumns)
        {
            this.RelatedGrid = relatedGrid;
            this.DisplayControl = displayControl;
            this.OperationsByCols = operationsByColumns;
            AddEvent();
        }


        private List<ColsOperations> BuildDefaultColsOperations(List<string> FieldsToConsidier = null, List<Operations> NonAvaliableOperations = null)
        {
            try
            {
                var GridColumns = RelatedGrid.DisplayLayout.Bands[0].Columns;
                var colsOperation = new List<ColsOperations>();

                foreach (UltraGridColumn Col in GridColumns)
                {
                    var ColCase = new ColsOperations();
                    if (FieldsToConsidier == null)
                    {
                        ColCase.ColName = Col.Key;
                        ColCase.TypeName = Col.DataType.ToString();
                    }


                    if (FieldsToConsidier != null && FieldsToConsidier.Contains(Col.Key.ToString()))
                    {
                        ColCase.ColName = Col.Key;
                        ColCase.TypeName = Col.DataType.ToString();
                    }

                    if (NonAvaliableOperations == null)
                    {
                        ColCase.AvaliableOperations = new DefaultOperations().GetListByType(Col.DataType.ToString());
                    }

                    if (NonAvaliableOperations != null)
                    {
                        var LstOp = new DefaultOperations().GetListByType(Col.DataType.ToString());
                        foreach (Operations Op in NonAvaliableOperations)
                        {
                            LstOp.Remove(Op);
                        }
                        ColCase.AvaliableOperations = LstOp;
                    }
                    colsOperation.Add(ColCase);
                    colsOperation = colsOperation.Where(Op => Op.ColName != null).ToList();
                }
                return colsOperation;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void SelecionOfCells()
        {
            try
            {
                if (RelatedGrid.Selected.Cells.Count > 1)
                {
                    var SelectedCells = RelatedGrid.Selected.Cells.All.ToList();
                    if (IsAlowedColumn())
                    {
                        GetPredominantType(OperationsByCols, SelectedCells);
                    }
                }
            }
            catch(Exception ex)
            {
                MyMenuStrip.Items.Clear();
                DisplayControl.Text = "Error";
                exceptions.Add(ex);
            }
        }

        private void CalcByModel(List<Operations> operations, List<object> CellsCollection)
        {
            try
            {
                var NonNullCellsCollection = GetNonNullValues(CellsCollection);
                foreach (Operations op in operations)
                {
                    switch (op)
                    {
                        case Operations.avg:
                            MyMenuStrip.Items.Add("AVG: " + Calculator.Average((from Values in NonNullCellsCollection
                                                                                select double.Parse(((UltraGridCell)Values).Text)).ToList()).ToString());
                            break;

                        case Operations.max:
                            MyMenuStrip.Items.Add("MAX: " + Calculator.Max((from Values in NonNullCellsCollection
                                                                            select double.Parse(((UltraGridCell)Values).Text)).ToList()).ToString());
                            break;


                        case Operations.maxDt:
                            MyMenuStrip.Items.Add("MAX: " + Calculator.MaxDate(GetListDate(NonNullCellsCollection)).ToShortDateString());
                            break;


                        case Operations.min:
                            MyMenuStrip.Items.Add("MIN: " + Calculator.Min((from Values in NonNullCellsCollection
                                                                            select double.Parse(((UltraGridCell)Values).Text)).ToList()).ToString());
                            break;

                        case Operations.minDt:
                            MyMenuStrip.Items.Add("MIN: " + Calculator.MinDate(GetListDate(NonNullCellsCollection)).ToShortDateString());
                            break;


                        case Operations.sum:
                            MyMenuStrip.Items.Add("SUM: " + Calculator.Sum((from Values in NonNullCellsCollection
                                                                            select double.Parse(((UltraGridCell)Values).Text)).ToList()).ToString());
                            break;

                        case Operations.count:
                            MyMenuStrip.Items.Add("COUNT: " + CellsCollection.Count().ToString());
                            break;

                        case Operations.True:
                            MyMenuStrip.Items.Add("TRUE: " + NonNullCellsCollection.Where(C => (bool)((UltraGridCell)C).Value == true).Count().ToString());
                            break;

                        case Operations.False:
                            MyMenuStrip.Items.Add("FALSE: " + NonNullCellsCollection.Where(C => (bool)((UltraGridCell)C).Value == false).Count().ToString());
                            break;

                        case Operations.NonNull:
                            MyMenuStrip.Items.Add("NONNULL: " + NonNullCellsCollection.Count().ToString());
                            break;
                    }
                }

                if(MyMenuStrip.Items.Count > 0) DisplayControl.Text = MyMenuStrip.Items[0].Text;
            }
            catch(Exception ex)
            {
                DisplayControl.Text = "Invalid Operation";
                exceptions.Add(ex);
            }
        }

        private void GetPredominantType(List<ColsOperations> Operations, List<object> CellsCollection)
        {
            var OpeCols = (from Op in Operations
                           join Tp in CellsCollection.Select(Cell => ((UltraGridCell)Cell).Column.Key.ToString()).Distinct().ToList()
                           on Op.ColName equals Tp
                           select Op).ToList();

            var OperationsFinal = OpeCols[0].AvaliableOperations;
            if (OpeCols.Count > 1)
            {
                var Pass = new List<Operations>();
                foreach (ColsOperations LstOp in OpeCols)
                {
                     Pass = OperationsFinal.Intersect(LstOp.AvaliableOperations).ToList();
                }
                OperationsFinal = Pass;
            }

            CalcByModel(OperationsFinal, CellsCollection);
        }

        private bool IsAlowedColumn()
        {
            var Selected = RelatedGrid.Selected.Cells.All.Select(C => ((UltraGridCell)C).Column.Key.ToString()).Distinct().ToList();
            var AlowedValues = OperationsByCols.Where(Op => Selected.Any(Sl => Sl.Contains(Op.ColName))).ToList();
            if (AlowedValues.Count == Selected.Count())
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private List<DateTime> GetListDate(List<object> CellsCollection)
        {
            var LDates = new List<DateTime>();
            foreach (UltraGridCell cell in CellsCollection)
            {
                LDates.Add(DateTime.Parse(cell.Text));
            }

            return LDates;

        }
         
        private List<object> GetNonNullValues(List<object> CellsCollection)
        {
            var FinalList = new List<object>();
            foreach (object Obj in CellsCollection)
            {
                if (((UltraGridCell)Obj).Value.ToString().Length > 0)
                {
                    FinalList.Add(Obj);
                }
            }

            return FinalList;
        }


        private void AddEvent()
        {
            try
            {
                DisplayControl.Visible = false;
                DisplayControl.Click += DisplayControl_Click;
                RelatedGrid.MouseUp += Ugv_MouseUp;
                RelatedGrid.AfterSelectChange += RelatedGrid_AfterSelectChange;
                RelatedGrid.BeforeSelectChange += RelatedGrid_BeforeSelectChange;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void RelatedGrid_BeforeSelectChange(object sender, BeforeSelectChangeEventArgs e)
        {
            MyMenuStrip.Items.Clear();
            DisplayControl.Text = "";
        }

        private void RelatedGrid_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            if (RelatedGrid.Selected.Cells.Count < 2)
            {
                DisplayControl.Text = "";
                DisplayControl.Visible = false;
            }
            else
            {
                DisplayControl.Visible = true;
            }
        }

        private void DisplayControl_Click(object sender, EventArgs e)
        {
            MyMenuStrip.ShowImageMargin = false;
            MyMenuStrip.Visible = true;
            MyMenuStrip.Show(DisplayControl, 0, -(MyMenuStrip.Height));
        }

        private void Ugv_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            SelecionOfCells();
        }
    }
}
