using SemiE10.Core.Interfaces;
using static SemiE10.Core.Enums.SysEnums;   

namespace SemiE10.Core.Engine
{
    public class StandardTransitionValidator: IStateTransitionValidator
    {
        private readonly HashSet<(MachineState, MachineState)> _validTransitions;   

        public StandardTransitionValidator()
        {
            _validTransitions =
            [
                //從Offline轉換成其他狀態
                (MachineState.Offline, MachineState.Initializing),
            
                //從Initializing轉換成其他狀態
                (MachineState.Initializing, MachineState.Offline),
                (MachineState.Initializing, MachineState.Idle),
                (MachineState.Initializing, MachineState.Alarm),

                //從Idle轉換成其他狀態
                (MachineState.Idle, MachineState.Initializing),
                (MachineState.Idle, MachineState.Running),
                (MachineState.Idle, MachineState.Alarm),

                //從Running轉換成其他狀態
                (MachineState.Running, MachineState.Idle),
                (MachineState.Running, MachineState.Paused),
                (MachineState.Running, MachineState.Alarm),

                //從Paused轉換成其他狀態
                (MachineState.Paused, MachineState.Idle),
                (MachineState.Paused, MachineState.Running),
                (MachineState.Paused, MachineState.Alarm),

                //從Alarm轉換成其他狀態            
                (MachineState.Alarm, MachineState.Offline),
                (MachineState.Alarm, MachineState.Idle)
            ];
        }   

        public bool IsVaild(MachineState currentState, MachineState newState)
        {
            // 查表判斷
            return _validTransitions.Contains((currentState, newState));
        }
    }
}
