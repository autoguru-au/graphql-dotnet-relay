using System;

namespace GraphQL
{
    public class GuidGlobalId : GlobalId<Guid>
    {
        public GuidGlobalId(string value)
            : base(value, GlobalIdParser.GetGuidIdFromValue(value))
        {

        }

        public GuidGlobalId(Guid value)
            : base(value.ToString(), value)
        {

        }
    }
}
