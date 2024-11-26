namespace ProductCatalog.Core.Entities;
public class Category
{
    public Guid Id { get; set; }
    public string? Nome { get; set; }
        public Category(string? nome)
    {
        Nome = nome;
    }
}
