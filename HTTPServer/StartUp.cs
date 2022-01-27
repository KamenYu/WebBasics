
using BasicWebServer.Demo.Controllers;
using BasicWebServer.Server;
using BasicWebServer.Server.Routing;
using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.Responses;
using System.Text;
using System.Web;

public class StartUp
{
    public static async Task Main()
    {
        await new HttpServer(routes => routes
            .MapGet<HomeController>("/", c => c.Index())
            .MapGet<HomeController>("/Redirect", c => c.Redirect())
            .MapGet<HomeController>("/HTML", c => c.Html())
            .MapPost<HomeController>("/HTML", c => c.HtmlFormPost())
            .MapGet<HomeController>("/Content", c => c.Content())
            .MapPost<HomeController>("/Content", c => c.DownloadContent())
            .MapGet<HomeController>("/Cookies", c => c.Cookies())
            .MapGet<HomeController>("/Session", c => c.Session())
            .MapGet<UsersController>("/Login", c => c.Login())
            .MapPost<UsersController>("/Login", c => c.LogInUser())
            .MapGet<UsersController>("/Logout", c => c.Logout())
            .MapGet<UsersController>("/UserProfile", c => c.GetUserData()))
            .Start();
    }

    //private static void GetUserDataAction(Request request, Response response)
    //{
    //    if (request.Session.ContainsKey(Session.SessionUserKey))
    //    {
    //        response.Body = string.Empty;
    //        response.Body += $"<h3>Currently logged-in user is with username '{Username}'</h3>";
    //    }
    //    else
    //    {
    //        response.Body = string.Empty;
    //        response.Body += $"<h3>You should first log in <a href='/Login'>Login</a></h3>";
    //    }
    //}

    private static void LogoutAction(Request request, Response response)
    {
        //var sessionBeforeLogout = request.Session;
        request.Session.Clear();
        //var sessionAfterLogout = request.Session;

        response.Body = string.Empty;
        response.Body += "<h3>Logget out successfully!</h3>";
    }

    //private static void LoginAction(Request request, Response response)
    //{
    //    request.Session.Clear();

    //    //var sessionBeforeLogin = request.Session;

    //    var bodyText = string.Empty;

    //    var usernameMatches = request.Form["Username"] == Username;
    //    var passwordMatches = request.Form["Password"] == Password;

    //    if (usernameMatches && passwordMatches)
    //    {
    //        request.Session[Session.SessionUserKey] = "MyUserId";
    //        response.Cookies.Add(Session.SessionCookieName, request.Session.Id);

    //        bodyText = "<h3>Logged Successfully!</h3>";
    //        //var sessionAfterLogin = request.Session;
    //    }
    //    else
    //    {
    //        bodyText = LoginForm;
    //    }

    //    response.Body = "";
    //    response.Body = bodyText;
    //}

    private static void DisplaySessionInfoAction(Request request, Response response)
    {
        bool sessionExists = request.Session.ContainsKey(Session.SessionCurrentDateKey);

        var bodyText = "";

        if (sessionExists)
        {
            var currentDate = request.Session[Session.SessionCurrentDateKey];

            bodyText = $"Stored date: {currentDate}";
        }
        else
        {
            bodyText = "Current date stored!";
        }

        response.Body = "";
        response.Body += bodyText;
    }

    private static void AddCookiesAction(Request request, Response response)
    {
        bool requestHasCookies = request.Cookies.Any(c => c.Name != Session.SessionCookieName);

        var bodyText = "";

        if (requestHasCookies)
        {
            var cookieText = new StringBuilder();

            cookieText
                .Append("<table border='1'><tr><th>Name</th><th>Value</th></tr>");

            foreach (var cookie in request.Cookies)
            {
                cookieText.Append("<tr>");

                cookieText
                    .Append($"<td>{HttpUtility.HtmlEncode(cookie.Name)}</td>");

                cookieText
                    .Append($"<td>{HttpUtility.HtmlEncode(cookie.Value)}</td>");

                cookieText.Append("</tr>");
            }

            cookieText.Append("</table>");

            bodyText = cookieText.ToString();
        }
        else
        {
            bodyText = "<h1>Cookies set!</h1>";
        }

        if(requestHasCookies == false)
        {
            response.Cookies.Add("My-Cookie", "My-Value");
            response.Cookies.Add("My-Second-Cookie", "My-Second-Value");
        }

        response.Body = "";
        response.Body += bodyText;
    }

    private static void AddFormDataAction(Request request, Response response)
    {
        response.Body = "";

        foreach (var (key, value) in request.Form)
        {
            response.Body += $"{key} - {value}";
            response.Body += Environment.NewLine;
        }
    }
}
 

