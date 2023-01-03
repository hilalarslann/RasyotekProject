using Microsoft.EntityFrameworkCore;
using Rasyotek.Dal;
using Rasyotek.DTO;
using Rasyotek.Entities.Concrete;
using Rasyotek.Repository.Abstract;
using Rasyotek.Repository.Concrete;
using Rasyotek.Service.HttpResponse;
using Rasyotek.Uow;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RasyotekContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnect")));

builder.Services.AddScoped<IUow, Uow>();
builder.Services.AddScoped<IEmployeeRep, EmployeeRep<Employee>>();
builder.Services.AddScoped<IDebitRep, DebitRep<Debit>>();
builder.Services.AddScoped<IDebitDetailRep, DebitDetailRep<EmployeeDebits>>();
builder.Services.AddScoped<Response>();
builder.Services.AddScoped<EmployeeModel>();
builder.Services.AddScoped<EmployeeDTO>();
builder.Services.AddScoped<DebitDetailDTO>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          //Bu html de post olarak gönderdiðimiz verileri okur.
                          policy.AllowAnyOrigin();
                          policy.AllowAnyMethod();
                          policy.AllowAnyHeader();
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
