﻿using MediatR;

namespace PushPlay.Application.AlbumContext.Handler.Command
{
    public class DeleteEstiloMusicalCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteEstiloMusicalCommand(Guid id)
        {
            Id = id;
        }
    }
}
