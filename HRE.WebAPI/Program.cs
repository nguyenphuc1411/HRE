using HRE.Application.Interfaces;
using HRE.Application.Mappings;
using HRE.Application.Services;
using HRE.Infrastructure.Extentions;
using HRE.Infrastructure.Seeders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<IRobotService, RobotService>();
builder.Services.AddScoped<IRecyclingMachineService, RecyclingMachineService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IPermissionService, PermissionService>();
builder.Services.AddScoped<IAreaService, AreaService>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<IGiftRuleService, GiftRuleService>();
builder.Services.AddScoped<IGiftService, GiftService>();

builder.Services.AddInfrastructure(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IDataSeeder>();

await seeder.Seed();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
