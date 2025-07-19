using Clareia.Application.Dtos;
using Clareia.Application.Services;
using Clareia.Domain.Entities;
using Clareia.Domain.Interfaces;
using FluentAssertions;
using Moq;

public class LeituraServiceTests
{
    private readonly Mock<IRepository<ColaboradorLeitura, Guid>> _repoMock;
    private readonly LeituraService _service;

    public LeituraServiceTests()
    {
        _repoMock = new();
        _service = new LeituraService(_repoMock.Object);
    }

    [Fact]
    public async Task RegistrarAsync_DeveSalvarLeitura()
    {
        var dto = new RegistrarLeituraDto
        {
            TermoId = Guid.NewGuid(),
            Email = "vinicius@clareia.com.br",
            Compreendido = true
        };

        await _service.RegistrarAsync(dto);

        _repoMock.Verify(r => r.AddAsync(It.Is<ColaboradorLeitura>(l =>
            l.TermoId == dto.TermoId &&
            l.ColaboradorEmail == dto.Email &&
            l.Compreendido == dto.Compreendido)), Times.Once);
    }

    [Fact]
    public async Task RegistrarAsync_LeituraJaExistente_DeveLancarExcecao()
    {
        var dto = new RegistrarLeituraDto
        {
            TermoId = Guid.NewGuid(),
            Email = "vinicius@clareia.com",
            Compreendido = true
        };

        _repoMock.Setup(r => r.FindAsync(It.IsAny<Func<ColaboradorLeitura, bool>>()))
            .ReturnsAsync(new[] { new ColaboradorLeitura(dto.TermoId, dto.Email, true) });

        Func<Task> act = async () => await _service.RegistrarAsync(dto);

        await act.Should().ThrowAsync<InvalidOperationException>()
            .WithMessage("*colaborador já registrou leitura para este termo*");
    }

}
