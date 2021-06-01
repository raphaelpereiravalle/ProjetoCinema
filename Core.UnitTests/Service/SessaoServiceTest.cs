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
    public class SessaoServiceTest
    {
        Mock<ISessaoRepository> _repositoryMock;
        Mock<Sessao> _SessaoMock;
        SessaoAppService _service;

        SessaoController _controller;
        Mock<ISessaoAppService> _serviceMock;

        public SessaoServiceTest()
        {
            _repositoryMock = new Mock<ISessaoRepository>();
            _SessaoMock = new Mock<Sessao>();

            _serviceMock = new Mock<ISessaoAppService>();
            _controller = new SessaoController(_serviceMock.Object);
        }
    }
}
