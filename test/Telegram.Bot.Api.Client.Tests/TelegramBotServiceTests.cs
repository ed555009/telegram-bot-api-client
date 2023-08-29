using System.Net;
using Moq;
using Telegram.Bot.Api.Client.Configs;
using Telegram.Bot.Api.Client.Interfaces;
using Telegram.Bot.Api.Client.Models.Requests;
using Telegram.Bot.Api.Client.Services;
using Telegram.Bot.Api.Client.Tests.Base;
using Xunit.Abstractions;
using ResponseModel = Telegram.Bot.Api.Client.Models.Responses;

namespace Telegram.Bot.Api.Client.Tests;

public class TelegramBotServiceTests : BaseServiceTests
{
	private readonly Mock<ITelegramBotApi> _telegramBotApiMock;
	private readonly Mock<TelegramBotApiConfig> _telegramBotApiConfigMock;
	private readonly TelegramBotApiConfig _telegramBotApiConfig;
	private readonly ITelegramBotService _telegramBotService;

	public TelegramBotServiceTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
	{
		_telegramBotApiMock = new Mock<ITelegramBotApi>();
		_telegramBotApiConfigMock = new Mock<TelegramBotApiConfig>();
		_telegramBotApiConfig = new() { BaseUrl = TelegramBotApiConfig.BaseUrl, Token = TelegramBotApiConfig.Token };
		_telegramBotService = new TelegramBotService(_telegramBotApiMock.Object, _telegramBotApiConfig);
	}

	[Theory]
	[InlineData(null)]
	[InlineData("MyToken")]
	public async void SendMessageAsync_ShouldSucceed(string? token)
	{
		// Given
		_ = _telegramBotApiMock
			.Setup(x => x.SendMessageAsync(It.IsAny<string>(), It.IsAny<SendMessageModel>()))
			.Returns(CreateResponse<ResponseModel.SendMessageModel>(HttpStatusCode.OK));

		// When
		var result = await _telegramBotService.SendMessageAsync(new() { ChatId = "123", Text = "Test" }, token);

		// Then
		Assert.Equal(HttpStatusCode.OK, result.StatusCode);
	}

	[Theory]
	[InlineData(null, null)]
	[InlineData("123", null)]
	[InlineData(null, "text")]
	public void SendMessageAsync_WithoutRequiredData_ShouldThrow(string? chatId, string? text)
	{
		// Given

		// When
		var ex = Assert.ThrowsAsync<ArgumentNullException>(() =>
			_telegramBotService.SendMessageAsync(new() { ChatId = chatId, Text = text }));

		// Then
		Assert.NotNull(ex);
	}
}
