using Pokemon_Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var allowedOrigins = "pokemonAllowedOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowedOrigins,
                     policy =>
                     {
                         policy.AllowAnyOrigin().WithMethods("GET");
                     });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient<IPokemonApiClient, PokemonApiClient>();

var app = builder.Build();

app.UseCors(allowedOrigins);

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
