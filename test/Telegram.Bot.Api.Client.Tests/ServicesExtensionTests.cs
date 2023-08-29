using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot.Api.Client.Extensions;
using Telegram.Bot.Api.Client.Interfaces;
using Telegram.Bot.Api.Client.Services;
using Telegram.Bot.Api.Client.Tests.Base;
using Xunit.Abstractions;

namespace Telegram.Bot.Api.Client.Tests;

public class ServicesExtensionTests : BaseServiceTests
{
	private readonly string _settings;
	private readonly string _nullSettings;

	public ServicesExtensionTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
	{
		_settings = JsonSerializer.Serialize(new
		{
			Telegram = new
			{
				Bot = new
				{
					TelegramBotApiConfig.BaseUrl,
					TelegramBotApiConfig.Token
				}
			}
		});

		_nullSettings = JsonSerializer.Serialize(new
		{
			Telegram = new
			{
				Bot = new
				{
				}
			}
		});
	}

	[Fact]
	public void AddTelegramBotServices_ShouldSucceed()
	{
		// Given
		var services = new ServiceCollection();
		var builder = new ConfigurationBuilder();
		var configuration = builder.AddJsonStream(new MemoryStream(Encoding.UTF8.GetBytes(_settings))).Build();

		// When
		ServicesExtensions.AddTelegramBotServices(services, configuration);

		// Then
		Assert.Contains(services, x => x.ServiceType == typeof(ITelegramBotApi));

		Assert.Contains(services, x => x.ServiceType == typeof(ITelegramBotService)
								 && x.ImplementationType == typeof(TelegramBotService));
	}

	[Fact]
	public void AddTelegramBotServices_WithNullConfig_ShouldThrow()
	{
		// Given
		var services = new ServiceCollection();
		var builder = new ConfigurationBuilder();
		var configuration = builder.AddJsonStream(new MemoryStream(Encoding.UTF8.GetBytes(_nullSettings))).Build();

		// When
		var ex = Assert.Throws<ArgumentNullException>(() =>
			ServicesExtensions.AddTelegramBotServices(services, configuration));

		// Then
		Assert.NotNull(ex);
	}
}
