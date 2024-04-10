using LoanModule.Middleware;
using LoanModule.Repositories.Implementation;
using LoanModule.Repositories.Interface;
using LoanModule.Service.Implementation;
using LoanModule.Service.Interface;
using Shared.Repositories.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IBranchService, BranchService>();
builder.Services.AddTransient<IBranchRepository, BranchRepository>();
builder.Services.AddTransient<IGenericRepository, GenericRepositroy>();
builder.Services.AddTransient<IDapperRepository, DapperRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();
