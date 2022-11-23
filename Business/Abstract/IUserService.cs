﻿using System.Collections.Generic;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {
        void Add(User user);
        List<OperationClaim> GetClaims(User user);
        User GetByMail(string email);
    }
}