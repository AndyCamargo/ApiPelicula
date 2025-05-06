using ApiPeliculas.Modelos;
using ApiPeliculas.Modelos.Dtos;
using ApiPeliculas.Repositorios.IRepositorio;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace ApiPeliculas.Controllers
{
    [Route("api/usuarios")]////para la url 
    [ApiController]
    //[ResponseCache(Duration = 30)] // duracion de cache
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usRepo;
        private readonly IMapper _mapper;
        protected RespuestaApi _respuestaAPI;

        public UsuariosController(IUsuarioRepositorio usRepo, IMapper mapper)
        {

            _usRepo = usRepo;
            _mapper = mapper;
            this._respuestaAPI = new();
        }


        /// consaulta todos la lista de usuarios
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
   

        public IActionResult GetUsuarios()
        {
            var listaUsuarios = _usRepo.GetUsuarios();
            var listaUsuariosDtos = new List<UsuarioDtos>();

            foreach (var lista in listaUsuariosDtos)
            {
                listaUsuariosDtos.Add(_mapper.Map<UsuarioDtos>(lista));
            }
            return Ok(listaUsuariosDtos);
        }



        //segundo consulta de usuario por id
        [HttpGet("{usuarioId}", Name = "GetUsuario")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetUsuario(string usuarioId)
        {
            var itemusuario = _usRepo.GetUsuario(usuarioId);
            if (itemusuario == null)
            {
                return NotFound();
            }

            var itemUsuarioDto = _mapper.Map<UsuarioDtos>(itemusuario);
            return Ok(itemUsuarioDto);
        }




        //registro de usuario 
        //[Authorize(Roles = "admin")]
        [HttpPost("Registro")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[EnableCors("PoliticaCors")]//Aplica politica de cors o dominios
        public async Task<IActionResult> Registro([FromBody] UsuarioRegistroDtos usuarioRegistroDtos)
        {
            bool validarNombreUsuarioUnico = _usRepo.IsUniqueUser(usuarioRegistroDtos.NombreUsuario);
            if (!validarNombreUsuarioUnico)
            {
                _respuestaAPI.StatusCode = HttpStatusCode.BadRequest;
                _respuestaAPI.IsSuccess = false;
                _respuestaAPI.ErrorMessages.Add("El nombre de usuario ya existe");
                return BadRequest(_respuestaAPI);
            }

            var usuario = await _usRepo.Registro(usuarioRegistroDtos);

            if (usuario == null)

            {

                _respuestaAPI.StatusCode = HttpStatusCode.BadRequest;
                _respuestaAPI.IsSuccess = false;
                _respuestaAPI.ErrorMessages.Add("Error en el registro");
                return BadRequest(_respuestaAPI);
            }
            _respuestaAPI.StatusCode = HttpStatusCode.OK;
            _respuestaAPI.IsSuccess = true;
            return Ok(_respuestaAPI);
           // return CreatedAtRoute("GetUsuario", new { usuarioId = usuario.Id }, usuario);

        }



        //login

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[EnableCors("PoliticaCors")]//Aplica politica de cors o dominios
        public async Task<IActionResult> Login([FromBody] UsuarioLoginDtos usuarioLoginDtos)
        {
           var respuestaLogin = await _usRepo.Login(usuarioLoginDtos);
            if (respuestaLogin.Usuario == null || string.IsNullOrEmpty(respuestaLogin.Token))
            {
                _respuestaAPI.StatusCode = HttpStatusCode.BadRequest;
                _respuestaAPI.IsSuccess = false;
                _respuestaAPI.ErrorMessages.Add("El nombre de usuario o password son incorrectos");
                return BadRequest(_respuestaAPI);
            }

                _respuestaAPI.StatusCode = HttpStatusCode.OK;
                _respuestaAPI.IsSuccess = true;
                _respuestaAPI.Result = respuestaLogin;
                return Ok(_respuestaAPI);
           

        }



    }
}
