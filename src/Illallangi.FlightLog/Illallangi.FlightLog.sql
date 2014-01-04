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

CREATE VIRTUAL TABLE Year
	USING zumero
	(
		YearId INTEGER PRIMARY KEY AUTOINCREMENT,
        YearName TEXT NOT NULL,
		Unique (YearName)
    );

CREATE VIRTUAL TABLE Trip
	USING zumero
	(
		TripId INTEGER PRIMARY KEY AUTOINCREMENT,
		YearId INTEGER NOT NULL REFERENCES Year(YearId),
		TripName TEXT NOT NULL,
		Description TEXT,
		Unique (YearId,TripName)
	);

CREATE VIRTUAL TABLE Flight
	USING zumero
	(
		FlightId INTEGER PRIMARY KEY AUTOINCREMENT,
		TripId INTEGER NOT NULL REFERENCES Trip(TripId),
		OriginId INTEGER NOT NULL REFERENCES Airport(AirportId),
		DestinationId INTEGER NOT NULL REFERENCES Airport(AirportId),
		Departure TEXT NOT NULL,
		Arrival TEXT NOT NULL,
		Airline TEXT NOT NULL,
		Number TEXT NOT NULL,
		Aircraft TEXT,
		Seat TEXT,
		Note TEXT,
		Unique (TripId,OriginId,DestinationId)
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

CREATE VIEW Years
	AS
		SELECT
            Year.YearId as YearId,
			Year.YearName as YearName,
			Count (Trip.TripId) as TripCount
        FROM
            z$Year as Year
			LEFT JOIN z$Trip as Trip
				ON Year.YearId = Trip.YearId
		GROUP BY
			Year.YearId,
			Year.YearName;

CREATE VIEW Trips
	AS
		SELECT
			Trip.TripId as TripId,
			Trip.TripName as TripName,
			Trip.Description as Description,
			Year.YearName as YearName,
			Count(Flight.FlightId) as FlightCount
		FROM
			z$Trip as Trip
			INNER JOIN z$Year as Year
				ON Trip.YearId = Year.YearId
			LEFT JOIN z$Flight as Flight
				On Trip.TripId = Flight.TripId
		GROUP BY
			Trip.TripId,
			Trip.TripName,
			Trip.Description,
			Year.YearName;

CREATE VIEW Flights
	AS
		SELECT
			Flight.FlightId as FlightId,
			Flight.Airline as Airline,
			Flight.Number as Number,
			Flight.Note as Note,
			Flight.Departure as Departure,
			Flight.Arrival as Arrival,
			Flight.Seat as Seat,
			Flight.Aircraft as Aircraft,
			Trip.TripName as TripName,
			Year.YearName as YearName,
			Origin.Icao as OriginIcao,
			Origin.Timezone as OriginTimezone,
			Destination.Icao as DestinationIcao,
			Destination.Timezone as DestinationTimezone
		FROM
			z$Flight as Flight
			INNER JOIN z$Trip as Trip
				ON Flight.TripId = Trip.TripId
			INNER JOIN z$Year as Year
				ON Trip.YearId = Year.YearId
			INNER JOIN z$Airport as Origin
				ON Flight.OriginId = Origin.AirportId
			INNER JOIN z$Airport as Destination
				ON Flight.DestinationId = Destination.AirportId