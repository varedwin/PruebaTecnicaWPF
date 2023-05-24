using WebAppUsuario.AccesoDatos;
using WebAppUsuario.LogicaNegocio;
using WebAppUsuario.Modelos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUsuarioLN,  UsuarioLN>();
builder.Services.AddScoped<IGenericoAD<Usuario>, UsuarioAD>();

builder.Services.AddScoped<IAreaLN, AreaLN>();
builder.Services.AddScoped<IAreaAD, AreaAD>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
