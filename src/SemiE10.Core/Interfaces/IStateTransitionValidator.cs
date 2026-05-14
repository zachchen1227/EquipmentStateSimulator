using static SemiE10.Core.Enums.SysEnums;   

namespace SemiE10.Core.Interfaces
{
    public interface IStateTransitionValidator
    {
        bool IsVaild(MachineState currentState, MachineState newState);
    }
}
