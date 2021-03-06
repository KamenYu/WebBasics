using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;

namespace BasicWebServer.Demo.Controllers
{
    public class UsersController : Controller
    {
        private const string Username = "user";

        private const string Password = "user123";

        public UsersController(Request request) : base(request)
        {
        }

        public Response Login() => View();

        public Response LogInUser()
        {
            Request.Session.Clear();

            bool usernameMatches = Request.Form["Username"] == Username;
            bool passowrdMatches = Request.Form["Password"] == Password;

            if (usernameMatches && passowrdMatches)
            {
                if(Request.Session.ContainsKey(Session.SessionUserKey) == false)
                {
                    Request.Session[Session.SessionUserKey] = "MyUserId";

                    var cookies = new CookieCollection();
                    cookies.Add(Session.SessionCookieName, Request.Session.Id);

                    return Html("<h3>Logged Successfully!</h3>", cookies);
                }

                return Html("<h3>Logged Successfully!</h3>");
            }

            return Redirect("/Login");
        }

        public Response Logout()
        {
            Request.Session.Clear();

            return Html("<h3>Logged out successfully!</h3>");
        }

        public Response GetUserData()
        {
            if (Request.Session.ContainsKey(Session.SessionUserKey))
            {
                return Html($"<h3>Currently logged in user is with username '{Username}'</h3>");
            }

            return Redirect("/Login");
        }
    }
}
