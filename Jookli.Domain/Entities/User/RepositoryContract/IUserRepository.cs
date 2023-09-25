﻿using System;
using System.Collections.Generic;


namespace Jookli.Domain.Entities.User.RepositoryContract
{
    public interface IUserRepository
    {
        /// <summary>
        /// Adds a user object to the data store
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Returns the person object after adding it to the table</returns>
        Task<UserEntity?> AddUser(UserEntity user);

        /// <summary>
        /// Gets a user object from the data store
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Returns the person object from the table</returns>
        Task<UserEntity?> GetUser(Guid userID);
    }
}