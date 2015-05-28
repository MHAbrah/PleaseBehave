using System;

namespace PleaseBehave.Decorators
{
    /// <summary>
    /// Inverter takes it's child's NodeStatus and converts Failure to Success and vice versa. 
    /// NodeStatus.Running is not converted.
    /// </summary>
    class Inverter : DecoratorNode
    {
        /// <summary>
        /// Inverts the NodeStatus returned by the child node.
        /// </summary>
        /// <returns>NodeStatus.Success if childnode failed, NodeStatus.Failure if child succeeded,
        /// else NodeStatus.Running.</returns>
        public override NodeStatus Update()
        {
            var childStatus = Child.Update();
            switch (childStatus)
            {
                case NodeStatus.Success:
                    return NodeStatus.Failure;
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
