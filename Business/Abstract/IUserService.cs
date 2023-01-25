using System.Collections.Generic;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IUserService
    {
        void Add(User user);
        List<OperationClaim> GetClaims(User user);
        User GetByMail(string email);
        IDataResult<List<User>> GetAll();
        IDataResult<List<UserDto>> GetAllDto();
        IDataResult<User> GetUserById(int userId);
        IDataResult<UserDto> GetUserDtoById(int userId);
        IResult Delete(int userId);
        IResult Update(User user);
        IResult UpdateByDto(UserDto userDto);
        IDataResult<User> GetUserByMail(string email);
        IDataResult<UserDto> GetUserDtoByMail(string email);
    }
}