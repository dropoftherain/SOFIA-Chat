// var builder = WebApplication.CreateBuilder(args);
// var app = builder.Build();

// app.MapGet("/", () => "Hello World!");
// app.MapGet("/ping", () => "pong");


// app.UseDefaultFiles();
// app.UseStaticFiles();
// app.Run();

using SofiaChat.Services;
using SofiaChat.Models;

var builder = WebApplication.CreateBuilder(args);

// bind config pre OpenAI (model name)
builder.Services.Configure<OpenAiSettings>(builder.Configuration.GetSection("OpenAI"));
builder.Services.AddSingleton<LlmService>();

var app = builder.Build();

app.UseDefaultFiles();  // wwwroot/index.html
app.UseStaticFiles();

// health-check
app.MapGet("/ping", () => "pong");

// chat endpoint
app.MapPost("/api/chat", async (ChatRequest req, LlmService llm, CancellationToken ct) =>
{
    if (string.IsNullOrWhiteSpace(req.Message))
        return Results.BadRequest("Empty message.");

    try
    {
        var resp = await llm.AskAsync(req.Message, ct);
        return Results.Ok(resp);
    }
    catch (Exception ex)
    {
        // v praxi by si zalogovala a vrátila generickú chybu
        return Results.Problem($"Chat error: {ex.Message}");
    }
});

app.Run();
