using System;
using System.Windows.Forms;

namespace Lab6
{
    public partial class settingsForm : Form
    {
        private int Outline;
        private int FillColor;
        private int PenWidth;

        // Assign list box values
        public settingsForm(int inputOutline, int inputFillColor, int inputPenWidth)
        {
            InitializeComponent();
            Outline = inputOutline;
            listBoxOutline.SelectedIndex = Outline;
            FillColor = inputFillColor;
            listBoxFillColor.SelectedIndex = FillColor;
            PenWidth = inputPenWidth;
            listBoxPenWidth.SelectedIndex = PenWidth;
        }
        private void CancelSettingsButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            Outline = listBoxOutline.SelectedIndex;
            FillColor = listBoxFillColor.SelectedIndex;
            PenWidth = listBoxPenWidth.SelectedIndex;
        }

        public int GetOutline()
        {
            return Outline;
        }
        public int GetFillColor()
        {
            return FillColor;
        }
        public int GetPenWidth()
        {
            return PenWidth;
        }
    }
}
