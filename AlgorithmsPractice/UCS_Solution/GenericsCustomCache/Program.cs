var countryToCurrencyMapping = new Dictionary<string,string>();

// Modern way to initialize a dictionary
var countryToCurrencyMapping1 = new Dictionary<string,string>
{
    ["USA"] = "USD",
    ["IND"] = "INR",
    ["SPA"] = "EUR"
};

// Old way to initialize a dictionary
var countryToCurrencyMapping2 = new Dictionary<string,string>
{
    { "USA", "USD" },
    { "IND", "INR" },
    { "SPA", "EUR" }
};

countryToCurrencyMapping.Add("USA","USD");
countryToCurrencyMapping.Add("IND","INR");
countryToCurrencyMapping.Add("SPA","EUR");
countryToCurrencyMapping.Add("ITA","EUR");
countryToCurrencyMapping.Add("FRA","EUR");

Console.WriteLine($"SPA currency is: {countryToCurrencyMapping["SPA"]}");

countryToCurrencyMapping["PND"] = "PLN";
foreach (var country in countryToCurrencyMapping)
{
    Console.WriteLine(country.Key + ", " + country.Value);
}

Console.ReadKey();