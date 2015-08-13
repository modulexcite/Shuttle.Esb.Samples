﻿using System;
using Shuttle.ESB.Core;
using Shuttle.RequestResponse.Messages;

namespace Shuttle.RequestResponse.Server
{
	public class RegisterMemberHandler : IMessageHandler<RegisterMemberCommand>
	{
		public void ProcessMessage(HandlerContext<RegisterMemberCommand> context)
		{
			Console.WriteLine();
			Console.WriteLine("[MEMBER REGISTERED] : user name = '{0}'", context.Message.UserName);
			Console.WriteLine();

			context.Send(new MemberRegisteredEvent
			{
				UserName = context.Message.UserName
			}, c => c.Reply());
		}

		public bool IsReusable
		{
			get { return true; }
		}
	}
}