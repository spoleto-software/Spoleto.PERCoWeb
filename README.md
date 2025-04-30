# Spoleto.PERCoWeb

[![](https://img.shields.io/github/license/spoleto-software/Spoleto.PERCoWeb)](https://github.com/spoleto-software/Spoleto.PERCoWeb/blob/main/LICENSE)
[![](https://img.shields.io/nuget/v/Spoleto.PERCoWeb)](https://www.nuget.org/packages/Spoleto.PERCoWeb/)
![Build](https://github.com/spoleto-software/Spoleto.PERCoWeb/actions/workflows/ci.yml/badge.svg)

Spoleto.PERCoWeb is a .NET library written in C# that provides a simple and convenient way to interact with the PERCo-Web access control system API. This library allows developers to easily integrate their applications with PERCo-Web
 
This project supports .NET Standard 2.0 and .NET 8.

https://github.com/spoleto-software/Spoleto.PERCoWeb


## Key Features

•   Easy-to-use API client.
•   Asynchronous operations.
•   Serialization/deserialization of PERCo-Web API data models.
•   Authentication handling.
•   Detailed documentation and code examples.

## Installation

You can install the Spoleto.PERCoWeb library using NuGet:
```bash
Install-Package Spoleto.PERCoWeb

```

Or using the .NET CLI:
```bash
dotnet add package Spoleto.PERCoWeb
```

## Usage

Here's a basic example of how to use the Spoleto.PERCoWeb library:


```csharp
using Spoleto.PERCoWeb;

// Replace with your PERCo-Web API endpoint and credentials
var apiEndpoint = "https://your-perco-web-server/";
var username = "your_username";
var password = "your_password";
var percoWebOptions = new PercoWebOptions
{
    ServiceUrl = apiEndpoint,
    Login = apiEndpoint,
    Password = password
}
;
var provider = new PercoWebProviderFactory().WithOptions(percoWebOptions).Build();

var request = new AccessReportEventRequest(DateTime.Parse("2025-04-28"), DateTime.Parse("2025-04-30"));
request.Rows = 1000;
request.Filters = new(LogicalOperator.Or);
request.Filters.Rows.Add(new FilterRow(FilterColumn.Fio, "Иванов"));
request.Filters.Rows.Add(new FilterRow(FilterColumn.Fio, "Петров"));

// Load all access report events for the specified request:
var accessReportEvents = await provider.GetAllAccessReportEventsAsync(request);
```

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
