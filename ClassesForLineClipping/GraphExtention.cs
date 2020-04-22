using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassesForLineClipping
{
    public static class GraphExtention
    {
        /// <summary>
        /// Draws Between two Points using simple Sutherland Koen Algorithm
        /// </summary>
        /// <param name="Graph"></param>
        /// <param name="clippingWindow">Sets clipping window(отсекающее окно)</param>
        /// <param name="a">First point of section</param>
        /// <param name="b">Second point of section</param>
        public static void DrawSection1(this Graphics Graph,Rectangle clippingWindow, Pen visibleLine, Pen inVisibleLine, SectionPoint a,SectionPoint b)
        {

            //Defining borders just for the sake of usability
            int yUp = clippingWindow.Y;//Upper border
            int yDown = clippingWindow.Y + clippingWindow.Height;//Down border
            int xLeft = clippingWindow.X; //Left border
            int xRight = clippingWindow.X + clippingWindow.Width; //Right border

            //First thing first we must define codes of section endings.
            int codeStart = SectionPoint.GetCode(a.X, a.Y, yUp, yDown, xLeft, xRight);
            int codeEnd = SectionPoint.GetCode(b.X,b.Y, yUp, yDown, xLeft, xRight);

            float xStart = a.X, yStart = a.Y, xEnd = b.X, yEnd = b.Y;

            //dx, dy - difference between coordinated of start and end of segments
            float dx,dy,dydx =0,dxdy=0; 
           
            //Finding dx and dy
            dx = xEnd-xStart;
            dy = yEnd-yStart;
            if (dx != 0) //If x difference is not euqal 0 then find dydx
                dydx = dy / dx;
            else if (dy == 0) //If dx equal zero and dy equal zero, it means segment has zero length, we shouldn't draw it
                    return;
            if (dy != 0) 
                dxdy = dx / dy;//If y difference is not euqal 0 then find dxdy
            bool isVisible = false; //Setting flag to zero
            for(int i=0;i<5;i++) //Main clipping algorithm
            {
                
                if ((codeStart & codeEnd) != 0) break; //Means its out of window
                if (codeStart == 0 && codeEnd == 0) //Means if inside window
                {
                    isVisible = true;
                    break;
                }
                if (codeStart == 0) //starting point inside of window
                {
                    //We need it outside, so we swaps with ending point
                    Swap(ref codeStart, ref codeEnd);
                    Swap(ref xStart, ref xEnd);
                    Swap(ref yStart, ref yEnd);
                }
                if ((codeStart & 1) != 0)//Crosses left border
                {
                    float tempY = (float)(yStart + dydx * (xLeft - xStart)); //saving y position at crossing with side of border
                    Graph.DrawLine(inVisibleLine, xStart, yStart, xLeft, tempY); //Draw "invisible" line just for representation purposes
                    yStart = tempY;
                    xStart = xLeft;
                }
                else if ((codeStart & 2) != 0) //Crosses right border
                {
                    float tempY = (float)(yStart + dydx * (xRight - xStart));
                    Graph.DrawLine(inVisibleLine, xStart, yStart, xRight, tempY);
                    yStart = tempY;
                    xStart = xRight;
                }
                else if ((codeStart & 4) != 0) //Crosses bottom border
                {
                    float tempX = (float)(xStart + dxdy * (yDown - yStart));
                    Graph.DrawLine(inVisibleLine, xStart, yStart, tempX, yDown);
                    xStart = tempX;
                    yStart = yDown;
                }
                else if ((codeStart & 8) != 0) //Crosses upper border
                {
                    float tempX = (float)(xStart + dxdy * (yUp - yStart));
                    Graph.DrawLine(inVisibleLine, xStart, yStart, tempX, yUp);
                    xStart = tempX;
                    yStart = yUp;
                }
                
                codeStart = SectionPoint.GetCode((int)xStart, (int)yStart, yUp, yDown, xLeft, xRight);
            }
            if(isVisible)
            {
                Graph.DrawLine(visibleLine, xStart, yStart, xEnd, yEnd);
            }
            else
                Graph.DrawLine(inVisibleLine, xStart, yStart, xEnd, yEnd);
        }


        public static void DrawBeck(this Graphics Graph,List<PointF>clippingWindow, Pen visible, Pen invisible,PointF A, PointF B)
        {

            //Firstly we need to define array of innter normal
            List<PointF> normal = DefineNormales(Graph, clippingWindow);
            float t0 = 0, t1 = 1;  //Default values of t0/t1
            float Qx, Qy; //Position relativle clipping window
            float normalX, normalY; //Coordinates of normal
            float Pn, Qn; //Pn scalar product of difference and normal
                          //Qn scalar product of Position relatively clippoing window and normal

            bool isVisible = true; //visibility flag

            float dx = B.X - A.X; //finding dx,dy
            float dy = B.Y - A.Y;

            //Main cycle
            for(int i=0;i < clippingWindow.Count; i++) //iterations = number of cube edges
            {
                Qx = A.X - clippingWindow[i].X;  
                Qy = A.Y - clippingWindow[i].Y;
                normalX = normal[(i) % clippingWindow.Count].X; //getting normal for current edge
                normalY = normal[(i) % clippingWindow.Count].Y;
                Pn = dx * normalX + dy * normalY; //scalar product of current vector and normal
                Qn = Qx * normalX + Qy * normalY; //scalad product of position relavive to clipping window and normal 

                if (Pn == 0) //current vector is perpendicular to normal
                {
                    if (Qn < 0) // qn must be more than zero to stay within clipping window
                    {
                        isVisible = false;
                        break;
                    }
                }
                else
                { //vector is not perpendicular to normal
                    float r = -Qn / Pn;
                    if(Pn<0)
                    {
                        if (r < t0) //r out of range
                        {
                            isVisible = false;
                            break;
                        }
                        if (r < t1) //setting t1
                            t1 = r;
                    }
                    else
                    {
                        if(r>t1) //r out of range
                        {
                            isVisible = false;
                            break;
                        }
                        if(r > t0)
                            t0 = r; //setting t0
                    }
                }
            }
            PointF oldA = A, oldB = B;
            if (isVisible)
            {
                if (t0 > t1)
                    isVisible = false;
                else
                {

                    if (t0 > 0)
                    {
                        A.X = oldA.X + t0 * dx;
                        A.Y = oldA.Y + t0 * dy;
                    }
                    if (t1 < 1)
                    {
                        B.X = oldA.X + t1 * dx;
                        B.Y = oldA.Y + t1 * dy;
                    }
                }
                Graph.DrawLine(visible, A, B);
                Graph.DrawLine(invisible, oldA, A);
                Graph.DrawLine(invisible, oldB, B);
            }
            else
                Graph.DrawLine(invisible, A, B);
            

        }

        public static void DrawBeckWithoutNormalesDefinition(this Graphics Graph, List<PointF> clippingWindow, List<PointF> normal,Pen visible, Pen invisible, PointF A, PointF B)
        {

            //Firstly we need to define array of innter normal
            float t0 = 0, t1 = 1;  //Default values of t0/t1
            float Qx, Qy; //Position relativle clipping window
            float normalX, normalY; //Coordinates of normal
            float Pn, Qn; //Pn scalar product of difference and normal
                          //Qn scalar product of Position relatively clippoing window and normal

            bool isVisible = true; //visibility flag

            float dx = B.X - A.X; //finding dx,dy
            float dy = B.Y - A.Y;

            //Main cycle
            for (int i = 0; i < clippingWindow.Count; i++) //iterations = number of cube edges
            {
                Qx = A.X - clippingWindow[i].X;
                Qy = A.Y - clippingWindow[i].Y;
                normalX = normal[(i) % clippingWindow.Count].X; //getting normal for current edge
                normalY = normal[(i) % clippingWindow.Count].Y;
                Pn = dx * normalX + dy * normalY; //scalar product of current vector and normal
                Qn = Qx * normalX + Qy * normalY; //scalad product of position relavive to clipping window and normal 

                if (Pn == 0) //current vector is perpendicular to normal
                {
                    if (Qn < 0) // qn must be more than zero to stay within clipping window
                    {
                        isVisible = false;
                        break;
                    }
                }
                else
                { //vector is not perpendicular to normal
                    float r = -Qn / Pn;
                    if (Pn < 0)
                    {
                        if (r < t0) //r out of range
                        {
                            isVisible = false;
                            break;
                        }
                        if (r < t1) //setting t1
                            t1 = r;
                    }
                    else
                    {
                        if (r > t1) //r out of range
                        {
                            isVisible = false;
                            break;
                        }
                        if (r > t0)
                            t0 = r; //setting t0
                    }
                }
            }
            PointF oldA = A, oldB = B;
            if (isVisible)
            {
                if (t0 > t1)
                    isVisible = false;
                else
                {

                    if (t0 > 0)
                    {
                        A.X = oldA.X + t0 * dx;
                        A.Y = oldA.Y + t0 * dy;
                    }
                    if (t1 < 1)
                    {
                        B.X = oldA.X + t1 * dx;
                        B.Y = oldA.Y + t1 * dy;
                    }
                }
                Graph.DrawLine(visible, A, B);
                Graph.DrawLine(invisible, oldA, A);
                Graph.DrawLine(invisible, oldB, B);
            }
            else
                Graph.DrawLine(invisible, A, B);


        }
        // Auxiliary algorithms
        private static void Swap(ref int a,ref int b)
        {
            a += b;
            b = a - b;
            a = a - b;
        }
        private static void Swap(ref float a, ref float b)
        {
            a += b;
            b = a - b;
            a = a - b;
        }
        public static List<PointF> DefineNormales(this Graphics Graph, List<PointF> vertexes)
        {
            List<PointF> normales = new List<PointF>();
            for(int i=0;i<vertexes.Count;i++)
            {
                PointF vector = new PointF(vertexes[(i + 1) % vertexes.Count].X - vertexes[i].X, vertexes[(i + 1)%vertexes.Count].Y - vertexes[i].Y);
                PointF n1 = new PointF(-vector.Y, vector.X);
                PointF n2 = new PointF(vector.Y, -vector.X);
                PointF middlepoint = MiddlePoint(vertexes[(i + 1) % vertexes.Count], vertexes[i]);
                if (Length(new PointF(middlepoint.X+n1.X, middlepoint.Y + n1.Y),vertexes[(i+2)%vertexes.Count])< Length(new PointF(middlepoint.X + n2.X, middlepoint.Y + n2.Y), vertexes[(i + 2) % vertexes.Count]))
                    normales.Add(new PointF(/*middlepoint.X +   */   n1.X/10, /*middlepoint.Y +*/ n1.Y/10));
                else
                    normales.Add(new PointF(/*middlepoint.X +*/ n2.X/10, /*middlepoint.Y +*/ n2.Y/10));
            }
            return normales;
        }

        private static float Length(PointF point1, PointF point2)
        {
            return (float)Math.Sqrt(Math.Pow(point2.X - point1.X, 2) + Math.Pow(point2.Y - point1.Y,2));
        }

        private static PointF MiddlePoint(PointF point1,PointF point2)
        {
            return new PointF((point1.X + point2.X) / 2, (point1.Y + point2.Y) / 2);
        }

    }

}
