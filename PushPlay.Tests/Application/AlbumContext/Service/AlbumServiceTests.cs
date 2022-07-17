using AutoMapper;
using FluentAssertions;
using Moq;
using PushPlay.Application.AlbumContext.Dto;
using PushPlay.Application.AlbumContext.Service;
using PushPlay.Domain.AlbumContext;
using PushPlay.Domain.AlbumContext.Repository;
using PushPlay.Tests.Application.AlbumContext;

namespace PushPlay.Tests.Api
{
    public class AlbumServiceTests
    {
        private Mock<IAlbumRepository> _repositoryMock;
        private Mock<IMapper> _mapperMock;
        private AlbumService _service;

        public AlbumServiceTests()
        {
            _repositoryMock = new Mock<IAlbumRepository>();
            _mapperMock = new Mock<IMapper>();
            _service = new AlbumService(_repositoryMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task GetAll_deve_retornar_conforme_esperado()
        {
            var expected = new List<AlbumOutputDto>{
                AlbumMockHelper.MockAlbumOutputDto()
            };
            var albuns = new List<Album>{
                new Album(expected.ElementAt(0).Nome, new Musica { Id = Guid.NewGuid() })
            };

            _repositoryMock.Setup(mock => mock.GetAllWithIncludes()).ReturnsAsync(albuns);
            _mapperMock.Setup(mock => mock.Map<List<AlbumOutputDto>>(albuns)).Returns(expected);

            var actual = await _service.GetAll();

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task Create_deve_retornar_conforme_esperado()
        {
            var input = AlbumMockHelper.MockAlbumInputDto();
            var expected = AlbumMockHelper.MockAlbumOutputDto();
            var album = new Album(input.Nome, new Musica { Id = Guid.NewGuid() });

            _mapperMock.Setup(mock => mock.Map<Album>(input)).Returns(album);
            _mapperMock.Setup(mock => mock.Map<AlbumOutputDto>(album)).Returns(expected);

            var actual = await _service.Create(input);

            actual.Should().BeEquivalentTo(expected);

        }

        [Fact]
        public async Task Create_deve_chamar_repositorio_conforme_esperado()
        {
            var input = AlbumMockHelper.MockAlbumInputDto();
            var expected = AlbumMockHelper.MockAlbumOutputDto();
            var album = new Album(input.Nome, new Musica { Id = Guid.NewGuid() })
            {
                Id = expected.Id
            };

            _mapperMock.Setup(mock => mock.Map<Album>(input)).Returns(album);
            _mapperMock.Setup(mock => mock.Map<AlbumOutputDto>(album)).Returns(expected);

            _ = await _service.Create(input);

            _repositoryMock.Verify(mock => mock.Save(It.Is<Album>(a => a.Id == album.Id)), Times.Once);
        }
    }
}