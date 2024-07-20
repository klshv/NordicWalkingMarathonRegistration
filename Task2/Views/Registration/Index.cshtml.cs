using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Task2.Models;

namespace Task2.Views.Registration {

    public class IndexModel : PageModel {

        public void OnGet() {
            ViewData["Title"] = "Registration Form";
        }

        public IActionResult OnPostRegister(Participant participant) {
            return new JsonResult(participant);
        }
    }
}