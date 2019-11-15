using System.Collections.Generic;

namespace DDD_Template1.Domain.DTOs
{
    public class DistanceResultDTO
    {
        #region Public props

        public double Distance { get; set; }

        public List<string> Notifications { get; set; }

        public string Url { get; set; }

        #endregion Public props

        #region Ctors

        public DistanceResultDTO()
        {
            Notifications = new List<string>();
        }

        #endregion Ctors
    }
}