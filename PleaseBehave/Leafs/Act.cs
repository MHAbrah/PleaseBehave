using System;

namespace PleaseBehave.Leafs
{
    /// <summary>
    /// A Node that does some function until it completes.
    /// </summary>
    public class Act : Node, IResetable
    {
        protected bool Initialized = false;
        protected Action Initialize;
        /// <summary>
        /// Tick should return false while not finished, true when finished.
        /// </summary>
        protected Func<bool> Tick;

        /// <summary>
        /// Creates a new Act that will call the argument Func(bool) 
        /// on each tick after triggered until it retuns true.
        /// </summary>
        /// <param name="act"></param>
        public Act(Func<bool> act)
        {
            Tick = act;
        }

        /// <summary>
        /// Creates a new Act that will call the argument Func(bool) 
        /// on each tick after triggered until it retuns true.
        /// Also takes a initialization action that will be called on first tick after a reset.
        /// </summary>
        /// <param name="act"></param>
        /// <param name="init"></param>
        public Act(Func<bool> act, Action init) : this (act)
        {
            Initialize = init;
        }
        
        /// <summary>
        /// Initializes the node if not already initialized, then processes a one tick.
        /// </summary>
        /// <returns>Nodestatus.Running if the action is unfinished, 
        /// NodeStatus.Success if the action is finished.</returns>
        public override NodeStatus Update()
        {
            if (!Initialized && Initialize != null)
            {
                Initialize();
                Initialized = true;
            }

            var isRunning = Tick != null && !Tick();
            if (isRunning)
            {
                return NodeStatus.Running;
            }
            Reset();
            return NodeStatus.Success;
        }

        /// <summary>
        /// Set Initialized to false.
        /// </summary>
        public void Reset()
        {
            Initialized = false;            
        }
    }
}
