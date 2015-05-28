using System;

namespace PleaseBehave.Composites
{
    /// <summary>
    /// Selector will succeed if any of it's children succeeds.
    /// </summary>
    public class Selector : CompositeNode
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Success if any child succeeds, failure if no childs succeeds
        /// or Running if a child is running</returns>
        public override NodeStatus Update()
        {
            while (Currentchild < Children.Count)
            {
                var childStatus = Children[Currentchild].Update();
                switch (childStatus)
                {
                    case NodeStatus.Success:
                        Currentchild = 0;
                        return NodeStatus.Success;
                    case NodeStatus.Failure:
                        Currentchild++;
                        continue;
                    case NodeStatus.Running:
                        return NodeStatus.Running;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            // All children failed.
            Reset();
            return NodeStatus.Failure;
        }
    }
}
