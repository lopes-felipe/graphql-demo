using Demo.Service.Gateway.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.Service.Gateway.Core.Service
{
    public interface ITitleService
    {
        Task<Title> GetAsync(string id);

        Task<IEnumerable<Title>> ListAsync(int first);

        Task<IEnumerable<Title>> ListFromPersonId(string personId);
    }
}
