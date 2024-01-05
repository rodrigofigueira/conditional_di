using ConditionalDI.Concret;
using ConditionalDI.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//para ter acesso ao http
builder.Services.AddHttpContextAccessor();

//inicializar as classes concretas
builder.Services.AddScoped<AdminMessage>();
builder.Services.AddScoped<SimpleMessage>();

//resolve qual objeto injetar baseado no cookie
builder.Services.AddScoped<IMessageService>(provider => {
    var context = provider.GetRequiredService<IHttpContextAccessor>();

        var isAdmin = context.HttpContext?.Request.Cookies.ContainsKey("admin") == true;

        if (isAdmin)
        {
            return provider.GetRequiredService<AdminMessage>();
        }

        return provider.GetRequiredService<SimpleMessage>();
});

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
