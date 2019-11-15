using DDD_Template1.Domain.Interfaces.Notifications;
using System.Collections.Generic;
using System.Linq;

namespace DDD_Template1.Domain.Notifications
{
    public class DomainNotificationHandler : IDomainNotificationHandler
    {
        private readonly List<DomainNotification> _notifications;

        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        public void Add(string value, int version = 1)
        {
            Add(string.Empty, value, version);
        }

        public void Add(string key, string value, int version = 1)
        {
            _notifications.Add(new DomainNotification(key, value, version));
        }

        public void Dispose()
        {
            _notifications.Clear();
        }

        public IEnumerable<DomainNotification> GetNotifications()
        {
            return _notifications;
        }

        public bool HasNotifications
        {
            get
            {
                return _notifications.Any();
            }
        }
    }
}