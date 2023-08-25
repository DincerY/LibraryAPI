using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using LibraryAPI.Domain.Entities;

namespace LibraryAPI.Application.Features.Books.Commands.Create;

public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
{
    public CreateBookCommandValidator()
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