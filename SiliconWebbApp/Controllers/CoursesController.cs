using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SiliconWebbApp.Models.Views;

namespace SiliconWebbApp.Controllers
{

    [Authorize]
    public class CoursesController(HttpClient httpClient) : Controller
    {
        private readonly HttpClient _httpClient = httpClient;

        [Route("/courses")]
        public async Task<IActionResult> Courses()
        {
            var viewModel = new CourseIndexViewModel();

            var response = await _httpClient.GetAsync("https://localhost:7116/api/courses");
            if (response.IsSuccessStatusCode) 
            {
                var courses = JsonConvert.DeserializeObject<IEnumerable<CourseViewModel>>(await response.Content.ReadAsStringAsync());
                if(courses != null && courses.Any())
                    viewModel.Course = courses;

               

            }

            return View(viewModel);

        }
    }
}
