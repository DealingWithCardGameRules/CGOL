using System;

namespace CardGameWebApp.Shared.Inquiries
{
    public class AskPlayerInquiry
    {
        public Guid CorrespondenceId { get; }
        public string Message { get; }

        public AskPlayerInquiry(Guid correspondenceId, string message)
        {
            CorrespondenceId = correspondenceId;
            Message = message;
        }
    }
}
