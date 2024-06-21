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


    public async Task<List<UserDTO>> GetFiltered(FilterUserModel filter)
    {
        return await _userRepository.GetFiltered(filter);
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