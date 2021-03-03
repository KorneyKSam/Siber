using Sibers.DbStuff.Models;
using System.Linq;

namespace Sibers.DbStuff.Repository
{
    public class User_Repository : Base_Repository<User>
    {
        public User_Repository(DBSibersContext context) : base(context) { }

    }
}
