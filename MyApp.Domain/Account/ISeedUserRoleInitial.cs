using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Account
{
    public interface ISeedUserRoleInitial
    {
        void seedUser();
        void seedRoles();
    }
}
