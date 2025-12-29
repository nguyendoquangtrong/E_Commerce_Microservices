var builder = WebApplication.CreateBuilder(args);
var assembly = typeof(Program).Assembly;
//Add services to container.
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});
builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
    opts.Schema.For<ShoppingCart>().Identity(x => x.UserName);
}).UseLightweightSessions();
builder.Services.AddStackExchangeRedisCache(opt =>
{
    opt.Configuration = builder.Configuration.GetConnectionString("Redis");
});

builder.Services.AddExceptionHandler<CustomExceptionHandler>();
builder.Services.AddValidatorsFromAssembly(assembly);
builder.Services.AddCarter();
builder.Services.AddHealthChecks()
    .AddNpgSql(builder.Configuration.GetConnectionString("Database"))
    .AddRedis(builder.Configuration.GetConnectionString("Redis"));

builder.Services.AddGrpcClient<DiscountProtoService.DiscountProtoServiceClient>(options =>
    options.Address = new Uri(builder.Configuration["GrpcSettings:DiscountUrl"]!)); 

builder.Services.AddScoped<IBasketReponsitory, BasketReponsitory>();
builder.Services.Decorate<IBasketReponsitory, CachedBasketReponsitory>();

//Configure the HTTP request pipeline
var app = builder.Build();
app.MapCarter();
app.UseExceptionHandler(options => { });
app.UseHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});
app.Run();