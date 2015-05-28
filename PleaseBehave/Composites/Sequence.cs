using System;

namespace PleaseBehave.Composites
{
    /// <summary>
    /// Composite that checks the statuses of each of its children. Returns success if all children succeed.
    /// </summary>
    public class Sequence : CompositeNode
    {
        /// <summary>
        /// Update the child nodes.
        /// </summary>
        /// <returns>Success if all nodes return success, running or failure if any child fails or is running.</returns>
        public override NodeStatus Update()
        {
            while (Children != null && Currentchild < Children.Count)
            {
                var childStatus = Children[Currentchild].Update();
                switch (childStatus)
                {
                    case NodeStatus.Success:
                        Currentchild++;
                        continue;
                    case NodeStatus.Failure:
                        Reset();
                        return NodeStatus.Failure;
                    case NodeStatus.Running:
                        return NodeStatus.Running;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            Reset();
            return NodeStatus.Success;
        }
    }
}
