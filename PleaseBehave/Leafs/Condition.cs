using System;

namespace PleaseBehave.Leafs
{
    public class Condition : Node
    {
        private readonly Func<bool> _conditionFunc;

        public Condition(Func<bool> conditionFunc )
        {
            _conditionFunc = conditionFunc;
        }

        /// <summary>
        /// Call the supplied Func.
        /// </summary>
        /// <returns>NodeStatus.Success if the Func returns true,
        ///  NodeStatus.Failure if the func returns false.</returns>
        public override NodeStatus Update()
        {
            var result = _conditionFunc();
            switch (result)
            {
                case true:
                    return NodeStatus.Success;
                case false:
                    return NodeStatus.Failure;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}