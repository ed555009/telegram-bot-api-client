using System.Text.Json.Serialization;

namespace Telegram.Bot.Api.Client.Models.Responses;

/// <summary>
/// This object represents a message.<br/>
/// https://core.telegram.org/bots/api#message
/// </summary>
public class MessageModel
{
	/// <summary>
	/// Unique message identifier inside this chat
	/// </summary>
	[JsonPropertyName("message_id")]
	public long? MessageId { get; set; }

	/// <summary>
	/// Optional. Unique identifier of a message thread to which the message belongs; for supergroups only
	/// </summary>
	[JsonPropertyName("message_thread_id")]
	public long? MessageThreadId { get; set; }

	/// <summary>
	/// Optional. Sender of the message; empty for messages sent to channels.
	/// For backward compatibility, the field contains a fake sender user in non-channel chats,
	/// if the message was sent on behalf of a chat.
	/// </summary>
	public UserModel? From { get; set; }

	/// <summary>
	/// Optional. Sender of the message, sent on behalf of a chat.
	/// For example, the channel itself for channel posts, the supergroup itself for messages from anonymous group
	/// administrators, the linked channel for messages automatically forwarded to the discussion group. For backward
	/// compatibility, the field from contains a fake sender user in non-channel chats, if the message was sent on
	/// behalf of a chat.
	/// </summary>
	[JsonPropertyName("sender_chat")]
	public ChatModel? SenderChat { get; set; }

	/// <summary>
	/// Date the message was sent in Unix time
	/// </summary>
	public int? Date { get; set; }

	/// <summary>
	/// Conversation the message belongs to
	/// </summary>
	public ChatModel? Chat { get; set; }

	/// <summary>
	/// Optional. For forwarded messages, sender of the original message
	/// </summary>
	[JsonPropertyName("forward_from")]
	public UserModel? ForwardFrom { get; set; }

	/// <summary>
	/// Optional.
	/// For messages forwarded from channels or from anonymous administrators, information about the original sender chat
	/// </summary>
	[JsonPropertyName("forward_from_chat")]
	public ChatModel? ForwardFromChat { get; set; }

	/// <summary>
	/// Optional. For messages forwarded from channels, identifier of the original message in the channel
	/// </summary>
	[JsonPropertyName("forward_from_message_id")]
	public long? ForwardFromMessageId { get; set; }

	/// <summary>
	/// Optional. For text messages, the actual UTF-8 text of the message
	/// </summary>
	public string? Text { get; set; }

	//TODO: add the rest fields
}
