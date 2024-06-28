
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();


builder.Services.AddHttpClient();


var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    
    app.UseExceptionHandler("/Home/Error");

    
    app.UseHsts();
}


app.UseHttpsRedirection();


app.UseStaticFiles();

// Enable routing
app.UseRouting();


app.UseAuthorization();

// Mapping controller using the itemid
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
