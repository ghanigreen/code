using System;
using DataAccess;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class SecurityService : ISecurityService
    {
        /// <summary>
        /// GetAllUsers service method
        /// </summary>
        /// <returns>An instance of List<UserAuthentication></returns>
        public List<UserAuthentication> GetAllUsers()
        {
            using (RepositoryBase<SecurityEntities> repository = new RepositoryBase<SecurityEntities>("SecurityEntities"))
            {
                return repository.Select<UserAuthentication>().ToList<UserAuthentication>();
            }
        }

        /// <summary>
        /// GetUserByID service method
        /// </summary>
        /// <param name="userID">userID as Int32</param>
        /// <returns>An instance of List<UserAuthentication></returns>
        public List<UserAuthentication> GetUserByID(Int32 userID)
        {
            using (RepositoryBase<SecurityEntities> repository = new RepositoryBase<SecurityEntities>("SecurityEntities"))
            {
                return repository.Select<UserAuthentication>().Where( x => x.UserID == userID).ToList<UserAuthentication>();
            }
        }
    }
}
