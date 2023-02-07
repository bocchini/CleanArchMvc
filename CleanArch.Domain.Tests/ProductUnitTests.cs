using Bogus;
using FluentAssertions;
using CleanArchMvc.Domain.Entities;

namespace CleanArch.Domain.Tests;

public class ProductUnitTests
{
    private readonly Faker _faker;
    public ProductUnitTests() => _faker = new Faker();

    [Fact]
    public void CreateProduct_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "product file for image to upload");
        action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
    }

    [Fact]
    public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
    {
        Action action = () => new Product(-1, "Product Name", "Product Description", 9.99m, 99, "product file for image to upload");
        action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid Id");
    }

    [Fact]
    public void CreateProduct_ShortNameValue_DomainExceptionShortName()
    {
        Action action = () => new Product(1, "Pr", "Product Description", 9.99m, 99, "product file for image to upload");
        action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid Name. too short, minimum 3 caracters");
    }

    [Fact]
    public void CreateProduct_NullNameValue_DomainExceptionNullName()
    {
        Action action = () => new Product(1, null, "Product Description", 9.99m, 99, "product file for image to upload");
        action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid Name. Name is required");
    }

    [Fact]
    public void CreateProduct_NullDescription_DomainExceptionNullDescription()
    {
        Action action = () => new Product(1, "Product Name", null, 9.99m, 99, "product file for image to upload");
        action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid description. Description is required");
    }

    [Fact]
    public void CreateProduct_ShortDescription_DomainExceptionShortDescription()
    {
        Action action = () => new Product(1, "Product Name", "pro", 9.99m, 99, "product file for image to upload");
        action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid description. too short, minimum 5 caracters");
    }

    [Fact]
    public void CreateProduct_NegativePrice_DomainExceptionNegativePrice()
    {
        Action action = () => new Product(1, "Product Name", "Product Description", -1m, 99, "product file for image to upload");
        action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid price value. Description is required");
    }

    [Fact]
    public void CreateProduct_NegativeStock_DomainExceptionNegativeStock()
    {
        Action action = () => new Product(1, "Product Name", "Product Description", 1m, -1, "product file for image to upload");
        action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid stock value");
    }

    [Fact]
    public void CreateProduct_ShortImage_DomainExceptionShortImageName()
    {
        Action action = () => new Product(1, "Product Name", "Product Description", 1m, 1, _faker.Random.AlphaNumeric(3));
        action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid image. too short, minimum 25 caracters");
    }

    [Fact]
    public void CreateProduct_MaximunImageName_DomainExceptionMaximumImageName()
    {
        var ImageName = _faker.Random.AlphaNumeric(256);
        Action action = () => new Product(1, "Product Name", "Product Description", 1m, 1, ImageName);
        action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid image name, too long, maximum 255 caracters");
    }

    [Fact]
    public void CreateProduct_WithNullImageName_NoDomainException()
    {       
        Action action = () => new Product(1, "Product Name", "Product Description", 1m, 99, null);
        action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
    }

    [Fact]
    public void CreateProduct_WithNullImageName_NoNullReferenceException()
    {
        Action action = () => new Product(1, "Product Name", "Product Description", 1m, 1, null);
        action.Should().NotThrow<NullReferenceException>();
    }
}
