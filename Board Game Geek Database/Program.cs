using AspNetStatic;
using AspNetStatic.Optimizer;
using AspNetStaticContrib.AspNetStatic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

var provider = new StaticResourcesInfoProvider(
    new PageResource[]
    {
      new PageResource("/"),
      new PageResource("/Home/Privacy"),
      new PageResource("/Home/About"),
      new PageResource("/Home/BGDatabase"),
      new PageResource("/Home/Poke"),
    });

provider.AddAllWebRootContent(builder.Environment);

builder.Services.AddSingleton<IStaticResourcesInfoProvider>(provider);

var app = builder.Build();

if(app.Environment.IsProduction())
{
    app.UsePathBase("/Board-Game-Geek-Database");
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

string outputPath = Path.Combine(builder.Environment.ContentRootPath, "..", "docs");
app.GenerateStaticContent(outputPath, alwaysDefaultFile: true);

app.Run();
