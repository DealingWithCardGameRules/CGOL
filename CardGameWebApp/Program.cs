using CardGameWebApp;
using dk.itu.game.msc.cgdl;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Setup Game Description Language
builder.Services.AddCardGameDescriptionLanguage();
builder.Services.AddSingleton(p => p.GetRequiredService<GDLFactory>().Create());

var app = builder.Build();

// Setup simple handlers for common concepts
app.Services.GetService<GDLSetup>()?.AddHandlers();

await app.RunAsync();
