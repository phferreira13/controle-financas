using AccountService.Business.UseCases.Users.AddUser;
using AccountService.EFConfiguration.Contexts;
using AccountService.EFConfiguration.Startups;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEntityFramework(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add MediatR
builder.Services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(AddUserCommand).Assembly));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<ControleFinancasContext>();
    context.Database.Migrate();
    context.LoadAccountTypes();
}

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
//if (app.Environment.IsDevelopment())
//{
//}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
