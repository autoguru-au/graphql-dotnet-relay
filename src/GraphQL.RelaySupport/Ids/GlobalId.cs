namespace GraphQL
{
    public abstract class GlobalId<TId>
    {
        public string ParsedValue { get; }

        public TId Id { get; }

        public GlobalId(string value, TId id)
        {
            ParsedValue = value;
            Id = id;
        }
    }
}
