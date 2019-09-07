using System;
using System.Collections.Generic;
using System.Linq;

namespace DataSummarizer
{
    internal class DefaultOperations
    {

        public static List<Summarizer.Operations> GetDefaultStringOperations()
        {
            return new List<Summarizer.Operations>()
                    {
                        Summarizer.Operations.count,
                        Summarizer.Operations.NonNull
                    };
        }

        public static List<Summarizer.Operations> GetDefaultNumericosOperations()
        {
            return new List<Summarizer.Operations>()
                    {
                        Summarizer.Operations.sum,
                        Summarizer.Operations.avg,
                        Summarizer.Operations.count,
                        Summarizer.Operations.max,
                        Summarizer.Operations.min,
                        Summarizer.Operations.NonNull
                    };
        }

        public static List<Summarizer.Operations> GetDefaultBooleanOperations()
        {
            return new List<Summarizer.Operations>()
                    {
                        Summarizer.Operations.True,
                        Summarizer.Operations.count,
                        Summarizer.Operations.False,
                        Summarizer.Operations.NonNull
                    };
        }

        public static List<Summarizer.Operations> GetDefaultDateOperations()
        {
            return new List<Summarizer.Operations>()
                    {
                        Summarizer.Operations.maxDt,
                        Summarizer.Operations.minDt,
                        Summarizer.Operations.count,
                        Summarizer.Operations.NonNull
                    };
        }


    }
}
