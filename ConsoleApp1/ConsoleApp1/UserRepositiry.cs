using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    public class User
    {
        public string Name { get; set; }
    }

    public class UserViewModel
    {
        public string Name { get; set; }
    }
    public class UserRepositiry : RepositoryBase<User, UserViewModel>
    {

    }
}
