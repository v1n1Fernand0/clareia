using Clareia.Application.Dtos;
using Clareia.Application.Services;
using Clareia.Domain.Entities;
using Clareia.Domain.Interfaces;
using FluentAssertions;
using Moq;

public class TermoServiceTests
{
    private readonly Mock<IRepository<Termo, Guid>> _repoMock;
    private readonly TermoService _service;

    public TermoServiceTests()
    {
        _repoMock = new();
        _service = new TermoService(_repoMock.Object);
    }

    [Fact]
    public async Task CadastrarAsync_DeveAdicionarTermo()
    {
        var dto = new CadastrarTermoDto { Titulo = "Segurança", Conteudo = "Use EPIs corretamente." };

        await _service.CadastrarAsync(dto);

        _repoMock.Verify(r => r.AddAsync(It.Is<Termo>(t =>
            t.Titulo == dto.Titulo &&
            t.Conteudo == dto.Conteudo)), Times.Once);
    }

    [Fact]
    public async Task ObterPorIdAsync_DeveRetornarTermoDto()
    {
        var termo = new Termo("Teste", "Conteúdo",new DateTime());
        _repoMock.Setup(r => r.GetByIdAsync(termo.Id)).ReturnsAsync(termo);

        var result = await _service.ObterPorIdAsync(termo.Id);

        Assert.NotNull(result);
        Assert.Equal(termo.Id, result!.Id);
        Assert.Equal(termo.Titulo, result.Titulo);
    }

    [Fact]
    public async Task CadastrarAsync_ComTituloVazio_DeveLancarExcecao()
    {
        var dto = new CadastrarTermoDto { Titulo = "", Conteudo = "Texto válido" };

        Func<Task> act = async () => await _service.CadastrarAsync(dto);

        await act.Should().ThrowAsync<ArgumentException>()
            .WithMessage("*título não pode ser vazio*");
    }

}
