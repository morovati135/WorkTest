using Application.Dto;
using Application.Repositories;
using Application.Services;
using AutoMapper;
using Domain.Models.Users;

namespace Infrastructure.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserDto?> GetUserById(int id)
    {
        var user = await _userRepository.GetById(id);
        return user == null ? null : _mapper.Map<UserDto>(user);
    }

    public async Task<IReadOnlyList<UserDto>> GetAllUsers()
    {
        var users = await _userRepository.GetAll();
        return _mapper.Map<IReadOnlyList<UserDto>>(users);
    }
    
    public async Task<IReadOnlyList<ProductDto>> GetUserProducts(int userId)
    {
        var products = await _userRepository.GetProductsByUserId(userId);
        return _mapper.Map<IReadOnlyList<ProductDto>>(products);
    }


    public async Task<UserDto> CreateUser(CreateUserDto createUserDto)
    {
        var user = _mapper.Map<User>(createUserDto);
        await _userRepository.Add(user);
        return _mapper.Map<UserDto>(user);
    }

    public async Task UpdateUser(int id, UpdateUserDto updateUserDto)
    {
        var user = await _userRepository.GetById(id);
        if (user == null) throw new Exception("User not found");

        _mapper.Map(updateUserDto, user);
        await _userRepository.Update(user);
    }

    public async Task DeleteUser(int id)
    {
        var user = await _userRepository.GetById(id);
        if (user == null) throw new Exception("User not found");

        await _userRepository.Delete(user);
    } 
}