using Pic.Service.Extensions;

var app = WebApplication
    .CreateBuilder(args)
    .AddConfigurations()
    .RegisterServices()
    .Build();

app.UseConfiguredSwagger();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseStaticFiles();

app.UseSpaStaticFiles();

app.UseClientApp();

app.MapControllers();

app.RunMigrations();

app.Run();
