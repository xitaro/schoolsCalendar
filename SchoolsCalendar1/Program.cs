using SchoolsCalendar1.Data;
using Microsoft.EntityFrameworkCore;
using SchoolsCalendar1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SchoolsCalendarContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("SchoolsCalendarConnection"), new MySqlServerVersion(new Version(8, 0, 22))));

builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<IStudentService, StudentService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("https://schoolscalendar-heroku.herokuapp.com");
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(/*c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
}*/);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
