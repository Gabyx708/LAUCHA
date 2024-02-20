using LAUCHA.application.interfaces;
using LAUCHA.application.UseCase.AgregarEmpleadoNuevo;
using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;
using LAUCHA.domain.interfaces.IUnitsOfWork;
using LAUCHA.infrastructure.persistence;
using LAUCHA.infrastructure.repositories;
using LAUCHA.infrastructure.unitOfWork;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using LAUCHA.application.UseCase.AgregarUnAdicional;
using LAUCHA.application.UseCase.ConsultarAdicionales;
using LAUCHA.application.UseCase.ConsultarContratoDeTrabajo;
using LAUCHA.application.UseCase.ContratosDeTrabajo;
using LAUCHA.application.UseCase.ConsultarEmpleado;
using LAUCHA.application.UseCase.CrearRetencionesFijas;
using LAUCHA.application.UseCase.ConsultarRetencionesFijas;
using LAUCHA.application.UseCase.AgregarCuenta;
using LAUCHA.application.UseCase.CrearRemuneracionNueva;
using LAUCHA.application.UseCase.ConsultarRemuneraciones;
using LAUCHA.application.UseCase.ConsularModalidades;
using LAUCHA.application.UseCase.OperacionesDescuento;
using LAUCHA.application.UseCase.OperarRetenciones;
using LAUCHA.application.UseCase.CalculadoraSueldos;
using LAUCHA.application.UseCase.HacerUnaLiquidacion;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//custom

//database
string connectionString = builder.Configuration["ConnectionStrings:Production"];

if (builder.Environment.IsDevelopment())
{
    connectionString = builder.Configuration["ConnectionStrings:Test"];
}

builder.Services.AddDbContext<LiquidacionesDbContext>(options => options.UseMySQL(connectionString));

//dependecy injection
builder.Services.AddScoped<ICrearEmpleadoService, AgregarEmpleadoNuevoService>();
builder.Services.AddScoped<IUnitOfWorkEmpleado, UnitOfWorkEmpleado>();
builder.Services.AddScoped<IGenericRepository<Empleado>, EmpleadoRepository>();
builder.Services.AddScoped<IGenericRepository<Cuenta>, CuentaRepository>();

builder.Services.AddScoped<IGenericRepository<ModalidadPorContrato>, ModalidadPorContratoRepository>();
builder.Services.AddScoped<IGenericRepository<Adicional>,AdicionalRepository>();
builder.Services.AddScoped<IGenericRepository<AdicionalPorContrato>, AdicionalPorContratoRepository>();
builder.Services.AddScoped<IAdicionalesPorContratoRepository,AdicionalPorContratoRepository> ();
builder.Services.AddScoped<IGenericRepository<AcuerdoBlanco>,AcuerdoBlancoRepository>();
builder.Services.AddScoped<IGenericRepository<Contrato>, ContratosRepository>();
builder.Services.AddScoped<IGenericRepository<Modalidad>, ModalidadRepository>();
builder.Services.AddScoped<IUnitOfWorkContrato, UnitOfWorkContrato>();
builder.Services.AddScoped<ICrearAdicionalService,CrearAdicionalService>();
builder.Services.AddScoped<IConsultarAdicionalesService, ConsultarAdicionales>();
builder.Services.AddScoped<IConsultarContratoTrabajoService, ConsultarContratoTrabajoService>();
builder.Services.AddScoped<ICrearContratoService, CrearContratoService>();

builder.Services.AddScoped<ICuentaRepository, CuentaRepository>();
builder.Services.AddScoped<IConsultarEmpleadoService, ConsultarEmpleadoService>();

builder.Services.AddScoped<IContratoRepository, ContratosRepository>();

builder.Services.AddScoped<IGenericRepository<RetencionFija>, RetencionFijaRepository>();
builder.Services.AddScoped<ICrearRetencionesFijasService, CrearRetencionesFijasService>();
builder.Services.AddScoped<IConsultarRetencionesFijasService, ConsultarRetencionesFijasService>();

builder.Services.AddScoped<IRetencionFijaPorCuentaRepository,RetencionFijaPorCuentaRepository>();
builder.Services.AddScoped<IUnitOfWorkRetencionFijaCuenta, UnitOfWorkRetencionFijaCuenta>();
builder.Services.AddScoped<IGenericRepository<RetencionFijaPorCuenta>, RetencionFijaPorCuentaRepository>();
builder.Services.AddScoped<IAgregarCuentaService, AgregarCuentaService>();

builder.Services.AddScoped<IGenericRepository<Remuneracion>,RemuneracionRepository>();
builder.Services.AddScoped<ICrearRemuneracionService, CrearRemuneracionNuevaService>();
builder.Services.AddScoped<IConsultarRemuneracionService, ConsultarRemuneracionesService>();
builder.Services.AddScoped<IRemuneracionRepository, RemuneracionRepository>();

builder.Services.AddScoped<IGenericRepository<Modalidad>, ModalidadRepository>();
builder.Services.AddScoped<IConsultarModalidadesService, ConsultarModalidadesService>();

builder.Services.AddScoped<IGenericRepository<Descuento>, DescuentoRepository>();
builder.Services.AddScoped<IGenericRepository<Concepto>, ConceptoRepository>();
builder.Services.AddScoped<IOperarDescuentosService, OperarDescuentosService>();

builder.Services.AddScoped<IGenericRepository<Retencion>, RetencionRepository>();
builder.Services.AddScoped<IOperarRetencionService, OperarRetencionesService>();

builder.Services.AddScoped<IRetencionRepository, RetencionRepository>();
builder.Services.AddScoped<IDescuentoRepository, DescuentoRepository>();

builder.Services.AddScoped<IFabricaCalculadoraSueldo, FabricaCalculadoraSueldo>();
builder.Services.AddScoped<ILiquidacionService, LiquidacionService>();
builder.Services.AddScoped<IUnitOfWorkLiquidacion, UnitOfWorkLiquidacion>();

//CORS deshabilitar
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseHttpsRedirection();
    app.UseAuthorization();
}

app.UseCors("AllowAll");

app.MapControllers();

app.Run();
