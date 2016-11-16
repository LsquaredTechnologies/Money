using System.Diagnostics;
using System.Globalization;

namespace Lsquared.Extensions
{
    /// <content>
    /// For debugging purpose.
    /// </content>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    partial struct Money
    {
#if !(PORTABLE || NETFX_CORE || NETSTANDARD)
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
        private string DebuggerDisplay
            => $"{ToString()} ({ToDecimal(CultureInfo.CurrentCulture)} {(_currency == Currency.None ? "<No currency>" : _currency.Name)})";
    }
}
