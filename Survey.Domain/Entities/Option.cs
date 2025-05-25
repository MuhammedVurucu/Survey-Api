using System.Text.Json.Serialization;
using Survey.Domain.Entities;

public class Option
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid QuestionId { get; set; }
    public string Text { get; set; } = string.Empty;

    [JsonIgnore]
    public Question? Question { get; set; }

    public int NumberOfAnswers { get; set; } = 0;
}

