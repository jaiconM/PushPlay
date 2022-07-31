﻿using PushPlay.Application.ContaContext.Dto;

namespace PushPlay.Application.ContaContext.Service
{
    public interface IUsuarioService
    {
        Task<UsuarioOutputDto> Create(UsuarioInputDto dto);
        Task<List<UsuarioOutputDto>> GetAll();
        Task<UsuarioOutputDto> GetById(Guid id);
        Task<UsuarioOutputDto> Update(Guid id, UsuarioInputDto dto);
        Task<bool> Delete(Guid id);

    }
}