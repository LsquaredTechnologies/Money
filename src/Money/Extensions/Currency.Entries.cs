using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace Lsquared.Extensions
{
    /// <content>
    /// Initializes all known currencies.
    /// </content>
    partial struct Currency
    {
        /// <summary>
        /// Initializes the <see cref="Currency"/> struct.
        /// </summary>
        static Currency()
        {
            ReadEntries();
            #region Assign fields
            ALL = new Currency(008);
            DZD = new Currency(012);
            ARS = new Currency(032);
            AUD = new Currency(036);
            BSD = new Currency(044);
            BHD = new Currency(048);
            BDT = new Currency(050);
            AMD = new Currency(051);
            BBD = new Currency(052);
            BMD = new Currency(060);
            BOB = new Currency(068);
            BWP = new Currency(072);
            BZD = new Currency(084);
            SBD = new Currency(090);
            BND = new Currency(096);
            MMK = new Currency(104);
            BIF = new Currency(108);
            KHR = new Currency(116);
            CAD = new Currency(124);
            CVE = new Currency(132);
            KYD = new Currency(136);
            LKR = new Currency(144);
            CLP = new Currency(152);
            CNY = new Currency(156);
            COP = new Currency(170);
            KMF = new Currency(174);
            CRC = new Currency(188);
            HRK = new Currency(191);
            CUP = new Currency(192);
            CZK = new Currency(203);
            DKK = new Currency(208);
            DOP = new Currency(214);
            SVC = new Currency(222);
            ETB = new Currency(230);
            ERN = new Currency(232);
            FKP = new Currency(238);
            FJD = new Currency(242);
            DJF = new Currency(262);
            GMD = new Currency(270);
            GIP = new Currency(292);
            GTQ = new Currency(320);
            GNF = new Currency(324);
            GYD = new Currency(328);
            HTG = new Currency(332);
            HNL = new Currency(340);
            HKD = new Currency(344);
            HUF = new Currency(348);
            ISK = new Currency(352);
            INR = new Currency(356);
            IDR = new Currency(360);
            IRR = new Currency(364);
            IQD = new Currency(368);
            ILS = new Currency(376);
            JMD = new Currency(388);
            JPY = new Currency(392);
            KZT = new Currency(398);
            JOD = new Currency(400);
            KES = new Currency(404);
            KPW = new Currency(408);
            KRW = new Currency(410);
            KWD = new Currency(414);
            KGS = new Currency(417);
            LAK = new Currency(418);
            LBP = new Currency(422);
            LVL = new Currency(428);
            LRD = new Currency(430);
            LYD = new Currency(434);
            LTL = new Currency(440);
            MOP = new Currency(446);
            MWK = new Currency(454);
            MYR = new Currency(458);
            MVR = new Currency(462);
            MRO = new Currency(478);
            MUR = new Currency(480);
            MXN = new Currency(484);
            MNT = new Currency(496);
            MDL = new Currency(498);
            MAD = new Currency(504);
            OMR = new Currency(512);
            NPR = new Currency(524);
            ANG = new Currency(532);
            AWG = new Currency(533);
            VUV = new Currency(548);
            NZD = new Currency(554);
            NIO = new Currency(558);
            NGN = new Currency(566);
            NOK = new Currency(578);
            PKR = new Currency(586);
            PAB = new Currency(590);
            PGK = new Currency(598);
            PYG = new Currency(600);
            PEN = new Currency(604);
            PHP = new Currency(608);
            GWP = new Currency(624);
            QAR = new Currency(634);
            RUB = new Currency(643);
            RWF = new Currency(646);
            SHP = new Currency(654);
            STD = new Currency(678);
            SAR = new Currency(682);
            SCR = new Currency(690);
            SLL = new Currency(694);
            SGD = new Currency(702);
            SKK = new Currency(703);
            VND = new Currency(704);
            SOS = new Currency(706);
            ZAR = new Currency(710);
            ZWD = new Currency(716);
            SZL = new Currency(748);
            SEK = new Currency(752);
            CHF = new Currency(756);
            SYP = new Currency(760);
            THB = new Currency(764);
            TOP = new Currency(776);
            TTD = new Currency(780);
            AED = new Currency(784);
            TND = new Currency(788);
            TMM = new Currency(795);
            UGX = new Currency(800);
            MKD = new Currency(807);
            EGP = new Currency(818);
            GBP = new Currency(826);
            TZS = new Currency(834);
            USD = new Currency(840);
            UYU = new Currency(858);
            UZS = new Currency(860);
            WST = new Currency(882);
            YER = new Currency(886);
            ZMK = new Currency(894);
            TWD = new Currency(901);
            GHS = new Currency(936);
            VEF = new Currency(937);
            SDG = new Currency(938);
            RSD = new Currency(941);
            MZN = new Currency(943);
            AZN = new Currency(944);
            RON = new Currency(946);
            TRY = new Currency(949);
            XAF = new Currency(950);
            XCD = new Currency(951);
            XOF = new Currency(952);
            XPF = new Currency(953);
            XAU = new Currency(959);
            XDR = new Currency(960);
            XAG = new Currency(961);
            XPT = new Currency(962);
            XTS = new Currency(963);
            XPD = new Currency(964);
            SRD = new Currency(968);
            MGA = new Currency(969);
            AFN = new Currency(971);
            TJS = new Currency(972);
            AOA = new Currency(973);
            BYR = new Currency(974);
            BGN = new Currency(975);
            CDF = new Currency(976);
            BAM = new Currency(977);
            EUR = new Currency(978);
            UAH = new Currency(980);
            GEL = new Currency(981);
            PLN = new Currency(985);
            BRL = new Currency(986);
            XXX = new Currency(999);
            #endregion
        }
        
        private static void ReadEntries()
        {
#if NET20 || NET35 || NET40
            using (var stream = typeof(Money).Assembly.GetManifestResourceStream(@"Lsquared.Extensions.OpenAuth.data.json.zip"))
#else
            using (var stream = typeof(Money).GetTypeInfo().Assembly.GetManifestResourceStream(@"Lsquared.Extensions.OpenAuth.data.json.zip"))
#endif
            using (var gzip = new GZipStream(stream, CompressionMode.Decompress))
            using (var reader = new StreamReader(gzip, Encoding.UTF8, false, 1000))
            {
                var json = reader.ReadToEnd();
                dynamic data = JsonConvert.DeserializeObject(json);

                foreach (var t in data.a)
                {
                    var isoNumber = Convert.ToInt16(t.Name);
                    _entries.Add(isoNumber, new Entry(isoNumber, t.Value.c.Value, t.Value.s.Value, t.Value.n.Value));
                }

                foreach (var t in data.b)
                {
                    var values = new List<short>(t.Value.Count);
                    foreach (short value in t.Value)
                        values.Add(value);
                    _symbolToIsoNumbers.Add(t.Name, values);
                }

                foreach (var t in data.c)
                {
                    _isoCodeToIsoNumber.Add((string)t.Name, (short)t.Value);
                }

                foreach (var t in data.d)
                {
                    _nameToIsoNumber.Add((string)t.Name, (short)t.Value);
                }

                foreach (var t in data.e)
                {
                    var values = new List<string>(t.Value.Count);
                    foreach (string value in t.Value)
                        values.Add(value);
                    var isoNumber = Convert.ToInt16(t.Name);
                    _isoNumberToName.Add(isoNumber, values);
                }
            }
        }

#if !(NET20 || NET35 || NET40)
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        private static Entry CreateEntry(Dictionary<string, string> symbols, short isoNumber, string isoCode, string name)
            => new Entry(isoNumber, isoCode, symbols.ContainsKey(isoCode) ? symbols[isoCode] : "¤", name); // General purpose currency symbol

#region Fields

        private static readonly Dictionary<short, Entry> _entries = new Dictionary<short, Entry>(50);
        private static readonly Dictionary<string, List<short>> _symbolToIsoNumbers = new Dictionary<string, List<short>>(50, StringComparer.OrdinalIgnoreCase);
        private static readonly Dictionary<string, short> _isoCodeToIsoNumber = new Dictionary<string, short>(50);
        private static readonly Dictionary<string, short> _nameToIsoNumber = new Dictionary<string, short>(50, StringComparer.OrdinalIgnoreCase);
        private static readonly Dictionary<short, List<string>> _isoNumberToName = new Dictionary<short, List<string>>(50);

#endregion

#region Nested

        private struct Entry : IEquatable<Entry>
        {
#pragma warning disable IDE1006
            internal readonly short IsoNumber;
            internal readonly string IsoCode;
            internal readonly string Symbol;
            internal readonly string Name;
#pragma warning restore IDE1006

            internal Entry(short isoNumber, string isoCode, string symbol, string name)
            {
                IsoNumber = isoNumber;
                IsoCode = isoCode;
                Symbol = symbol;
                Name = name;
            }

#if !(NET20 || NET35 || NETSTANDARD1_3 || UAP10)
            [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
#endif
            public bool Equals(Entry other)
            {
                return IsoNumber == other.IsoNumber;
            }
        }

#endregion
    }
}
