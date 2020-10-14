using System.Collections.Generic;

namespace BLL.Contracts.DTObjects
{
    public class SendInvitesDto
    {
        public List<string> PhoneNumbers { get; set; }

        public string Message { get; set; }
    }
}
