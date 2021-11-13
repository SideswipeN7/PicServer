using Pic.Service.Extensions;

var app = WebApplication
    .CreateBuilder(args)
    .AddConfigurations()
    .RegisterServicesAndDI()
    .Build();

app.UseConfiguredSwagger();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseStaticFiles();

app.UseClientApp();

app.RunMigrations();

app.Run();
