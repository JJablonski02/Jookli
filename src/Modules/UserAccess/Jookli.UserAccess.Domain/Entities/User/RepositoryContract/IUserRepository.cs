using System;
using System.Collections.Generic;


namespace Jookli.UserAccess.Domain.Entities.User.RepositoryContract
{
    public interface IUserRepository
    {
        /// <summary>
        /// Adds a user object to the data store
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Returns the person object after adding it to the table</returns>
        Task AddAsync(UserEntity user, CancellationToken cancellationToken);

        /// <summary>
        /// Gets a user object from the data store
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Returns the person object from the table</returns>
        Task<UserEntity?> GetByUserIdAsync(Guid userID, CancellationToken cancellationToken = default);
        Task<UserEntity?> GetByUserEmailAsync(string email, CancellationToken cancellationToken = default);
        Task<UserEntity?> GetUserAndLoginAttemptsAsync(string email, CancellationToken cancellationToken = default);
    }
}
