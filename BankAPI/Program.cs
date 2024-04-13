using BankApp.API.Extensions;
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
    typeof(TransactionProfile),
    typeof(LoanProfile)
    );

// adding swagger stuff.
builder.Services.AddSwaggerExtended();


// dbcontext setup.
builder.Services.AddDbContext<BankAppDataContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("LocalBankAppDB")));

// set up identity stuff
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<BankAppDataContext>()
    .AddDefaultTokenProviders();


// test stuff
builder.Services.AddScoped<ITestService, TestService>();
builder.Services.AddScoped<ITestRepo, TestRepo>();

// real stuff
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IAccountRepo, AccountRepo>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ILoanRepo, LoanRepo>();
builder.Services.AddScoped<ILoanService, LoanService>();
builder.Services.AddScoped<ITransactionRepo, TransactionRepo>();
builder.Services.AddScoped<ITransactionService, TransactionService>();

// cookie stuff
builder.Services.AddCookieExtended();

var app = builder.Build();

app.UseSwaggerExtensions();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();
