using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6
{
    public partial class Form1 : Form
    {
        private readonly ArrayList myObjects = new ArrayList();

        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = panelDraw.CreateGraphics();
            if (isFirstClick == true)
            {
                g.FillEllipse(Brushes.Black, firstPoint.X - 5, firstPoint.Y - 5, 10, 10);
            }
        }

        // Initial selected index is 0 for each list box
        private int Outline = 0;
        private int FillColor = 0;
        private int PenWidth = 0;
        private void SettingsButton_Click(object sender, EventArgs e)
        {
            settingsForm f2 = new settingsForm(Outline, FillColor, PenWidth);
            // Access data from the settings form if OK button is clicked
            if (f2.ShowDialog() == DialogResult.OK)
            {
                Outline = f2.GetOutline();
                FillColor = f2.GetFillColor();
                PenWidth = f2.GetPenWidth();
            }
            Invalidate();
        }

        bool isFirstClick = false;
        public Point firstPoint;
        private void PanelDraw_MouseClick(object sender, MouseEventArgs e)
        {
            Point myDrawing = new Point(e.X, e.Y);
            // check to see if a second click is needed and draw first circle through override paint event
            if (false == isFirstClick)
            {
                isFirstClick = true;
                firstPoint = myDrawing;
                Invalidate();
            }
            else
            {
                if (Outline != 0 || FillColor != 0)
                {
                    if (LineRadioButton.Checked)
                    {
                        // Adding 1 to PenWidth because ListBox is indexed at 0
                        var drawLine = new LineClass(firstPoint, myDrawing, Outline, PenWidth + 1);
                        myObjects.Add(drawLine);
                    }
                    else if (RectangleRadioButton.Checked)
                    {
                        var drawRectangle = new RectangleClass(firstPoint, myDrawing, Outline, FillColor, PenWidth + 1);
                        myObjects.Add(drawRectangle);
                    }
                    else if (EllipseRadioButton.Checked)
                    {
                        var drawEllipse = new EllipseClass(firstPoint, myDrawing, Outline, FillColor, PenWidth + 1);
                        myObjects.Add(drawEllipse);
                    }
                    else { }
                    // Reset first click bool
                    isFirstClick = false;
                    Refresh();
                }
                else
                {
                    MessageBox.Show("Fill and or pen/outline color must be selected.");
                    isFirstClick = false;
                    // Delete black circle
                    Refresh();
                }
            }
        }

        private void PanelDraw_Paint_1(object sender, PaintEventArgs e)
        {
            Graphics g = panelDraw.CreateGraphics();
            foreach (BaseGraphicsElementClass myDrawing in myObjects)
            {
                myDrawing.Draw(g);
            }
        }
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myObjects.Clear();
            Refresh();
        }

        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count = myObjects.Count;
            if (myObjects.Count >= 1)
            {
                myObjects.RemoveAt(count - 1);
            }
            else { }
            Refresh();
        }
    }
}
