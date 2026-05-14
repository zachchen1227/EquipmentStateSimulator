using EquipmentState.UI.WinForms.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EquipmentState.UI.WinForms.Controls
{
    public partial class stateDisplayControl : UserControl
    {
        private readonly Label _label;
        public stateDisplayControl()
        {
            InitializeComponent();

            _label = new Label { Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Segoe UI", 12, FontStyle.Bold) };
            Controls.Add(_label);
            Height = 60;
        }

        public void Render(UiStateItem item)
        {
            _label.Text = $"{item.Name} ({item.Code})";
            _label.BackColor = item.Color;
            _label.ForeColor = Color.Black;
        }
    }
}
