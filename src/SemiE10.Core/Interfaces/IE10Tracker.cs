using static SemiE10.Core.Enums.SysEnums;
using SemiE10.Core.Models;

namespace SemiE10.Core.Interfaces
{
    public interface IE10Tracker
    {
        // 屬性
        MachineState CurrentMachineState { get; }
        E10State CurrentE10State { get; }
        OperationMode CurrentMode { get; }

        // 事件   
        event EventHandler<StateChangedEventArgs>? OnStateChanged;
        event EventHandler? OnTimeUpdated;

        // 方法
        bool TryChangeState(MachineState newState, string reason = "");
        bool TryChangeMode(OperationMode newMode);

        double CaculateUtilization();
        double CaculateAvailability();
        double GetStateAccumulatedSeconds(E10State targetState);
    }
}
