namespace Events.Classes;

public class Article
{
    public int Id { get; init; }
    public string Content { get; init; }
    public Article(int id, string content) =>
        (Id, Content) = (id, content);

    public override string ToString() => $"No. {Id}: {Content}";

}
