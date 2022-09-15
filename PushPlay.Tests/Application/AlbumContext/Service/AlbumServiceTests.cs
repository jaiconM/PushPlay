using AutoMapper;
using FluentAssertions;
using Moq;
using PushPlay.Application.AlbumContext.Dto;
using PushPlay.Application.AlbumContext.Service;
using PushPlay.CrossCutting.Exceptions;
using PushPlay.Data.AzureBlobStorageHelper;
using PushPlay.Domain.AlbumContext;
using PushPlay.Domain.AlbumContext.Repository;

namespace PushPlay.Tests.Application.AlbumContext.Service
{
    public class AlbumServiceTests
    {
        private readonly Mock<IAlbumRepository> _repositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IAzureBlobStorage> _storageMock;
        private readonly AlbumService _service;

        public AlbumServiceTests()
        {
            _repositoryMock = new Mock<IAlbumRepository>();
            _mapperMock = new Mock<IMapper>();
            _storageMock = new Mock<IAzureBlobStorage>();
            _service = new AlbumService(_repositoryMock.Object, _mapperMock.Object, _storageMock.Object);
        }

        [Fact]
        public async Task GetAll_deve_retornar_conforme_esperado()
        {
            List<AlbumOutputDto> expected = new()
            {
                AlbumMockHelper.MockAlbumOutputDto()
            };
            List<Album> albuns = new()
            {
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
            Album album = new(input.Nome, new Musica { Id = Guid.NewGuid() })
            {
                LinkFoto = "https://sienaconstruction.com/wp-content/uploads/2017/05/test-image.jpg"
            };

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
            Album album = new(input.Nome, new Musica { Id = Guid.NewGuid() })
            {
                Id = expected.Id,
                LinkFoto = "https://sienaconstruction.com/wp-content/uploads/2017/05/test-image.jpg"
            };

            _mapperMock.Setup(mock => mock.Map<Album>(input)).Returns(album);
            _mapperMock.Setup(mock => mock.Map<AlbumOutputDto>(album)).Returns(expected);
            _storageMock.Setup(mock => mock.UploadFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Stream>())).ReturnsAsync(album.LinkFoto);

            _ = await _service.Create(input);

            _repositoryMock.Verify(mock => mock.Save(It.Is<Album>(a => a.Id == album.Id)), Times.Once);
        }

        [Fact]
        public async Task GetById_deve_gerar_IdNotFoundException_quando_id_invalido()
        {
            _repositoryMock.Setup(mock => mock.Get(It.IsAny<Guid>())).ReturnsAsync((Album)null);

            Func<Task> act = () => _service.GetById(Guid.NewGuid());
            await act.Should().ThrowAsync<IdNotFoundException>().WithMessage("Id de Album não localizado");
        }

        [Fact]
        public async Task Update_deve_gerar_IdNotFoundException_quando_id_invalido()
        {
            _repositoryMock.Setup(mock => mock.Get(It.IsAny<Guid>())).ReturnsAsync((Album)null);

            Func<Task> act = () => _service.Update(Guid.NewGuid(), AlbumMockHelper.MockAlbumInputDto());
            await act.Should().ThrowAsync<IdNotFoundException>().WithMessage("Id de Album não localizado");
        }

        [Fact]
        public async Task Delete_deve_gerar_IdNotFoundException_quando_id_invalido()
        {
            _repositoryMock.Setup(mock => mock.Get(It.IsAny<Guid>())).ReturnsAsync((Album)null);

            Func<Task> act = () => _service.Delete(Guid.NewGuid());
            await act.Should().ThrowAsync<IdNotFoundException>().WithMessage("Id de Album não localizado");
        }
    }
}