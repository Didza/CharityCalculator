using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CharityCalculator.Application.Models.Identity;

namespace CharityCalculator.Application.Contracts.Identity
{
    public interface IUserService
    {
        Task<List<Donor>> GetDonors();
        Task<Donor> GetDonor(string userId);
        Task<List<EventPromoter>> GetEventPromoters();
        Task<EventPromoter> GetEventPromoter(string userId);
        Task<List<SiteAdministrator>> GetSiteAdministrators();
        Task<SiteAdministrator> GetSiteAdministrator(string userId);
    }
}
