using Pic.Service.Extensions;

var app = WebApplication
    .CreateBuilder(args)
    .AddConfigurations()
    .RegisterServices()
    .Build();

app.UseConfiguredSwagger();

app.UseCors(options => options.WithOrigins("http://localhost:4200").AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseStaticFiles();

app.UseSpaStaticFiles();

app.UseClientApp();

app.MapControllers();

app.UseMigrations();

app.Run();
