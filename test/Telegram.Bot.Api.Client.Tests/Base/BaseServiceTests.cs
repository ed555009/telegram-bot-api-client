using System.Net;
using Refit;
using Telegram.Bot.Api.Client.Configs;
using Telegram.Bot.Api.Client.Interfaces;
using Xunit.Abstractions;

namespace Telegram.Bot.Api.Client.Tests.Base;

public abstract class BaseServiceTests
{
	protected readonly ITestOutputHelper TestOutputHelper;
	protected readonly TelegramBotApiConfig TelegramBotApiConfig;

	public BaseServiceTests(ITestOutputHelper testOutputHelper)
	{
		TestOutputHelper = testOutputHelper;
		TelegramBotApiConfig = new()
		{
			BaseUrl = "http://localhost:5000",
			Token = "MyToken"
		};
	}

	protected static Task<ApiResponse<T>> CreateResponse<T>(HttpStatusCode statusCode) where T : IBaseResponseModel =>
		Task.FromResult(new ApiResponse<T>(
			new HttpResponseMessage(statusCode),
			default,
			new RefitSettings()));

	protected static Task<ApiResponse<object?>> CreateEmptyResponse(HttpStatusCode statusCode) =>
		Task.FromResult(new ApiResponse<object?>(
			new HttpResponseMessage(statusCode),
			default,
			new RefitSettings()));
}
