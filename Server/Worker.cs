using System.Threading;

namespace Server
{
    public abstract class Worker
    {
        /// <summary>
        /// Working thread
        /// </summary>
        private Thread _t;
        /// <summary>
        /// Name of the thread
        /// </summary>
        public string Name { get { return _t.Name; } set { _t.Name = value; } }
        /// <summary>
        /// Priority of the Thread
        /// </summary>
        public ThreadPriority Priority { get { return _t.Priority; } set { _t.Priority = value; } }
        /// <summary>
        /// State of the thread
        /// </summary>
        public bool IsAlive { get { return _t.IsAlive; } }
        /// <summary>
        /// Internal bool to stop the execution
        /// </summary>
        protected bool _endSignal;

        /// <summary>
        /// constructor
        /// </summary>
        public Worker()
        {
            _t = new Thread(doWork);
            _t.Priority = System.Threading.ThreadPriority.Normal;
            _endSignal = false;
        }
        /// <summary>
        /// Function of the thread
        /// </summary>
        protected virtual void doWork() { }
        /// <summary>
        /// Start method
        /// </summary>
        public void Start() { _t.Start(); }
        /// <summary>
        /// Abort method
        /// </summary>
        public void Abort() { _t.Abort(); }
        /// <summary>
        /// Join method
        /// </summary>
        public void Join() { _t.Join(); }
        /// <summary>
        /// Interrupt method
        /// </summary>
		public void Interrupt() { _t.Interrupt(); }
        /// <summary>
        /// Stops the execution
        /// </summary>
        public virtual void Stop() { }
    }
}
