using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemiE10.Core.Enums
{
    public class SysEnums
    {
        /// <summary>
        /// 機台狀態:離線、初始化、空閒、運行中、暫停和報警
        /// </summary>
        public enum MachineState 
        { 
            Offline = 0,
            Initializing = 1,
            Idle = 2,
            Running = 3,
            Paused = 4,
            Alarm = 5   
        }

        /// <summary>
        /// 機台操作模式: 生產、工程和維護
        /// </summary>
        public enum OperationMode
        {
            Production = 0,
            Engineering = 1,
            Maintenance = 2
        }

        /// <summary>
        /// E10狀態: 生產、待機、工程、計劃停機、非計劃停機和非排定停機    
        /// </summary>
        public enum E10State
        {
            Productive = 0,
            Standby = 1,
            Engineering = 2,
            ScheduledDownTime = 3,
            UnscheduledDownTime = 4,
            NonScheduledDownTime = 5
        }

    }
}
