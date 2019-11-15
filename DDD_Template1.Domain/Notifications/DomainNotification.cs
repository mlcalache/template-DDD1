using System;

namespace DDD_Template1.Domain.Notifications
{
    public class DomainNotification
    {
        public string Key { get; private set; }
        public string Value { get; private set; }
        public DateTime DataHoraOcorrencia { get; private set; }
        public int Version { get; private set; }

        public DomainNotification(string key, string value, int version)
        {
            Key = key;
            Value = value;
            Version = version;
            DataHoraOcorrencia = DateTime.Now;
        }
    }
}