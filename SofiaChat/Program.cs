var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/ping", () => "pong");


app.UseDefaultFiles();
app.UseStaticFiles();
app.Run();
