﻿using MediatR;
using NSE.Core.Messages.Integration;
using NSE.MessageBus;
using System.Threading;
using System.Threading.Tasks;

namespace NSE.Pedidos.API.Application.Events
{
    public class PedidoEventHandler : INotificationHandler<PedidoRealizadoEvent>
    {
        private readonly IMessageBus _bus;

        public PedidoEventHandler(IMessageBus _bus)
        {
            this._bus = _bus;
        }

        public async Task Handle(PedidoRealizadoEvent message, CancellationToken cancellationToken)
        {
            await _bus.PublishAsync(new PedidoRelizadoIntegrationEvent(message.ClienteId));
        }
    }
}
