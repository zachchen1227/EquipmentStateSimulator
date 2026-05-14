using System.Drawing;
using static SemiE10.Core.Enums.SysEnums;

namespace EquipmentState.UI.WinForms.Theme
{
    public static class E10ColorPalette
    {
        // 根據 E10State 狀態返回對應的顏色
        public static Color GetColor(E10State state)=>
            state switch
            {
                E10State.Productive => Color.FromArgb(0, 128, 0), //綠色
                E10State.Standby => Color.FromArgb(255, 165, 0), //橙色
                E10State.Engineering => Color.FromArgb(30, 144, 255), //道奇藍
                E10State.ScheduledDownTime => Color.FromArgb(255, 215, 0), //金色
                E10State.UnscheduledDownTime => Color.FromArgb(255, 0, 0), //紅色
                E10State.NonScheduledDownTime => Color.FromArgb(128, 128, 128), //灰色
                _ => Color.LightGray 
            };  

    }
}
