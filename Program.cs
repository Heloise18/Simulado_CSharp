

using Microsoft.EntityFrameworkCore;
using simulado.Entities;
using simulado.UseCases.Auth;
using simulado.UseCases.DeleteFicByID;
using simulado.UseCases.EditList;
using simulado.UseCases.GetList;
using simulado.UseCases.RegisterFic;

var builder = WebApplication.CreateBuilder(args);

// var strConnection = Environment.GetEnvironmentVariable("SQLCONN");
//     builder.Services.AddDbContext<FicsDbContext>(options
//     => options.UseSqlServer(strConnection)
// );

// builder.Services.AddDbContext<FicsDbContext>(options => {
//     var sqlConn = Environment.GetEnvironmentVariable("SQL_CONNECTION");
//     options.UseSqlServer(sqlConn);
// });


builder.Services.AddTransient<AuthUseCase>();
builder.Services.AddTransient<DeleteFicUseCase>();
builder.Services.AddTransient<EditListUseCase>();
builder.Services.AddTransient<GetListUseCase>();
builder.Services.AddTransient<RegisterFicUseCase>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();



app.Run();
