using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace purevanillymatnenaushilasshitat.Entities
{
    class users
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password_hash { get; set; }
        public int role_id { get; set; }
    }
}
