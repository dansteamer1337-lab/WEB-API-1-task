using WebApplication4.Repositories;
using WebApplication4.Repositories.Interfaces;
using WebApplication4.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<MemoryProvider>();

builder.Services.AddScoped<IUserRepositoryInMemory, UsersRepositoryInMemory>();

var app = builder.Build();
1 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();