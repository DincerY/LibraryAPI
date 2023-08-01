using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using LibraryAPI.Application.ViewModels.Books;

namespace LibraryAPI.Application.Validators.Books
{
    public class CreateBookValidator : AbstractValidator<Book_Create_VM>
    {
        public CreateBookValidator()
        {
            RuleFor(b => b.AuthorId)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen yazar seçiniz");
            RuleFor(b => b.Description)
                .NotEmpty()
                .NotNull()
                .WithMessage("Kitap açıklmasını boş geçmeyiniz");
            RuleFor(b => b.LibraryId)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen kütüphane seçiniz");
            RuleFor(b => b.PageNumber)
                .NotEmpty()
                .NotNull()
                .WithMessage("Kitap sayfasını boş geçmeyiniz");
            RuleFor(b => b.Title)
                .NotEmpty()
                .NotNull()
                .WithMessage("Kitap başlığını boş geçmeyiniz");

        }
        
    }
}
