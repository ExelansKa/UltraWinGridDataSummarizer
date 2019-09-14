using System;
using System.Collections.Generic;

namespace DataSummarizer
{
    internal class Calculator
    {

        public static double Average(List<double> ValuesCollection)
        {
            double FinalAvg = 0;

            foreach (double cell in ValuesCollection)
            {
                FinalAvg += cell;
            }

            return Math.Round((FinalAvg) / ValuesCollection.Count, 2);
        }

        public static double Sum(List<double> ValuesCollection)
        {
            double FinalSum = 0;

            foreach (double cell in ValuesCollection)
            {
                FinalSum += cell;
            }

            return FinalSum;
        }

        public static double Max(List<double> ValuesCollection)
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

        public static double Min(List<double> ValuesCollection)
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

        public static DateTime MaxDate(List<DateTime> ValuesCollection)
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

        public static DateTime MinDate(List<DateTime> ValuesCollection)
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
    }
}
