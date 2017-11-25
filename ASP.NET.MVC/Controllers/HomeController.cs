using System;
using System.Web.Mvc;
using ASP.NET.MVC.Models;
using Services;
using System.Linq;
using System.Linq.Expressions;

namespace ASP.NET.MVC.Controllers
{
    public class HomeController : Controller
    {
        SecurityService serviceObj = new SecurityService();

        public ActionResult Index()
        {
            UserAuthenticationModel userModel = new UserAuthenticationModel();
            ViewBag.ListUser = new SelectList(serviceObj.GetAllUsers().ToList(), "UserID", "UserName");
            return View(userModel);
        }

        private IQueryable<T> SortIQueryable<T>(IQueryable<T> data, string fieldName, string sortOrder)
        {
            if (string.IsNullOrWhiteSpace(fieldName)) return data;
            if (string.IsNullOrWhiteSpace(sortOrder)) return data;

            var param = Expression.Parameter(typeof(T), "i");
            Expression conversion = Expression.Convert(Expression.Property(param, fieldName), typeof(object));
            var mySortExpression = Expression.Lambda<Func<T, object>>(conversion, param);

            return (sortOrder == "desc") ? data.OrderByDescending(mySortExpression)
                : data.OrderBy(mySortExpression);
        }
        public JsonResult userList(string id, string sidx = "UserId", string sord = "asc", int page = 1, int rows = 10)
        {
            var userData = serviceObj.GetAllUsers().AsQueryable();
            if (id != null)
            {
                userData = serviceObj.GetUserByID(Convert.ToInt32(id)).AsQueryable();
            }
            var sortedDept = SortIQueryable<DataAccess.UserAuthentication>(userData, sidx, sord);
            var totalRecords = userData.Count();
            var totalPages = (int)Math.Ceiling((double)totalRecords / (double)rows);
            var data = (from s in userData
                        select new
                        {
                            id = s.UserID,
                            cell = new object[] { s.UserID, s.UserName, s.UserEmail, }
                        }).ToArray();

            var jsonData = new
            {
                total = totalPages,
                page = page,
                records = totalRecords,
                rows = data.Skip((page - 1) * rows).Take(rows)
            };
            return Json(jsonData);
        }
    }
}
