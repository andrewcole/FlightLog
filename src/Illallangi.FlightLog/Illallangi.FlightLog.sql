CREATE VIRTUAL TABLE Country
	USING zumero
	(
		CountryId INTEGER PRIMARY KEY AUTOINCREMENT,
        CountryName TEXT,
		Unique (CountryName)
    );

CREATE VIRTUAL TABLE City
    USING zumero
	(
		CityId INTEGER PRIMARY KEY AUTOINCREMENT,
		CountryId INTEGER NOT NULL REFERENCES Country(CountryId),
		CityName TEXT,
		Unique(CityName, CountryId)
    );

CREATE VIRTUAL TABLE Airport
	USING zumero
	(
		AirportId INTEGER PRIMARY KEY AUTOINCREMENT,
		CityId INTEGER NOT NULL REFERENCES City(CityId),
		AirportName TEXT,
		Iata TEXT NOT NULL,
		Icao TEXT NOT NULL,
		Latitude DOUBLE NOT NULL,
		Longitude DOUBLE NOT NULL,
		Altitude DOUBLE NOT NULL,
		Timezone TEXT NOT NULL,
		Unique(AirportName, CityId)
    );

CREATE VIEW Airports
	AS
		SELECT
            Country.CountryId as CountryId,
			Country.CountryName as CountryName,
            City.CityId as CityId,
            City.CityName as CityName,
            Airport.AirportId as AirportId,
            Airport.AirportName as AirportName,
            Airport.Iata as Iata,
		    Airport.Icao as Icao,
		    Airport.Latitude as Latitude,
		    Airport.Longitude as Longitude,
		    Airport.Altitude as Altitude,
		    Airport.Timezone as Timezone
        FROM
            z$Country as Country
            INNER JOIN z$City as City
                ON Country.CountryId = City.CountryId
            INNER JOIN z$Airport as Airport
                ON City.CityId = Airport.CityId;

CREATE VIEW Cities
	AS
		SELECT
			Country.CountryName as CountryName,
            City.CityId as CityId,
            City.CityName as Name,
            Count (Airport.AirportId) as Airports
        FROM
            z$Country as Country
            INNER JOIN z$City as City
                ON Country.CountryId = City.CountryId
            LEFT JOIN z$Airport as Airport
                ON City.CityId = Airport.CityId
        GROUP BY
            Country.CountryId,
            Country.CountryName,
            City.CityId,
            City.CityName;

CREATE VIEW Countries
	AS
		SELECT
            Country.CountryId as CountryId,
			Country.CountryName as CountryName,
            Count (City.CityId) as Cities,
            Count (Airport.AirportId) as Airports
        FROM
            z$Country as Country
            LEFT JOIN z$City as City
                ON Country.CountryId = City.CountryId
            LEFT JOIN z$Airport as Airport
                ON City.CityId = Airport.CityId
        GROUP BY
            Country.CountryId,
            Country.CountryName;