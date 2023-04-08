using RW7.DotNetSecurityTools.ClientCredentials;
using RW7.DotNetSecurityTools.JsonWebKeys;
using RW7.DotNetSecurityTools.RsaSecurityKeys;

using WebApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddSingleton<IRsaSecurityKeyCreator, RsaSecurityKeyCreator>();

builder.Services.AddSingleton<IJsonWebKeyCreator, JsonWebKeyCreator>();

builder.Services.AddSingleton<IClientCredentialsCreator, ClientCredentialsCreator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
