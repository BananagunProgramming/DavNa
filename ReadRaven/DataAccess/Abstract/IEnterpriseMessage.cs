using System;

namespace DataAccess.Models
{
    public interface IEnterpriseMessage : IMessage
    {
        Guid EnterpriseId { get; set; }
    }
}
