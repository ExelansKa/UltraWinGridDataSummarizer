using System.Collections.Generic;

namespace DataSummarizer
{
    public class ColsOperations
    {
        public string ColName { get; set; }
        public string TypeName { get; set; }
        public List<Summarizer.Operations> AvaliableOperations { get; set; }


        public ColsOperations()
        {

        }

        public ColsOperations(string colName, string typeName)
        {
            ColName = colName;
            TypeName = typeName;
        }

        public ColsOperations(string colName, List<Summarizer.Operations> avaliableOperations)
        {
            ColName = colName;
            AvaliableOperations = avaliableOperations;
        }

        public ColsOperations(string colName, string typeName, List<Summarizer.Operations> avaliableOperations)
        {
            ColName = colName;
            TypeName = typeName;
            AvaliableOperations = avaliableOperations;
        }
    }
}
