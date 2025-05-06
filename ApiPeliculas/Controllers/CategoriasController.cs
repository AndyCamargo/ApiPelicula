using ApiPeliculas.Modelos;
using ApiPeliculas.Modelos.Dtos;
using ApiPeliculas.Repositorios.IRepositorio;
using AutoMapper;
using AutoMapper.Configuration.Annotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using XAct.Security;


namespace ApiPeliculas.Controllers
{
    //[Authorize]// para todos los metodos en el controlador
    [Route("api/[controller]")]////para la url 
    [ApiController]
    
    
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaRepositorio _ctRepo;
        private readonly IMapper _mapper;
        public CategoriasController(ICategoriaRepositorio ctRepo, IMapper mapper)
        {

            _ctRepo = ctRepo;
            _mapper = mapper;
        }

        /// consaulta todos las categorias
        [XAct.Security.AllowAnonymous]//publico 
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ResponseCache(Duration = 30)] // duracion de cache en segundos 

        public IActionResult Getcategorias()
        {
            var listaCategorias = _ctRepo.GetCategorias();
            var listaCategoriasDtos= new List<CategoriaDtos>();
           
            foreach (var lista in listaCategoriasDtos)
            {
                listaCategoriasDtos.Add(_mapper.Map<CategoriaDtos>(lista));
            }
            return Ok(listaCategoriasDtos);
        }

        //segundo consulta de categorias por id
        [XAct.Security.AllowAnonymous]//publico 
        [HttpGet("{categoriaId:int}",Name ="GetCategoria")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ResponseCache(Duration = 30)] // duracion de cache en segundos 
        public IActionResult GetCategoria(int categoriaId)
        {
            var itemCategoria=_ctRepo.GetCategoria(categoriaId);
            if (itemCategoria == null) {
            return NotFound();
            }

            var itemCategoriaDto=_mapper.Map <CategoriaDtos> (itemCategoria);
            return Ok(itemCategoriaDto);
        }

        ///  crear categoria

        [Authorize(Roles ="admin")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[EnableCors("PoliticaCors")]//Aplica politica de cors o dominios
        public IActionResult CrearCategoria([FromBody] CrearCategoriaDtos crearCategoriaDtos)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            if (crearCategoriaDtos == null) {
                return BadRequest(ModelState);
            }
            if (_ctRepo.ExisteCategoria(crearCategoriaDtos.Nombre))
            {
                ModelState.AddModelError("", "La categoria ya existe");
                return BadRequest(ModelState);
            }
            var categoria = _mapper.Map<Categoria>(crearCategoriaDtos);
            if (!_ctRepo.CrearCategoria(categoria)) {
                ModelState.AddModelError("", $"Algo salio mal guardando el registro{categoria.Nombre}");
                return StatusCode(404,ModelState);
            
            }

            return CreatedAtRoute("GetCategoria",new { categoriaId = categoria.Id },categoria);
        }

        //actualizar con el patch
        [Authorize(Roles = "admin")]
        [HttpPatch("{categoriaId:int}", Name = "ActualizarPatchCategoria")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
       // [EnableCors("PoliticaCors")]//Aplica politica de cors o dominios
        public IActionResult ActualizarPatchCategoria( int categoriaId, [FromBody]CategoriaDtos CategoriaDtos)
            {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (CategoriaDtos == null || categoriaId != CategoriaDtos.Id) {
                return BadRequest(ModelState);

            }
            var categoriaExistente = _ctRepo.GetCategoria(categoriaId);

            if (categoriaExistente == null)
            {
                return NotFound($"No se encontro la categoria con ID{categoriaId}");
            }
            var categoria = _mapper.Map<Categoria>(CategoriaDtos);
            if (!_ctRepo.ActualizarCategoria(categoria)) {
                ModelState.AddModelError("", $"Algo salio mal actualizando el registro{categoria.Nombre}");
                return StatusCode(500, ModelState);

            }
            return NoContent();
        }

        // actualizar con el put
        [Authorize(Roles = "admin")]
        [HttpPut("{categoriaId:int}", Name = "ActualizarPutCategoria")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[EnableCors("PoliticaCors")]//Aplica politica de cors o dominios

        public IActionResult ActualizarPutCategoria(int categoriaId, [FromBody] CategoriaDtos CategoriaDtos)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (CategoriaDtos == null || categoriaId != CategoriaDtos.Id)
            {
                return BadRequest(ModelState);

            }

            var categoriaExistente=_ctRepo.GetCategoria(categoriaId);

            if (categoriaExistente==null)
            {
                return NotFound($"No se encontro la categoria con ID{categoriaId}");
            }

            var categoria = _mapper.Map<Categoria>(CategoriaDtos);
            if (!_ctRepo.ActualizarCategoria(categoria))
            {
                ModelState.AddModelError("", $"Algo salio mal actualizando el registro{categoria.Nombre}");
                return StatusCode(500, ModelState);

            }
            return NoContent();
        }

        // eliminar con el delete 
        [Authorize(Roles = "admin")]
        [HttpDelete("{categoriaId:int}", Name = "BorrarCategoria")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[EnableCors("PoliticaCors")]//Aplica politica de cors o dominios

        public IActionResult BorrarCategoria(int categoriaId)
        {

            

            if (!_ctRepo.ExisteCategoria(categoriaId))
            {
                return NotFound();
            }
            var categoria = _ctRepo.GetCategoria(categoriaId);

           
            if (!_ctRepo.BorraCategoria(categoria))
            {
                ModelState.AddModelError("", $"Algo salio mal actualizando el registro{categoria.Nombre}");
                return StatusCode(500, ModelState);

            }
            return NoContent();
        }


    }
}
