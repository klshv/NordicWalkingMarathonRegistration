using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

using Task2.DB;
using Task2.Models;

namespace Task2.Controllers {

    public class RegistrationController : Controller {
        [HttpGet]
        public IActionResult Index() {
            return View(new Participant());
        }

        private readonly AppDbContext _dbContext;

        public RegistrationController(AppDbContext dbContext) {
            _dbContext = dbContext;
        }

        public IActionResult Confirmation(Participant participant) {
            return View(participant);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Participant participant) {
            if (!ModelState.IsValid) {
                return View("Index", participant);
            }

            _dbContext.Participants.Add(participant);
            _dbContext.SaveChanges();

            return RedirectToAction("Confirmation", participant);
        }
        
        public IActionResult AllParticipants() {
            List<Participant> participants = _dbContext.Participants.ToList();
            return View(participants);
        }

        public IActionResult DownloadParticipants() {
            List<Participant> participants = _dbContext.Participants.ToList();

            string json = JsonConvert.SerializeObject(participants);

            string tempDirectory = Path.Combine(Path.GetTempPath(), "MyAppTemp");
            Directory.CreateDirectory(tempDirectory);

            string filePath = Path.Combine(tempDirectory, "participants.json");

            try {
                System.IO.File.WriteAllText(filePath, json);

                if (System.IO.File.Exists(filePath)) {
                    byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
                    return File(fileBytes, "application/json", "participants.json");
                } else {
                    return BadRequest("Failed to generate JSON file.");
                }
            } catch (Exception ex) {
                Console.WriteLine($"Failed to save JSON file: {ex.Message}");
                return BadRequest("Failed to generate JSON file.");
            }
        }
    }
}