﻿using System;
using Shuttle.Core.Host;
using Shuttle.Esb;
using Shuttle.Esb.SqlServer.Idempotence;

namespace Shuttle.Idempotence.Server
{
	public class Host : IHost, IDisposable
	{
		private IServiceBus _bus;

		public void Start()
		{
			_bus = ServiceBus.Create(c => c.IdempotenceService(IdempotenceService.Default())).Start();
		}

		public void Dispose()
		{
			_bus.Dispose();
		}
	}
}