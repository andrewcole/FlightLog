CREATE VIRTUAL TABLE Country
	USING zumero
	(
		CountryId INTEGER PRIMARY KEY AUTOINCREMENT,
		CountryName TEXT NOT NULL,
		Unique (CountryName)
	);

CREATE VIRTUAL TABLE City
	USING zumero
	(
		CityId INTEGER PRIMARY KEY AUTOINCREMENT,
		CountryId INTEGER NOT NULL REFERENCES Country(CountryId),
		CityName TEXT NOT NULL,
		Unique(CountryId, CityName)
	);

CREATE VIRTUAL TABLE Airport
	USING zumero
	(
		AirportId INTEGER PRIMARY KEY AUTOINCREMENT,
		CityId INTEGER NOT NULL REFERENCES City(CityId),
		AirportName TEXT NOT NULL,
		Icao TEXT NOT NULL,
		Iata TEXT NOT NULL,
		Latitude DOUBLE NOT NULL,
		Longitude DOUBLE NOT NULL,
		Altitude DOUBLE NOT NULL,
		Timezone TEXT NOT NULL,
		Unique(CityId, AirportName),
		Unique(Icao),
		Unique(Iata),
		Unique(Latitude, Longitude)
    );



CREATE VIEW Airports
	AS
		SELECT
			Country.CountryName as CountryName,
			City.CityName as CityName,
            Airport.AirportId as AirportId,
			Airport.AirportName as AirportName,
			Airport.Icao as Icao,
			Airport.Iata as Iata,
			Airport.Latitude as Latitude,
			Airport.Longitude as Longitude,
			Airport.Altitude as Altitude,
			Airport.Timezone as Timezone
		FROM
			z$Airport as Airport
			INNER JOIN z$City as City
				On Airport.CityId = City.CityId
			INNER JOIN z$Country as Country
				ON City.CountryId = Country.CountryId;

CREATE VIEW Cities
	AS
		SELECT
			City.CityId as CityId,
			City.CityName as CityName,
			Country.CountryName as CountryName,
			Count(Airport.AirportId) as AirportCount
		FROM
			z$City as City
			INNER JOIN z$Country as Country
				ON City.CountryId = Country.CountryId
			LEFT JOIN z$Airport as Airport
				On City.CityId = Airport.CityId
		GROUP BY
			City.CityId,
			City.CityName,
			Country.CountryName;
			
CREATE VIEW Countries
	AS
		SELECT
			Country.CountryId as CountryId,
			Country.CountryName as CountryName,
			Count (City.CityId) as CityCount,
			Count (Airport.AirportId) as AirportCount
        FROM
            z$Country as Country
            LEFT JOIN z$City as City
                ON Country.CountryId = City.CountryId
            LEFT JOIN z$Airport as Airport
                ON City.CityId = Airport.CityId
        GROUP BY
            Country.CountryId,
            Country.CountryName;