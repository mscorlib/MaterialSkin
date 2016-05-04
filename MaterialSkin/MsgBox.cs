using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;

namespace MaterialSkin
{
    public class MsgBox
    {
        private const string DefaultCaption = "Info:";

        public static DialogResult Show(string message)
        {
            return Show(message, string.Empty, MessageButtonSet.Ok);
        }

        public static DialogResult Show(string message, string caption)
        {
            return Show(message, caption, MessageButtonSet.Ok);
        }

        public static DialogResult Show(string message, MessageButtonSet set)
        {
            return Show(message, string.Empty, set);
        }

        public static DialogResult Show(string message, string caption, MessageButtonSet set)
        {
            if (string.IsNullOrWhiteSpace(caption))
                caption = DefaultCaption;

            using (var messageBox = new MaterialMessageBox(caption, message, set))
            {
                return messageBox.ShowDialog();
            }
        }
    }
}
