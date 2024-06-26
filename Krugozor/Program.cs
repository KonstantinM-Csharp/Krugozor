using Krugozor.Models;
using Krugozor.Services;
using Krugozor.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.Configure<MailSettings>(
        builder
            .Configuration
            .GetSection(nameof(MailSettings))
    );
builder.Services.Configure<MailData>(
        builder
            .Configuration
            .GetSection(nameof(MailData))
    );
builder.Services.AddTransient<IMailService, MailService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Mail}/{action=Index}");

app.Run();
