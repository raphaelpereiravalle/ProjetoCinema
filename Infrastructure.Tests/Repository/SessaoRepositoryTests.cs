using Microsoft.AspNetCore.Mvc;
using Moq;
using ProjetoCinema.ApplicationService.Interface.Repository;
using ProjetoCinema.ApplicationService.Interface.Service;
using ProjetoCinema.ApplicationService.Service;
using ProjetoCinema.Domain.Model;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Infrastructure.Tests.Repository
{
    public class SessaoRepositoryTests
    {
        Mock<ISessaoRepository> _repositoryMock;
        Mock<Sessao> _sessaoMock;
        SessaoAppService _service;
        Mock<ISessaoAppService> _serviceMock;
        private const int PRAZO_EXCLLUSAO_FILME = 10;
        public SessaoRepositoryTests()
        {
            _repositoryMock = new Mock<ISessaoRepository>();
            _sessaoMock = new Mock<Sessao>();
            _serviceMock = new Mock<ISessaoAppService>();
        }

        [Theory]
        [InlineData("1:00")]
        [InlineData("2:30")]
        public void CalculadoDuracaoDoFilme(string horarioInicial)
        {
            // Arrange
            var result = _repositoryMock.Setup(_ => _.CalculadoHoraFinal("4ac4219e-6a88-4045-8627-c482b1c664fd", horarioInicial));

            // Assert
            Assert.Empty((System.Collections.IEnumerable)result);
            Assert.Equal("-1", (System.Collections.IEnumerable)result);
        }


        [Theory]
        [InlineData("070ca962-f30b-4a04-b137-cc9840c3597c")]
        [InlineData("0b1ff34b-c947-4dd6-98b7-adb41dc5177a")]
        public void CalcularPrazoParaExcluirSessaoDoFilmeFalha(string idSessoa)
        {
            // Arrange
            var result = _repositoryMock.Setup(_ => _.CalcularPrazoParaExcluirSessao(idSessoa));
            var totalDias = Assert.IsType<int>(result);

            // Assert
            Assert.NotNull(totalDias);
            Assert.Equal(5, totalDias);
        }

        [Theory]
        [InlineData("070ca962-f30b-4a04-b137-cc9840c3597c")]
        [InlineData("0b1ff34b-c947-4dd6-98b7-adb41dc5177a")]
        public void CalcularPrazoParaExcluirSessaoDoFilme(string idSessoa)
        {
            // Arrange
            var result = _repositoryMock.Setup(_ => _.CalcularPrazoParaExcluirSessao(idSessoa));
            var totalDias = Assert.IsType<int>(result);

            // Assert
            Assert.Equal(10, totalDias);
        }
    }
}