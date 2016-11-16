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

            var names = _isoNumberToName[_isoNumber];

            var name = names.Contains(CultureInfo.CurrentCulture.Name) ?
                             CultureInfo.CurrentCulture.Name : 
                             names[0];

            return new CultureInfo(name).NumberFormat;
        }
    }
}
