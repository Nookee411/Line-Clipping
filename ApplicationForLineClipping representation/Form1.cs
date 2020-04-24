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
using System.Xml.Linq;
using System.IO;
using System.Diagnostics;
using System.Globalization;

namespace ApplicationForLineClipping_representation
{
    public partial class MainForm : Form
    {
        Pen visible;
        Pen inVisible;
        Pen bord;

        const string testTimeFile = "..\\..\\..\\Tests_time.txt";

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
                            Graph.DrawSutherland(border, visible, inVisible, a, b);
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

        private void Test(bool isSutherland, bool isRandom,bool isFullVisible, bool isPartlyVisible, int iterationMulipier, int ITERATIONS)
        {
            const int SIZE = 400;
            Point center = new Point(pictureBoxField.Width / 2, pictureBoxField.Height / 2);
            Rectangle clippingwindow;
            List<PointF> vertexes= new List<PointF>();
            if (isRandom)
                clippingwindow = new Rectangle(center.X - pictureBoxField.Width/4, center.Y -pictureBoxField.Height/4, pictureBoxField.Width / 2, pictureBoxField.Height / 2);
            else
                clippingwindow = new Rectangle(center.X - SIZE / 2, center.Y - SIZE / 2, SIZE, SIZE);
            if (!isSutherland)
            {
                vertexes.Add(new PointF(clippingwindow.Left, clippingwindow.Top));
                vertexes.Add(new PointF(clippingwindow.Left, clippingwindow.Bottom));
                vertexes.Add(new PointF(clippingwindow.Right, clippingwindow.Bottom));
                vertexes.Add(new PointF(clippingwindow.Right, clippingwindow.Top));
            }
            Graph.DrawRectangle(bord, clippingwindow);
            SectionPoint A;
            SectionPoint B;
            Random rand = new Random();
            var sw = new Stopwatch();
            Task.Run(() =>
            {
                for (int k = 1; k <= iterationMulipier; k++)
                {
                    StreamWriter output = new StreamWriter(testTimeFile, true);
                    string s;
                    if (isFullVisible)
                        s = "Full visible";
                    else if (isPartlyVisible)
                        s = "Parly visible";
                    else if (isRandom)
                        s = "Random";
                    else
                        s = "Full invisible";
                    output.WriteLine(((isSutherland) ? "Sutherland" : "Beck") + " test starts\n"+s);
                    output.WriteLine("Iterations  Time");
                    long totalTime = 0;
                    for (int j = 0; j < 10; j++)
                    {

                        Graph.Clear(pictureBoxField.BackColor);
                        Graph.DrawRectangle(Pens.Blue,clippingwindow);
                        
                        for (double i = 0; i < Math.PI; i+=Math.PI/(ITERATIONS*k))
                        {
                            if(isRandom)
                            {
                                A = new SectionPoint(rand.Next() % pictureBoxField.Width, rand.Next() % pictureBoxField.Height);
                                B = new SectionPoint(rand.Next() % pictureBoxField.Width, rand.Next() % pictureBoxField.Height);
                            }
                            else if(isPartlyVisible)
                            {
                                A = new SectionPoint((int)(center.X + SIZE * Math.Cos(i)), (int)(center.Y + SIZE * Math.Sin(i)));
                                B = new SectionPoint((int)(center.X + SIZE * Math.Cos(i + Math.PI)), (int)(center.Y + SIZE * Math.Sin(i + Math.PI)));
                            }
                            else if(isFullVisible)
                            {
                                A = new SectionPoint((int)(center.X + SIZE/3 * Math.Cos(i)), (int)(center.Y + SIZE/3 * Math.Sin(i)));
                                B = new SectionPoint((int)(center.X + SIZE/3 * Math.Cos(i + Math.PI)), (int)(center.Y + SIZE/3 * Math.Sin(i + Math.PI)));

                            }
                            else
                            {
                                A = new SectionPoint((int)(center.X+300 + SIZE/3 * Math.Cos(i)), (int)(center.Y + SIZE/3 * Math.Sin(i)));
                                B = new SectionPoint((int)(center.X+300 + SIZE/3 * Math.Cos(i + Math.PI)), (int)(center.Y + SIZE/3 * Math.Sin(i + Math.PI)));

                            }
                            if (isSutherland)
                            {
                                sw.Start();
                                Graph.DrawSutherland(clippingwindow, visible, inVisible, A, B);
                                sw.Stop();
                            }
                            else
                            {
                                var normales = Graph.DefineNormales(vertexes);
                                sw.Start();
                                Graph.DrawBeckWithoutNormalesDefinition(vertexes, normales, visible, inVisible, (PointF)A, (PointF)B);
                                sw.Stop();
                            }
                            totalTime += sw.ElapsedMilliseconds;
                            sw.Reset();

                        }
                        sw.Reset();
                    }
                    output.WriteLine($"{ITERATIONS}\t{totalTime / 10}");
                    output.Close();
                }
            });
        }
        private void partlyVisibleLinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Test(true,true, false, true, 1,1000);
        }

        private void roundPartlyVisibleLinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Test(true,false, false, true, 1,1000);
        }

        private void fullyInvisibleLinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Test(true,false, false, false, 1,1000);
        }

        private void fullyVisibleLinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Test(true,false, true, false, 1, 1000);
        }

        private void randomPartlyVisibleLinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Test(false, true, false, true, 1, 1000);
        }

        private void roundPartlyVisibleLinesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Test(false, false, false, true, 2, 1000);
        }

        private void fullyVisibleLinesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Test(false, false, true, false, 1, 1000);

        }

        private void fullyInvisibleLinesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Test(false, false, false, false, 1, 1000);
        }
    }
}
