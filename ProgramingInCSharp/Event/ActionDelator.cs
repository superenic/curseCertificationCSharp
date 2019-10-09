using ProgramingInCSharp.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramingInCSharp.Event
{
    public class ActionDelegator: ICommand
    {
        public string Description => "Execute 2 alarms";

        // Method that must run when the alarm is raised
        public static void AlarmListener1(object sender, AlarmEventArgs e)
        {
            Console.WriteLine("Alarm listener 1 {0}", e.Location);
            throw new Exception("Bang");
        }

        // Method that must run when the alarm is raised
        public static void AlarmListener2(object sender, AlarmEventArgs e)
        {
            Console.WriteLine("Alarm listener 2 {0}", e.Location);
            throw new Exception("Beng");
        }

        public void StartCommand()
        {
            // Create a new alarm
            Alarm alarm = new Alarm();

            // Connect the two listener methods
            alarm.OnAlarmRaised += AlarmListener1;
            alarm.OnAlarmRaised += AlarmListener2;
            // Attribute event avoid property change to null, only can remove method on deletation.
            //alarm.OnAlarmRaised = null;

            try
            {
                alarm.RaiseAlarm("este es la n");
            }
            catch(AggregateException agg)
            {
                foreach (Exception ex in agg.InnerExceptions)
                    Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Alarm raised");

            Console.ReadKey();
        }
    }
}
