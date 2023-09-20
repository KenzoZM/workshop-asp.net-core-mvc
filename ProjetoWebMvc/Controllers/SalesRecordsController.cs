using Microsoft.AspNetCore.Mvc;
using ProjetoWebMvc.Services;

namespace ProjetoWebMvc.Controllers
{
    public class SalesRecordsController : Controller
    {
        private readonly SalesRecordService _salesRecordService;

        public SalesRecordsController(SalesRecordService salesRecordService)
        {
            _salesRecordService = salesRecordService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SimpleSearchAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = await _salesRecordService.FindByDateAsync(minDate, maxDate);
            return View(result);
        }

        public IActionResult GroupingSearch()
        {
            return View();
        }
    }
}
