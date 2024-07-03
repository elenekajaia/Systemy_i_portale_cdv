using AzureWebsite.Api;
using Microsoft.EntityFrameworkCore; 


        var builder = WebApplication.CreateBuilder(args);
        var connectionString = builder.Configuration.GetConnectionString("PeopleDb");

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        // Register DbContext using AddDbContext
        builder.Services.AddDbContext<PeopleDb>(options =>
        {
            options.UseSqlServer(connectionString);
        });

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
