using Refit;
using Telegram.Bot.Api.Client.Models.Requests;
using ResponseModel = Telegram.Bot.Api.Client.Models.Responses;

namespace Telegram.Bot.Api.Client.Interfaces;

[Headers("User-Agent: Telegram.Bot.Api.Client", "Accept: application/json", "Content-Type: application/json")]
public interface ITelegramBotApi
{
	[Post("/bot{token}/sendMessage")]
	Task<ApiResponse<ResponseModel.SendMessageModel>> SendMessageAsync(string token, [Body] SendMessageModel payload);
}
