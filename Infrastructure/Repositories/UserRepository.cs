using System.Linq;
using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Models;
using Core.Request;
using Infrastructure.Context;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly PersonalExpensesContext _context;
    private readonly IPasswordHasher<User> _passwordHasher;

    public UserRepository(PersonalExpensesContext context, IPasswordHasher<User> passwordHasher)
    {
        _context = context;
        _passwordHasher = passwordHasher;
    }

    public async Task<UserDTO> Add(CreateUserModel model)
    {
        var createUser = model.Adapt<User>();

        createUser.Password = _passwordHasher.HashPassword(createUser, model.Password);

        var userExiste = await _context.Users
                                        .FirstOrDefaultAsync(u => u.Email.ToLower() == model.Email.ToLower());

        if (userExiste != null)
        {
            throw new Exception ($"The user with {model. Email} is already registered");
        }

        _context.Users.Add(createUser);
        await _context.SaveChangesAsync();

        var userDTO = createUser.Adapt<UserDTO>();
        return userDTO;
    }


    public async Task<UserDTO> GetById(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null || user.IsDeleted == true)
        {
            throw new NotFoundException($"The user with the id: {id} does not exist");
        }

        var userDTO = user.Adapt<UserDTO>();
        return userDTO;
    }


    // public async Task<(int totalSize, int totalPages, int page, int sizeRegisters, List<UserDTO>)> GetFiltered(FilterUserModel filter)
    // {
    //     var query = _context.Users
    //                             .Where(u => u.IsDeleted != true)
    //                             .AsQueryable();

    //     if (!string.IsNullOrEmpty(filter.Name))
    //     {
    //         query = query.Where(u => u.Name.Contains(filter.Name));
    //     }

    //     if (!string.IsNullOrEmpty(filter.Email))
    //     {
    //         query = query.Where(u => u.Email.Contains(filter.Email));
    //     }

    //     var totalSize = await query.CountAsync();

    //     var totalPages = totalSize / filter.PageSize;

    //     var page = filter.PageIndex;

    //     var sizeRegisters = filter.PageSize;

    //     query = query.Skip((filter.PageIndex -1) * filter.PageSize) 
    //                  .Take(filter.PageSize);

    //     var result = await query.ToListAsync();
    //     return (totalSize, totalPages, page, sizeRegisters,result.Adapt<List<UserDTO>>());
    // }
    public async Task<ListViewUserDTO> GetFiltered(FilterUserModel filter)
    {
        var query = _context.Users
                                .Where(u => u.IsDeleted != true)
                                .AsQueryable();

        if (!string.IsNullOrEmpty(filter.Name))
        {
            query = query.Where(u => u.Name.Contains(filter.Name));
        }

        if (!string.IsNullOrEmpty(filter.Email))
        {
            query = query.Where(u => u.Email.Contains(filter.Email));
        }

        var result = new ListViewUserDTO(pageIndex: filter.PageIndex, pageSize: filter.PageSize, list: query);

        query = query.Skip((filter.PageIndex -1) * filter.PageSize) 
                     .Take(filter.PageSize);

        var userlist = await query.ToListAsync();
        result.List = userlist.Adapt<List<UserDTO>>();
        return result;
    }


    public async Task<List<UserDTO>> GetAll()
    {
        var user = await _context.Users
                                    .Where(u => u.IsDeleted != true)
                                    .ToListAsync();

        var userDTO = user.Adapt<List<UserDTO>>();
        return userDTO;
    }


    public async Task<UserDTO> Update(UpdateUserModel model)
    {
        var user = await _context.Users.FindAsync(model.Id);
        if (user == null || user.IsDeleted == true)
        {
            throw new NotFoundException($"The user with the id: {model.Id} does not exist");
        }

        model.Adapt(user);
        user.Password = _passwordHasher.HashPassword(user, model.Password);
        user.UpdatedDatetime = DateTime.Now;
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
        var userDTO = user.Adapt<UserDTO>();
        return userDTO;  
    }


    public async Task<bool> Delete(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            throw new NotFoundException($"The user with the id: {id} does not exist");
        }

        user.IsDeleted = true;

        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

}