using System;

namespace TicketViewer.App.Web.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public Exception Exception { get; set; }

        public string InnerErrorMessage
        {
            get
            {
                var exception = this.Exception;
                while (exception?.InnerException != null)
                {
                    exception = exception.InnerException;
                }

                return exception?.Message;
            }
        }
    }
}
