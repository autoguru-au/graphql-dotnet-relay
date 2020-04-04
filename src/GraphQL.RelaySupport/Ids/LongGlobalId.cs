namespace GraphQL
{
    public class LongGlobalId : GlobalId<long>
    {
        public LongGlobalId(string value)
            : base(value, GlobalIdParser.GetLongIdFromValue(value))
        {

        }

        public LongGlobalId(long value)
            : base(value.ToString(), value)
        {

        }
    }
}
