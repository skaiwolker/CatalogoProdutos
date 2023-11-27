using CatalogoProdutos;
using CatalogoProdutos.Data;
using CatalogoProdutos.Services;
using CatalogoProdutos.Services.Interface;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("CatalogoDB"));

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IProdutoService, ProdutoService>();

await builder.Build().RunAsync();
