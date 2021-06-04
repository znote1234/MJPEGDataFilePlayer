using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MJPEGDataFilePlayer
{
    public partial class TrackBarCustom : TrackBar
    {
        public TrackBarCustom()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            // フォーカスを定義します。
            const int WM_SETFOCUS = 0x0007;

            switch (m.Msg)
            {
                case WM_SETFOCUS:
                    return;
            }

            base.WndProc(ref m);
        }
    }
}
