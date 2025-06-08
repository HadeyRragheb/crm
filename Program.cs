using CRMProject.Components;         // root Razor component <App>
using CRMProject.Data;               // DbContext
using Microsoft.EntityFrameworkCore; // UseSqlServer extension

var builder = WebApplication.CreateBuilder(args);

// ---------- Add services to DI container ----------
builder.Services.AddRazorComponents()          // Blazor components
                .AddInteractiveServerComponents(); // interactive mode

// Register EF-Core DbContext (scoped per request / circuit)
builder.Services.AddDbContext<CRMContext>(opts =>
    opts.UseSqlServer(                       // SQL Server provider
        builder.Configuration
               .GetConnectionString("DefaultConnection"))); // from appsettings

// ---------- Build the web-app ----------
var app = builder.Build();

// ---------- Middleware pipeline ----------
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true); // nice error page
    app.UseHsts();                                                // 30-day HSTS
}

app.UseHttpsRedirection(); // redirect http ? https
app.UseStaticFiles();      // serve wwwroot/*
app.UseAntiforgery();      // antiforgery cookie

// Map Razor components (root is <App/>)
app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode();  // enable server-side interactivity

app.Run(); // start Kestrel
