using System.Collections.Generic;

namespace AcParamEditor.Extensions
{
    internal static class ParamExt
    {
        /// <summary>
        /// Check if a ParamInfo list contains a param already.
        /// </summary>
        /// <param name="paramlist">An enumerable list of ParamInfo.</param>
        /// <param name="path">The param info path to check for.</param>
        /// <returns>Whether or not the ParamInfo list contains the param already.</returns>
        public static bool ContainsParam(this IEnumerable<ParamInfo> paramlist, string path)
        {
            foreach (var param in paramlist)
                if (param.Path == path)
                    return true;
            return false;
        }
    }
}
