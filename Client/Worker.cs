using System.Threading;

namespace Client
{ 
    /// <summary>
    /// Abstract thread class
    /// </summary>
    public class Worker
    {
        /// <summary>
        /// Thread
        /// </summary>
        protected Thread _t;
        /// <summary>
        /// Name of the thread
        /// </summary>
        public string Name { get { return _t.Name; } set { _t.Name = value; } }
        /// <summary>
        /// Priority of the thread
        /// </summary>
        public ThreadPriority Priority { get { return _t.Priority; } set { _t.Priority = value; } }
        /// <summary>
        /// Indicates if thethread is still alive
        /// </summary>
        public bool IsAlive { get { return _t.IsAlive; } }
        /// <summary>
        /// Indicates if the thread should end (not used here)
        /// </summary>
        protected bool _end;
        /// <summary>
        /// Process identifier of the thread
        /// </summary>
        public int PID { get { return _t.ManagedThreadId; } }

        /// <summary>
        /// Constructor
        /// </summary>
        public Worker()
        {
            _t = new Thread(doWork);
        }
        /// <summary>
        /// Virtual method to do the work of the thread
        /// </summary>
        protected virtual void doWork() { }
        /// <summary>
        /// Sarts the thread
        /// </summary>
        public void Start() { _t.Start(); }
        /// <summary>
        /// Abort the thread
        /// </summary>
        public virtual void Abort() { _t.Abort(); }
        /// <summary>
        /// Waits until the thread ends
        /// </summary>
        public void Join() { _t.Join(); }
        /// <summary>
        /// frees the execution of the thread if it is blocked
        /// </summary>
        public void Interrupt() { _t.Interrupt(); }
        /// <summary>
        /// Stops the execution of the thread
        /// </summary>
        public virtual void Stop()
        {
            _end = true;
            Interrupt();
        }
    }
}
