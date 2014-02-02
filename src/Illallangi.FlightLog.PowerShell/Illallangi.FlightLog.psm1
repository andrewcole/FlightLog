if ($null -eq (Get-Module PSCompletion))
{
	Write-Debug "Import-Module PSCompletion -Global"
	Import-Module PSCompletion -Global -ErrorAction SilentlyContinue
	if ($null -eq (Get-Module PSCompletion))
	{
		Write-Warning "PSCompletion module not found; tab completion will be unavailable."
	}
}

if ($null -ne (Get-Module PSCompletion))
{
	Register-ParameterCompleter Add-City Country {
		param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
		Get-Country -Name "$wordToComplete*" | Sort-Object { $_.Name } |%{ New-CompletionResult """$($_.Name)""" }
	}

	Register-ParameterCompleter Add-Trip Year {
		param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
		Get-Year -Name "$wordToComplete*" | Sort-Object { $_.Name } |%{ New-CompletionResult """$($_.Name)""" }
	}

	Write-Debug "Register-ParameterCompleter Add-Flight Year {}"
	Register-ParameterCompleter Add-Flight Year {
		param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
		Get-Year -Name "$wordToComplete*" | Sort-Object { $_.Name } |%{ New-CompletionResult """$($_.Name)""" }
	}

	Write-Debug "Register-ParameterCompleter Add-Flight Trip {}"
	Register-ParameterCompleter Add-Flight Trip {
		param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)
		Get-Trip | Where-Object { $_.Name -Like "$wordToComplete*" } | Sort-Object { $_.Name } |%{ New-CompletionResult """$($_.Name)""" }
	}
}

Function Get-Data
{
    param(
        [string]$Source,
		[string]$Destination,
        [System.Net.WebClient]$WebClient = (New-Object System.Net.WebClient)
    )
	Begin
    {
        Write-Debug "Get-Data -Source ""$($Source)"" -Destination ""$($Destination)"" -WebClient ""$($WebClient)"""

        if ((Test-Path $Destination) -ne $true)
		{
			$WebClient.DownloadFile($Source, $Destination)
        }

        Import-Csv $Destination
    }
}

Function Get-AirportsData
{
    param(
        [string]$Source = "http://sourceforge.net/p/openflights/code/HEAD/tree/openflights/data/airports.dat?format=raw",
		[string]$Destination = "$($env:temp)\airports.dat",
        [System.Net.WebClient]$WebClient = (New-Object System.Net.WebClient)
    )
	Begin
	{
		Write-Debug "Get-AirportsData -Source ""$($Source)"" -Destination ""$($Destination)"" -WebClient ""$($WebClient)"""

        if ((Test-Path $Destination) -ne $true)
		{
			$WebClient.DownloadFile($Source, $Destination)
			$Airports = (import-csv $Destination -Header ("Id","Name","City","Country","Iata","Icao","Latitude","Longitude","Altitude","Timezone","DST"))
			$Airports | Where-Object { $_.Name -NotMatch "\?" -and $_.City -NotMatch "\?" -and $_.Country -NotMatch "\?" } | export-csv -NoTypeInformation $Destination
		}

		Import-Csv $destination
	}
}

Function Get-FlightsData
{
    param(
        $Source = [string]"https://gist.github.com/andrewcole/8760689/raw/c8e1cbfa57863cd1df8ffd3d4088c3daf3dc0dde/flights.csv",
        $Destination = [string]"$($env:temp)\flights.dat"
    )
    Begin
    {
        Write-Debug "Get-FlightsData -Source ""$($Source)"" -Destination ""$($Destination)"""

        Get-Data -Source $source -Destination $destination
    }
}

Function Get-AirportTimezonesData
{
    param(
        $Source = [string]"https://gist.github.com/andrewcole/8760689/raw/56f978c5fda691fd86c4c5848c042b33b12bc27c/airportTimezones.csv",
        $Destination = [string]"$($env:temp)\airportTimezones.dat"
    )
    Begin
    {
        Write-Debug "Get-AirportTimezonesData -Source ""$($Source)"" -Destination ""$($Destination)"""

        Get-Data -Source $source -Destination $destination
    }
}

Function Get-AirportTimezone
{
    param(
		[string]$Icao
    )
    Begin
    {
        Write-Debug "Get-AirportTimezone -Icao ""$($Icao)"""
        
        $result = (Get-AirportTimezonesData | Where-Object { $_.Icao -eq "$($Icao)" }).Timezone
        if (($null -eq $result) -or ("" -eq $result))
        {
            Write-Warning "Airport ""$($Icao)"" not found; returning ""Unknown/Unknown"" timezone"
            "Unknown/Unknown"
        }
        else
        {
            $result
        }
    }
}


