using GerenciarTarefas.Application.Interfaces;
using GerenciarTarefas.Application.UseCases;
using GerenciarTarefas.Domain.Interfaces;
using GerenciarTarefas.Infrastructure.Context;
using GerenciarTarefas.Infrastructure.Repositories;
using GerenciarTarefas.Presentation.Middlewares;
using Microsoft.EntityFrameworkCore;

namespace GerenciarTarefas.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Banco de dados,eu defino que o EF Core vai usar o SQL Server e pego a string de conexão
            builder.Services.AddDbContext<TarefaContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            //Repositório
            builder.Services.AddScoped<ITarefaRepository, TarefaRepository>();

            //Use Cases
            builder.Services.AddScoped<ICreateTarefaUseCase, CreateTarefaUseCase>();
            builder.Services.AddScoped<IGetAllTarefasUseCase, GetAllTarefasUseCase>();
            builder.Services.AddScoped<IGetTarefaByIdUseCase, GetTarefaByIdUseCase>();
            builder.Services.AddScoped<IUpdateTarefaUseCase, UpdateTarefaUseCase>();
            builder.Services.AddScoped<IDeleteTarefaUseCase, DeleteTarefaUseCase>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}