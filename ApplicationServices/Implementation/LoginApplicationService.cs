﻿using Models;
using Data.Unit_Of_Work;

namespace ApplicationServices
{
    public class LoginApplicationService : ILoginApplicationService
    {
        private readonly IDALServiceData dalServiceData;

        public LoginApplicationService(IDALServiceData data)
        {
            dalServiceData = data;
        }

        public UserLogin Execute(UserLogin command)
        {
            var user = dalServiceData.Users.FindEntity(x => x.Email == command.Email);

            if (user != null)
            {
                return new UserLogin()
                {
                    UserId = user.Id,
                    DoesUserExists = true
                };
            }

            return new UserLogin()
            {
                DoesUserExists = false
            };
        }
    }
}
