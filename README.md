# Telegram.Bot.Api.Client

[![GitHub](https://img.shields.io/github/license/ed555009/telegram-bot-api-client)](LICENSE)
![Build Status](https://dev.azure.com/edwang/github/_apis/build/status/telegram-bot-api-client?branchName=master)
[![Nuget](https://img.shields.io/nuget/v/Line.Notify.Api.Client)](https://www.nuget.org/packages/Telegram.Bot.Api.Client)

![Coverage](https://sonarcloud.io/api/project_badges/measure?project=telegram-bot-api-client&metric=coverage)
![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=telegram-bot-api-client&metric=alert_status)
![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=telegram-bot-api-client&metric=reliability_rating)
![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=telegram-bot-api-client&metric=security_rating)
![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=telegram-bot-api-client&metric=vulnerabilities)

## Description

This is a .NET6 library for interacting with [Telegram Bot](https://core.telegram.org/bots) Api.

__*This library is not finished and yet very limited*__

## Quick start

### Installation

```bash
dotnet add package Telegram.Bot.Api.Client
```

### Appsettings.json

```json
{
	"Telegram": {
		"Bot": {
			"BaseUrl": "https://api.telegram.org",
			"Token": "YOUR_BOT_TOKEN"
		}
	}
}
```

### Add services

```csharp
using Telegram.Bot.Api.Client.Extensions;

ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
	// this injects as SINGLETON
	services.AddTelegramBotServices(configuration);

	// you can also inject as SCOPED or TRANSIENT by specifying the ServiceLifetime
	services.AddTelegramBotServices(configuration, ServiceLifetime.Scoped);
}
```

### Using services

```csharp
using Telegram.Bot.Api.Client.Interfaces;
using Telegram.Bot.Api.Client.Services;

public class MyProcess
{
	private readonly ITelegramBotService _telegramBotService;

	public MyProcess(ITelegramBotService telegramBotService) =>
		_telegramBotService = telegramBotService;

	public async Task SendMessageAsync()
	{
		var response = await _telegramBotService.SendMessageAsync(
			new SendMessageModel
			{
				ChatId = "123456789",
				Text = "Hello World!"
			}
		);

		// or pass in another token so you can manipulate multiple bots at the same time
		var response = await _telegramBotService.SendMessageAsync(
			new SendMessageModel
			{
				ChatId = "123456789",
				Text = "Hello World!"
			},
			"ANOTHER_BOT_TOKEN"
		);

		// you should always check if the request was successful
		if (!res.IsSuccessStatusCode || !res.Content.Ok)
			// failed
			return;

		// success, do something
		...
	}
}
```

## Reference

- [Telegram Bot Api](https://core.telegram.org/bots/api)
