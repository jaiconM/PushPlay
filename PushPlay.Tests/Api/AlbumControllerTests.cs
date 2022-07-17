using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PushPlay.Api.Controllers;
using PushPlay.Application.AlbumContext.Dto;
using PushPlay.Application.AlbumContext.Handler.Command;
using PushPlay.Application.AlbumContext.Handler.Query;
using PushPlay.Tests.Application.AlbumContext;

namespace PushPlay.Tests.Api
{
    public class AlbumControllerTests
    {
        private Mock<IMediator> _mediatorMock;
        private AlbumController _controller;

        public AlbumControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new AlbumController(_mediatorMock.Object);
        }

        [Fact]
        public async Task ListarTodos_deve_retornar_conforme_esperado()
        {
            var expected = new List<AlbumOutputDto>
            {
                AlbumMockHelper.MockAlbumOutputDto(),
                AlbumMockHelper.MockAlbumOutputDto()
            };

            _mediatorMock.Setup(mock => mock.Send(It.IsAny<GetAllAlbumQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new GetAllAlbumQueryResponse(expected));

            var result = await _controller.ListarTodos();

            var actual = result as OkObjectResult;

            actual.StatusCode.Should().Be(200);
            actual.Value.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task Criar_deve_retornar_conforme_esperado()
        {
            var expected = AlbumMockHelper.MockAlbumOutputDto();
            var input = AlbumMockHelper.MockAlbumInputDto();

            _mediatorMock.Setup(mock => mock.Send(It.IsAny<CreateAlbumCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(new CreateAlbumCommandResponse(expected));

            var result = await _controller.Criar(input);

            var actual = result as CreatedResult;

            actual.StatusCode.Should().Be(201);
            actual.Value.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task Criar_deve_chamar_mediatr_conforme_esperado()
        {
            var input = AlbumMockHelper.MockAlbumInputDto();

            _mediatorMock.Setup(mock => mock.Send(It.IsAny<CreateAlbumCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(new CreateAlbumCommandResponse(AlbumMockHelper.MockAlbumOutputDto()));

            _ = await _controller.Criar(input);

            _mediatorMock.Verify(mock => mock.Send(It.Is<CreateAlbumCommand>(command => command.Album == input), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}