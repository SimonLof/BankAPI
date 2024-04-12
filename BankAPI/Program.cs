using BankApp.Core.Interfaces;
using BankApp.Core.Services;
using BankApp.Data.Identity;
using BankApp.Data.Interfaces;
using BankApp.Data.Repos;
using BankApp.Domain.Entities;
using BankApp.Domain.Profiles;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// automapper profiles (Kom ihåg att sätta public på profilerna)
builder.Services.AddAutoMapper(
    typeof(CustomerProfile),
    typeof(AccountProfile),
    typeof(DispositionProfile),
    typeof(TransactionProfile)
    );

// adding swagger stuff.
builder.Services.AddSwaggerGen();

// dbcontext setup.
builder.Services.AddDbContext<BankAppDataContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("LocalBankAppDB")));

// set up identity stuff
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<BankAppDataContext>();

// test stuff
builder.Services.AddScoped<ITestService, TestService>();
builder.Services.AddScoped<ITestRepo, TestRepo>();

// real stuff
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IAccountRepo, AccountRepo>();
builder.Services.AddScoped<IAccountService, AccountService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();
