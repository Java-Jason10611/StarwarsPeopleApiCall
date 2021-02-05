
using SwapiPeopleThisTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwapiPeopleThisTime.Services
{
    public interface IPeopleClient
    {
        public Task<PeopleResponse> GetPeopleInfo();
        public Task<PeopleResponse> GetPeopleInfo(string urlStrippedToPageInfo);
    }
}
