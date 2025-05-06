using ApiPeliculas.Data;
using ApiPeliculas.PeliculasMappers;
using ApiPeliculas.Repositorios;
using ApiPeliculas.Repositorios.IRepositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using ApiPeliculas.Modelos.Dtos;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using ApiPeliculas.Modelos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDBContext>(opciones=>opciones.UseSqlServer(builder.Configuration.GetConnectionString("ConexionSql")));   
builder.Services.AddControllers();

//soporte para autenticacion con .net identity

builder.Services.AddIdentity<AppUsuario,IdentityRole>().AddEntityFrameworkStores<ApplicationDBContext>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//donde se confiogura la autenticacion en el mismo servicio expuesto con le login del token 
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(options => 
{
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description =
       "Autenticacion JWT usando el esquema Bearer.\r\n\r\n"+
       "Ingresa la palabra 'Bearer' seguido de un [Espacio] y despues su token en el campo de abajo.\r\n\r\n "+
       "Ejemplo : \"Bearer thjhsdjhkhks\"",
       Name = "Authorizaztion",
       In=ParameterLocation.Header,
       Scheme="Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
            Reference = new OpenApiReference
            {
            Type=ReferenceType.SecurityScheme,
            Id="Bearer"
            },
            Scheme="oauth2",
            Name = "Bearer",
            In=ParameterLocation.Header
        },
        new List<string>()
        }
    });
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1.0",
        Title = "PeliculasApi",
        Description = "Api de peliculas",
        TermsOfService = new Uri("https://andycamargo.com"),
        Contact = new OpenApiContact
        {
            Name = "AndyCamargo",
            Url = new Uri("https://andycamargo.com")
        },
        License = new OpenApiLicense
        {
            Name = "Licencia Personal",
            Url = new Uri("https://andycamargo.com")
        }
    });

});




//soporte para cors
//se puede habilitar 1 o mas diminios 
//se puede habiliatar todos los dominios con (*) pero tambien se puede habilitar uno a uno 
//para mayor seguridad 
builder.Services.AddCors(p => p.AddPolicy("PoliticaCors",builder => 
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();//aqui va los dominios de momento se deja todos los dominios *

}));

//soporte para cache
builder.Services.AddResponseCaching();


//Agregamos los repositorios
builder.Services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
builder.Services.AddScoped<IPeliculaRepositorio, PeliculaRepositorio>();
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

var key = builder.Configuration.GetValue<string>("ApiSettings:Secreta");
// agregra el auto mapper
builder.Services.AddAutoMapper(typeof(PeliculasMapper));
//aqui se configura la autenticacion

builder.Services.AddAuthentication(x => 
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x => 
{ 
    x.RequireHttpsMetadata = false;// en produccion hay que cambiarlo a true 
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
        ValidateIssuer=false,
        ValidateAudience=false,
    };
});

var app = builder.Build();
app.UseSwagger();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
    app.UseSwaggerUI(opciones =>
    {
        opciones.SwaggerEndpoint("/swagger/v1/swagger.json","ApiPeliculaV1");
    }
        );
}
else
{
    app.UseSwaggerUI(opciones =>
    {
        opciones.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiPeliculaV1");
        opciones.RoutePrefix = "";
    }
       );
}


    //soporte para archivos estaticos como imagenes 
    app.UseStaticFiles();

app.UseHttpsRedirection();

//Soporte Para Cors
app.UseCors("PoliticaCors");
//soporte de autenticacion 

app.UseAuthorization();

app.MapControllers();

app.Run();
