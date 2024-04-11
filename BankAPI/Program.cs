using BankApp.Core.Interfaces;
using BankApp.Core.Services;
using BankApp.Data.Identity;
using BankApp.Data.Interfaces;
using BankApp.Data.Repos;
using BankApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// adding swagger stuff.
builder.Services.AddSwaggerGen();

// dbcontext setup.
builder.Services.AddDbContext<BankAppDataContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("LocalBankAppDB")));

// set up identity stuff
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<BankAppDataContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<ITestService, TestService>();
builder.Services.AddScoped<ITestRepo, TestRepo>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();

app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();
