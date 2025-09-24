using exercise3.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register the product service
builder.Services.AddSingleton<IProductService, ProductService>();

// Configure Kestrel to use port 5100
builder.WebHost.ConfigureKestrel(options =>
{
  options.ListenAnyIP(5100);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();