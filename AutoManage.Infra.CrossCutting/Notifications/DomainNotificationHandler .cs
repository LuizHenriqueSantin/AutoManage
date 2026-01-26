using AutoManage.Domain.Notifications;

namespace AutoManage.Infra.CrossCutting.Notifications
{
    public class DomainNotificationHandler : IDomainNotificationHandler
    {
        private readonly List<DomainNotification> _notifications = new();

        public void Add(DomainNotification notification)
        {
            if (notification != null)
                _notifications.Add(notification);
        }

        public bool HasNotifications()
        {
            return _notifications.Count > 0;
        }

        public IReadOnlyCollection<DomainNotification> GetNotifications()
        {
            return _notifications.AsReadOnly();
        }
    }
}
