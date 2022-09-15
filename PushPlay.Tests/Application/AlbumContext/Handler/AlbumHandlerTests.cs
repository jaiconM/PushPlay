using FluentAssertions;
using Moq;
using PushPlay.Application.AlbumContext.Dto;
using PushPlay.Application.AlbumContext.Handler;
using PushPlay.Application.AlbumContext.Handler.Command;
using PushPlay.Application.AlbumContext.Handler.Query;
using PushPlay.Application.AlbumContext.Service;

namespace PushPlay.Tests.Application.AlbumContext.Handler
{
    public class AlbumHandlerTests
    {
        private readonly Mock<IAlbumService> _serviceMock;
        private readonly AlbumHandler _handler;

        public AlbumHandlerTests()
        {
            _serviceMock = new Mock<IAlbumService>();
            _handler = new AlbumHandler(_serviceMock.Object);
        }

        [Fact]
        public async Task GetAllAlbumQuery_Handle_deve_retornar_conforme_esperado()
        {
            var albuns = new List<AlbumOutputDto>
            {
                AlbumMockHelper.MockAlbumOutputDto(),
                AlbumMockHelper.MockAlbumOutputDto(),
                AlbumMockHelper.MockAlbumOutputDto()
            };
            var expected = new GetAllAlbumQueryResponse(albuns);

            _serviceMock.Setup(mock => mock.GetAll()).ReturnsAsync(albuns);

            var actual = await _handler.Handle(new GetAllAlbumQuery(), new CancellationToken());

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task CreateAlbumCommand_Handle_deve_retornar_conforme_esperado()
        {
            var album = AlbumMockHelper.MockAlbumOutputDto();

            var expected = new CreateAlbumCommandResponse(album);

            var input = AlbumMockHelper.MockAlbumInputDto();
            _serviceMock.Setup(mock => mock.Create(input)).ReturnsAsync(album);

            var actual = await _handler.Handle(new CreateAlbumCommand(input), new CancellationToken());

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task GetByIdAlbumQuery_Handle_deve_retornar_conforme_esperado()
        {
            var id = Guid.NewGuid();
            var album = AlbumMockHelper.MockAlbumOutputDto();
            var expected = new GetByIdAlbumQueryResponse(album);

            _serviceMock.Setup(mock => mock.GetById(id)).ReturnsAsync(album);

            var actual = await _handler.Handle(new GetByIdAlbumQuery(id), new CancellationToken());

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task UpdateAlbumCommand_Handle_deve_retornar_conforme_esperado()
        {
            var id = Guid.NewGuid();
            var input = AlbumMockHelper.MockAlbumInputDto();

            var album = AlbumMockHelper.MockAlbumOutputDto();
            var expected = new UpdateAlbumCommandResponse(album);

            _serviceMock.Setup(mock => mock.Update(id, input)).ReturnsAsync(album);

            var actual = await _handler.Handle(new UpdateAlbumCommand(id, input), new CancellationToken());

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task DeleteAlbumCommand_Handle_deve_retornar_conforme_esperado()
        {
            var id = Guid.NewGuid();
            var expected = true;

            _serviceMock.Setup(mock => mock.Delete(id)).ReturnsAsync(expected);

            var actual = await _handler.Handle(new DeleteAlbumCommand(id), new CancellationToken());

            actual.Should().Be(expected);
        }
    }
}