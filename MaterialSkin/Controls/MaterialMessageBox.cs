using System;
using System.Drawing;
using System.Windows.Forms;

namespace MaterialSkin.Controls
{
    public partial class MaterialMessageBox : MaterialForm
    {
        public MaterialMessageBox(string caption, string message, MessageButtonSet set)
        {
            InitializeComponent();

            Text = caption;
            tbMessage.BorderStyle = BorderStyle.None;
            tbMessage.Text = message;
            FixMessagePosition();
            SetButtons(set);
        }

        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        private void FixMessagePosition()
        {
            Size size = TextRenderer.MeasureText(tbMessage.Text, tbMessage.Font);
            var maxWidth = Width - 30;
            var lines = Math.Ceiling((double) size.Width/maxWidth);
            var lineHeight = size.Height;
            tbMessage.Width = maxWidth > size.Width ? size.Width : maxWidth;
            tbMessage.Height = (int)lines * lineHeight;

            int y = (Height - btnOk.Height - 10) / 2 - tbMessage.Height / 2 + STATUS_BAR_HEIGHT/2;
            tbMessage.Location = new Point((Width - tbMessage.Width) / 2, y);
            
        }

        private void SetButtons(MessageButtonSet set)
        {
            int y = Height - btnOk.Height - 5;
            const int distance = 10;
            switch (set)
            {
                case MessageButtonSet.Ok:
                    btnOk.Location = new Point((Width - btnOk.Width)/2, y);
                    btnOk.Visible = true;
                    break;
                case MessageButtonSet.OkCancel:
                    btnOk.Location = new Point((Width - btnOk.Width - btnCancel.Width - distance)/2, y);
                    btnOk.Visible = true;
                    btnCancel.Location =
                        new Point((Width - btnOk.Width - btnCancel.Width - distance)/2 + btnOk.Width + distance, y);
                    btnCancel.Visible = true;
                    break;
                case MessageButtonSet.YesNo:
                    btnYes.Location = new Point((Width - btnYes.Width - btnNo.Width - distance)/2, y);
                    btnYes.Visible = true;
                    btnNo.Location =
                        new Point((Width - btnYes.Width - btnNo.Width - distance)/2 + btnYes.Width + distance, y);
                    btnNo.Visible = true;
                    break;
                case MessageButtonSet.YesNoCancel:
                    btnYes.Location = new Point((Width - btnYes.Width - btnNo.Width - btnCancel.Width - 2*distance)/2, y);
                    btnYes.Visible = true;
                    btnNo.Location =
                        new Point(
                            (Width - btnYes.Width - btnNo.Width - btnCancel.Width - 2*distance)/2 + btnYes.Width +
                            distance, y);
                    btnNo.Visible = true;
                    btnCancel.Location =
                        new Point(
                            (Width - btnYes.Width - btnNo.Width - btnCancel.Width - 2*distance)/2 + btnYes.Width +
                            btnCancel.Width + 2*distance, y);
                    btnCancel.Visible = true;
                    break;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }
    }
}