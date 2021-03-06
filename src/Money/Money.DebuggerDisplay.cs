using System.Diagnostics;
using System.Globalization;
using System.Threading;

namespace Lsquared.Extensions
{
    /// <content>
    /// For debugging purpose.
    /// </content>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    partial struct Money
    {
#if !(NET20 || NET35 || NETSTANDARD1_3 || UAP10)
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
        private string DebuggerDisplay
            => $"{ToString()} ({ToDecimal(Thread.CurrentThread.CurrentCulture.NumberFormat)} {(_currency == Currency.None ? "<No currency>" : _currency.Name)})";
    }
}
