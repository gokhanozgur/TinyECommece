using FluentValidation.AspNetCore;
using TinyECommerce.Application.Validators;
using TinyECommerce.Infrastructure.Filters;
using TinyECommerce.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

/* Add Services to Ioc Container */
builder.Services.AddPersistenceServices();

/* CORS Policies */
builder.Services.AddCors(options =>
    options.AddDefaultPolicy(policyBuilder =>
        policyBuilder.AllowAnyHeader().AllowAnyMethod().WithOrigins(Configuration.AllowedHosts)
            .SetIsOriginAllowedToAllowWildcardSubdomains()
    )
);

/* Application controllers with fluent validations declaration */
builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>())
    .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateProductValidator>())
    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);

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

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();