using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities;

public sealed class Product : Entity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public int Stock { get; private set; }
    public string Image { get; private set; }

    public Product(int id, string name, string description, decimal price, int stock, string image)
    {
        DomainExceptionValidation.When(id < 0, "Invalid Id");
        Id = id;
        ValidateDomain(name, description, price, stock, image);
    }

    public Product(string name, string description, decimal price, int stock, string image) => ValidateDomain(name, description, price, stock, image);
    
    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
    {
        ValidateDomain(name, description, price, stock, image);
        CategoryId = categoryId;
    }

    private void ValidateDomain(string name, string description, decimal price, int stock, string image)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid Name. Name is required");
        DomainExceptionValidation.When(name.Length < 3, "Invalid Name. too short, minimum 3 caracters");

        DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Invalid description. Description is required");
        DomainExceptionValidation.When(description.Length < 5, "Invalid description. too short, minimum 5 caracters");

        DomainExceptionValidation.When(price < 0, "Invalid price value. Description is required");
        DomainExceptionValidation.When(stock < 0, "Invalid stock value");
        Description = description;
        DomainExceptionValidation.When(image?.Length < 25, "Invalid image. too short, minimum 25 caracters");
        DomainExceptionValidation.When(image?.Length > 255, "Invalid image name, too long, maximum 255 caracters");

        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        Image = image;
    }
}
