namespace PleaseBehave.Decorators
{
    /// <summary>
    /// Repeatedly updates its child as long as Repetions are above 0 or LoopForever is true.
    /// </summary>
    public class Repeater : DecoratorNode
    {
        private uint? _repetitions;
        private bool _loopForever;

        public uint? Repetitions
        {
            get { return _repetitions; }
            set
            {
                _repetitions = value;
                LoopForever = false;
            }
        }

        public bool LoopForever
        {
            get { return _loopForever; }
            set
            {
                _loopForever = value;
                if (value)
                {
                    _repetitions = null;
                }
            }
        }

        /// <summary>
        /// Returns a new Repeater that runs forever.
        /// </summary>
        public Repeater()
        {
            LoopForever = true;
        }
        
        /// <summary>
        /// Returns a new Repeater that will run for a number of repetitions.
        /// </summary>
        /// <param name="repetitions"></param>
        public Repeater(uint repetitions)
        {
            Repetitions = repetitions;
        }

        public override NodeStatus Update()
        {
            var result = NodeStatus.Running;

            if (_repetitions != null && _repetitions > 0)
            {
                while (_repetitions > 0)
                {
                    result = Child.Update();
                    _repetitions--;
                }
            }
            else
            {
                while (_loopForever)
                {
                    result = Child.Update();
                }
            }
            return result;
        }
    }
}
