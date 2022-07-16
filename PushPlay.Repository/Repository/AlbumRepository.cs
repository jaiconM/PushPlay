﻿using Microsoft.EntityFrameworkCore;
using PushPlay.Data.Contexto;
using PushPlay.Data.Database;
using PushPlay.Domain.AlbumContext;
using PushPlay.Domain.AlbumContext.Repository;

namespace PushPlay.Data.Repository
{
    public class AlbumRepository : Repository<Album>, IAlbumRepository
    {
        public AlbumRepository(PushPlayContext context) : base(context) { }

        public async Task<IEnumerable<Album>> ObterTodosAlbuns()
        {
            return await Query.Include(x => x.Musicas).ToListAsync();
        }
    }
}
