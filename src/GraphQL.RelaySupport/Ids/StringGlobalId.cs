namespace GraphQL
{
    public class StringGlobalId : GlobalId<string>
    {
        public StringGlobalId(string value)
            : base(value, GlobalIdParser.GetStringIdFromValue(value))
        {

        }
    }
}
