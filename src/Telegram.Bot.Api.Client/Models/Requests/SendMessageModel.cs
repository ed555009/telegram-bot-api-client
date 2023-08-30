using System.Text.Json.Serialization;
using Telegram.Bot.Api.Client.Enums;
using Telegram.Bot.Api.Client.Interfaces;

namespace Telegram.Bot.Api.Client.Models.Requests;

public class SendMessageModel : IBaseRequestModel
{
	[JsonPropertyName("chat_id")]
	public string? ChatId { get; set; }

	[JsonPropertyName("text")]
	public string? Text { get; set; }

	[JsonPropertyName("parse_mode")]
	public ParseModeType? ParseMode { get; set; } = ParseModeType.MarkdownV2;
}
