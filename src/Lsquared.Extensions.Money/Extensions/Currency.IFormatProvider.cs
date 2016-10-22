using System;
using System.Globalization;

namespace Lsquared.Extensions
{
    /// <content>
    /// Implements IFormatProvider interface.
    /// </content>
    partial struct Currency : IFormatProvider
    {
        /// <inheritdoc />
        public object GetFormat(Type formatType)
        {
            if (typeof(NumberFormatInfo) != formatType)
                return null;

            var lcids = _isoNumberToLcid[_isoNumber];

            var lcid = lcids.Contains(CultureInfo.CurrentCulture.LCID) ?
                             CultureInfo.CurrentCulture.LCID : 
                             lcids[0];

            return new CultureInfo(lcid).NumberFormat;
        }
    }
}
