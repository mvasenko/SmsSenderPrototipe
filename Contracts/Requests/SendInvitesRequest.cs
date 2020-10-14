using System.Collections.Generic;

namespace Contracts.Requests
{
    public class SendInvitesRequest
    {
        public List<string> PhoneNumbers { get; set; }

        public string Message { get; set; }
    }
}
