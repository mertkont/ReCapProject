using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }
        
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), "user listelendi");
        }

        public IDataResult<List<UserDto>> GetAllDto()
        {
            return new SuccessDataResult<List<UserDto>>(_userDal.GetUsersDtos(), "user listelendi");
        }

        public IDataResult<User> GetUserById(int userId)
        {
            var user = _userDal.Get(u => u.Id == userId);
            if (user != null)
            {
                return new SuccessDataResult<User>(user, "user yok");
            }

            return new ErrorDataResult<User>("user yok");
        }

        public IDataResult<UserDto> GetUserDtoById(int userId)
        {
            return new SuccessDataResult<UserDto>(_userDal.GetUsersDtos(u => u.Id == userId).SingleOrDefault(),
                "user listelendi");
        }

        public IResult Update(User user)
        {
            var rulesResult = BusinessRules.Run(CheckIfUserIdExist(user.Id)
                , CheckIfEmailAvailable(user.Email));
            if (rulesResult != null)
            {
                return rulesResult;
            }

            _userDal.Update(user);
            return new SuccessResult("user güncellendi");
        }

        public IResult UpdateByDto(UserDto userDto)
        {
            var rulesResult = BusinessRules.Run(CheckIfUserIdExist(userDto.Id)
                , CheckIfEmailAvailable(userDto.Email));
            if (rulesResult != null)
            {
                return rulesResult;
            }

            var updatedUser = _userDal.Get(u => u.Id == userDto.Id && u.Email == userDto.Email);
            if (updatedUser == null)
            {
                return new ErrorResult(Messages.UserNotFound);
            }

            updatedUser.FirstName = userDto.FirstName;
            updatedUser.LastName = userDto.LastName;
            _userDal.Update(updatedUser);
            return new SuccessResult("user güncellendi");
        }

        public IDataResult<User> GetUserByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }

        public IDataResult<UserDto> GetUserDtoByMail(string email)
        {
            return new SuccessDataResult<UserDto>(_userDal.GetUsersDtos(u => u.Email == email).SingleOrDefault(), "user listelendi");
        }

        public IResult Delete(int userId)
        {
            var rulesResult = BusinessRules.Run(CheckIfUserIdExist(userId));
            if (rulesResult != null)
            {
                return rulesResult;
            }

            var deletedUser = _userDal.Get(u => u.Id == userId);
            _userDal.Delete(deletedUser);
            return new SuccessResult("user silindi");
        }
        
        private IResult CheckIfUserIdExist(int userId)
        {
            var result = _userDal.GetAll(u => u.Id == userId).Any();
            if (!result)
            {
                return new ErrorResult("kullanıcı not found");
            }
            return new SuccessResult();
        }

        private IResult CheckIfEmailExist(string userEmail)
        {
            var result = BaseCheckIfEmailExist(userEmail);
            if (result)
            {
                return new ErrorResult("eposta kayıtlı");
            }
            return new SuccessResult();
        }

        private IResult CheckIfEmailAvailable(string userEmail)
        {
            var result = BaseCheckIfEmailExist(userEmail);
            if (!result)
            {
                return new ErrorResult("eposta yok");
            }
            return new SuccessResult();
        }

        private bool BaseCheckIfEmailExist(string userEmail)
        {
            return _userDal.GetAll(u => u.Email == userEmail).Any();
        }
    }
}