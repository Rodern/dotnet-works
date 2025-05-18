using BridgeMall.Models.Data;
using BridgeMall.Models.Relational;
using System.Collections.ObjectModel;

namespace BridgeMall.Services.Interfaces
{
    public interface IUserService
    {
        public ObservableCollection<User> GetUsers();
        public ObservableCollection<User> GetUsers(string? searchString);
        public User GetUser(int id);
        public User GetUserByEmail(string email);
        public CrudResponse CreateUser(User user);
        public CrudResponse UpdateUser(User user);
        public CrudResponse DeleteUser(int id);
    }
}
