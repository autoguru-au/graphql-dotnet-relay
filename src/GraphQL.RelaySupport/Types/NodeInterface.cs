namespace GraphQL.Types
{
    public class NodeInterface : InterfaceGraphType
    {
        public NodeInterface()
        {
            Name = "Node";
            Description = "An object with an ID.";

            Field<IdGraphType>("id", "ID of the object.");
        }
    }
}