Function Get-TripDescriptionsData
{
    param(
        $Source = [string]"https://gist.github.com/andrewcole/8760689/raw/8375a5eac48e3433b0a85342a68a1c1e57bc7c31/tripDescriptions.csv",
        $Destination = [string]"$($env:temp)\tripDescriptions.dat"
    )
    Begin
    {
        Write-Debug "Get-TripDescriptionsData -Source ""$($Source)"" -Destination ""$($Destination)"""

        Get-Data -Source $source -Destination $destination
    }
}

Function Get-TripDescription
{
    param(
		[string]$Year,
        [string]$Trip
    )
    Begin
    {
        Write-Debug "Get-TripDescription -Year ""$($Year)"" -Trip ""$($Trip)"""

        (Get-TripDescriptionsData | Where-Object { ($_.Year -eq "$($Year)") -and ($_.Trip -eq "$($Trip)") }).Description
    }
}

Function Get-CountrySample
{
	Begin
	{
		$destination = "$($env:temp)\countries.csv"

		if ((Test-Path $destination) -ne $true)
		{
			Get-AirportsData | Select-Object Country | Sort-Object -Unique Country | Where-Object { $_.Country -NotMatch "\?" } | Export-Csv -NoTypeInformation $destination
		}

		import-csv $destination
	}
}


Function Get-CitySample
{
	Begin
	{
		$destination = "$($env:temp)\cities.csv"

		if ((Test-Path $destination) -ne $true)
		{
			Get-AirportsData | Select-Object City, Country | Sort-Object -Unique City, Country | Where-Object { $_.City -NotMatch "\?" -and $_.Country -NotMatch "\?" } | Export-Csv -NoTypeInformation $destination
		}

		import-csv $destination
	}
}

Function Get-AirportSample
{
	Begin
	{
		$destination = "$($env:temp)\airports.csv"

		if ((Test-Path $destination) -ne $true)
		{
			Get-AirportsData | Select-Object Name, City, Country, @{n='Timezone';e={Get-AirportTimezone -Icao $_.Icao}}, Iata, Icao, Latitude, Longitude, Altitude | Sort-Object -Unique Name, City, Country, Iata, Icao, Latitude, Longitude, Altitude, Timezone | Where-Object { $_.Name -NotMatch "\?" -and $_.City -NotMatch "\?" -and $_.Country -NotMatch "\?" -and $_.Icao -Match "...." -and $_.Iata -Match "..." } | Export-Csv -NoTypeInformation $destination
		}

		import-csv $destination
	}
}

Function Get-TimezoneSample
{
    Begin
    {
        $destination = "$($env:temp)\timezones.csv"

		if ((Test-Path $destination) -ne $true)
		{
			Get-AirportSample | Select-Object Timezone | Sort-Object -Unique Timezone | Export-Csv -NoTypeInformation $destination
		}

		import-csv $destination
    }
}


Function Get-YearSample
{
    Begin
    {
        $destination = "$($env:temp)\years.csv"

		if ((Test-Path $destination) -ne $true)
		{
			Get-FlightsData | Select-Object Year | Sort-Object -Unique Year | Export-Csv -NoTypeInformation $destination
		}

		import-csv $destination
    }
}

Function Get-TripSample
{
    Begin
    {
        $destination = "$($env:temp)\trips.csv"

		if ((Test-Path $destination) -ne $true)
		{
            Get-FlightsData | Select-Object Year, Trip, @{n='Description';e={Get-TripDescription -Year $_.Year -Trip $_.Trip}} | Sort-Object -Unique Year, Trip, Description | Export-Csv -NoTypeInformation $destination
		}

        import-csv $destination
    }
}


Function Get-FlightSample
{
	Begin
	{
		$destination = "$($env:temp)\flights.csv"
        
		if ((Test-Path $destination) -ne $true)
		{
            Get-FlightsData | Select-Object Year, Trip, Origin, Destination, Departure, Arrival, Airline, Number, Aircraft, Seat, Comment | Sort-Object -Unique Year, Trip, Origin, Destination, Departure, Arrival, Airline, Number, Aircraft, Seat, Comment | Export-Csv -NoTypeInformation $destination
		}

        import-csv $destination
	}
}




Function Import-FlightLogSampleData
{
	Begin
	{
        Remove-Flight -Confirm:$false
        Remove-Trip -Confirm:$false
        Remove-Year -Confirm:$false
        Remove-Airport -Confirm:$false
        Remove-City -Confirm:$false
        Remove-Country -Confirm:$false
        Remove-Timezone -Confirm:$false

        
        Get-TimezoneSample | Import-Timezone
		Get-CountrySample | Import-Country
        Get-CitySample | Import-City
        Get-AirportSample | Import-Airport
        Get-YearSample | Import-Year
        Get-TripSample | Import-Trip
        Get-FlightSample | Import-Flight
	}
}