using FluentValidation;
using SiteManagement.Models.Db.Entities;

namespace SiteManagement.Models.Validators

{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.NameSurname).NotNull().WithMessage("İsim boş olamaz.").MinimumLength(3).WithMessage("Geçerli bir isim giriniz.").MaximumLength(80).WithMessage("Geçerli bir isim giriniz.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Lütfen geçerli bir Email adresi giriniz.").NotNull().WithMessage("Email boş olamaz.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş olamaz.").Equal(x => x.PasswordConfirmation).WithMessage("Şifreler aynı değil.");
            RuleFor(x => x.PasswordConfirmation).NotEmpty().WithMessage("Şifre boş olamaz.");
        }
    }
}
