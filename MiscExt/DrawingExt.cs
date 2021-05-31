using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Drawing
{
    public static class DrawingExt
    {
        /// <summary>
        /// Converts a RectangleF to Rectangle
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public static Rectangle ToRect(this RectangleF r)
        {
            return new Rectangle((int)r.X, (int)r.Y, (int)r.Width, (int)r.Height);
        }

        /// <summary>
        /// Returns a rectangle 1 pixel smaller than the original
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public static Rectangle MinusOne(this Rectangle r)
        {
            return new Rectangle(r.X, r.Y, r.Width - 1, r.Height - 1);
        }
    }
}
