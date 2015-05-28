using System.Collections.Generic;

namespace PleaseBehave
{
    public enum NodeStatus
    {
        Success,
        Failure,
        Running
    }

    public abstract class Node
    {
        public abstract NodeStatus Update();
    }

    public abstract class CompositeNode : Node, IResetable
    {
        public int Currentchild { get; protected set; }
        public IList<Node> Children;
        public void Reset()
        {
            Currentchild = 0;
        }
    }

    public abstract class DecoratorNode : Node
    {
        public Node Child { get; set; }
    }
}
