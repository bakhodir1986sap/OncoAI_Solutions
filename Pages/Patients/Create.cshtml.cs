using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OncoAIApp.Data;
using OncoAIApp.Models;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace OncoAIApp.Pages.Patients
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public CreateModel(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [BindProperty]
        public Patient Patient { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Пожалуйста, загрузите медицинское изображение.")]
        public IFormFile MedicalImage { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (MedicalImage != null)
            {
                ModelState["Patient.ImagePath"].ValidationState = ModelValidationState.Valid;
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Handle file upload
            if (MedicalImage != null)
            {
                var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
                Directory.CreateDirectory(uploadsFolder);
                var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(MedicalImage.FileName);
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await MedicalImage.CopyToAsync(fileStream);
                }
                Patient.ImagePath = "/uploads/" + uniqueFileName;
            }

            _context.Patients.Add(Patient);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}