//**********************************************************
// Hotels
//**********************************************************
using TravelNet.Vakanties;
using TravelNet.Verblijven;
using TravelNet;
using System.Text.RegularExpressions;

Hotel albergoNero = new Hotel("Albergo Nero", 120m, true, true, 0m);
Hotel capella = new Hotel("Capella", 150m, false, false, null);
Hotel hotelletFrokost = new Hotel("Hotellet Frokost", 200m, true, true, 75m);
Hotel meniBeach = new Hotel("MeniBeach", 100m, true, true, 50m);

//**********************************************************
// Appartementen
//**********************************************************
Appartement casaBlanca = new Appartement("Casa Blanca", 150m, false, 20m, true);
Appartement parcoVista = new Appartement("Parco Vista", 100m, false, 15m, true);
Appartement hviteHus = new Appartement("Hvite Hus", 125m, false, 15m, false);
Appartement husetSvart = new Appartement("Huset Svart", 200m, true, 20m, false);

//**********************************************************
//Vakantiehuizen
//**********************************************************
Vakantiehuis fioriTorre = new Vakantiehuis("Fiori Torre", 150m, false, 15m, 5m);
Vakantiehuis gronnpark = new Vakantiehuis("Gronnpark", 120m, false, 10m, 10m);
Vakantiehuis blomsterTarnet = new Vakantiehuis("BlomsterTarnet", 100m, false, 10m, 10m);
Vakantiehuis visning = new Vakantiehuis("Visning", 200m, false, 20m, 10m);



//**********************************************************
//Routes
//**********************************************************

Route routeLucca = new Route("Lucca", "Prato", casaBlanca, Formule.Ontbijt);
Route routePrato = new Route("Prato", "Bologna", albergoNero, Formule.Ontbijt);
Route routeBologna = new Route("Bologna", "Arezzo", parcoVista, Formule.HalfPension);
Route routeArezzo = new Route("Arezzo", "Livorno", fioriTorre, Formule.Ontbijt);
Route routeLivorno = new Route("Livorno", "Firenze", capella, Formule.Ontbijt);
Route routeStavanger = new Route("Stavanger", "EgerSund", hviteHus, Formule.Ontbijt);
Route routeEgerSund = new Route("EgerSund", "Kragera", husetSvart, Formule.Ontbijt);
Route routeKragera = new Route("Kragera", "Porsgrunn", gronnpark, Formule.Ontbijt);
Route routePorsgrunn = new Route("Porsgrunn", "Drammen", blomsterTarnet, Formule.Ontbijt);
Route routeDrammen = new Route("Drammen", "Oslo", visning, Formule.Ontbijt);
Route routeOslo = new Route("Oslo", "Moss", hotelletFrokost, Formule.Ontbijt);
Route routeAthene = new Route("Athene", "Kos", meniBeach, Formule.VolPension);



//**********************************************************
//Activiteiten
//**********************************************************
MTB volwassenenFiets = new MTB
{
    Naam = "Volwassenenfiets",
    PrijsUitrusting = 20m,
    HuurprijsFietsPerUur = 10m,
    AantalUren = 4
};

MTB kinderFiets = new MTB
{
    Naam = "Kinderfiets",
    PrijsUitrusting = 15m,
    HuurprijsFietsPerUur = 7.5m,
    AantalUren = 3
};

Cinema volwassenenCinema = new Cinema
{
    Naam = "Volwassenencinema",
    Inkom = 7.5m,
    Snoepgoed = 5m
};

Cinema kinderCinema = new Cinema
{
    Naam = "Kindercinema",
    Inkom = 5m,
    Snoepgoed = 5.25m
};

Stadsbezoek stadsbezoekAthene = new Stadsbezoek
{
    Naam = "Athene",
    PrijsGidsPer10Personen = 150m,
    AantalPersonen = 15
};

Stadsbezoek stadsbezoekRome = new Stadsbezoek
{
    Naam = "Rome",
    PrijsGidsPer10Personen = 125m,
    AantalPersonen = 12
};

Stadsbezoek stadsbezoekOslo = new Stadsbezoek
{
    Naam = "Oslo",
    PrijsGidsPer10Personen = 175m,
    AantalPersonen = 7
};

List<Vakantie> vakanties = new()
{
    new Cruise(1, Bestemming.Finland, new DateTime(2020, 8, 12), new DateTime(2020, 8, 20), new(){}, "Helsinki", "Helsinki", new(){"Turku, Rauma, Vaasa, Oulu"}, 6800m),

    new Autovakantie(2, Bestemming.Italië, new DateTime(2020, 5, 14), new DateTime(2020, 5, 19), new() { stadsbezoekRome, volwassenenCinema, volwassenenCinema, kinderCinema }, new() { routeLucca, routePrato, routeBologna, routeArezzo, routeLivorno }, WagenType.Camper, 500m),

    new Autovakantie(3, Bestemming.Noorwegen, new DateTime(2020, 8, 8), new DateTime(2020, 8, 14), new() { stadsbezoekOslo, volwassenenFiets, kinderFiets }, new() { routeStavanger, routeEgerSund, routeKragera, routePorsgrunn, routeDrammen, routeOslo }, WagenType.Camper, 600m),

    new Vliegvakantie(4, Bestemming.Griekenland, new DateTime(2020, 9, 1), new DateTime(2020, 9, 15), new(){ stadsbezoekAthene, volwassenenFiets, kinderFiets, volwassenenFiets, kinderFiets }, routeAthene, 800m)
};

var vakantiesInVolgorde = from vakantie in vakanties
                          group vakantie by vakantie.Naam into groep
                          select new { Naam = groep.Key, Vakantie = groep.ToList() };

foreach (var item in vakantiesInVolgorde)
{
    Console.WriteLine($"{item.Naam}s");
    Console.WriteLine("****************************************************************");
    foreach (var vakantie in item.Vakantie)
    {
        vakantie.ToonGegevens();
        Console.WriteLine();
    }
    Console.WriteLine();
}