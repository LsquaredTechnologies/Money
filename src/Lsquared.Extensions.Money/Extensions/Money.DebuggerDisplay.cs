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
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        private string DebuggerDisplay
            => $"{ToString()} ({ToDecimal(CultureInfo.CurrentCulture)} {(_currency == Currency.None ? "<No currency>" : _currency.Name)})";
    }
}
