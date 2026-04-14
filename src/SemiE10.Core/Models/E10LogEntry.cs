using static SemiE10.Core.Enums.SysEnums;

namespace SemiE10.Core.Enums
{
    public class E10LogEntry
    {
        public DateTime TimeStamp { get; set; }
        public MachineState OldState { get; set; }
        public MachineState NewState { get; set; }
        public OperationMode Mode { get; set; }
        public E10State E10MappedState { get; set; }
        public string Reason { get; set; } = string.Empty;
    }
}
