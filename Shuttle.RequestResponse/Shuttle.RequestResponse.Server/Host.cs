﻿using System;
using Shuttle.Core.Host;
using Shuttle.Esb;

namespace Shuttle.RequestResponse.Server
{
	public class Host : IHost, IDisposable
	{
		private IServiceBus _bus;

		public void Start()
		{
			_bus = ServiceBus.Create().Start();
		}

		public void Dispose()
		{
			_bus.Dispose();
		}
	}
}