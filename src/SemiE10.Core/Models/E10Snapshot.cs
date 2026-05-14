using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SemiE10.Core.Enums.SysEnums;

namespace SemiE10.Core.Models
{
    public class E10Snapshot
    {
        public MachineState CurrentMachineState { get; init; }
        public OperationMode CurrentMode { get; init; }
        public E10State CurrentE10State { get; init; }

        public double Availability { get; init; }
        public double Reliability { get; init; }
        public double Maintainability { get; init; }
        public double Utilization { get; init; }

        // 1. 使用 init 確保容器參考在初始化後不可更換。
        // 2. 使用 IReadOnlyDictionary 確保外部無法透過此屬性修改各狀態累積秒數。
        public IReadOnlyDictionary<E10State, double> StateAccumulatedSeconds { get; init; }
            = new Dictionary<E10State, double>();
    }
}
