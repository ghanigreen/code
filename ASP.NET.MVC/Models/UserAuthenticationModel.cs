using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET.MVC.Models
{
    public class UserAuthenticationModel
    {
        public UserAuthenticationModel()
        {
            listUserAuthentication = new List<UserAuthenticationModel>();
           
        }

        public List<UserAuthenticationModel> listUserAuthentication { get; set; }
        public int userID { get; set; }
        public string userName { get; set; }
        public string userEmail { get; set; }
      
    }
}