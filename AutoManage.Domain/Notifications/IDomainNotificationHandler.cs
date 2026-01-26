namespace AutoManage.Domain.Notifications
{
    public interface IDomainNotificationHandler
    {
        void Add(DomainNotification notification);
        IReadOnlyCollection<DomainNotification> GetNotifications();
        bool HasNotifications();
    }
}
