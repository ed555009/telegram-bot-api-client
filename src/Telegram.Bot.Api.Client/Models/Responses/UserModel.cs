using System.Text.Json.Serialization;
using Telegram.Bot.Api.Client.Interfaces;

namespace Telegram.Bot.Api.Client.Models.Responses;

/// <summary>
/// This object represents a Telegram user or bot.<br/>
/// https://core.telegram.org/bots/api#user
/// </summary>
public class UserModel : IBaseResponseModel
{
	/// <summary>
	/// Unique identifier for this chat.<br/>
	/// This number may have more than 32 significant bits and some programming languages may have difficulty/silent
	/// defects in interpreting it. But it has at most 52 significant bits, so a signed 64-bit integer or
	/// double-precision float type are safe for storing this identifier.
	/// </summary>
	public long? Id { get; set; }

	/// <summary>
	/// True, if this user is a bot
	/// </summary>
	[JsonPropertyName("is_bot")]
	public bool? IsBot { get; set; }

	/// <summary>
	/// User's or bot's first name
	/// </summary>
	[JsonPropertyName("first_name")]
	public string? FirstName { get; set; }

	/// <summary>
	/// Optional. User's or bot's last name
	/// </summary>
	[JsonPropertyName("last_name")]
	public string? LastName { get; set; }

	/// <summary>
	/// Optional. User's or bot's username
	/// </summary>
	public string? Username { get; set; }

	/// <summary>
	/// Optional. <a href="https://en.wikipedia.org/wiki/IETF_language_tag">IETF language tag</a> of the user's language
	/// </summary>
	[JsonPropertyName("language_code")]
	public string? LanguageCode { get; set; }

	/// <summary>
	/// Optional. True, if this user is a Telegram Premium user
	/// </summary>
	[JsonPropertyName("is_premium")]
	public bool? IsPremium { get; set; }

	/// <summary>
	/// Optional. True, if this user added the bot to the attachment menu
	/// </summary>
	[JsonPropertyName("added_to_attachment_menu")]
	public bool? AddedToAttachmentMenu { get; set; }

	/// <summary>
	/// Optional. True, if the bot can be invited to groups.
	/// Returned only in <a href="https://core.telegram.org/bots/api#getme">getMe</a>.
	/// </summary>
	[JsonPropertyName("can_join_groups")]
	public bool? CanJoinGroups { get; set; }

	/// <summary>
	/// Optional. True, if <a href="https://core.telegram.org/bots/features#privacy-mode">privacy mode</a> is disabled
	/// for the bot. Returned only in <a href="https://core.telegram.org/bots/api#getme">getMe</a>.
	/// </summary>
	[JsonPropertyName("can_read_all_group_messages")]
	public bool? CanReadAllGroupMessages { get; set; }

	/// <summary>
	/// Optional. True, if the bot supports inline queries.
	/// Returned only in <a href="https://core.telegram.org/bots/api#getme">getMe</a>.
	/// </summary>
	[JsonPropertyName("supports_inline_queries")]
	public bool? SupportsInlineQueries { get; set; }
}
