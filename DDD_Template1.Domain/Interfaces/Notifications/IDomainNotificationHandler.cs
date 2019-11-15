using DDD_Template1.Domain.Notifications;
using System;
using System.Collections.Generic;

namespace DDD_Template1.Domain.Interfaces.Notifications
{
    public interface IDomainNotificationHandler : IDisposable
    {
        bool HasNotifications { get; }

        IEnumerable<DomainNotification> GetNotifications();

        void Add(string value, int version = 1);

        void Add(string key, string value, int version = 1);
    }
}