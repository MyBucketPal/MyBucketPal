using Backend.Data;
using Backend.Repository;
using Backend.Services;
using Backend.Services.Authentication;
using Backend.Services.Authentication.TokenService;
using Backend.Services.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add configuration files and secrets
builder.Configuration.AddJsonFile("appsettings.json");
builder.Configuration.AddUserSecrets<Program>();

ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Ensure the application listens on all network interfaces
app.Urls.Add("http://0.0.0.0:80");

ConfigureMiddleware(app);

app.Run();

void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    // Application services
    services.AddScoped<IUnitOfWork, UnitOfWork>();
    services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    services.AddScoped<IUserRepository, UserRepository>();

    // Add controllers and Swagger
    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

    // Configure Application DbContext
    var connectionString = configuration.GetConnectionString("DefaultConnection");
    services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

    // Configure Identity DbContext
    services.AddDbContext<UserContext>(options => options.UseSqlServer(connectionString));

    // Add Identity services
    services.AddIdentity<IdentityUser, IdentityRole>()
        .AddEntityFrameworkStores<UserContext>()
        .AddDefaultTokenProviders();

    // Register the UserService
    services.AddScoped<UserService>();

    // JWT Configuration
    var jwtSettings = configuration.GetSection("Jwt");
    var issuerSigningKey = jwtSettings["IssuerSigningKey"];

    // Add authentication services with JWT and Cookies
    services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings["ValidIssuer"],
            ValidAudience = jwtSettings["ValidAudience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(issuerSigningKey))
        };
        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                context.Token = context.Request.Cookies["jwt"];
                return Task.CompletedTask;
            }
        };
    })
    .AddCookie(options =>
    {
        options.Cookie.HttpOnly = true;
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Set to Always in production
        options.Cookie.SameSite = SameSiteMode.None;
        options.Cookie.Name = "jwt";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    });

    services.AddScoped<TokenManager>();

    // Add CORS
    services.AddCors(options =>
    {
        options.AddDefaultPolicy(
            builder =>
            {
                builder.WithOrigins("http://localhost:5173")
                       .AllowAnyHeader()
                       .AllowAnyMethod()
                       .AllowCredentials();
            });
    });
}

async void ConfigureMiddleware(WebApplication app)
{
    // Swagger configuration
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    // Middleware configuration
    app.UseHttpsRedirection();
    app.UseStaticFiles(); // Serve static files from wwwroot

    app.UseRouting();
    app.UseCors();

    app.UseAuthentication();
    app.UseAuthorization();

    app.UseCookiePolicy(new CookiePolicyOptions
    {
        HttpOnly = HttpOnlyPolicy.Always,
        Secure = CookieSecurePolicy.Always, // Set to Always in production
        MinimumSameSitePolicy = SameSiteMode.None
    });

    // Endpoint configuration
    app.MapControllers();

    // Fallback to serve index.html for SPA
    app.MapFallbackToFile("index.html");

    // Seed data
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var userContext = scope.ServiceProvider.GetRequiredService<UserContext>();

        dbContext.Database.Migrate();

        userContext.Database.Migrate();

        var services = scope.ServiceProvider;
        await SeedData.Initialize(services);
    }
}