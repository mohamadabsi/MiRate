using Framework.Attachments;
using Framework.Attachments.Data;
using Framework.Core.Contracts;
using Framework.Core.Data;
using Framework.Core.Data.Repositories;
using Framework.Core.Data.Uow;
using Framework.Notifications.Data;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MiRate.Web.Data;
using System;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));


// Configure the main application DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Configure the AttachmentsDbContext
builder.Services.AddDbContext<AttachmentsDbContext>(options =>
    options.UseSqlServer(connectionString));


// Configure the NotificationsDbContext
builder.Services.AddDbContext<NotificationsDbContext>(options =>
    options.UseSqlServer(connectionString));



// Configure the CommonDbContext
builder.Services.AddDbContext<CommonDbContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddDatabaseDeveloperPageExceptionFilter();



builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
.AddEntityFrameworkStores<ApplicationDbContext>();






builder.Services.AddRazorPages();
var app = builder.Build();



builder.Services.UseDatabase<AttachmentsDbContext>(app.Configuration, app.Environment, "DefaultConnection");

builder.Services.AddScoped(typeof(IUnitOfWorkBase<>), typeof(UnitOfWorkBase<>));

builder.Services.AddScoped<IAttachmentsUnitOfWork, AttachmentsUnitOfWork>();

builder.Services.AddScoped(typeof(IEfCoreRepository<,>), typeof(EfCoreRepository<,>));

builder.Services.AddScoped(typeof(IAttachmentsDbContext), typeof(AttachmentsDbContext));

builder.Services.AddScoped(typeof(IAttachmentsRepository<>), typeof(AttachmentsRepository<>));

app.Migrate<AttachmentsDbContext>(app.Services, app.Configuration, app.Environment);


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();


}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();


app.MapRazorPages();

app.Run();
