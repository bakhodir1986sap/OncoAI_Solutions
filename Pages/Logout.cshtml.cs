using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OncoAIApp.Pages
{
    public class LogoutModel : PageModel
    {
        public async Task OnGetAsync()
        {
            await HttpContext.SignOutAsync("CookieAuth");
            Response.Redirect("/Login");
        }
    }
}