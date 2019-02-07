# Money & Currency

[![Build status](https://lsquared.visualstudio.com/Money/_apis/build/status/Build%20and%20publish)](https://lsquared.visualstudio.com/Money/_build/latest?definitionId=2)

## Documentation

### Currency

This assembly contains all information to handle currencies in .Net.

You can use currency in different ways:

- with ISO-3166-N code (integer)
- with ISO-3166-3A code (3-letters code)
- even via currency symbol (in this case, using the current culture to find the best match)
- from the current culture

Samples:

```csharp
var euro = new Currency(978);
var usd = new Currency("USD");
Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
var poundSterling = new Currency("£");
var türkLirası = Currency.FromCulture(new CultureInfo("tr-TR"));
```

### Money

From an amount (int or float or decimal) and a currency, you can manipulate money.

Multiple 'money' amount with same currency can be added, subtracted.
Money can also be multiplied or divided by a constant (not another money amount).

A special 'Zero' value is provided. It is the default value of a `Money`.
This value does not have any currency.

By default, `Money` use the culture of the `Currency` to format itself.

You can save a money in a single `varchar` field in any database. Serialization is handled.

Samples:

```csharp
Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");
Money m1 = 1000; // m1 == "1 000,00 €"
Money m2 = 2002; // m2 == "2 002,00 €"
var mA = m1 + m2; // mA == "3 002,00 €"
var mS = m2 - m1; // mS == "1 002,00 €"
var mM = m1 * 3; // mM == "3 000,00 €"
var mD = m2 / 3; // mD == "667,33 €"
```

```csharp
Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
Money m1 = 1000; // m1 == "$1,000.00"
Money m2 = 2002; // m2 == "$2,002.00"
var mA = m1 + m2; // mA == "$3,002.00"
var mS = m2 - m1; // mS == "$1,002.00"
var mM = m1 * 3; // mM == "$3,000.00"
var mD = m2 / 3; // mD == "$667.33"
```
