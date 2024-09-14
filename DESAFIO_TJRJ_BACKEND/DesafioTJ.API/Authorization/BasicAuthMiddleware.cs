using DesafioTJ.Domain.ViewModel;
using System.Net.Http.Headers;
using System.Text;

namespace DesafioTJ.API.Authorization
{
    public class BasicAuthMiddleware
    {
        private readonly RequestDelegate _next;

        public BasicAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(context.Request.Headers["Authorization"]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':', 2);
                var username = credentials[0];
                var password = credentials[1];

                context.Items["User"] = (username == "tjrj" && password == "12345") ? new UsuarioViewModel() : null;
            }
            catch
            {
                // Não precisa fazer nada, se o auth header estiver inválido, não guarda a instância do
                // Usuario e a autorização não acontece
            }

            await _next(context);
        }
    }
}
