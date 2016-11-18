using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chaotica_Dev_Kit
{
    class ChaoticaUser
    {
        public String Username { get; set; }
        public String Password { get; set; }

        public String Title { get; set; }

        public static ChaoticaUser GenerateProfile(String username)
        {

            return new ChaoticaUser();
        }
    }
}
