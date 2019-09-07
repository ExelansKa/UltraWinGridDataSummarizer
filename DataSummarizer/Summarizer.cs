using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using Infragistics.Win.UltraWinGrid;


namespace DataSummarizer
{
    class Summarizer
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

        public List<String> FieldsToConsidier { get; private set; }

        public Control DisplayControl { get; private set; }

        public List<Operations> AvailableOperations { get; private set; }

        public List<ColsOperations> OperationsByCols { get; private set; }

        public ContextMenuStrip MyMenuStrip { get; set; } = new ContextMenuStrip();

        //COISAS QUE ESTÃO FALTANDO AQUI: 
        //UM SUMÁRIO DE TIPO OPERAÇÃO ONDE O TIPO COM MAIS OPERAÇÕES É O MENOS PREDOMINANTE
        //UM RELACIONADOR QUE DIGA PARA CADA TIPO QUAL CARA MOSTRAR COMO MAIN INFO
        // A CLASSE DE MANIPULADOR DE EVENTOS PODE SERVIR MUITO BEM SE EU QUISER PASSAR O EVENTO PARA QUALQUER N BOTÃO



        public Summarizer(UltraGrid relatedGrid,
                          Control displayControl)
        {
            this.RelatedGrid = relatedGrid;
            this.DisplayControl = displayControl;
            AddEvent();
        }

        public Summarizer(UltraGrid relatedGrid,
                          List<String> fields)
        {
            this.RelatedGrid = relatedGrid;
            this.FieldsToConsidier = fields;
            AddEvent();
        }

        public Summarizer(UltraGrid relatedGrid,
                          List<String> fields,
                          List<Operations> avaibleOperations)
        {
            this.RelatedGrid = relatedGrid;
            this.FieldsToConsidier = fields;
            this.AvailableOperations = avaibleOperations;
            AddEvent();
        }

        public Summarizer(UltraGrid relatedGrid,
                          List<ColsOperations> operationsByColumns)
        {
            this.RelatedGrid = relatedGrid;
            this.OperationsByCols = operationsByColumns;
            this.FieldsToConsidier = GetColumnsInModel(OperationsByCols);
            AddEvent();
        }



        private void SelecionOfCells()
        {
            if (RelatedGrid.Selected.Cells.Count > 1)
            {
                var SelectedCells = RelatedGrid.Selected.Cells.All.ToList();
                Type TipoRegente = ((UltraGridCell)SelectedCells[0]).Column.DataType;
                Boolean TiposIguais = SelectedCells.All(C => ((UltraGridCell)C).Column.DataType == TipoRegente);

                if (TiposIguais)
                {
                    var ValuesRange = ValidatingValueRange(SelectedCells);
                    CalcByDataType(ValuesRange);
                }
            }

        }

        private List<object> ValidatingValueRange(List<object> SelectedCells)
        {

            var ColumnsName = SelectedCells.Select(C => ((UltraGridCell)C).Column.Key).Distinct().ToList();

            if (FieldsToConsidier != null)
            {
                var ValidFields = FieldsToConsidier.Where
                    (
                         SelCols => ColumnsName.Contains(SelCols)
                    );

                if (ColumnsName.Count() == ValidFields.Count())
                {
                    return SelectedCells;
                }

            }
            else if (FieldsToConsidier is null)
            {
                return SelectedCells;
            }

            return null;
        }

        private void CalcByDataType(List<object> CellsCollection)
        {
            //TODO: usar eventos para não usar isso:
            MyMenuStrip.Items.Clear();

            switch (((UltraGridCell)CellsCollection[0]).Column.DataType.ToString())
            {

                case "System.Decimal":
                    CalcByModel(OperationsDefault.GetDefaultNumericosOperations(), CellsCollection);
                    break;


                case "System.String":
                    CalcByModel(OperationsDefault.GetDefaultStringOperations(), CellsCollection);
                    break;


                case "System.Int32":
                    CalcByModel(OperationsDefault.GetDefaultNumericosOperations(), CellsCollection);
                    break;


                case "System.Boolean":
                    CalcByModel(OperationsDefault.GetDefaultBooleanOperations(), CellsCollection);
                    break;


                case "System.DateTime":
                    CalcByModel(OperationsDefault.GetDefaultDateOperations(), CellsCollection);
                    break;

            }
        }

        private void CalcByModel(List<Operations> operations, List<object> CellsCollection)
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

            DisplayControl.Text = MyMenuStrip.Items[0].Text;
        }



        private List<string> GetColumnsInModel(List<ColsOperations> ModelCollection)
        {
            var LstColsName = new List<string>();
            foreach (ColsOperations Col in ModelCollection)
            {
                LstColsName.Add(Col.ColName);
            }

            return LstColsName;
        }

        public List<DateTime> GetListDate(List<object> CellsCollection)
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
            DisplayControl.Click += DisplayControl_Click;
            RelatedGrid.MouseUp += Ugv_MouseUp;
        }

        private void DisplayControl_Click(object sender, EventArgs e)
        {
            MyMenuStrip.Visible = true;
        }

        private void Ugv_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            SelecionOfCells();
        }
    }
}
