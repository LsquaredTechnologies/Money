using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Lsquared.GenerateData
{
    static class Program
    {
        static void Main()
        {
            const string filename = "data.json.zip";
            var cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            BuildEntries(cultures);
            Save(filename);
            CheckFile(filename);
        }

        private static void CheckFile(string filename)
        {
            var s = Stopwatch.StartNew();
            using (var file = File.OpenRead(filename))
            using (var gzip = new GZipStream(file, CompressionMode.Decompress))
            using (var reader = new StreamReader(gzip, Encoding.UTF8, false, 1000))
            {
                var json = reader.ReadToEnd();
                dynamic data = JsonConvert.DeserializeObject(json);

                _entries.Clear();
                _symbolToIsoNumbers.Clear();
                _isoCodeToIsoNumber.Clear();
                _nameToIsoNumber.Clear();
                _isoNumberToName.Clear();

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

            s.Stop();
            Console.WriteLine($"Take {s.ElapsedMilliseconds}ms");
        }

        private static void Save(string filename)
        {
            var a = (from t in _entries select new { t.Key, Value = new { c = t.Value.IsoCode, s = t.Value.Symbol, n = t.Value.Name } }).ToDictionary(t => t.Key, t => t.Value);
            var b = _symbolToIsoNumbers;
            var c = _isoCodeToIsoNumber;
            var d = _nameToIsoNumber;
            var e = _isoNumberToName;

            var json = JsonConvert.SerializeObject(new { a, b, c, d, e });
            using (var file = File.OpenWrite(filename))
            using (var gzip = new GZipStream(file, CompressionMode.Compress))
            using (var writer = new StreamWriter(gzip, Encoding.UTF8, 1000))
            {
                writer.Write(json);
            }
        }

        private static void BuildEntries(CultureInfo[] cultures)
        {
            var isoCodeToName = new Dictionary<string, List<string>>();
            var isoCodeToSymbol = new Dictionary<string, string>(100);

            foreach (var culture in cultures)
            {
                var name = culture.Name;
                var regionInfo = new RegionInfo(name);
                var isoCode = regionInfo.ISOCurrencySymbol;

                if (!isoCodeToName.ContainsKey(isoCode))
                    isoCodeToName[isoCode] = new List<string>();

                isoCodeToName[isoCode].Add(name);
                isoCodeToSymbol[isoCode] = regionInfo.CurrencySymbol;
            }

            // TODO Use translation in each language if possible.
            _entries[008] = CreateEntry(isoCodeToSymbol, 008, "ALL", "Albanian Lek");
            _entries[012] = CreateEntry(isoCodeToSymbol, 012, "DZD", "Algerian Dinar");
            _entries[032] = CreateEntry(isoCodeToSymbol, 032, "ARS", "Argentine Peso");
            _entries[036] = CreateEntry(isoCodeToSymbol, 036, "AUD", "Australian Dollar");
            _entries[044] = CreateEntry(isoCodeToSymbol, 044, "BSD", "Bahamian Dollar");
            _entries[048] = CreateEntry(isoCodeToSymbol, 048, "BHD", "Bahraini Dinar");
            _entries[050] = CreateEntry(isoCodeToSymbol, 050, "BDT", "Bangladeshi Taka");
            _entries[051] = CreateEntry(isoCodeToSymbol, 051, "AMD", "Armenian Dram");
            _entries[052] = CreateEntry(isoCodeToSymbol, 052, "BBD", "Barbados Dollar");
            _entries[060] = CreateEntry(isoCodeToSymbol, 060, "BMD", "Bermudian Dollar");
            _entries[068] = CreateEntry(isoCodeToSymbol, 068, "BOB", "Boliviano");
            _entries[072] = CreateEntry(isoCodeToSymbol, 072, "BWP", "Botswana Pula");
            _entries[084] = CreateEntry(isoCodeToSymbol, 084, "BZD", "Belize Dollar");
            _entries[090] = CreateEntry(isoCodeToSymbol, 090, "SBD", "Solomon Islands Dollar");
            _entries[096] = CreateEntry(isoCodeToSymbol, 096, "BND", "Brunei Dollar");
            _entries[104] = CreateEntry(isoCodeToSymbol, 104, "MMK", "Myanmar Kyat");
            _entries[108] = CreateEntry(isoCodeToSymbol, 108, "BIF", "Burundi Franc");
            _entries[116] = CreateEntry(isoCodeToSymbol, 116, "KHR", "Cambodian Riel");
            _entries[124] = CreateEntry(isoCodeToSymbol, 124, "CAD", "Canadian Dollar");
            _entries[132] = CreateEntry(isoCodeToSymbol, 132, "CVE", "Cape Verde Escudo");
            _entries[136] = CreateEntry(isoCodeToSymbol, 136, "KYD", "Cayman Islands Dollar");
            _entries[144] = CreateEntry(isoCodeToSymbol, 144, "LKR", "Sri Lanka Rupee");
            _entries[152] = CreateEntry(isoCodeToSymbol, 152, "CLP", "Chilean Peso");
            _entries[156] = CreateEntry(isoCodeToSymbol, 156, "CNY", "Yuan Renminbi");
            _entries[170] = CreateEntry(isoCodeToSymbol, 170, "COP", "Colombian Peso");
            _entries[174] = CreateEntry(isoCodeToSymbol, 174, "KMF", "Comoro Franc");
            _entries[188] = CreateEntry(isoCodeToSymbol, 188, "CRC", "Costa Rican Colon");
            _entries[191] = CreateEntry(isoCodeToSymbol, 191, "HRK", "Croatian Kuna");
            _entries[192] = CreateEntry(isoCodeToSymbol, 192, "CUP", "Cuban Peso");
            _entries[203] = CreateEntry(isoCodeToSymbol, 203, "CZK", "Czech Koruna");
            _entries[208] = CreateEntry(isoCodeToSymbol, 208, "DKK", "Danish Krone");
            _entries[214] = CreateEntry(isoCodeToSymbol, 214, "DOP", "Dominican Peso");
            _entries[222] = CreateEntry(isoCodeToSymbol, 222, "SVC", "El Salvador Colon");
            _entries[230] = CreateEntry(isoCodeToSymbol, 230, "ETB", "Ethiopian Birr");
            _entries[232] = CreateEntry(isoCodeToSymbol, 232, "ERN", "Eritrean Nakfa");
            _entries[238] = CreateEntry(isoCodeToSymbol, 238, "FKP", "Falkland Islands Pound");
            _entries[242] = CreateEntry(isoCodeToSymbol, 242, "FJD", "Fiji Dollar");
            _entries[262] = CreateEntry(isoCodeToSymbol, 262, "DJF", "Djibouti Franc");
            _entries[270] = CreateEntry(isoCodeToSymbol, 270, "GMD", "Gambian Dalasi");
            _entries[292] = CreateEntry(isoCodeToSymbol, 292, "GIP", "Gibraltar Pound");
            _entries[320] = CreateEntry(isoCodeToSymbol, 320, "GTQ", "Guatemalan Quetzal");
            _entries[324] = CreateEntry(isoCodeToSymbol, 324, "GNF", "Guinea Franc");
            _entries[328] = CreateEntry(isoCodeToSymbol, 328, "GYD", "Guyana Dollar");
            _entries[332] = CreateEntry(isoCodeToSymbol, 332, "HTG", "Haitian Gourde");
            _entries[340] = CreateEntry(isoCodeToSymbol, 340, "HNL", "Honduran Lempira");
            _entries[344] = CreateEntry(isoCodeToSymbol, 344, "HKD", "Hong Kong Dollar");
            _entries[348] = CreateEntry(isoCodeToSymbol, 348, "HUF", "Hungarian Forint");
            _entries[352] = CreateEntry(isoCodeToSymbol, 352, "ISK", "Iceland Krona");
            _entries[356] = CreateEntry(isoCodeToSymbol, 356, "INR", "Indian Rupee");
            _entries[360] = CreateEntry(isoCodeToSymbol, 360, "IDR", "Indonesian Rupiah");
            _entries[364] = CreateEntry(isoCodeToSymbol, 364, "IRR", "Iranian Rial");
            _entries[368] = CreateEntry(isoCodeToSymbol, 368, "IQD", "Iraqi Dinar");
            _entries[376] = CreateEntry(isoCodeToSymbol, 376, "ILS", "Israeli Sheqel");
            _entries[388] = CreateEntry(isoCodeToSymbol, 388, "JMD", "Jamaican Dollar");
            _entries[392] = CreateEntry(isoCodeToSymbol, 392, "JPY", "Japanese Yen");
            _entries[398] = CreateEntry(isoCodeToSymbol, 398, "KZT", "Kazakhstani Tenge");
            _entries[400] = CreateEntry(isoCodeToSymbol, 400, "JOD", "Jordanian Dinar");
            _entries[404] = CreateEntry(isoCodeToSymbol, 404, "KES", "Kenyan Shilling");
            _entries[408] = CreateEntry(isoCodeToSymbol, 408, "KPW", "North Korean Won");
            _entries[410] = CreateEntry(isoCodeToSymbol, 410, "KRW", "South Korean Won");
            _entries[414] = CreateEntry(isoCodeToSymbol, 414, "KWD", "Kuwaiti Dinar");
            _entries[417] = CreateEntry(isoCodeToSymbol, 417, "KGS", "Kyrgyzstani Som");
            _entries[418] = CreateEntry(isoCodeToSymbol, 418, "LAK", "Lao Kip");
            _entries[422] = CreateEntry(isoCodeToSymbol, 422, "LBP", "Lebanese Pound");
            _entries[428] = CreateEntry(isoCodeToSymbol, 428, "LVL", "Latvian Lats");
            _entries[430] = CreateEntry(isoCodeToSymbol, 430, "LRD", "Liberian Dollar");
            _entries[434] = CreateEntry(isoCodeToSymbol, 434, "LYD", "Libyan Dinar");
            _entries[440] = CreateEntry(isoCodeToSymbol, 440, "LTL", "Lithuanian Litas");
            _entries[446] = CreateEntry(isoCodeToSymbol, 446, "MOP", "Macanese Pataca");
            _entries[454] = CreateEntry(isoCodeToSymbol, 454, "MWK", "Malawian Kwacha");
            _entries[458] = CreateEntry(isoCodeToSymbol, 458, "MYR", "Malaysian Ringgit");
            _entries[462] = CreateEntry(isoCodeToSymbol, 462, "MVR", "Maldivian Rufiyaa");
            _entries[478] = CreateEntry(isoCodeToSymbol, 478, "MRO", "Mauritanian Ouguiya");
            _entries[480] = CreateEntry(isoCodeToSymbol, 480, "MUR", "Mauritius Rupee");
            _entries[484] = CreateEntry(isoCodeToSymbol, 484, "MXN", "Mexican Peso");
            _entries[496] = CreateEntry(isoCodeToSymbol, 496, "MNT", "Mongolian Tögrög");
            _entries[498] = CreateEntry(isoCodeToSymbol, 498, "MDL", "Moldovan Leu");
            _entries[504] = CreateEntry(isoCodeToSymbol, 504, "MAD", "Moroccan Dirham");
            _entries[512] = CreateEntry(isoCodeToSymbol, 512, "OMR", "Omani Rial");
            _entries[524] = CreateEntry(isoCodeToSymbol, 524, "NPR", "Nepalese Rupee");
            _entries[532] = CreateEntry(isoCodeToSymbol, 532, "ANG", "Netherlands Antillian Guilder");
            _entries[533] = CreateEntry(isoCodeToSymbol, 533, "AWG", "Aruban Guilder");
            _entries[548] = CreateEntry(isoCodeToSymbol, 548, "VUV", "Vanuatu Vatu");
            _entries[554] = CreateEntry(isoCodeToSymbol, 554, "NZD", "New Zealand Dollar");
            _entries[558] = CreateEntry(isoCodeToSymbol, 558, "NIO", "Cordoba Oro");
            _entries[566] = CreateEntry(isoCodeToSymbol, 566, "NGN", "Nigerian Naira");
            _entries[578] = CreateEntry(isoCodeToSymbol, 578, "NOK", "Norwegian Krone");
            _entries[586] = CreateEntry(isoCodeToSymbol, 586, "PKR", "Pakistan Rupee");
            _entries[590] = CreateEntry(isoCodeToSymbol, 590, "PAB", "Panamanian Balboa");
            _entries[598] = CreateEntry(isoCodeToSymbol, 598, "PGK", "Papua New Guinean Kina");
            _entries[600] = CreateEntry(isoCodeToSymbol, 600, "PYG", "Paraguayan Guaraní");
            _entries[604] = CreateEntry(isoCodeToSymbol, 604, "PEN", "Peruvian Sol");
            _entries[608] = CreateEntry(isoCodeToSymbol, 608, "PHP", "Philippine Peso");
            _entries[624] = CreateEntry(isoCodeToSymbol, 624, "GWP", "Guinea-Bissau Peso");
            _entries[634] = CreateEntry(isoCodeToSymbol, 634, "QAR", "Qatari Rial");
            _entries[643] = CreateEntry(isoCodeToSymbol, 643, "RUB", "Russian Ruble");
            _entries[646] = CreateEntry(isoCodeToSymbol, 646, "RWF", "Rwanda Franc");
            _entries[654] = CreateEntry(isoCodeToSymbol, 654, "SHP", "Saint Helena Pound");
            _entries[678] = CreateEntry(isoCodeToSymbol, 678, "STD", "São Tomé and Príncipe Dobra");
            _entries[682] = CreateEntry(isoCodeToSymbol, 682, "SAR", "Saudi Riyal");
            _entries[690] = CreateEntry(isoCodeToSymbol, 690, "SCR", "Seychelles Rupee");
            _entries[694] = CreateEntry(isoCodeToSymbol, 694, "SLL", "Sierra Leonean Leone");
            _entries[702] = CreateEntry(isoCodeToSymbol, 702, "SGD", "Singapore Dollar");
            _entries[703] = CreateEntry(isoCodeToSymbol, 703, "SKK", "Slovak Koruna");
            _entries[704] = CreateEntry(isoCodeToSymbol, 704, "VND", "Vietnamese Dong");
            _entries[706] = CreateEntry(isoCodeToSymbol, 706, "SOS", "Somali Shilling");
            _entries[710] = CreateEntry(isoCodeToSymbol, 710, "ZAR", "South African Rand");
            _entries[716] = CreateEntry(isoCodeToSymbol, 716, "ZWD", "Zimbabwe Dollar");
            _entries[748] = CreateEntry(isoCodeToSymbol, 748, "SZL", "Swazi Lilangeni");
            _entries[752] = CreateEntry(isoCodeToSymbol, 752, "SEK", "Swedish Krona");
            _entries[756] = CreateEntry(isoCodeToSymbol, 756, "CHF", "Swiss Franc");
            _entries[760] = CreateEntry(isoCodeToSymbol, 760, "SYP", "Syrian Pound");
            _entries[764] = CreateEntry(isoCodeToSymbol, 764, "THB", "Thai Baht");
            _entries[776] = CreateEntry(isoCodeToSymbol, 776, "TOP", "Tongan Paʻanga");
            _entries[780] = CreateEntry(isoCodeToSymbol, 780, "TTD", "Trinidad and Tobago Dollar");
            _entries[784] = CreateEntry(isoCodeToSymbol, 784, "AED", "UAE Dirham");
            _entries[788] = CreateEntry(isoCodeToSymbol, 788, "TND", "Tunisian Dinar");
            _entries[795] = CreateEntry(isoCodeToSymbol, 795, "TMM", "Turkmenistani Manat");
            _entries[800] = CreateEntry(isoCodeToSymbol, 800, "UGX", "Uganda Shilling");
            _entries[807] = CreateEntry(isoCodeToSymbol, 807, "MKD", "Macedonian Denar");
            _entries[818] = CreateEntry(isoCodeToSymbol, 818, "EGP", "Egyptian Pound");
            _entries[826] = CreateEntry(isoCodeToSymbol, 826, "GBP", "Pound Sterling");
            _entries[834] = CreateEntry(isoCodeToSymbol, 834, "TZS", "Tanzanian Shilling");
            _entries[840] = CreateEntry(isoCodeToSymbol, 840, "USD", "US Dollar");
            _entries[858] = CreateEntry(isoCodeToSymbol, 858, "UYU", "Uruguayan Peso");
            _entries[860] = CreateEntry(isoCodeToSymbol, 860, "UZS", "Uzbekistan Sum");
            _entries[882] = CreateEntry(isoCodeToSymbol, 882, "WST", "Samoan Tala");
            _entries[886] = CreateEntry(isoCodeToSymbol, 886, "YER", "Yemeni Rial");
            _entries[894] = CreateEntry(isoCodeToSymbol, 894, "ZMK", "Malawian Kwacha");
            _entries[901] = CreateEntry(isoCodeToSymbol, 901, "TWD", "Taiwan Dollar");
            _entries[936] = CreateEntry(isoCodeToSymbol, 936, "GHS", "Ghana Cedi");
            _entries[937] = CreateEntry(isoCodeToSymbol, 937, "VEF", "Bolivar Fuerte");
            _entries[938] = CreateEntry(isoCodeToSymbol, 938, "SDG", "Sudanese Pound");
            _entries[941] = CreateEntry(isoCodeToSymbol, 941, "RSD", "Serbian Dinar");
            _entries[943] = CreateEntry(isoCodeToSymbol, 943, "MZN", "Mozambican Metical");
            _entries[944] = CreateEntry(isoCodeToSymbol, 944, "AZN", "Azerbaijanian Manat");
            _entries[946] = CreateEntry(isoCodeToSymbol, 946, "RON", "Romanian Leu");
            _entries[949] = CreateEntry(isoCodeToSymbol, 949, "TRY", "Türk Lirası");
            _entries[950] = CreateEntry(isoCodeToSymbol, 950, "XAF", "CFA Franc (BEAC)");
            _entries[951] = CreateEntry(isoCodeToSymbol, 951, "XCD", "East Caribbean Dollar");
            _entries[952] = CreateEntry(isoCodeToSymbol, 952, "XOF", "CFA Franc (BCEAO)");
            _entries[953] = CreateEntry(isoCodeToSymbol, 953, "XPF", "CFP Franc (BEAC)");
            _entries[959] = CreateEntry(isoCodeToSymbol, 959, "XAU", "Gold");
            _entries[960] = CreateEntry(isoCodeToSymbol, 960, "XDR", "SDR");
            _entries[961] = CreateEntry(isoCodeToSymbol, 961, "XAG", "Silver");
            _entries[962] = CreateEntry(isoCodeToSymbol, 962, "XPT", "Platinum");
            _entries[963] = CreateEntry(isoCodeToSymbol, 963, "XTS", "");
            _entries[964] = CreateEntry(isoCodeToSymbol, 964, "XPD", "Palladium");
            _entries[968] = CreateEntry(isoCodeToSymbol, 968, "SRD", "Surinam Dollar");
            _entries[969] = CreateEntry(isoCodeToSymbol, 969, "MGA", "Malagasy Ariary");
            _entries[971] = CreateEntry(isoCodeToSymbol, 971, "AFN", "Afghan Afghani");
            _entries[972] = CreateEntry(isoCodeToSymbol, 972, "TJS", "Tajikistani Somoni");
            _entries[973] = CreateEntry(isoCodeToSymbol, 973, "AOA", "Angolan Kwanza");
            _entries[974] = CreateEntry(isoCodeToSymbol, 974, "BYR", "Belarussian Ruble");
            _entries[975] = CreateEntry(isoCodeToSymbol, 975, "BGN", "Bulgarian Lev");
            _entries[976] = CreateEntry(isoCodeToSymbol, 976, "CDF", "Franc Congolais");
            _entries[977] = CreateEntry(isoCodeToSymbol, 977, "BAM", "Bosnia and Herzegovina convertible Mark");
            _entries[978] = CreateEntry(isoCodeToSymbol, 978, "EUR", "Euro");
            _entries[980] = CreateEntry(isoCodeToSymbol, 980, "UAH", "Ukrainian Hryvnia");
            _entries[981] = CreateEntry(isoCodeToSymbol, 981, "GEL", "Georgian Lari");
            _entries[985] = CreateEntry(isoCodeToSymbol, 985, "PLN", "Polish Złoty");
            _entries[986] = CreateEntry(isoCodeToSymbol, 986, "BRL", "Brazilian Real");
            _entries[999] = CreateEntry(isoCodeToSymbol, 999, "XXX", "");

            foreach (var entry in _entries.Values)
            {
                var isoCode = entry.IsoCode;
                var symbol = entry.Symbol;

                List<string> names;
                if (isoCodeToName.TryGetValue(isoCode, out names))
                {
                    foreach (var name in names)
                    {
                        _nameToIsoNumber[name] = entry.IsoNumber;
                    }
                    _isoNumberToName[entry.IsoNumber] = names;
                }

                _isoCodeToIsoNumber[isoCode] = entry.IsoNumber;

                if (symbol == null)
                    continue;

                List<short> isoNumbers;
                if (!_symbolToIsoNumbers.TryGetValue(symbol, out isoNumbers))
                {
                    isoNumbers = new List<short>();
                    _symbolToIsoNumbers[symbol] = isoNumbers;
                }

                isoNumbers.Add(entry.IsoNumber);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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

#if !NETSTANDARD1_6
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
