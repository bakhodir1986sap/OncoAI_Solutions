using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OncoAIApp.Data;
using OncoAIApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace OncoAIApp.Pages.Patients
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public IList<Patient> Patients { get; set; }

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            Patients = await _context.Patients.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync(string action, int[] selectedPatients)
        {
            if (action == "delete" && selectedPatients.Length > 0)
            {
                var patientsToDelete = _context.Patients.Where(p => selectedPatients.Contains(p.Id));
                _context.Patients.RemoveRange(patientsToDelete);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}