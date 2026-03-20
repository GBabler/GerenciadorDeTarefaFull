using GerenciarTarefas.Application.UseCases;
using GerenciarTarefas.Domain.Interfaces;
using GerenciarTarefas.Infrastructure.Context;
using GerenciarTarefas.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GerenciarTarefas.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ✅ Banco de dados
            builder.Services.AddDbContext<TarefaContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // ✅ Repositório
            builder.Services.AddScoped<ITarefaRepository, TarefaRepository>();

            // ✅ Use Cases
            builder.Services.AddScoped<CreateTarefaUseCase>();
            builder.Services.AddScoped<GetAllTarefasUseCase>();
            builder.Services.AddScoped<GetTarefaByIdUseCase>();
            builder.Services.AddScoped<UpdateTarefaUseCase>();
            builder.Services.AddScoped<DeleteTarefaUseCase>();

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
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}