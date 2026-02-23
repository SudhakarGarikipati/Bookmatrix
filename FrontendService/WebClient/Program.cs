using WebClient.HttpClients;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure HttpClient with base address and timeout
builder.Services.AddHttpClient("HttpClient", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiGatewayAddress"]);
    client.Timeout = TimeSpan.FromMinutes(2);
});

// Register AuthHttpClient as a scoped service
builder.Services.AddScoped<AuthHttpClient>(sp =>
{
    var httpClientFactory = sp.GetRequiredService<IHttpClientFactory>();
    var client = httpClientFactory.CreateClient("HttpClient"); 
    return new AuthHttpClient(client);
});

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
     name: "areas",
     pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
   );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
