using Microsoft.EntityFrameworkCore;
using SchoolProject.core;
 
using SchoolProject.Infrustructure;
using SchoolProject.Infrustructure.Data;
using SchoolProject.Infrustructure.Repository;
using SchoolProject.Infrustructure.Repository.IRepository;
using SchoolProject.Service.Service;
using SchoolProject.Service.Service.IService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Connection SQL
builder.Services.AddDbContext<ApplicationDBContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("SchoolSystemConnection"));
});

builder.Services.AddTransient<IStudentService, StudentService>();
builder.Services.AddCoreDependencies().AddDependencies();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
 


app.UseAuthorization();

app.MapControllers();

app.Run();
