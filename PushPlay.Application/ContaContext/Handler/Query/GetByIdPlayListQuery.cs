﻿using MediatR;

namespace PushPlay.Application.ContaContext.Handler.Query
{
    public class GetByIdPlayListQuery : IRequest<GetByIdPlayListQueryResponse>
    {
        public Guid Id { get; set; }

        public GetByIdPlayListQuery(Guid id)
        {
            Id = id;
        }
    }
}
