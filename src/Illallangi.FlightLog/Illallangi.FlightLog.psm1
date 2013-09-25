Function Get-SampleData
{
	param(
		[string]$Href,
		[string]$Cache,
		[string[]]$Header,
		[System.Net.WebClient]$WebClient = (New-Object System.Net.WebClient)
	)

	Begin
	{
		If (Test-Path $cache)
		{
			Write-Host "Using cached copy of $($href)"
		}
		else
		{
			Write-Host "Downloading $($href)"
			$WebClient.DownloadFile($href,$cache)
		}

		Import-Csv -Path $cache -Header $Header
	}
}

Function Get-SampleAirports
{
	Begin
	{
		$Href = "http://sourceforge.net/p/openflights/code/HEAD/tree/openflights/data/airports.dat?format=raw"
		$Cache = "$($env:LocalAppData)\Illallangi\FlightLog\airports.dat"
		Get-SampleData -Href $Href -Cache $Cache -Header "ID","Name","City","Country","Iata","Icao","Latitude","Longitude","Altitude","Timezone","Dst"
	}
}

Function Get-SampleAirlines
{
	Begin
	{
		$Href = "http://sourceforge.net/p/openflights/code/HEAD/tree/openflights/data/airlines.dat?format=raw"
		$Cache = "$($env:LocalAppData)\Illallangi\FlightLog\airlines.dat"
		Get-SampleData -Href $Href -Cache $Cache -Header "ID","Name","Alias","Iata","ICAO","Callsign","Country","Active"
	}
}


Function Import-SampleFlightLogData
{
	Begin
	{
		Get-SampleAirlines | Add-Airline
		Get-SampleAirports | Add-Airport
	}
}