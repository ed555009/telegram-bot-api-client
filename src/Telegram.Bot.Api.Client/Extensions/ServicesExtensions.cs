using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using Telegram.Bot.Api.Client.Configs;
using Telegram.Bot.Api.Client.Interfaces;
using Telegram.Bot.Api.Client.Services;

namespace Telegram.Bot.Api.Client.Extensions;

public static class ServicesExtensions
{
	public static IServiceCollection AddTelegramBotServices(
		this IServiceCollection services,
		IConfiguration configuration,
		ServiceLifetime serviceLifetime = ServiceLifetime.Singleton)
	{
		var config = GetNotifyApiConfig(configuration);
		var refitSettings = GetRefitSettings();

		_ = services
			.AddSingleton(config ?? throw new ArgumentNullException(nameof(config)))
			.AddRefitClient<ITelegramBotApi>(refitSettings)
			.ConfigureHttpClient(c =>
				c.BaseAddress = new Uri(config.BaseUrl ?? throw new ArgumentNullException(nameof(config.BaseUrl))));

		return serviceLifetime switch
		{
			ServiceLifetime.Scoped => services.AddScoped<ITelegramBotService, TelegramBotService>(),
			ServiceLifetime.Transient => services.AddTransient<ITelegramBotService, TelegramBotService>(),
			_ => services.AddSingleton<ITelegramBotService, TelegramBotService>()
		};
	}

	static TelegramBotApiConfig? GetNotifyApiConfig(IConfiguration configuration) =>
		configuration
			.GetSection("Telegram")
			.GetSection("BotApi")
			.Get<TelegramBotApiConfig>();

	static RefitSettings GetRefitSettings() =>
		new()
		{
			ContentSerializer = new SystemTextJsonContentSerializer(new JsonSerializerOptions
			{
				Converters =
				{
					new JsonStringEnumConverter()
				},
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
				DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
				ReferenceHandler = ReferenceHandler.IgnoreCycles,
				NumberHandling = JsonNumberHandling.AllowReadingFromString,
				PropertyNameCaseInsensitive = true
			})
		};
}
