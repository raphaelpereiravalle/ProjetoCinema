using Microsoft.AspNetCore.Mvc;
using Moq;
using ProjetoCinema.ApplicationService.Interface.Repository;
using ProjetoCinema.ApplicationService.Interface.Service;
using ProjetoCinema.ApplicationService.Service;
using ProjetoCinema.Domain.Model;
using ProjetoCinema.Infrastructure;
using ProjetoCinema.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace Core.UnitTests
{
    public class FilmeServiceTest
    {
        Mock<IFilmeRepository> _repositoryMock;
        Mock<Filme> _filmeMock;
        FilmeAppService _service;

        FilmeController _controller;
        Mock<IFilmeAppService> _serviceMock;

        public FilmeServiceTest()
        {
            _repositoryMock = new Mock<IFilmeRepository>();
            _filmeMock = new Mock<Filme>();
            _service = new FilmeAppService(_repositoryMock.Object);

            _serviceMock = new Mock<IFilmeAppService>();
            _controller = new FilmeController(_serviceMock.Object);
        }

        [Theory]
        [InlineData(
        "601e5714-a687-4b45-87cb-3a04bb3432f6",
        "Teste 01",
        "teste 01",
        "FBAB822C-A180-475A-8A20-0B711C9073B0.jpg",
        "wwwroot\\images\\filme",
        "01:00",
        "2021-05-17 12:13:42.993",
        true,
        "5e7c17d1-2f47-4b9f-a6de-fc260a735d6c")]
        public void BuscarFilme_retorno200(string idFilme, string titulo, string descricao, string imagem, string caminho, string duracao, DateTime dataRegistro, bool ativo, string idUsuario)
        {
            Filme esperado = new Filme
            {
                IdFilme = idFilme,
                Titulo = titulo,
                Descricao = descricao,
                Imagem = imagem,
                Caminho = caminho,
                Duracao = duracao,
                DataRegistro = dataRegistro,
                Ativo = ativo,
                IdUsuario = idUsuario
            };

            FilmeRepository filmeRepository = new FilmeRepository(null);

            _serviceMock.Setup(_ => _.BuscarFilme("4ac4219e-6a88-4045-8627-c482b1c664fd")).ReturnsAsync(esperado);

            var result = _repositoryMock.Setup(_ => _.BuscarFilme("4ac4219e-6a88-4045-8627-c482b1c664fd"));

            _serviceMock.Verify(x => x.BuscarFilme("4ac4219e-6a88-4045-8627-c482b1c664fd"), Times.Once);

            var objResult = Assert.IsType<NotFoundResult>(result);
            Assert.Equal(200, objResult.StatusCode);
        }

        [Fact]
        public void GetById_ShouldCallService_AndReturn404_WhenPersonNotFound()
        {

            FilmeRepository filmeRepository = new FilmeRepository(null);

            _serviceMock.Setup(_ => _.BuscarFilme("4ac4219e-6a88-4045-8627-c482b1c664fd")).Returns(value: null);

            var result = _repositoryMock.Setup(_ => _.BuscarFilme("4ac4219e-6a88-4045-8627-c482b1c664fd"));

            _serviceMock.Verify(x => x.BuscarFilme("4ac4219e-6a88-4045-8627-c482b1c664fd"), Times.Once);

            var objResult = Assert.IsType<NotFoundResult>(result);
            Assert.Equal(404, objResult.StatusCode);
        }
    }
}
