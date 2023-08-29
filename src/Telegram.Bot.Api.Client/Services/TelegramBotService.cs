using Refit;
using Telegram.Bot.Api.Client.Configs;
using Telegram.Bot.Api.Client.Interfaces;
using Telegram.Bot.Api.Client.Models.Requests;
using ResponseModel = Telegram.Bot.Api.Client.Models.Responses;

namespace Telegram.Bot.Api.Client.Services;

public class TelegramBotService : ITelegramBotService
{
	private readonly ITelegramBotApi _telegramBotApi;
	private readonly TelegramBotApiConfig _telegramBotApiConfig;

	public TelegramBotService(ITelegramBotApi telegramBotApi, TelegramBotApiConfig telegramBotApiConfig)
	{
		_telegramBotApi = telegramBotApi;
		_telegramBotApiConfig = telegramBotApiConfig;
	}

	public async Task<ApiResponse<ResponseModel.SendMessageModel>> SendMessageAsync(
		SendMessageModel data,
		string? token = null)
	{
		ValidateToken(token ?? _telegramBotApiConfig.Token);
		ArgumentNullException.ThrowIfNull(data.ChatId, nameof(data.ChatId));
		ArgumentNullException.ThrowIfNull(data.Text, nameof(data.Text));

		return await _telegramBotApi.SendMessageAsync(token ?? _telegramBotApiConfig.Token!, data);
	}

	void ValidateToken(string? token) => ArgumentNullException.ThrowIfNull(token, nameof(token));
}
