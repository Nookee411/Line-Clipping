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

        const string testTimeFile = "..\\..\\..\\test_time.txt";
        const string testTimeFileBeck = "..\\..\\..\\test_time_beck.txt";

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
            toolStripButtonTestSutherland.Checked = false;
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

        private void toolStripButtonTestSutherland_Click(object sender, EventArgs e)
        {
            UncheckAllItems();
            toolStripButtonTestSutherland.Checked = true;
            testSutherland();
        }

        private void testSutherland()
        {
            const int SIZE = 100;
            const int ITERATIONS = 5000;
            Point center = new Point(pictureBoxField.Width / 2, pictureBoxField.Height / 2);
            Rectangle clippingwindow = new Rectangle(center.X - pictureBoxField.Width/4, center.Y -pictureBoxField.Height/4, pictureBoxField.Width / 2, pictureBoxField.Height / 2);
            Graph.DrawRectangle(bord, clippingwindow);
            SectionPoint A;
            SectionPoint B;
            Random rand = new Random();
            var sw = new Stopwatch();
            Task.Run(() =>
            {
                    StreamWriter output = new StreamWriter(testTimeFile, true);
                    long totalTime = 0;
                    for (int j = 0; j < 10; j++)
                    {

                        Graph.Clear(pictureBoxField.BackColor);
                        sw.Start();
                        for (int i=0;i<ITERATIONS;i++)
                        {
                        //A = new SectionPoint((int)(center.X+300 + SIZE/3 * Math.Cos(i)), (int)(center.Y + SIZE/3 * Math.Sin(i)));
                        //B = new SectionPoint((int)(center.X+300 + SIZE/3 * Math.Cos(i + Math.PI)), (int)(center.Y + SIZE/3 * Math.Sin(i + Math.PI)));
                        //A = new SectionPoint(center.X+rand.Next() % 20, center.Y - 200- rand.Next() % 50);
                        //B = new SectionPoint(center.X- rand.Next() % 20, center.Y + 200+ rand.Next() % 50);
                        A = new SectionPoint(rand.Next() % pictureBoxField.Width, rand.Next() % pictureBoxField.Height);
                        B = new SectionPoint(rand.Next() % pictureBoxField.Width, rand.Next()%pictureBoxField.Height);
                        Graph.DrawSection1(clippingwindow, visible, inVisible, A, B);
                        }
                        sw.Stop();
                        totalTime += sw.ElapsedMilliseconds;
                        sw.Reset();
                    }
                    output.WriteLine($"{ITERATIONS}\t{totalTime/10}");
                    output.Close();
            });
        }

        private void toolStripButtonTextBeck_Click(object sender, EventArgs e)
        {

            const int SIZE = 300;
            const int ITERATIONS = 5000;
            Point center = new Point(pictureBoxField.Width / 2, pictureBoxField.Height / 2);
            List<PointF> clippingwindow = new List<PointF>();
            clippingwindow.Add(new PointF(center.X - pictureBoxField.Width / 4, center.Y - pictureBoxField.Height / 4));
            clippingwindow.Add(new PointF(center.X - pictureBoxField.Width / 4, center.Y + pictureBoxField.Height / 4));
            clippingwindow.Add(new PointF(center.X + pictureBoxField.Width / 4, center.Y + pictureBoxField.Height / 4));
            clippingwindow.Add(new PointF(center.X + pictureBoxField.Width / 4, center.Y - pictureBoxField.Height / 4));
            //clippingwindow.Add(new PointF(center.X - SIZE / 2, center.Y - SIZE / 2));
            //clippingwindow.Add(new PointF(center.X - 40 - SIZE / 2, center.Y));
            //clippingwindow.Add(new PointF(center.X - SIZE / 2, center.Y + SIZE / 2));
            //clippingwindow.Add(new PointF(center.X + SIZE / 2, center.Y + SIZE / 2));
            //clippingwindow.Add(new PointF(center.X + 40 + SIZE / 2, center.Y));
            //clippingwindow.Add(new PointF(center.X + SIZE / 2, center.Y - SIZE / 2));
            //clippingwindow.Add(new PointF(center.X, center.Y - 40 - SIZE / 2));

            int[] sides = {3,4,5,7,8,9,10,12};
            Random rand = new Random();
            PointF A;
            PointF B;
            var sw = new Stopwatch();
                //for (double j = 0; j < Math.PI * 2; j += Math.PI * 2 /sides[k])
                //    clippingwindow.Add(new PointF((float)(center.X + SIZE/2 * Math.Cos(j)), (float)(center.Y + SIZE/2 * Math.Sin(j))));
                var normales = Graph.DefineNormales(clippingwindow);
                //Graph.DrawPolygon(Pens.Black, clippingwindow.ToArray());
                    StreamWriter output = new StreamWriter(testTimeFileBeck, true);
                    long totalTime = 0;
            for (int j = 0; j < 10; j++)
            {         

                Graph.Clear(pictureBoxField.BackColor);
                sw.Start();
                for (double i = 0; i < Math.PI; i += Math.PI * 2 / ITERATIONS)
                {
                    A = new PointF(rand.Next() % pictureBoxField.Width, rand.Next() % pictureBoxField.Height);
                    B = new PointF(rand.Next() % pictureBoxField.Width, rand.Next() % pictureBoxField.Height);
                    //A = new Point((int)(center.X + SIZE * Math.Cos(i)), (int)(center.Y + SIZE * Math.Sin(i)));
                    //B = new Point((int)(center.X + SIZE * Math.Cos(i + Math.PI)), (int)(center.Y + SIZE * Math.Sin(i + Math.PI)));
                    Graph.DrawBeckWithoutNormalesDefinition(clippingwindow, normales, visible, inVisible, A, B);

                }
                sw.Stop();
                totalTime += sw.ElapsedMilliseconds;
                sw.Reset();
            }
                    output.WriteLine($"{clippingwindow.Count}\t{ITERATIONS}\t{totalTime / 10}");
                    output.Close();
        }
    }
}
