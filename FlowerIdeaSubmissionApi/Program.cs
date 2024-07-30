using FlowerIdeaSubmissionApi.Mapper;
using FlowerIdeaSubmissionApi.Repository;
using FlowerIdeaSubmissionApi.Repository.Repository;
using FlowerIdeaSubmissionApi.Repository.Repository.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<FlowerIdeaSubmissionApiDbContext>(x => x.UseSqlServer(FlowerIdeaSubmissionApiDbContext.CONNECTION_STRING));
//Repository
builder.Services.AddScoped<IIdeaRepository, IdeaRepository>();
// Services
builder.Services.AddScoped<IIdeaMapper, IdeaMapper>();  

builder.Services.AddCors(o =>
{
    o.AddDefaultPolicy(p =>
    {
        p.AllowAnyHeader();
        p.AllowAnyMethod();        
        p.SetIsOriginAllowed(x => true);
        p.AllowCredentials();
    });
});

var app = builder.Build();
app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
