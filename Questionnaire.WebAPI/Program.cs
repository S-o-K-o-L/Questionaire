using Questionnaire.WebAPI.AppConfiguration.ServicesExtensions;
using Questionnaire.WebAPI.AppConfiguration.ApplicationExtensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


builder.AddSerilogConfiguration();
builder.Services.AddVersioningConfiguration(); //add api versioning
builder.Services.AddControllers();
builder.Services.AddSwaggerConfiguration();




var app = builder.Build();

app.UseSerilogConfiguration();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerConfiguration();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();