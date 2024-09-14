using DesafioTJ.Domain.Entities.Validation;
using DesafioTJ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioTJ.Domain.ViewModel;
using DesafioTJ.Domain.ViewModel.Validation;

namespace DesafioTJ.Domain.Helper
{
    public class ValidatorHelper
    {
        public static void ValidarUsuario(UsuarioViewModel usuario)
        {
            var validator = new UsuarioViewModelValidator();
            var result = validator.Validate(usuario);

            if (result.Errors.Any())
            {
                StringBuilder erros = new StringBuilder();

                foreach (var error in result.Errors)
                {
                    erros.Append($" | {error.ErrorMessage}");
                }

                throw new Exception(erros.ToString());
            }
        }
    }
}
