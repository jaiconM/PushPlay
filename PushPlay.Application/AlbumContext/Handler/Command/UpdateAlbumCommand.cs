﻿using MediatR;
using PushPlay.Application.AlbumContext.Dto;

namespace PushPlay.Application.AlbumContext.Handler.Command
{
    public class UpdateAlbumCommand : IRequest<UpdateAlbumCommandResponse>
    {
        public Guid Id { get; set; }
        public AlbumInputDto Album { get; set; }

        public UpdateAlbumCommand(Guid id, AlbumInputDto album)
        {
            Id = id;
            Album = album;
        }
    }
}
