using Sibers.DbStuff.Models;
using System.Linq;

namespace Sibers.DbStuff.Repository
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(DBSibersContext context) : base(context) { }

        //public User GetUserByEmail(string email)
        //{
        //    return _dbSet.SingleOrDefault(x => x.Email == email);
        //}

    }
}
