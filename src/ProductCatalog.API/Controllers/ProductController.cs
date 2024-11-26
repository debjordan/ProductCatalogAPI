using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Core.Entities;
using ProductCatalog.Core.Repositories;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet]
    public async Task<IActionResult> ObterListaProdutos()
    {
        var products = await _productRepository.GetAllAsync();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterProduto(int id)
    {
        var product = await _productRepository.GetByAsync(id);
        if (product == null)
        {
            return NotFound(new { Message = "Produto não encontrado." });
        }
        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> AdicionaProduto([FromBody] Product product)
    {
        if (product == null)
        {
            return BadRequest(new { Message = "Produto inválido." });
        }

        await _productRepository.AddAsync(product);
        return CreatedAtAction(nameof(ObterProduto), new { id = product.Id }, product);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizaProduto(int id, [FromBody] Product produtoatualizado)
    {
        if (produtoatualizado == null || id != produtoatualizado.Id)
        {
            return BadRequest(new { Message = "Os dados não batem!" });
        }

        var produtoexiste = await _productRepository.GetByAsync(id);
        if (produtoexiste == null)
        {
            return NotFound(new { Message = "Produto não encontrado!" });
        }

        await _productRepository.UpdateAsync(produtoatualizado);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> ExcluirProduto(int id)
    {
        var produtoexiste = await _productRepository.GetByAsync(id);
        if (produtoexiste == null)
        {
            return NotFound(new { Message = "Produto não encontrado!" });
        }

        await _productRepository.DeleteAsync(id);
        return NoContent();
    }
}
