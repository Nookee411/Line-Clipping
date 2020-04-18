using ClassesForLineClipping;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicationForLineClipping_representation
{
    public partial class MainForm : Form
    {
        Pen visible;
        Pen inVisible;
        Pen bord;

        private enum tools: byte { border, Sutherland };
        tools activeTool = new tools();
        Graphics Graph;
        Point startPoint;
        Rectangle border;
        public MainForm()
        {
            InitializeComponent();
            Graph = pictureBoxField.CreateGraphics();
            visible = new Pen(Color.Green, 2);
            inVisible = new Pen(Color.Red, 2);
            bord = new Pen(Color.Blue,2);
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBoxField_Click(object sender, EventArgs e)
        {
            Graph.DrawRectangle(bord, border);
            //SectionPoint a
            //Graph.DrawSection1(border);
        }

        private void pictureBoxField_MouseUp(object sender, MouseEventArgs e)
        {

            switch (activeTool)
            {
                case tools.border:
                    {

                        border = Rectangle.FromLTRB(Math.Min(startPoint.X, e.X), Math.Min(startPoint.Y, e.Y), Math.Max(startPoint.X, e.X), Math.Max(startPoint.Y, e.Y));
                        Graph.DrawRectangle(bord, border);
                        break;
                    }

                case tools.Sutherland:
                    {
                        if (border != null)
                        {
                            SectionPoint a = new SectionPoint(startPoint.X, startPoint.Y);
                            SectionPoint b = new SectionPoint(e.X, e.Y);
                            Graph.DrawSection1(border, visible, inVisible, a, b);
                        }
                        break;
                    }

               
            }


        }

        private void pictureBoxField_MouseDown(object sender, MouseEventArgs e)
        {
            startPoint = new Point(e.X, e.Y);
        }

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graph.Clear(BackColor);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            toolStripButtonSutherland.Checked = false;
            toolStripButtonRestrictiveBorder.Checked = true;
            activeTool = tools.border;

        }

        private void toolStripButtonSutherland_Click(object sender, EventArgs e)
        {
            toolStripButtonRestrictiveBorder.Checked = false;
            toolStripButtonSutherland.Checked = true;
            activeTool = tools.Sutherland;
        }
    }
}
