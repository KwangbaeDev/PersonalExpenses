using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models;
using Core.Request;

namespace Infrastructure.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserDTO> Add(CreateUserModel model)
    {
        return await _userRepository.Add(model);
    }


    public async Task<UserDTO> GetById(int id)
    {
        return await _userRepository.GetById(id);
    }


    // public async Task<(int totalSize, int totalPages, int page, int sizeRegisters, List<UserDTO>)> GetFiltered(FilterUserModel filter)
    // {
    //     var result = await _userRepository.GetFiltered(filter);
    //     return (result.totalSize, result.totalPages, result.page, result.sizeRegisters, result.Item5);
    // }
    public async Task<ListViewUserDTO> GetFiltered(FilterUserModel filter)
    {
        var result = await _userRepository.GetFiltered(filter);
        return result;
    }
    

    public async Task<List<UserDTO>> GetAll()
    {
        return await _userRepository.GetAll();
    }


    public async Task<UserDTO> Update(UpdateUserModel model)
    {
        return await _userRepository.Update(model);
    }


    public async Task<bool> Delete(int id)
    {
        return await _userRepository.Delete(id);
    }

}