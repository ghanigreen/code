using DataAccess;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Services
{
    [ServiceContract]
    public interface ISecurityService
    {
        /// <summary>
        /// GetAllUsers operation contract
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<UserAuthentication> GetAllUsers();

        /// <summary>
        /// GetUserByID operation contract
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        [OperationContract]
        List<UserAuthentication> GetUserByID(Int32 userID);
    }
}
