using System;
using System.Collections.Generic;
using System.Linq;

namespace WinFExcel
{
    class OperationsDefault
    {

        public static List<DataSummarizer.Operations> GetDefaultStringOperations()
        {
            return new List<DataSummarizer.Operations>()
                    {
                        DataSummarizer.Operations.count,
                        DataSummarizer.Operations.NonNull
                    };
        }

        public static List<DataSummarizer.Operations> GetDefaultNumericosOperations()
        {
            return new List<DataSummarizer.Operations>()
                    {
                        DataSummarizer.Operations.sum,
                        DataSummarizer.Operations.avg,
                        DataSummarizer.Operations.count,
                        DataSummarizer.Operations.max,
                        DataSummarizer.Operations.min,
                        DataSummarizer.Operations.NonNull
                    };
        }

        public static List<DataSummarizer.Operations> GetDefaultBooleanOperations()
        {
            return new List<DataSummarizer.Operations>()
                    {
                        DataSummarizer.Operations.True,
                        DataSummarizer.Operations.count,
                        DataSummarizer.Operations.False,
                        DataSummarizer.Operations.NonNull
                    };
        }

        public static List<DataSummarizer.Operations> GetDefaultDateOperations()
        {
            return new List<DataSummarizer.Operations>()
                    {
                        DataSummarizer.Operations.maxDt,
                        DataSummarizer.Operations.minDt,
                        DataSummarizer.Operations.count,
                        DataSummarizer.Operations.NonNull
                    };
        }


    }
}
