namespace GraphQL
{
    public class IntGlobalId : GlobalId<int>
    {
        public IntGlobalId(string value)
            : base(value, GlobalIdParser.GetIntIdFromValue(value))
        {

        }

        public IntGlobalId(int value)
            : base(value.ToString(), value)
        {

        }
    }
}
