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

        private enum tools : byte { border, Sutherland, clippingWindow, beck };
        tools activeTool = new tools();
        Graphics Graph;
        Point startPoint;
        Rectangle border;
        List<PointF> vertexes;
        public MainForm()
        {
            InitializeComponent();
            Graph = pictureBoxField.CreateGraphics();
            visible = new Pen(Color.Green, 2);
            inVisible = new Pen(Color.Red, 2);
            bord = new Pen(Color.Blue, 3);
            vertexes = new List<PointF>();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBoxField_Click(object sender, EventArgs e)
        {
            //SectionPoint a
            //Graph.DrawSection1(border);
        }

        private void pictureBoxField_MouseUp(object sender, MouseEventArgs e)
        {
            //choosing functional of tool
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
                        if (border != new Rectangle())
                        {
                            SectionPoint a = new SectionPoint(startPoint.X, startPoint.Y);
                            SectionPoint b = new SectionPoint(e.X, e.Y);
                            Graph.DrawSection1(border, visible, inVisible, a, b);
                        }
                        break;
                    }
                case tools.clippingWindow:
                    {
                        if (e.Button == MouseButtons.Left)
                        {
                            vertexes.Add(new PointF(e.X, e.Y));
                            if (vertexes.Count > 1)
                                Graph.DrawLine(bord, vertexes[vertexes.Count - 2], new PointF(e.X, e.Y));
                        }
                        else if (e.Button == MouseButtons.Right)
                        {
                            Graph.DrawLine(bord, vertexes[vertexes.Count - 1], vertexes[0]);
                            Graph.DefineNormales(vertexes);
                        }
                        break;
                    }
                case tools.beck:
                    {
                        if (vertexes.Count > 1)
                            Graph.DrawBeck(vertexes, visible, inVisible, startPoint, new PointF(e.X, e.Y));
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
            ResetTool();   
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ResetTool();
            UncheckAllItems();
            toolStripButtonRestrictiveBorder.Checked = true;
            activeTool = tools.border;

        }

        
        private void toolStripButtonSutherland_Click(object sender, EventArgs e)
        {
            UncheckAllItems();
            toolStripButtonSutherland.Checked = true;
            activeTool = tools.Sutherland;
        }

        private void toolStripButtonClippingWindow_Click(object sender, EventArgs e)
        {
            ResetTool();
            UncheckAllItems();
            toolStripButtonClippingWindow.Checked = true;
            activeTool = tools.clippingWindow;
        }
        private void toolStripButtonBeckAlgorithm_Click_1(object sender, EventArgs e)
        {
            UncheckAllItems();
            toolStripButtonBeckAlgorithm.Checked = true;
            activeTool = tools.beck;
        }

        private void UncheckAllItems()
        {
            toolStripButtonSutherland.Checked = false;
            toolStripButtonRestrictiveBorder.Checked = false;
            toolStripButtonBeckAlgorithm.Checked = false;
            toolStripButtonClippingWindow.Checked = false;
        }

        private void ResetTool()
        {
            Graph.Clear(pictureBoxField.BackColor);
            border = new Rectangle();
            vertexes.Clear();
        }

        private void toolStrip_Resize(object sender, EventArgs e)
        {
            Graph = pictureBoxField.CreateGraphics();
        }
    }
}
