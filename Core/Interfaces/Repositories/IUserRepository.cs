using Core.Models;
using Core.Request;

namespace Core.Interfaces.Repositories;

public interface IUserRepository
{
    Task<string> Add(CreateUserModel model);
    Task<UserDTO> GetById(int id);
    Task<ListViewUserDTO> GetFiltered(FilterUserModel filter);
    Task<List<UserDTO>> GetAll();
    Task<string> Update(UpdateUserModel model);
    Task<bool> Delete(int id);
}