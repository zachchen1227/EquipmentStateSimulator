using static SemiE10.Core.Enums.SysEnums;
using SemiE10.Core.Models;

namespace SemiE10.Core.Interfaces
{
    public interface IE10Tracker
    {
        #region 屬性
        //當前機台狀態
        MachineState CurrentMachineState { get; }

        //當前E10狀態（根據機台狀態+操作模式映射而來）
        E10State CurrentE10State { get; }

        //當前操作模式
        OperationMode CurrentMode { get; }
        #endregion

        #region 事件
        //狀態改變事件，提供舊狀態、新狀態、對應的E10狀態以及改變原因
        event EventHandler<StateChangedEventArgs>? OnStateChanged;     
        #endregion

        #region 方法

        #region 改變狀態或操作模式

        //嘗試改變機台狀態，根據實際需求判斷是否允許改變，並提供改變原因
        bool TryChangeState(MachineState newState, string reason = "");

        //嘗試改變操作模式，根據實際需求判斷是否允許改變
        bool TryChangeMode(OperationMode newMode);

        #endregion

        #region 計算4大指標

        //計算機台可靠度（Availability  = Uptime / 當機發生的總次數）
        double CalculateReliability();

        //計算機台可用性（MTBF = Uptime / Operations Time × 100%）
        double CaculateAvailability();

        //計算機台可維護性（MTTR = UnscheduledDown Time/ 當機發生的總次數）
        double CaculateMaintainability();

        //計算機台利用率（ Utilization = ProductiveTime / Operations Time × 100% ）
        double CaculateUtilization();

        #endregion

        #region 查詢累積時間
        //獲取指定E10狀態累積的秒數
        bool GetStateAccumulatedSeconds(E10State targetState, out double accumulatedSeconds);
        #endregion

        #endregion
    }
}
