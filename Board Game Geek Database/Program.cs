using AspNetStatic;
using AspNetStatic.Optimizer;
using AspNetStaticContrib.AspNetStatic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

builder.Services.AddSingleton<IStaticResourcesInfoProvider>(
  new StaticResourcesInfoProvider(
    new ResourceInfoBase[]
    {
      new PageResource("/"),
      new PageResource("/Home/Privacy"),
      new PageResource("/Home/About"),
      new PageResource("/Home/BGDatabase"),
      new PageResource("/Home/Poke"),
      new CssResource("/lib/bootstrap/dist/css/bootstrap.css") { OptimizationType = OptimizationType.None },
      new CssResource("/css/site.css"),
      new JsResource("/js/site.js"),
      new BinResource("/favicon.ico")
    }));

var app = builder.Build();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

string outputPath = Path.Combine(builder.Environment.ContentRootPath, "docs");
app.GenerateStaticContent(outputPath);

app.Run();
