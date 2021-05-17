using Microsoft.AspNetCore.Mvc;
using Moq;
using ProjetoCinema.ApplicationService.Interface.Repository;
using ProjetoCinema.ApplicationService.Interface.Service;
using ProjetoCinema.ApplicationService.Service;
using ProjetoCinema.Domain.Model;
using ProjetoCinema.Infrastructure;
using System;
using Xunit;

namespace Infrastructure.Tests.Repository
{
    public class FilmeRepositoryTests
    {
        Mock<IFilmeRepository> _repositoryMock;
        Mock<Filme> _filmeMock;
        FilmeAppService _service;
        Mock<IFilmeAppService> _serviceMock;

        public FilmeRepositoryTests()
        {
            _repositoryMock = new Mock<IFilmeRepository>();
            _filmeMock = new Mock<Filme>();
            _service = new FilmeAppService(_repositoryMock.Object);

            _serviceMock = new Mock<IFilmeAppService>();
        }

        [Theory]
        [InlineData(
                null,
                "Teste 01",
                "Descrição do filme",
                "FBAB822C-A180-475A-8A20-0B711C9073B0.jpg",
                "wwwroot/image",
                "01:00",
                 "2020-05-16",
                true,
                "5e7c17d1-2f47-4b9f-a6de-fc260a735d6c")]
        public void NovoFilme(string idFilme, string titulo, string descricao, string imagem, string caminho, string duracao, DateTime dataRegistro, bool ativo, string idUsuario)
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

            var atual = _repositoryMock.Setup(_ => _.IncluirFilme(esperado));

            // Assert
            Assert.NotNull(atual);
        }

        [Theory]
        [InlineData(
            "FDAB822C-A180-475A-8A20-0B711C9073B1",
            "Teste 01",
            "Descrição do filme",
            "FBAB822C-A180-475A-8A20-0B711C9073B0.jpg",
            "wwwroot/image",
            "01:00",
            "2020-05-16",
            true,
            "5e7c17d1-2f47-4b9f-a6de-fc260a735d6c")]
        public void ValidarIncluirFilme(string idFilme, string titulo, string descricao, string imagem, string caminho, string duracao, DateTime dataRegistro, bool ativo, string idUsuario)
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

            FilmeRepository filmeRepository =  new FilmeRepository(null);

            var atual = _repositoryMock.Setup(x => x.IncluirFilme(esperado));

            // Assert
            Assert.NotNull(atual);
        }

        [Fact]
        public void BuscaFilme_returno200()
        {
            _serviceMock.Setup(_ => _.BuscarFilme("537C608E-DD65-4839-ACD8-C7D5190FDED5"));

            var result = _repositoryMock.Setup(_ => _.BuscarFilme("537C608E-DD65-4839-ACD8-C7D5190FDED5"));

            _serviceMock.Verify(x => x.BuscarFilme("537C608E-DD65-4839-ACD8-C7D5190FDED5"), Times.Once);

            // Assert
            var objResult = Assert.IsType<NotFoundResult>(result);
            Assert.Equal(200, objResult.StatusCode);
        }
    }
}