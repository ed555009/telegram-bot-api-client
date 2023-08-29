using System.Text.Json.Serialization;
using Telegram.Bot.Api.Client.Enums;
using Telegram.Bot.Api.Client.Interfaces;

namespace Telegram.Bot.Api.Client.Models.Responses;

/// <summary>
/// This object represents a chat.<br/>
/// https://core.telegram.org/bots/api#chat
/// </summary>
public class ChatModel : IBaseResponseModel
{
	/// <summary>
	/// Unique identifier for this chat.<br/>
	/// This number may have more than 32 significant bits and some programming languages may have difficulty/silent
	/// defects in interpreting it. But it has at most 52 significant bits, so a signed 64-bit integer or
	/// double-precision float type are safe for storing this identifier.
	/// </summary>
	public long? Id { get; set; }

	/// <summary>
	/// Type of chat<br/>
	/// Can be either Private, Group, Supergroup or Channel
	/// </summary>
	public ChatType? Type { get; set; }

	/// <summary>
	/// Optional. Title, for supergroups, channels and group chats
	/// </summary>
	public string? Title { get; set; }

	/// <summary>
	/// Optional. Username, for private chats, supergroups and channels if available
	/// </summary>
	public string? Username { get; set; }

	/// <summary>
	/// Optional. First name of the other party in a private chat
	/// </summary>
	[JsonPropertyName("first_name")]
	public string? FirstName { get; set; }

	/// <summary>
	/// Optional. Last name of the other party in a private chat
	/// </summary>
	[JsonPropertyName("last_name")]
	public string? LastName { get; set; }

	/// <summary>
	/// Optional. True, if the supergroup chat is a forum (has <a href="https://telegram.org/blog/topics-in-groups-collectible-usernames#topics-in-groups">topics</a> enabled)
	/// </summary>
	[JsonPropertyName("is_forum")]
	public bool? IsForum { get; set; }

	//TODO: add the rest fields
}
