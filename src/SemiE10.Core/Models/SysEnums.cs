using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemiE10.Core.Enums
{
    public class SysEnums
    {
        public enum MachineState 
        { 
            Offline = 0,
            Initializing = 1,
            Idle = 2,
            Running = 3,
            Paused = 4,
            Alarm = 5
        }

        public enum OperationMode
        {
            Production = 0,
            Engineering = 1,
            Maintenance = 2
        }

        public enum E10State
        {
            Productive = 0,
            Standby = 1,
            Engineering = 2,
            ScheduleDownTime = 3,
            UnscheduledDownTime = 4,
            NonScheduledDownTime = 5
        }

    }
}
