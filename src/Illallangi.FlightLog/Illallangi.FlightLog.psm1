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

Function Get-OpenFlightsSampleData
{
	Begin
	{
		$source = "http://sourceforge.net/p/openflights/code/HEAD/tree/openflights/data/airports.dat?format=raw"
		$destination = "$($env:temp)\airports.dat"

		if ((Test-Path $destination) -ne $true)
		{
			Write-Host "Downloading $($source)"
			$wc = New-Object System.Net.WebClient
			$wc.DownloadFile($source, $destination)
			$Airports = (import-csv $destination -Header ("Id","Name","City","Country","IATA","ICAO","Latitude","Longitude","Altitude","Timezone","DST"))
			$Airports | export-csv $destination
		}

		import-csv $destination
	}
}

Function Get-FlightSampleData
{
	Begin
	{
		$source = "https://gist.github.com/andrewcole/b9aa3ee4eaf0199ca181/raw/54961f6f2dae139a0f7d99fc9e83b1e7cceb9d5d/flights.csv"
		$destination = "$($env:temp)\flights.csv"

		if ((Test-Path $destination) -ne $true)
		{
			Write-Host "Downloading $($source)"
			$wc = New-Object System.Net.WebClient
			$wc.DownloadFile($source, $destination)
			$Flights = (import-csv $destination)
			$Flights | export-csv $destination
		}

		import-csv $destination
	}
}

Function Get-CountrySampleData
{
	Begin
	{
		$destination = "$($env:temp)\countries.csv"

		if ((Test-Path $destination) -ne $true)
		{
			$airports = (Get-OpenFlightsSampleData)
			Write-Host "Calculating Unique Countries"
			$Airports | Select-Object Country -Unique | Export-Csv $destination
		}

		import-csv $destination
	}
}


Function Get-CitySampleData
{
	Begin
	{
		$destination = "$($env:temp)\cities.csv"

		if ((Test-Path $destination) -ne $true)
		{
			$airports = (Get-OpenFlightsSampleData)
			Write-Host "Calculating Unique Cities"
			$Airports | Select-Object Country, City -Unique | Export-Csv $destination
		}

		import-csv $destination
	}
}

Function Get-AirportSampleData
{
	Begin
	{
		$destination = "$($env:temp)\airports.csv"

		if ((Test-Path $destination) -ne $true)
		{
			$airports = (Get-OpenFlightsSampleData)
			Write-Host "Calculating Unique Airports"
			$Airports | Export-Csv $destination
		}

		import-csv $destination
	}
}

Function Import-CountrySampleData
{
	param(
		[int]$ParentProgressId = $null,
		[int]$MyProgressId = $ParentProgressId + 1
	)
	Begin
	{
		$i = 0
		$countries = (Get-CountrySampleData)
		$countryCount = $countries.Count
		foreach ($country in $countries)
		{
			$i += 1
			Write-Progress -Id $MyProgressId -ParentId $ParentProgressId -Activity "Importing Countries" -status "$($country.Country) ($($i) / $($countryCount))" -PercentComplete (($i / $countryCount) * 100)
			Add-Country -Name $country.Country
		}
	}
}

Function Import-CitySampleData
{
	param(
		[int]$ParentProgressId = $null,
		[int]$MyProgressId = $ParentProgressId + 1
	)
	Begin
	{
		$i = 0
		$cities = (Get-CitySampleData)
		$cityCount = $cities.Count
		foreach ($city in $cities)
		{
			$i += 1
			Write-Progress -Id $MyProgressId -ParentId $ParentProgressId -Activity "Importing Cities" -status "$($city.City), $($city.Country) ($($i) / $($cityCount))" -PercentComplete (($i / $cityCount) * 100)
			Add-City -Name $city.City -Country $city.Country
		}
	}
}

Function Import-AirportSampleData
{
	param(
		[int]$ParentProgressId = $null,
		[int]$MyProgressId = $ParentProgressId + 1
	)
	Begin
	{
		Get-AirportSampleData |%{ Add-Airport -Name $_.Name -City $_.City -Country $_.Country -Altitude $_.Altitude -Longitude $_.Longitude -Latitude $_.Latitude -Icao $_.Icao -Iata $_.Iata  }
	}
}

Function Import-OpenFlightsSampleData
{
	param(
		[int]$ParentProgressId = $null,
		[int]$MyProgressId = $ParentProgressId + 1
	)
	Begin
	{
		Write-Progress -Id $MyProgressId -ParentId $ParentProgressId -Activity "Importing Sample Data" -Status "Importing Countries" -PercentComplete 0
		Import-CountrySampleData -ParentProgressId $MyProgressId
		Write-Progress -Id $MyProgressId -ParentId $ParentProgressId -Activity "Importing Sample Data" -Status "Importing Cities" -PercentComplete 33
		Import-CitySampleData -ParentProgressId $MyProgressId
		Write-Progress -Id $MyProgressId -ParentId $ParentProgressId -Activity "Importing Sample Data" -Status "Importing Airports" -PercentComplete 67
		Import-AirportSampleData -ParentProgressId $MyProgressId
	}
}