using Telegram.Bot.Api.Client.Interfaces;

namespace Telegram.Bot.Api.Client.Models.Responses;

public class BaseResponseModel : IBaseResponseModel
{
	public bool Ok { get; set; }
}
