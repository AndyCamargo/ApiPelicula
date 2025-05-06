using ApiPeliculas.Data;
using ApiPeliculas.Modelos;
using ApiPeliculas.Modelos.Dtos;
using ApiPeliculas.Repositorios.IRepositorio;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using XSystem.Security.Cryptography;

namespace ApiPeliculas.Repositorios
{
    public class UsuarioRepositorio:IUsuarioRepositorio
    {

        private readonly ApplicationDBContext _bd;
        private string claveSecreta;
        private readonly UserManager<AppUsuario> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        public UsuarioRepositorio(ApplicationDBContext bd, IConfiguration config, UserManager<AppUsuario> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _bd = bd;
            claveSecreta = config.GetValue<string>("ApiSettings:Secreta");
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public AppUsuario GetUsuario(string usuarioID)
        {
            return _bd.AppUsuario.FirstOrDefault(c => c.Id == usuarioID);
        }

        public ICollection<AppUsuario> GetUsuarios()
        {
            return _bd.AppUsuario.OrderBy(c => c.UserName).ToList();
        }

        public bool IsUniqueUser(string usuario)
        {
           // var usuarioBd= _bd.Usuario.FirstOrDefault(u  =>u.NombreUsuario == usuario);
            var usuarioBd = _bd.AppUsuario.FirstOrDefault(u => u.UserName == usuario);
            if (usuarioBd == null) 
            { 
                return true;
            }
            return false;
        }

        public async Task<UsuarioLoginRespuestaDTOS> Login(UsuarioLoginDtos usuarioLoginDtos)
        {
            //var pasworrdEncriptado = obtenermd5(usuarioLoginDtos.Password);

            //var usuario = _bd.Usuario.FirstOrDefault
            //    (u => u.NombreUsuario.ToLower() == usuarioLoginDtos.NombreUsuario.ToLower() && u.Password.ToString()
            //    == pasworrdEncriptado);
            // valida si el usuario no existe con la combianacion de usuario y contraseña correcta 
            //if (usuario == null)
            //{

            //    return new UsuarioLoginRespuestaDTOS()
            //    {
            //        Token = "",
            //        Usuario = null
            //    };

            //}
            var usuario = _bd.AppUsuario.FirstOrDefault
                (u => u.UserName.ToLower() == usuarioLoginDtos.NombreUsuario.ToLower());
            bool isValid= await _userManager.CheckPasswordAsync(usuario, usuarioLoginDtos.Password);
            if (usuario == null || isValid==false)
            {

                return new UsuarioLoginRespuestaDTOS()
                {
                    Token = "",
                    Usuario = null
                };

            }

            // aqui exite el usuario entonces podemos procesar el login
            var roles=await _userManager.GetRolesAsync(usuario);//nuevo
            var manejadoToken = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(claveSecreta);

            var tokenDescriptor = new SecurityTokenDescriptor { 
            Subject = new System.Security.Claims.ClaimsIdentity(new Claim []{ 

                //new Claim (ClaimTypes.Name,usuario.NombreUsuario.ToString()),
                //new Claim (ClaimTypes.Role,usuario.Role)
                new Claim (ClaimTypes.Name,usuario.UserName.ToString()),
                new Claim (ClaimTypes.Role,roles.FirstOrDefault())

            }),
            //7 dias de expiracion de token
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new (new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
            };

            var token = manejadoToken.CreateToken(tokenDescriptor);

            UsuarioLoginRespuestaDTOS usuarioLoginRespuestaDTOS = new UsuarioLoginRespuestaDTOS() { 
            
            Token = manejadoToken.WriteToken(token),
                //Usuario =usuario //cambio
                Usuario = _mapper.Map<UsuarioDatosDtos>(usuario),

            };
            return usuarioLoginRespuestaDTOS;
        }

        //public async Task<Usuario> Registro(UsuarioRegistroDtos usuarioRegistroDtos)
        //{
        //    var passwordEncriptado = obtenermd5(usuarioRegistroDtos.Password);

        //    Usuario usuario = new Usuario()
        //    {
        //        NombreUsuario = usuarioRegistroDtos.NombreUsuario,
        //        Password =passwordEncriptado,
        //        Nombre = usuarioRegistroDtos.Nombre,
        //        Role = usuarioRegistroDtos.Role
        //    };
        //    _bd.Usuario.Add(usuario);
        //    await _bd.SaveChangesAsync();
        //    usuario.Password = passwordEncriptado;
        //    return usuario;
        //
        //
        // }

        public async Task<UsuarioDatosDtos> Registro(UsuarioRegistroDtos usuarioRegistroDtos)
        {
           // var passwordEncriptado = obtenermd5(usuarioRegistroDtos.Password);

            AppUsuario usuario = new AppUsuario()
            {
                UserName = usuarioRegistroDtos.NombreUsuario,
                Email = usuarioRegistroDtos.NombreUsuario,
                NormalizedEmail = usuarioRegistroDtos.NombreUsuario.ToUpper(),
                Nombre = usuarioRegistroDtos.Nombre
            };

            var result=await _userManager.CreateAsync(usuario,usuarioRegistroDtos.Password);
            if (result.Succeeded)
            {
                if (!_roleManager.RoleExistsAsync("admin").GetAwaiter().GetResult())
                {

                    await _roleManager.CreateAsync(new IdentityRole("admin"));
                    await _roleManager.CreateAsync(new IdentityRole("Registrado"));

                }
               
                await _userManager.AddToRoleAsync(usuario,"admin");
                var usuareioRetornado = _bd.AppUsuario.FirstOrDefault(u => u.UserName == usuarioRegistroDtos.NombreUsuario);
                return _mapper.Map<UsuarioDatosDtos>(usuareioRetornado);
            }
            return new UsuarioDatosDtos();
        }


        //// metodo para encriptar constraseña en formato md5 
        //public static string obtenermd5(string valor) {

        //    MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
        //    byte[] data = System.Text.Encoding.UTF8.GetBytes(valor);
        //    data = x.ComputeHash(data);
        //    string resp = "";
        //    for (int i = 0; i < data.Length; i++)
        //        resp += data[i].ToString("X2").ToLower();
        //    return resp;
        //}
    }
}
