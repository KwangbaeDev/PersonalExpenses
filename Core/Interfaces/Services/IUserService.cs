using Core.Models;
using Core.Request;

namespace Core.Interfaces.Services;

public interface IUserService
{
    Task<UserDTO> Add(CreateUserModel model);
    Task<UserDTO> GetById(int id);
    // Task<(int totalSize, int totalPages, int page, int sizeRegisters, List<UserDTO>)> GetFiltered(FilterUserModel filter);
    Task<ListViewUserDTO> GetFiltered(FilterUserModel filter);
    Task<List<UserDTO>> GetAll();
    Task<UserDTO> Update(UpdateUserModel model);
    Task<bool> Delete(int id);
}