using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
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
    }
}
