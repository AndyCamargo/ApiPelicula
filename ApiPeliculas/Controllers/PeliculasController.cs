using ApiPeliculas.Modelos;
using ApiPeliculas.Modelos.Dtos;
using ApiPeliculas.Repositorios.IRepositorio;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPeliculas.Controllers
{
    [Route("api/peliculas")]////para la url 
    [ApiController]
 
    public class PeliculasController : ControllerBase
    {
        private readonly IPeliculaRepositorio _pelRepo;
        private readonly IMapper _mapper;
        public PeliculasController(IPeliculaRepositorio pelRepo, IMapper mapper)
        {

            _pelRepo = pelRepo;
            _mapper = mapper;
        }

        /// consaulta todos las peliculas
        //[XAct.Security.AllowAnonymous]//publico 
        //[HttpGet]
        //[ProducesResponseType(StatusCodes.Status403Forbidden)]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ResponseCache(Duration = 30)] // duracion de cache en segundos 

        //public IActionResult Getpeliculas()
        //{
        //    var listaPeliculas = _pelRepo.GetPeliculas();
        //    var listaPeliculasDtos = new List<PeliculasDtos>();

        //    foreach (var lista in listaPeliculas)
        //    {
        //        listaPeliculasDtos.Add(_mapper.Map<PeliculasDtos>(lista));
        //    }
        //    return Ok(listaPeliculasDtos);
        //}

        // consaulta todos las peliculas
        [XAct.Security.AllowAnonymous]//publico 
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
       // [ResponseCache(Duration = 30)] // duracion de cache en segundos 

        public IActionResult Getpeliculas([FromQuery]int pageNumber=1,int pageSize = 10)
        {
            try
            {
                var totalpeliculas= _pelRepo.GetTotalPeliculas();
                var peliculas = _pelRepo.GetPeliculas(pageNumber,pageSize);
                if (peliculas == null || !peliculas.Any())
                { 
                    return NotFound("No se encontro peliculas");
                }
                var peliculasDtos = peliculas.Select(p => _mapper.Map<PeliculasDtos>(p)).ToList();
                var response = new
                {
                    PageNumber = pageNumber,
                    pageSize = pageSize,
                    TotalPages = (int)Math.Ceiling(totalpeliculas / (double)pageSize),
                    TotalItems = totalpeliculas,
                    Items = peliculasDtos
                };
                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error recuperando los datos de la aplicacion");
                
            }
            
        }



        // consulta pelicula id
        [XAct.Security.AllowAnonymous]//publico 
        [HttpGet("{peliculaId:int}", Name = "GetPelicula")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ResponseCache(Duration = 30)] // duracion de cache en segundos 
        public IActionResult GetPelicula(int peliculaId)
        {
            var itempelicula = _pelRepo.GetPelicula(peliculaId);
            if (itempelicula == null)
            {
                return NotFound();
            }

            var itempeliculaDto = _mapper.Map<PeliculasDtos>(itempelicula);
            return Ok(itempeliculaDto);
        }

        ///crear pelicula
        ///
       // [Authorize(Roles = "admin")]
        [HttpPost]
        [ProducesResponseType(201,Type =typeof(PeliculasDtos))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[EnableCors("PoliticaCors")]//Aplica politica de cors o dominios
        public IActionResult CrearPelicula([FromForm] CrearPeliculasDtos crearPeliculasDtos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (crearPeliculasDtos == null)
            {
                return BadRequest(ModelState);
            }
            if (_pelRepo.ExistePelicula(crearPeliculasDtos.Nombre))
            {
                ModelState.AddModelError("", "La Pelicula ya existe");
                return BadRequest(ModelState);
            }
            var pelicula = _mapper.Map<Pelicula>(crearPeliculasDtos);
            //if (!_pelRepo.CrearPelicula(pelicula))
            //{
            //    ModelState.AddModelError("", $"Algo salio mal guardando el registro{pelicula.Nombre}");
            //    return StatusCode(404, ModelState);

            //}
            //subida de archivo
            if (crearPeliculasDtos.Imagen != null)
            {

                string nombreArchivo = pelicula.Id + System.Guid.NewGuid().ToString() + Path.GetExtension(crearPeliculasDtos.Imagen.FileName);
                string rutaArchivo = @"wwwroot\ImagenesPeliculas\"+ nombreArchivo;

                var ubicacionDirectorio=Path.Combine(Directory.GetCurrentDirectory(), rutaArchivo);

                FileInfo file = new FileInfo(ubicacionDirectorio);

                if (file.Exists)
                {
                    
                file.Delete();
                }
                using (var fileStream = new FileStream(ubicacionDirectorio,FileMode.Create))
                {
                crearPeliculasDtos.Imagen.CopyTo(fileStream);
                }

                var Baseurl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.Value}{HttpContext.Request.PathBase.Value}";
                pelicula.RutaImagen = Baseurl + "/ImagenesPeliculas/"+ nombreArchivo;
                pelicula.RutaLocalIMagen=rutaArchivo;
            } 
            else 
            {
                pelicula.RutaImagen = "https://placehold.co/600x400";
            }

            _pelRepo.CrearPelicula(pelicula);
            return CreatedAtRoute("GetPelicula", new { peliculaId = pelicula.Id }, pelicula);
        }

        ////actualizar pelucila 
        ///sin subir archivo

        ////[Authorize(Roles = "admin")]
        //[HttpPatch("{peliculaId:int}", Name = "ActualizarPatchPelicula")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        ////[EnableCors("PoliticaCors")]//Aplica politica de cors o dominios
        //public IActionResult ActualizarPatchPelicula(int peliculaId, [FromBody] PeliculasDtos PeliculasDtos)
        //{

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    if( PeliculasDtos == null || peliculaId != PeliculasDtos.Id)
        //    {
        //        return BadRequest(ModelState);

        //    }
        //    var peliculaExistente = _pelRepo.GetPelicula(peliculaId);

        //    if (peliculaExistente == null)
        //    {
        //        return NotFound($"No se encontro la Pelicula  con ID {peliculaId}");
        //    }
        //    var pelicula = _mapper.Map<Pelicula>(PeliculasDtos);
        //    if (!_pelRepo.ActualizarPelicula(pelicula))
        //    {
        //        ModelState.AddModelError("", $"Algo salio mal actualizando el registro {pelicula.Nombre}");
        //        return StatusCode(500, ModelState);

        //    }
        //    return NoContent();
        //}


        [HttpPatch("{peliculaId:int}", Name = "ActualizarPatchPelicula")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[EnableCors("PoliticaCors")]//Aplica politica de cors o dominios
        public IActionResult ActualizarPatchPelicula(int peliculaId, [FromForm] ActualizarPeliculaDtos actualizarPeliculaDtos)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (actualizarPeliculaDtos == null || peliculaId != actualizarPeliculaDtos.Id)
            {
                return BadRequest(ModelState);

            }
            var peliculaExistente = _pelRepo.GetPelicula(peliculaId);

            if (peliculaExistente == null)
            {
                return NotFound($"No se encontro la Pelicula  con ID {peliculaId}");
            }
            var pelicula = _mapper.Map<Pelicula>(actualizarPeliculaDtos);


            //if (!_pelRepo.ActualizarPelicula(pelicula))
            //{
            //    ModelState.AddModelError("", $"Algo salio mal actualizando el registro {pelicula.Nombre}");
            //    return StatusCode(500, ModelState);

            //}

            if (actualizarPeliculaDtos.Imagen != null)
            {

                string nombreArchivo = pelicula.Id + System.Guid.NewGuid().ToString() + Path.GetExtension(actualizarPeliculaDtos.Imagen.FileName);
                string rutaArchivo = @"wwwroot\ImagenesPeliculas\" + nombreArchivo;

                var ubicacionDirectorio = Path.Combine(Directory.GetCurrentDirectory(), rutaArchivo);

                FileInfo file = new FileInfo(ubicacionDirectorio);

                if (file.Exists)
                {

                    file.Delete();
                }
                using (var fileStream = new FileStream(ubicacionDirectorio, FileMode.Create))
                {
                    actualizarPeliculaDtos.Imagen.CopyTo(fileStream);
                }

                var Baseurl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.Value}{HttpContext.Request.PathBase.Value}";
                pelicula.RutaImagen = Baseurl + "/ImagenesPeliculas/" + nombreArchivo;
                pelicula.RutaLocalIMagen = rutaArchivo;
            }
            else
            {
                pelicula.RutaImagen = "https://placehold.co/600x400";
            }

            _pelRepo.ActualizarPelicula(pelicula);
            return NoContent();
        }


        // eliminar con el delete 
        [Authorize(Roles = "admin")]
        [HttpDelete("{PeliculaId:int}", Name = "BorrarPelicula")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult BorrarPelicula(int PeliculaId)
        {



            if (!_pelRepo.ExistePelicula(PeliculaId))
            {
                return NotFound();
            }
            var pelicula = _pelRepo.GetPelicula(PeliculaId);


            if (!_pelRepo.BorrarPelicula(pelicula))
            {
                ModelState.AddModelError("", $"Algo salio mal actualizando el registro{pelicula.Nombre}");
                return StatusCode(500, ModelState);

            }
            return NoContent();
        }
        // traer peliculas en categoria
        [XAct.Security.AllowAnonymous]//publico 
        [HttpGet("GetPeliculasEnCategoria/{categoriaId:int}")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ResponseCache(Duration = 30)] // duracion de cache en segundos 
        public IActionResult GetPeliculasEnCategoria(int categoriaId)
        {
            try 
            {
                var listaPeliculas = _pelRepo.GetPeliculasEnCategoria(categoriaId);
                if (listaPeliculas == null || !listaPeliculas.Any())
                {
                    return NotFound($"No se encontro pelicula en la categoria con el ID {categoriaId}.");
                }

                var itemPelicula = listaPeliculas.Select(Pelicula => _mapper.Map<PeliculasDtos>(Pelicula)).ToList();
                //foreach (var item in listaPeliculas)
                //{
                //    itemPelicula.Add(_mapper.Map<PeliculasDtos>(item));
                //}
                return Ok(itemPelicula);

            }
            catch {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno");
            
            }
            
        }


        // buscar por nombre 
        [XAct.Security.AllowAnonymous]//publico 
        [HttpGet("Buscar")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ResponseCache(Duration = 30)] // duracion de cache en segundos 
        public IActionResult Buscar(string nombre)
        {


            try 
            {
                var resultado =_pelRepo.BuscarPelicula(nombre);
                if (!resultado.Any()) 
                {
                    return NotFound($"no se encontro peliculas que conincidan con los criterios {nombre}.");
                    //return Ok(resultado);

                }
                var peliculasDto = _mapper.Map<IEnumerable<PeliculasDtos>>(resultado);
                return Ok(peliculasDto);
                //return NotFound();
            } 
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error recuperando datos de la aplicacion");
            }

           
        }


    }
}
