# SofiaChat 💬

Simple C#/.NET 8 minimal API demo that connects to OpenAI's GPT model
for chatting about the SOFIA Flow 88 catheter.

## Run locally

```bash
export OPENAI_API_KEY="your-openai-api-key-here"
dotnet run --project SofiaChat
dotnet watch --project SofiaChat run --urls http://localhost:5088

# watch Launches URL automatically
