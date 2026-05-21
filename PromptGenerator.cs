using System;

public class PromptGenerator
{
    private readonly string[] prompts = new[]
    {
        "What made you smile today?",
        "What challenge did you overcome today?",
        "What are you grateful for right now?",
        "Describe a moment when you felt proud.",
        "What is one thing you learned today?",
        "How did you show kindness today?",
        "What is one goal you want to achieve tomorrow?",
        "Write about something that inspired you recently.",
        "What is one positive habit you want to build?",
        "How would you describe your day in one sentence?"
    };

    private readonly Random random = new();

    public string GetRandomPrompt()
    {
        int index = random.Next(prompts.Length);
        return prompts[index];
    }
}
