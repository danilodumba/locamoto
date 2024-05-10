using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locamoto.Domain.Services
{
    public interface IMessageBrokerService
    {
        Task Publish();
    }
}