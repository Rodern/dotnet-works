using BridgeMall.Contexts.RDB;
using BridgeMall.Models.CRUD;
using BridgeMall.Models.Data;
using BridgeMall.Models.Relational;
using BridgeMall.Services.Interfaces;
using System.Collections.ObjectModel;

namespace BridgeMall.Services.DB
{
    public class UserService : IUserService
    {
        private readonly ICrud _crud;
        private readonly BridgeMallDbContext _dbContext;
        public UserService(BridgeMallDbContext dbContext, ICrud crud)
        {
            _dbContext = dbContext;
            _crud = crud;
        }

        public CrudResponse CreateUser(User user)
        {
            return _crud.CreateEntity(user.UserId, user);
        }

        public CrudResponse DeleteUser(int id)
        {
            return _crud.DeleteEntity<User>(id);
        }

        public User GetUser(int id)
        {
            return _crud.GetEntity<User>(id);
        }

        public ObservableCollection<User> GetUsers()
        {
            return new(_dbContext.Users.ToList());
        }

        public ObservableCollection<User> GetUsers(string? searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                return new(_dbContext.Users.ToList());
            }
            else
            {
                return new(_dbContext.Users.Where(x => x.Name.ToLower().Contains(searchString.ToLower())).ToList());
            }
        }

        public CrudResponse UpdateUser(User user)
        {
            return _crud.UpdateEntity(user.UserId, user);
        }
    }
}
