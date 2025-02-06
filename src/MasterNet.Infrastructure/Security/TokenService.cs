using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MasterNet.Application.Interfaces;
using MasterNet.Domain;
using MasterNet.Persistence;
using MasterNet.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace MasterNet.Infrastructure.Security
{
    // Clase que implementa el servicio de generación de tokens, conforme a la interfaz ITokenService
    public class TokenService : ITokenService
    {
        // Contexto de la base de datos para acceder a la información de usuarios y roles
        private readonly MasterNetDbContext _context;
        // Objeto de configuración para acceder a valores del archivo de configuración (como la llave secreta)
        private readonly IConfiguration _configuration;

        // Constructor inyectando las dependencias requeridas: DbContext y configuración
        public TokenService(MasterNetDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // Método asíncrono que crea y retorna un token JWT basado en la información del usuario
        public async Task<string> CreateToken(AppUsuario user)
        {
            // Consulta SQL para obtener los valores de claim (politicas) asociados al usuario.
            // Se hace un LEFT JOIN entre AspNetUsers, AspNetUserRoles y AspNetRoleClaims para obtener las politicas
            // asociadas al rol del usuario.
            var policies = await _context.Database.SqlQuery<string>($@"
                SELECT 
                    aspr.ClaimValue
                FROM AspNetUsers a
                    LEFT JOIN AspNetUserRoles ar
                        ON a.Id = ar.UserId
                    LEFT JOIN AspNetRoleClaims aspr
                        ON ar.RoleId = aspr.RoleId
                    WHERE a.Id = {user.Id}      
            ").ToListAsync();

            // Creacion de una lista de claims basicos con informacion del usuario:
            // - Nombre de usuario
            // - Identificador unico del usuario
            // - Correo electronico del usuario
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName!),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email!)
            };

            // Se recorren las politicas (claims extraidos de la base de datos) y se añaden a la lista de claims
            foreach(var policy in policies)
            {
                // Se valida que el valor de la política no sea nulo
                if(policy is not null)
                {
                    // Se añade el claim con un tipo personalizado (CustomClaims.policies) y el valor obtenido
                    claims.Add(new Claim(CustomClaims.policies, policy));
                }
            }

            // Creacion de las credenciales de firma para el token:
            // - Se obtiene la llave secreta desde la configuración (TokenKey)
            // - Se convierte la llave a un arreglo de bytes usando UTF8
            // - Se utiliza el algoritmo HMAC SHA256 para la firma
            var creds = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["TokenKey"]!)),
                SecurityAlgorithms.HmacSha256
            );

            // Definicion del descriptor del token que incluye:
            // - La identidad (ClaimsIdentity) con la lista de claims
            // - La fecha de expiración del token (en este caso, 7 días desde la fecha actual)
            // - Las credenciales de firma (para validar la integridad del token)
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = creds
            };

            // Se crea un manejador de tokens para generar y escribir el token JWT
            var tokenHandler = new JwtSecurityTokenHandler();
            // Creación del token usando el descriptor definido anteriormente
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // Retorna el token en formato string (serializado)
            return tokenHandler.WriteToken(token);
        }
    }
}
