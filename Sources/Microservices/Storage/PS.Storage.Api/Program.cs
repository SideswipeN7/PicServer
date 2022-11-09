﻿using PS.Storage.Api.Extensions;

var app = WebApplication.CreateBuilder(args)
    .AddConfigurations()
    .AddServices()
    .Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
