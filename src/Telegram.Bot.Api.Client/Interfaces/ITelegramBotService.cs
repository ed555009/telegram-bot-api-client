using Refit;
using Telegram.Bot.Api.Client.Models.Requests;
using ResponseModel = Telegram.Bot.Api.Client.Models.Responses;

namespace Telegram.Bot.Api.Client.Interfaces;

public interface ITelegramBotService
{
	/// <summary>
	/// Send message<br/>
	/// Use this method to send text messages.
	/// On success, the sent <a href="https://core.telegram.org/bots/api#message">Message</a> is returned.<br/>
	/// https://core.telegram.org/bots/api#sendmessage
	/// </summary>
	Task<ApiResponse<ResponseModel.SendMessageModel>> SendMessageAsync(SendMessageModel data, string? token = null);
}
