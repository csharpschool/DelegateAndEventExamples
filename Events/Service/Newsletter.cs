using Events.Classes;

namespace Events.Service;

public class Newsletter
{
    event EventHandler<Article>? PublishArticleEvent;

    public void Subscribe(EventHandler<Article> subscriptionMethod) =>
        PublishArticleEvent += subscriptionMethod;

    public void Unsubscribe(EventHandler<Article> subscriptionMethod) => 
        PublishArticleEvent -= subscriptionMethod;

    public void Publish(string content)
    {
        var id = new Random().Next();
        Article article = new(id, content);

        if (PublishArticleEvent is not null)
            PublishArticleEvent(this, article);
    }

}
