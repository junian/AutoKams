// -----------------------------------------------------------------------
// <copyright file="IDGenerator.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Juniansoft.AutoKams.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class IDGenerator
    {
        public static string GenerateDateID()
        {
            return DateTime.Now.ToString("yyyy-MM-dd");
        }

        public static string GenerateDateTimeID()
        {
            return IDGenerator.GenerateDateID() + DateTime.Now.ToString("-HH-mm-ss-fffffff");
        }
    }
}
