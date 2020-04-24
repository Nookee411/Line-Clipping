using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.CodeDom;

namespace ClassesForLineClipping
{
    /// <summary>
    /// Class for containing Point of section and codes.
    /// </summary>
    public class SectionPoint
    {
        public int X { get; set; }
        public int Y { get; set; }
        public byte Code {get; set;}

        /// <summary>
        /// Constuctor sets X and Y values and initializes code array. 
        /// </summary>
        /// <param name="X">Location at X</param>
        /// <param name="Y">Location at Y</param>
        public SectionPoint(int X,int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        /// <summary>
        /// Define codes of point according to Cohen Sutherland algorithm
        /// </summary>
        /// <param name="Up">Upper border</param>
        /// <param name="Down">Bottom border</param>
        /// <param name="Left">Left border</param>
        /// <param name="Right">Right border</param>
        public static int GetCode(int x,int y, int Up, int Down, int Left, int Right)
        {
            int code = 0;
            if (x < Left) code += 1;
            else if (x > Right) code += 2;
            if (y > Down) code += 4;
            else if (y < Up) code += 8;
            return code;
        }

        public static explicit operator PointF(SectionPoint a) => new PointF(a.X,a.Y);
    }
}
