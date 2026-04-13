using static SemiE10.Core.Enums.SysEnums;

namespace SemiE10.Core.Models
{
    public class StateChangedEventArgs: EventArgs
    {
        public MachineState OldMachineState { get; }
        public MachineState NewMachineState { get; }
        public E10State NewE10State { get; }

        public StateChangedEventArgs(MachineState oldMachineState, MachineState newMachineState, E10State newE10State)
        {
            OldMachineState = oldMachineState;
            NewMachineState = newMachineState;
            NewE10State = newE10State;
        }
    }
}
