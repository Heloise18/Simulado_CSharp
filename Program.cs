

using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using simulado.Endpoints;
using simulado.Entities;
using simulado.UseCases.Auth;
using simulado.UseCases.DeleteFicByID;
using simulado.UseCases.EditList;
using simulado.UseCases.GetList;
using simulado.UseCases.RegisterFic;


var builder = WebApplication.CreateBuilder(args);

// var strConnection = Environment.GetEnvironmentVariable("SQL_CONNECTION");
//     builder.Services.AddDbContext<FicsDbContext>(options
//     => options.UseSqlServer(strConnection)
// );

builder.Services.AddDbContext<FicsDbContext>(options => {
    var sqlConn = Environment.GetEnvironmentVariable("SQL_CONNECTION");
    options.UseSqlServer(sqlConn);
});

//$env:SQL_CONNECTION = "Data Source=localhost/SQLEXPRESS22;Initial Catalog=FanficsHelo;Trust Server Certificate=true;Integrated Security=true"

// builder.Services.AddTransient<IJWTService, JWTService>();

builder.Services.AddTransient<RegisterFicUseCase>();
builder.Services.AddTransient<DeleteFicUseCase>();
builder.Services.AddTransient<EditListUseCase>();
builder.Services.AddTransient<GetListUseCase>();
builder.Services.AddTransient<AuthUseCase>();

var jwtSecret = Environment.GetEnvironmentVariable("JWT_SECRET");
var keyBytes = Encoding.UTF8.GetBytes(jwtSecret);
var key = new SymmetricSecurityKey(keyBytes);


// builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//     .AddJwtBearer(Options =>
//     {
//         Options.TokenValidationParameters = new()
//         {
//             ValidateIssuer = false,
//             ValidateAudience = false,
//             ValidIssuer = "Projeto-Final-Java-hihi",
//             ValidateIssuerSigningKey = true,
//             ValidateLifetime = true,
//             ClockSkew = TimeSpan.Zero,

//             IssuerSigningKey = key,
//         };
//     });


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();


app.ConfigureGetListByTitleEndpoint();
app.ConfigureAddFicByNameEndpoint();
app.ConfigureRegisterFicEndpoint();
app.ConfigureDeleteFicEndpoint();
app.ConfigureAuthEndpoints();

app.Run();
