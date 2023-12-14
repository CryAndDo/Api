using WebApplication1;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = AuthOptions.ISSUER,
        ValidateAudience = true,
        ValidAudience = AuthOptions.AUDIENCE,
        ValidateLifetime = true,
        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
        ValidateIssuerSigningKey = true
    };
});

string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
IServiceCollection serviceCollection = builder.Services.AddDbContext<ModelDB>(options => options.UseSqlServer(connection));
var app = builder.Build();
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.MapPost("/login", async(User loginData, ModelDB db) =>
{
    User? person = await db.Users!.FirstOrDefaultAsync(p => p.EMail == loginData.EMail && p.Password == loginData.Password);
    if (person == null) return Results.Unauthorized();

    var claims = new List<Claim> { new Claim(ClaimTypes.Email, person.EMail!) };
    var jwt = new JwtSecurityToken(issuer: AuthOptions.ISSUER,
        audience: AuthOptions.AUDIENCE,
        claims: claims,
        expires: DateTime.Now.Add(TimeSpan.FromMinutes(2)),
        signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
    var encoderJWT = new JwtSecurityTokenHandler().WriteToken(jwt);
    var response = new
    {
        access_token = encoderJWT,
        username = person.EMail
    };
    return Results.Json(response);  
});

app.MapGet("api/Tariffs", [Authorize] async (ModelDB db) => await db.Tariffs!.ToListAsync());
app.MapGet("api/Timesheet",  [Authorize] async (ModelDB db) => await db.Timesheets!.ToListAsync());
app.MapGet("api/Tariffs/{Id:int}", [Authorize] async (ModelDB db, int id) => await db.Tariffs!.Where(u=>u.Id == id).FirstOrDefaultAsync());
app.MapPost("api/Tariffs", [Authorize] async (Tariffs tarrif, ModelDB db) =>
{ 
    await db.Tariffs!.AddAsync(tarrif);
    await db.SaveChangesAsync();
    return tarrif;
});
app.MapPost("api/Timesheet", [Authorize] async (Timesheet timesheet, ModelDB db) =>
{
    await db.Timesheets!.AddAsync(timesheet);
    await db.SaveChangesAsync();
    return timesheet;
});
app.MapDelete("api/Tariffs/{Id:int}", [Authorize] async (int id, ModelDB db) =>
{
    Tariffs? tarrif = await db.Tariffs.Where(u => u.Id == id).FirstOrDefaultAsync();
    if (tarrif == null) return Results.NotFound(new { message = "Тариф не найден" });
    db.Tariffs.Remove(tarrif);
    await db.SaveChangesAsync();
    return Results.Json(tarrif);
});
app.MapDelete("api/Timesheet/{Id:int}", [Authorize] async (int Id, ModelDB db) =>
{
    Timesheet? timesheet = await db.Timesheets.Where(u => u.Id == Id).FirstOrDefaultAsync();
    if (timesheet == null) return Results.NotFound(new { message = "Табель учета рабочего времени не найден" });
    db.Timesheets.Remove(timesheet);
    await db.SaveChangesAsync();
    return Results.Json(timesheet);
});
app.MapPut("api/Tariffs", [Authorize] async (Tariffs tarrif, ModelDB db) =>
{
    Tariffs? a = await db.Tariffs.Where(u => u.Id == tarrif.Id).FirstOrDefaultAsync();
    if (a == null) return Results.NotFound(new { message = "Пользователь не найден" });
    a.Id = tarrif.Id;
    a.Price = tarrif.Price;  
    a.Name = tarrif.Name;
    db.Tariffs.Update(a);
    await db.SaveChangesAsync();
    return Results.Json(a);
});
app.MapPut("api/Timesheet", [Authorize] async (Timesheet timesheet, ModelDB db) =>
{
    Timesheet? s = await db.Timesheets.Where(u => u.Id == timesheet.Id).FirstOrDefaultAsync();
    if (s == null) return Results.NotFound(new { message = "Продажа не найдена" });
    s.Id = timesheet.Id;
    s.FIO = timesheet.FIO;
    s.Name = timesheet.Name;
    s.Speciality = timesheet.Speciality;
    s.Number_of_days_worked = timesheet.Number_of_days_worked;
    s.Zarplata = timesheet.Zarplata;
    s.Retention = timesheet.Retention;
    s.Amount_due = timesheet.Amount_due;
    db.Timesheets.Update(s);
    await db.SaveChangesAsync();
    return Results.Json(s);
});
app.Run();