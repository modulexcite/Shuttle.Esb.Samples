﻿using Shuttle.Core.Data;
using Shuttle.Core.Infrastructure;
using Shuttle.Esb;
using Shuttle.ProcessManagement;
using Shuttle.ProcessManagement.Messages;

namespace Shuttle.Process.QueryServer
{
    public class OrderProcessArchivedHandler : IMessageHandler<OrderProcessArchivedEvent>
    {
        private readonly IDatabaseContextFactory _databaseContextFactory;
        private readonly IOrderProcessViewQuery _orderProcessViewQuery;

        public OrderProcessArchivedHandler(IDatabaseContextFactory databaseContextFactory, IOrderProcessViewQuery orderProcessViewQuery)
        {
            Guard.AgainstNull(databaseContextFactory, "databaseContextFactory");
            Guard.AgainstNull(orderProcessViewQuery, "orderProcessViewQuery");

            _databaseContextFactory = databaseContextFactory;
            _orderProcessViewQuery = orderProcessViewQuery;
        }

        public void ProcessMessage(IHandlerContext<OrderProcessArchivedEvent> context)
        {
            using (_databaseContextFactory.Create(ProcessManagementData.ConnectionStringName))
            {
                _orderProcessViewQuery.Remove(context.Message.OrderProcessId);
            }
        }

        public bool IsReusable
        {
            get { return true; }
        }
    }
}