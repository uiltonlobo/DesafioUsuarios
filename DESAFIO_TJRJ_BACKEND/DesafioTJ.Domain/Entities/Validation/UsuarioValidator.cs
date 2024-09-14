using DesafioTJ.Domain.Resource;
using FluentValidation;

namespace DesafioTJ.Domain.Entities.Validation
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage(String.Format(ResourceMessages.CAMPO_OBRIGATORIO, "Usuário"))
                .Length(1,100).WithMessage(String.Format(ResourceMessages.CAMPO_MUITO_GRANDE,"Usuário", "100"));

            RuleFor(x => x.Matricula)
                .NotEmpty().WithMessage(String.Format(ResourceMessages.CAMPO_OBRIGATORIO, "Matrícula"))
                .Length(1, 100).WithMessage(String.Format(ResourceMessages.CAMPO_MUITO_GRANDE, "Matrícula", "15"));

            RuleFor(x => x.DataNascimento)
                .NotEmpty().WithMessage(String.Format(ResourceMessages.CAMPO_OBRIGATORIO, "Data de Nascimento"));

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(String.Format(ResourceMessages.CAMPO_OBRIGATORIO, "Email"))
                .Length(1, 100).WithMessage(String.Format(ResourceMessages.CAMPO_MUITO_GRANDE, "Email", "100"))
                .EmailAddress().WithMessage(String.Format(ResourceMessages.CAMPO_FORMATO_INVALIDO, "Email"));

            RuleFor(x => x.IdTipoUsuario)
                .GreaterThan(0).WithMessage(String.Format(ResourceMessages.CAMPO_OBRIGATORIO, "Tipo de Usuário"));
        }
    }
}
