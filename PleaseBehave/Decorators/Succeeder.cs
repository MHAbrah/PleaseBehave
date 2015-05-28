using System;

namespace PleaseBehave.Decorators
{
    /// <summary>
    /// Succeeds even if the child node fails. Treats NodeStatus.Running normally.
    /// </summary>
    public class Succeeder : DecoratorNode
    {
        /// <summary>
        /// Treats its child's failure as success.
        /// </summary>
        /// <returns>NodeStatus.Success on child success, same with child failure.
        /// Running if child returns running.</returns>
        public override NodeStatus Update()
        {
            var childStatus = Child.Update();
            switch (childStatus)
            {
                case NodeStatus.Success:
                    return NodeStatus.Success;
                case NodeStatus.Failure:
                    return NodeStatus.Success;
                case NodeStatus.Running:
                    return NodeStatus.Running;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
