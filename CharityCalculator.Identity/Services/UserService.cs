using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CharityCalculator.Application.Contracts.Identity;
using CharityCalculator.Application.Models.Identity;
using CharityCalculator.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace CharityCalculator.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public Task<List<Donor>> GetDonors()
        {
            throw new NotImplementedException();
        }

        public Task<Donor> GetDonor(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<EventPromoter>> GetEventPromoters()
        {
            throw new NotImplementedException();
        }

        public Task<EventPromoter> GetEventPromoter(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<SiteAdministrator>> GetSiteAdministrators()
        {
            throw new NotImplementedException();
        }

        public Task<SiteAdministrator> GetSiteAdministrator(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
