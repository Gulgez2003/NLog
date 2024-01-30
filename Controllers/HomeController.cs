using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace NLogExampleProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Process()
        {
            try
            {
                // Log information indicating the start of the processing
                _logger.LogInformation("Processing started");

                // Start a stopwatch to measure the processing time
                var stopwatch = Stopwatch.StartNew();

                // Log debug information for each iteration of the processing loop
                for (int i = 0; i < 5; i++)
                {
                    _logger.LogDebug($"Processing iteration {i}");
                }

                // Stop the stopwatch and log the total processing time
                stopwatch.Stop();
                _logger.LogInformation($"Processing completed in {stopwatch.ElapsedMilliseconds} ms");

                // Return the default view when processing is successful
                return View();
            }
            catch (Exception ex)
            {
                // Log an error and the exception details if an exception occurs during processing
                _logger.LogError(ex, "An error occurred during processing");

                // Return an error view in case of an exception
                return View("Error");
            }
        }
    }
}
