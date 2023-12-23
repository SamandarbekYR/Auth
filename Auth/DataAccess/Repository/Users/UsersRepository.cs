using Auth.DataAccess.Data;
using Auth.Entity.Users;

namespace Auth.DataAccess.Repository.Users
{
    public class UsersRepository
    {
        private AppDbContext _appDb;

        public UsersRepository(AppDbContext appDb)
        {
            _appDb = appDb;
        }

        public void Add (User user)
        {
            _appDb.User.Add(user);
            _appDb.SaveChanges();
        }
    }
}
