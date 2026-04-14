using SemiE10.Core.Interfaces;
using SemiE10.Core.Models;
using static SemiE10.Core.Enums.SysEnums;

namespace SemiE10.Core.Engine
{
    public class E10Tracker : IE10Tracker
    {
        public MachineState CurrentMachineState { get; private set; }   
        public OperationMode CurrentMode { get; private set; }
        public E10State CurrentE10State { get; private set; }

        //紀錄 6大狀態各自累積的秒數
        private Dictionary<E10State, double> _stateTimers = new Dictionary<E10State, double>();

        //狀態改變與時間更新的廣播事件
        public event EventHandler<StateChangedEventArgs>? OnStateChanged;    
        public event EventHandler? OnTimeUpdated;


        public E10Tracker()
        {
            //初始化狀態與計時器
            CurrentMachineState = MachineState.Offline;
            CurrentMode = OperationMode.Production;
            CurrentE10State = MapToE10State(CurrentMachineState);
            foreach (E10State state in Enum.GetValues(typeof(E10State)))
            {
                _stateTimers[state] = 0; //初始累積時間為0
            }
        }

        public bool TryChangeState(MachineState newState, string reason)
        {         

            if (!IsValidTransition(newState))
            {
                return false; //不合法的轉換，拒絕改變狀態
            }

            MachineState oldState = CurrentMachineState;

            CurrentMachineState = newState;

            CurrentE10State = MapToE10State(newState);  

            OnStateChanged?.Invoke(this, new StateChangedEventArgs(oldState, newState,CurrentE10State));

            return true;
        }

        public bool TryChangeMode(OperationMode newMode)
        {
            //根據實際需求，判斷是否允許改變操作模式
            CurrentMode = newMode;
            return true; //暫時允許所有模式改變，實際應根據需求實作
        }   

        public double CaculateReliability()
        {           
            return 0; //暫時預設為0，實際應根據需求實作
        }

        public double CaculateMaintainability()
        {
            return 0; //暫時預設為0，實際應根據需求實作
        }

        public double CaculateUtilization()
        {
     
            return 0; //暫時預設為0，實際應根據需求實作
        }

        public double CaculateAvailability()
        {
            
            return 0; //暫時預設為0，實際應根據需求實作
        }   
        
        public double GetStateAccumulatedSeconds(E10State targetState)
        {
            //返回指定狀態累積的秒數
            return _stateTimers.ContainsKey(targetState) ? _stateTimers[targetState] : 0;
        }


        private bool IsValidTransition(MachineState newState)
        {
            //根據目前狀態與新狀態，判斷是否為合法的轉換
            //例如：從Idle只能轉到Running，從Running只能轉到Idle或Error等
            //這裡可以根據實際需求定義轉換規則
            return true; //暫時允許所有轉換，實際應根據需求實作
        }

        private E10State MapToE10State(MachineState machineStat)
        {
            //根據機台狀態與操作模式，映射到對應的E10狀態
            return E10State.Standby; //暫時預設為Standby，實際應根據需求實作


        }

        }
}
