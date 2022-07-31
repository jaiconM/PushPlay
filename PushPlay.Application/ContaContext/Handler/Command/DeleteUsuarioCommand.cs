﻿using MediatR;

namespace PushPlay.Application.ContaContext.Handler.Command
{
    public class DeleteUsuarioCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteUsuarioCommand(Guid id)
        {
            Id = id;
        }
    }
}
