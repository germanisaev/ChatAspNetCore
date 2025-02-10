using ChatService.DataService;
using ChatService.Hubs;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins, builder =>
    {
        builder.WithOrigins("http://localhost:3000")
               .AllowAnyHeader()
               .AllowAnyMethod()
               .AllowCredentials();
    });
});

builder.Services.AddSignalR();
builder.Services.AddControllers();

builder.Services.AddSingleton<SharedDb>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseRouting(); // Make sure UseRouting is present

app.UseAuthorization();



app.MapControllers();

app.UseCors(MyAllowSpecificOrigins);

app.MapHub<ChatHub>("/chat");

/* app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<ChatHub>("/chat")
             .RequireCors(MyAllowSpecificOrigins); 
}); */

app.Run();
