using ETicaretAPI.Application.ViewModels.Products;
using ETicaretAPI.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Validators.Products
{
    public class CreateProductValidator : AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidator() 
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                    .WithMessage("lütfen ürün adını boş geçmeyiniz")
                .MaximumLength(150)
                .MinimumLength(5)
                    .WithMessage("Ürün aralığını 5 ile 150 arası olması gerekmektedir");
            RuleFor(p => p.Stock)
                .NotEmpty()
                .NotNull()
                    .WithMessage("lütfen ürün stoğunu boş geçmeyiniz")
                .Must(p => p >= 0)
                    .WithMessage("stok bilgisi sıfırdan büyük olmalıdır");
            RuleFor(p => p.Price)
                .NotEmpty()
                .NotNull()
                    .WithMessage("lütfen ürün fiyatı boş geçmeyiniz")
                .Must(p => p >= 0)
                    .WithMessage("ürün fiyatı sıfırdan büyük olmalıdır");
        }
    }
}
