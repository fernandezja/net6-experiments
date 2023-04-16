using Microsoft.AspNetCore.Server.Kestrel.Core;

var builder = WebApplication.CreateBuilder(args);


builder.Services.Configure<IISServerOptions>(options =>
{
    options.MaxRequestBodySize = int.MaxValue;
});

builder.Services.Configure<KestrelServerOptions>(options =>
{
    //Fix Exception > Microsoft.AspNetCore.Server.Kestrel.Core.BadHttpRequestException:
    //Request body too large. The max request body size is 30000000 bytes.
    options.Limits.MaxRequestBodySize = int.MaxValue; //Default value is: 30 MB
});


// Add services to the container.
builder.Services.AddControllersWithViews(options => {
                    //options.MaxModelBindingCollectionSize = int.MaxValue;
                })
                .AddJsonOptions(options => {
                    options.JsonSerializerOptions.PropertyNameCaseInsensitive = false;
                }); ;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
