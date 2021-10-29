﻿using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IUserService
    {
        Task<int> RegisterUser(UserRegisterRequestModel requestModel);

        // create a response model
        Task<UserLoginResponseModel> LoginUser(UserLoginRequestModel requestModel);
    }
}
