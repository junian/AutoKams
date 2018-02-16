// -----------------------------------------------------------------------
// <copyright file="BitmapUtils.cs" company="junian">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Juniansoft.AutoKams.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Drawing;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class BitmapUtil
    {
        public static Bitmap ResizeImage(Bitmap bmp, int width, int height)
        {
            double scale = 1.0f;
            if (bmp.Height - height < bmp.Width - width)
            {
                scale = (float)width / (float)bmp.Width;
            }
            else
            {
                scale = (float)height / (float)bmp.Height;
            }
            Size size = new Size((int)Math.Floor(scale * bmp.Width), (int)Math.Floor(scale * bmp.Height));
            return new Bitmap(bmp, size);
        }
    }
}
