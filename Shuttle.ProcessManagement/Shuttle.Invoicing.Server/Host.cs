﻿using System;
using Castle.Windsor;
using log4net;
using Shuttle.Castle;
using Shuttle.Core.Host;
using Shuttle.Core.Infrastructure;
using Shuttle.Core.Log4Net;
using Shuttle.Esb.Castle;
using Shuttle.Esb;
using Shuttle.Esb.SqlServer;

namespace Shuttle.Invoicing.Server
{
    public class Host : IHost, IDisposable
    {
        private IServiceBus _bus;
        private WindsorContainer _container;

        public void Dispose()
        {
            _bus.Dispose();
        }

        public void Start()
        {
            Log.Assign(new Log4NetLog(LogManager.GetLogger(typeof (Host))));

            _container = new WindsorContainer();

            _container.RegisterDataAccessCore();
            _container.RegisterDataAccess("Shuttle.Invoicing");

            _bus = ServiceBus.Create(
                c => c
                    .MessageHandlerFactory(new CastleMessageHandlerFactory(_container))
                    .SubscriptionManager(SubscriptionManager.Default())
                ).Start();
        }
    }
}