using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioTracker.Auth.Model
{
    public interface IUserOwnedResources
    {
        string UserId { get;  }

    }
}
