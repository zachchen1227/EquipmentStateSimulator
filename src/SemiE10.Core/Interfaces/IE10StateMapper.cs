using static SemiE10.Core.Enums.SysEnums;   

namespace SemiE10.Core.Interfaces
{
    public interface IE10StateMapper
    {
        // 透過機台狀態和操作模式來獲取對應的E10狀態
        E10State GetE10State(MachineState machineState, OperationMode operationMode);       
    }
}
