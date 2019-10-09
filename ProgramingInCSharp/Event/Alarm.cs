using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ProgramingInCSharp.Event
{
    class Alarm
    {
        /// <summary>
        /// public Action OnAlarmRaised { get; set; }
        /// 
        /// </summary>
        //public event Action OnAlarmRaised = delegate { };
        public event EventHandler<AlarmEventArgs> OnAlarmRaised = delegate { };


        /// <summary>
        /// if (OnAlarmRaised != null) this.OnAlarmRaised();
        /// OnAlarmRaised?.Invoke();
        /// OnAlarmRaised(this, new AlarmEventArgs(location));
        /// </summary>
        /// <exception cref="TargetException"></exception>
        public void RaiseAlarm(string location)
        {
            List<Exception> exceptionList = new List<Exception>();
            foreach (Delegate handler in OnAlarmRaised.GetInvocationList())
            {
                try
                {
                    handler.DynamicInvoke(this, new AlarmEventArgs(location));
                }
                catch (TargetInvocationException e)
                {
                    exceptionList.Add(e.InnerException);
                }
            }

            if (exceptionList.Count > 0)
                throw new AggregateException(exceptionList);
        }
    }
}
