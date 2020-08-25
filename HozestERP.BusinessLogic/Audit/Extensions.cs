using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HozestERP.BusinessLogic.Audit
{
    /// <summary>
    /// Extensions
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Find activity log type by system keyword
        /// </summary>
        /// <param name="source">Source</param>
        /// <param name="systemKeyword">The system keyword</param>
        /// <returns>Activity log type item</returns>
        public static ActivityLogType FindBySystemKeyword(this List<ActivityLogType> source,
            string systemKeyword)
        {
            for (int i = 0; i < source.Count; i++)
                if (source[i].SystemKeyword.ToLowerInvariant().Equals(systemKeyword.ToLowerInvariant()))
                    return source[i];
            return null;
        }
    }
}
