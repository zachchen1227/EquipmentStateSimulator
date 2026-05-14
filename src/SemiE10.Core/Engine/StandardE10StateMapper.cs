using SemiE10.Core.Interfaces;
using static SemiE10.Core.Enums.SysEnums;

namespace SemiE10.Core.Engine
{
    public class StandardE10StateMapper: IE10StateMapper
    {

        private readonly Dictionary<(MachineState, OperationMode), E10State> _mapping;

        public StandardE10StateMapper()
        {
            // 初始化對應規則
            _mapping = [];

            // 建立對應規則
            InitializeRules();
        }

        // 建立對應規則
        private void InitializeRules()
        {
            // 定義MachineState和OperationMode的組合對應到E10State的規則
            // 後續可以讀檔或從資料庫載入這些規則，這裡先硬編碼示例

            // Offline
            _mapping[(MachineState.Offline, OperationMode.Production)] = E10State.UnscheduledDownTime;
            _mapping[(MachineState.Offline, OperationMode.Engineering)] = E10State.Engineering;
            _mapping[(MachineState.Offline, OperationMode.Maintenance)] = E10State.UnscheduledDownTime;

            // Initializing
            _mapping[(MachineState.Initializing, OperationMode.Production)] = E10State.Standby;
            _mapping[(MachineState.Initializing, OperationMode.Engineering)] = E10State.Engineering;
            _mapping[(MachineState.Initializing, OperationMode.Maintenance)] = E10State.ScheduledDownTime;

            // Idle
            _mapping[(MachineState.Idle, OperationMode.Production)] = E10State.Standby;
            _mapping[(MachineState.Idle, OperationMode.Engineering)] = E10State.Engineering;
            _mapping[(MachineState.Idle, OperationMode.Maintenance)] = E10State.ScheduledDownTime;


            // Running  
            _mapping[(MachineState.Running, OperationMode.Production)] = E10State.Productive;
            _mapping[(MachineState.Running, OperationMode.Engineering)] = E10State.Engineering;
            _mapping[(MachineState.Running, OperationMode.Maintenance)] = E10State.ScheduledDownTime;


            // Paused
            _mapping[(MachineState.Paused, OperationMode.Production)] = E10State.Standby;
            _mapping[(MachineState.Paused, OperationMode.Engineering)] = E10State.Engineering;
            _mapping[(MachineState.Paused, OperationMode.Maintenance)] = E10State.ScheduledDownTime;


            // Alarm
            _mapping[(MachineState.Alarm, OperationMode.Production)] = E10State.UnscheduledDownTime;
            _mapping[(MachineState.Alarm, OperationMode.Engineering)] = E10State.Engineering;
            _mapping[(MachineState.Alarm, OperationMode.Maintenance)] = E10State.UnscheduledDownTime;

        }

        // 根據MachineState和OperationMode來決定E10State
        public E10State GetE10State(MachineState machineState, OperationMode operationMode)
        {
            // 1. 先判斷否為Alarm狀態，因為Alarm狀態優先於其他狀態
            if (machineState == MachineState.Alarm)
                return E10State.UnscheduledDownTime;

            // 2. 根據MachineState和OperationMode的組合來決定E10State
            if(_mapping.TryGetValue((machineState, operationMode), out var e10State))
            {
                return e10State;
            }
            else
            {
                throw new KeyNotFoundException($"無法識別的狀態組合: MachineState={machineState}, OperationMode={operationMode}。請檢查 MappingTable 設定。");
            }
         
        }

    }
}
