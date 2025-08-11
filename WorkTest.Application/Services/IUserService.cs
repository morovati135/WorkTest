using Application.Dto;

namespace Application.Services;

public interface IUserService
{
    Task<IReadOnlyList<UserDto>> GetAllUsers();
    Task<IReadOnlyList<ProductDto>> GetUserProducts(int userId);
    Task<UserDto?> GetUserById(int id);
    Task<UserDto> CreateUser(CreateUserDto createUserDto);
    Task UpdateUser(int id, UpdateUserDto updateUserDto);
    Task DeleteUser(int id); 
}