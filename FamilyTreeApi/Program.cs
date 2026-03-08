using FamilyTreeApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<FamilyTreeService>();
builder.Services.AddCors(options =>
                         {
                               options.AddDefaultPolicy(policy =>
                                                        {
                                                                  policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                                                        });
                         });
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseStaticFiles();
app.UseCors();
app.UseRouting();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
