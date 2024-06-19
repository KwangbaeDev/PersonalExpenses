using Core.Models;
using Core.Request;

namespace Core.Interfaces.Services;

public interface IUserService
{
    Task<UserDTO> Add(CreateUserModel model);
    Task<UserDTO> GetById(int id);
    Task<List<UserDTO>> GetAll();
    Task<UserDTO> Update(UpdateUserModel model);
    Task<bool> Delete(int id);
}