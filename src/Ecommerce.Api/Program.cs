// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// Add services to the container.build

using Ecommerce.Infrastructure.CrossCutting.Options;

var builder = WebApplication.CreateBuilder(args);


builder.Services.Configure<RavenDbSettings>(builder.Configuration.GetSection(nameof(RavenDbSettings)));

builder.Services.AddRavenDb();
builder.Services.AddDomainServices();
builder.Services.AddRepositories();
builder.Services.AddControllers();
builder.Services.AddMappers();
builder.Services.AddAplicationService();


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
