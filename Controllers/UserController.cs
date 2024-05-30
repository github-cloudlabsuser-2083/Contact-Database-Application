using CRUD_application_2.Models;
using System.Linq;
using System.Web.Mvc;

namespace CRUD_application_2.Controllers
{
    public class UserController : Controller
    {
        public static System.Collections.Generic.List<User> userList = new System.Collections.Generic.List<User>();

        // GET: User
        public ActionResult Index()
        {
            return View(userList);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            User user = userList.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            User existingUser = userList.FirstOrDefault(u => u.Id == id);

            if (existingUser == null)
            {
                return HttpNotFound();
            }

            // Update the existing user with the new details
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            // Add other fields as necessary

            return RedirectToAction("Index");
        }
    }
}
