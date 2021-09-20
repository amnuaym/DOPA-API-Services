using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace GeneralHelper
{
    public class ControlHelper
    {
        private delegate void SetCheckBoxCheckedCallback(CheckBox control, bool value);

        public static void SetCheckBoxChecked(CheckBox control, bool value)
        {
            if (control.InvokeRequired)
            {
                SetCheckBoxCheckedCallback c = new SetCheckBoxCheckedCallback(SetCheckBoxChecked);
                control.Invoke(c, new object[] { control, value });
            }
            else
            {
                control.Checked = value;
            }
        }

        private delegate void SetListBoxAddTextCallback(ListBox control, string text);

        public static void SetListBoxAddText(ListBox control, string text)
        {
            if (control.InvokeRequired)
            {
                SetListBoxAddTextCallback c = new SetListBoxAddTextCallback(SetListBoxAddText);
                control.Invoke(c, new object[] { control, text });
            }
            else
            {
                string[] items = text.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                control.Items.AddRange(items);
            }
        }

        private delegate void SetListBoxAddRangeCallback(ListBox control, object[] items);

        public static void SetListBoxAddRange(ListBox control, object[] items)
        {
            if (control.InvokeRequired)
            {
                SetListBoxAddRangeCallback c = new SetListBoxAddRangeCallback(SetListBoxAddRange);
                control.Invoke(c, new object[] { control, items });
            }
            else
            {
                control.Items.AddRange(items);
            }
        }

        private delegate void SetListBoxClearCallback(ListBox control);

        public static void SetListBoxClear(ListBox control)
        {
            if (control.InvokeRequired)
            {
                SetListBoxClearCallback c = new SetListBoxClearCallback(SetListBoxClear);
                control.Invoke(c, new object[] { control });
            }
            else
            {
                control.Items.Clear();
            }
        }

        private delegate void SetListBoxLastSelectedCallback(ListBox control);

        public static void SetListBoxLastSelected(ListBox control)
        {
            if (control.InvokeRequired)
            {
                SetListBoxLastSelectedCallback c = new SetListBoxLastSelectedCallback(SetListBoxLastSelected);
                control.Invoke(c, new object[] { control });
            }
            else
            {
                control.SelectedIndex = control.Items.Count - 1;
            }
        }

        private delegate void SetControlTextCallback(Control control, string text);

        public static void SetControlText(Control control, string text)
        {
            if (control.InvokeRequired)
            {
                SetControlTextCallback c = new SetControlTextCallback(SetControlText);
                control.Invoke(c, new object[] { control, text });
            }
            else
            {
                control.Text = text;
            }
        }

        private delegate void SetPictureBoxImageCallback(PictureBox control, Image img);

        public static void SetPictureBoxImage(PictureBox control, Image img)
        {
            if (control.InvokeRequired)
            {
                SetPictureBoxImageCallback c = new SetPictureBoxImageCallback(SetPictureBoxImage);
                control.Invoke(c, new object[] { control, img });
            }
            else
            {
                control.Image = img;
            }
        }
    }
}
