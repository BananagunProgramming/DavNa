using System;

namespace DataAccess.Models
{
    public interface ICommunityMessage : IEnterpriseMessage
    {
        Guid CommunityId { get; set; }
        Guid MemberId { get; set; }
    }
}
