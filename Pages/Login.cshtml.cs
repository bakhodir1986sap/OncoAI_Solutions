using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace OncoAIApp.Pages
{
    public class LoginModel : PageModel
    {
        public void OnGet()
        {
        }

        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Username == "admin" && Password == "admin")
            {
                // Create the security context
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "admin")
                };
                var identity = new ClaimsIdentity(claims, "CookieAuth");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("CookieAuth", claimsPrincipal);

                return RedirectToPage("/Patients/Index");
            }
            else
            {
                ErrorMessage = "Неверное имя пользователя или пароль.";
                return Page();
            }
        }
    }
}
