using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioTracker.Data.Dtos.Auth
{
    public class PortfolioUser : IdentityUser
    {
        [PersonalData]
        public string AdditionalInfo { get; set; }
    }
}
