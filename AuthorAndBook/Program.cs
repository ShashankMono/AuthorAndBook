
using AuthorAndBook.Data;
using AuthorAndBook.Mapper;
using AuthorAndBook.Repository;
using AuthorAndBook.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace AuthorAndBook
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Adding mappers
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            // Add services to the container.

            builder.Services.AddDbContext<AuthorAndBookContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("ConnString"));
            });
            builder.Services.AddTransient(typeof(IRepository<>),typeof(Repository<>));
            builder.Services.AddTransient<IAuthorService, AuthorService>();
            builder.Services.AddTransient<IAuthorDetailsService, AuthorDetailsService>();
            builder.Services.AddTransient<IBookService, BookService>();
            builder.Services.AddControllers();

            // to avoid cyclic issue
            builder.Services.AddControllers().AddJsonOptions(x =>
            {
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
        }
    }
}
