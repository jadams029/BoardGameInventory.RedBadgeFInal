using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameInventory.Services
{
    public class W40kArmyService
    {
        private readonly Guid _userID;
        public W40kArmyService(Guid userID)
        {
            _userID = userID;
        }
    }
}
