using System.Runtime.Serialization;

namespace Telegram.Bot.Api.Client.Enums;

/// <summary>
/// Type of chat<br/>
/// can be either Private, Group, Supergroup or Channel
/// </summary>
public enum ChatType
{
	[EnumMember(Value = "private")]
	Private,

	[EnumMember(Value = "group")]
	Group,

	[EnumMember(Value = "supergroup")]
	Supergroup,

	[EnumMember(Value = "channel")]
	Channel
}
