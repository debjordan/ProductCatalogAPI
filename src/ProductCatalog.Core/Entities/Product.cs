using ProductCatalog.Core.Entities;

namespace ProductCatalog.Core.Entities;
public class Product
{
    public Guid Id { get; private set; }
    public string? Nome { get; private set; }
    public string? Descricao { get; private set; }
    public string? Marca { get; private set; }
    public decimal Preco { get; private set; }
    public int CategoryId { get; private set; }
    public Category Categoria { get; private set; }
    public Product(string? nome, string? descricao, string? marca, decimal preco, int categoryId, Category categoria)
    {
        Nome = nome;
        Descricao = descricao;
        Marca = marca;
        Preco = preco;
        CategoryId = categoryId;
        Categoria = categoria;
    }
}