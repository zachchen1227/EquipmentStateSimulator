using SemiE10.Core.Interfaces;
using SemiE10.Core.Models;
using static SemiE10.Core.Enums.SysEnums;

namespace SemiE10.Core.Engine
{
    public class E10Tracker : IE10Tracker
    {
        private readonly IStateTransitionValidator _transitionValidator;
        private readonly IE10StateMapper _stateMapper;

        #region 屬性

        public MachineState CurrentMachineState { get; private set; } = MachineState.Offline;
        public OperationMode CurrentMode { get; private set; } = OperationMode.Production;
        public E10State CurrentE10State { get; private set; } = E10State.NonScheduledDownTime;

        #endregion

        //紀錄 6大狀態各自累積的秒數
        private readonly Dictionary<E10State, double> _stateTimers = Enum.GetValues<E10State>().ToDictionary(s => s, _ => 0d);

        //狀態改變與時間更新的廣播事件
        public event EventHandler<StateChangedEventArgs>? OnStateChanged;    

     
        public E10Tracker(IStateTransitionValidator transitionValidator, IE10StateMapper stateMapper)
        {
            _transitionValidator = transitionValidator;
            _stateMapper = stateMapper;

            //初始化狀態與計時器
            CurrentMachineState = MachineState.Offline;
            CurrentMode = OperationMode.Production;
            CurrentE10State = _stateMapper.GetE10State(CurrentMachineState, CurrentMode);
            foreach (E10State state in Enum.GetValues(typeof(E10State)))
            {
                _stateTimers[state] = 0d; //初始累積時間為0
            }         
        }

        // 改變機台狀態
        public bool TryChangeState(MachineState newState, string reason)
        {

            // 首先檢查是否為合法的狀態轉換
            if (!_transitionValidator.IsVaild(CurrentMachineState,newState)) { 
                return false; 
            }   

            MachineState oldState = CurrentMachineState;

            CurrentMachineState = newState;

            try
            {
                CurrentE10State = _stateMapper.GetE10State(CurrentMachineState, CurrentMode);
                OnStateChanged?.Invoke(this, new StateChangedEventArgs(oldState, newState, CurrentE10State, DateTime.Now));
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }             
        }

        // 改變操作模式
        public bool TryChangeMode(OperationMode newMode)
        {
            //根據實際需求，判斷是否允許改變操作模式
            CurrentMode = newMode;
            CurrentE10State = _stateMapper.GetE10State(CurrentMachineState, CurrentMode);   
            return true; //暫時允許所有模式改變，實際應根據需求實作
        }   

        public double CalculateReliability()
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

        // 取得特定E10狀態的累積秒數
        public bool GetStateAccumulatedSeconds(E10State targetState, out double accumulatedSeconds)
        {
            accumulatedSeconds = 0d;

            if (_stateTimers.TryGetValue(targetState, out double seconds))
            {
                accumulatedSeconds = seconds;
                return true;    
            }
            return false;
        }      

    }
}
