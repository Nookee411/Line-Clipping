using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

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
        /// Define codes of point according to ***?-left, ?***-Up, *?**-down, **?*
        /// </summary>
        /// <param name="Up"></param>
        /// <param name="Down"></param>
        /// <param name="Left"></param>
        /// <param name="Right"></param>
        public void SetCodes(int Up,int Down,int Left,int Right)
        {
            Code = 0;
            if (X < Left) Code += 1;
            else if (X > Right) Code += 2;
            if (Y > Down) Code += 4;
            else if (Y < Up) Code += 8;
        }

        /// <summary>
        /// Simple method of checking is AND operation equals 0
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static bool IsANDNull(SectionPoint first,SectionPoint second)
        {
            
            return (first.Code & second.Code)==0;
        }

        public static int GetCode(int x,int y, int Up, int Down, int Left, int Right)
        {
            int code = 0;
            if (x < Left) code += 1;
            else if (x > Right) code += 2;
            if (y > Down) code += 4;
            else if (y < Up) code += 8;
            return code;
        }
    }
}
