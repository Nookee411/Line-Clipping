using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
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
        /// <param name="restrictiveRect">Sets clipping window(отсекающее окно)</param>
        /// <param name="a">First point of section</param>
        /// <param name="b">Second point of section</param>
        public static void DrawSection1(this Graphics Graph,Rectangle restrictiveRect, Pen visibleLine, Pen inVisibleLine, SectionPoint a,SectionPoint b)
        {

            //Defining borders just for the sake of usability
            int yUp = restrictiveRect.Y;//Upper border
            int yDown = restrictiveRect.Y + restrictiveRect.Height;//Down border
            int xLeft = restrictiveRect.X; //Left border
            int xRight = restrictiveRect.X + restrictiveRect.Width; //Right border

            a.SetCodes(yUp, yDown, xLeft, xRight);
            b.SetCodes(yUp, yDown, xLeft, xRight);
            //First thing first we must define codes of section endings.
            int codeStart = a.Code;
            int codeEnd = b.Code;

            double xStart = a.X, yStart = a.Y, xEnd = b.X, yEnd = b.Y;

            double dx,dy,dydx,dxdy;
           
            //Graph.DrawLine(line, a.X, a.Y, b.X, b.Y);

            dx = xEnd-xStart;
            dy = yEnd-yStart;
            dydx = dy / dx;
            dxdy = dx / dy;
            if (dx != 0)
                dydx = dy / dx;
            else if (dy == 0)
                {
                    return;
                }

            if (dy != 0) 
                dxdy = dx / dy;

            bool isVisible = false;
            int i = 5;
            do
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
                    codeStart += codeEnd;
                    codeEnd = codeStart - codeEnd;
                    codeStart = codeStart- codeEnd;

                    xStart += xEnd;
                    xEnd = xStart - xEnd;
                    xStart = xStart - xEnd;

                    yStart += yEnd;
                    yEnd = yStart - yEnd;
                    yStart = yStart - yEnd;
                }
                if ((codeStart & 1) != 0)//Crosses left border
                {
                    double tempY = yStart + dydx * (xLeft - xStart);
                    Graph.DrawLine(inVisibleLine, (float)xStart, (float)yStart, (float)xLeft, (float)tempY);
                    yStart = tempY;
                    xStart = xLeft;
                }
                else if ((codeStart & 2) != 0) //Crosses right border
                {
                    double tempY = yStart + dydx * (xRight - xStart);
                    Graph.DrawLine(inVisibleLine, (float)xStart, (float)yStart, (float)xRight, (float)tempY);
                    yStart = tempY;
                    xStart = xRight;
                }
                else if ((codeStart & 4) != 0) //Crosses bottom border
                {
                    double tempX = xStart + dxdy * (yDown - yStart);
                    Graph.DrawLine(inVisibleLine, (float)xStart, (float)yStart, (float)tempX, (float)yDown);
                    xStart = tempX;
                    yStart = yDown;
                }
                else if ((codeStart & 8) != 0) //Crosses upper border
                {
                    double tempX = xStart + dxdy * (yUp - yStart);
                    Graph.DrawLine(inVisibleLine, (float)xStart, (float)yStart, (float)tempX, (float)yUp);
                    xStart = tempX;
                    yStart = yUp;
                }
                
                codeStart = SectionPoint.GetCode((int)xStart, (int)yStart, yUp, yDown, xLeft, xRight);
            } while (--i != 0);
            if(isVisible)
            {
                Graph.DrawLine(visibleLine, (int)xStart, (int)yStart, (int)xEnd, (int)yEnd);
            }
            else
                Graph.DrawLine(inVisibleLine, (int)xStart, (int)yStart, (int)xEnd, (int)yEnd);
        }
    }
}
