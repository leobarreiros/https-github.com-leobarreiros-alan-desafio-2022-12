using Commands.Clientes.CadastrarCliente;
using Commands.Clientes.CadastrarCliente.Dtos;
using Infra.DI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddApiDeMoedasServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapPost("/api/v1/cliente",
async (
    CadastrarClienteRequestDto request,
    CadastrarClienteHandler handler
) =>
{
    var result = await handler.Handle(request);
    return Results.Ok(result.Id);
});

app.Run();
