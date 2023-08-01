using Microsoft.AspNetCore.Authorization;
using MyWebBank.Application.Extensions;
using MyWebBank.Infrastructure.Extensions;
using MyWebBank.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddPersistenceServices(builder.Configuration);

//var key = builder.Configuration.GetValue<string>("ApiSettings:Secret");
//builder.Services.AddAuthentication(x =>
//{
//    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//})
//    .AddJwtBearer(x =>
//    {
//        x.RequireHttpsMetadata = false;
//        x.SaveToken = true;
//        x.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuerSigningKey = true,
//            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
//            ValidateIssuer = false,
//            ValidateAudience = false
//        };
//    });

builder.Services.AddControllers();
//builder.Services.AddControllers(option => {
//    option.CacheProfiles.Add("Default30",
//       new CacheProfile()
//       {
//           Duration = 30
//       });
//    //option.ReturnHttpNotAcceptable=true;
//}).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddSwaggerGen(options => {
//    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//    {
//        Description =
//            "JWT Authorization header using the Bearer scheme. \r\n\r\n " +
//            "Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\n" +
//            "Example: \"Bearer 12345abcdef\"",
//        Name = "Authorization",
//        In = ParameterLocation.Header,
//        Scheme = "Bearer"
//    });
//    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
//    {
//        {
//            new OpenApiSecurityScheme
//            {
//                Reference = new OpenApiReference
//                            {
//                                Type = ReferenceType.SecurityScheme,
//                                Id = "Bearer"
//                            },
//                Scheme = "oauth2",
//                Name = "Bearer",
//                In = ParameterLocation.Header
//            },
//            new List<string>()
//        }
//    });
//});

builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
