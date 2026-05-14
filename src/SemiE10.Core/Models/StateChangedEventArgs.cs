using static SemiE10.Core.Enums.SysEnums;

namespace SemiE10.Core.Models
{
    // 當機台狀態改變時的事件參數，包含舊狀態、新狀態、對應的E10狀態以及改變的時間戳
    public class StateChangedEventArgs(
        MachineState oldMachineState,
        MachineState newMachineState,
        E10State newE10State, 
        DateTime timestamp) : EventArgs
    {
        public MachineState OldMachineState { get; } = oldMachineState;
        public MachineState NewMachineState { get; } = newMachineState;
        public E10State NewE10State { get; } = newE10State;
        public DateTime Timestamp { get; } = timestamp;
    }
}
