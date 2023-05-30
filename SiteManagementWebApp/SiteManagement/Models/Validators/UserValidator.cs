using FluentValidation;
using SiteManagement.Models.Db.Entities;

namespace SiteManagement.Models.Validators

{
    public class UserValidator : AbstractValidator<User>
    {

        public UserValidator()
        {
            RuleFor(x => x.NameSurname).NotNull().WithMessage("İsim boş olamaz.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Lütfen geçerli bir Email adresi giriniz.");
            RuleFor(x => x.Email).NotNull().WithMessage("Email boş olamaz.");
        }
    }
}
