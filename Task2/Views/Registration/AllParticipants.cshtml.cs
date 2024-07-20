using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Task2.Views.Registration; 

public class AllParticipants : PageModel {

    public void OnGet() {
        ViewData["Title"] = "All participants";
    }

}