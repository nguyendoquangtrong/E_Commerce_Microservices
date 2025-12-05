using BuildingBlocks.Behaviors;

var builder = WebApplication.CreateBuilder(args);
var assembly = typeof(Program).Assembly;


// Add services to the container
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
});
builder.Services.AddValidatorsFromAssembly(assembly);
builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();
builder.Services.AddCarter();

// configure the HTTP request pipeline
var app = builder.Build();
app.MapCarter();
app.Run();