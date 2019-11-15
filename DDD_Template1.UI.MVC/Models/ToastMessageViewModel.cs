using System;
using System.Collections.Generic;

namespace DDD_Template1.UI.MVC.Models
{
    [Serializable]
    public class ToastMessageViewModel
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public ToastTypeEnum ToastType { get; set; }
        public bool IsSticky { get; set; }
    }

    public enum ToastTypeEnum
    {
        Danger,
        Info,
        Success,
        Warning
    }

    [Serializable]
    public class Toastr
    {
        public bool ShowNewestOnTop { get; set; }
        public bool ShowCloseButton { get; set; }
        public List<ToastMessageViewModel> ToastMessages { get; set; }
        public int Timeout { get; set; }

        public ToastMessageViewModel AddToastMessage(string message, ToastTypeEnum toastType, int timeout)
        {
            Timeout = timeout;
            var toast = new ToastMessageViewModel()
            {
                Message = message,
                ToastType = toastType
            };
            ToastMessages.Add(toast);
            return toast;
        }

        public Toastr()
        {
            ToastMessages = new List<ToastMessageViewModel>();
            ShowNewestOnTop = false;
            ShowCloseButton = false;
        }
    }
}