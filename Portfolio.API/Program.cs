using Microsoft.Extensions.FileProviders;
using Portfolio.API.Extensions;
using Portfolio.Helpers;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

//// Configs services
// Add Controllers
builder.Services.AddControllers().AddCustomResponse();

// Config Endpoints
builder.Services.AddEndpointsApiExplorer();

// Add DbContext
builder.Services.AddDbContext(builder.Configuration);

// Add AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add Identity
builder.Services.AddIdentity();

// Add Config Jwt
builder.Services.AddAuthJwt(builder.Configuration);

// Add Cors
builder.Services.AddCors(builder.Configuration);

// Add Repositories
builder.Services.AddRepositories();

// Add Services
builder.Services.AddServices();

// Add Swagger
builder.Services.AddSwaggerGeneration(builder.Configuration);

WebApplication app = builder.Build();

// Configure is Dev
if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();

// Config Swagger page
app.UseSwagger()
   .UseSwaggerUI(c => c.SwaggerEndpoint($"/swagger/v{builder.Configuration[ConfigAppSettings.VersionApi]}/swagger.json", "Portfolio.API"));

// Config Https
app.UseHttpsRedirection();

// Config http context
app.UseHttpContext();

// Config cors
app.UseCors(ConfigPolicy.Cors);

// Config static files
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(
               Path.Combine(Directory.GetCurrentDirectory(), @"Directory")),
    RequestPath = new PathString("/Static")
});
app.UseDirectoryBrowser(new DirectoryBrowserOptions()
{
    FileProvider = new PhysicalFileProvider(
    Path.Combine(Directory.GetCurrentDirectory(), @"Directory")),
    RequestPath = new PathString("/Static")
});

// Config authorization/authentication
app.UseAuthentication();
app.UseAuthorization();

// Config mapping controllers app
app.MapControllers();

// Config date postgres
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

app.Run();
