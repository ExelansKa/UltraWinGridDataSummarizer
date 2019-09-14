namespace DataSummarizer
{
    class TypeRelevance
    {
        public string TypeName { get; set; }
        public int RelevanceIndex { get; set; }

        public TypeRelevance(string typeName, int relevanceName)
        {
            TypeName = typeName;
            RelevanceIndex = relevanceName;
        }
    }
}
