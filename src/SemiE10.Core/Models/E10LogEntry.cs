using static SemiE10.Core.Enums.SysEnums;

namespace SemiE10.Core.Enums
{
    public class E10LogEntry
    {
        public DateTime TimeStamp { get; set; }
        public MachineState OldMachineState { get; set; }
        public MachineState NewMachineState { get; set; }
        public OperationMode Mode { get; set; }
        public E10State E10State { get; set; }
        public string Reason { get; set; } = string.Empty;
    }
}
