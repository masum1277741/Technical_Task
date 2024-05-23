using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TECHNICALTASK.Models;
using TECHNICALTASK.Repository;

namespace TECHNICALTASK.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDetailsRepositoryAsync detailsRepositoryAsync;
        private readonly IMasterRepositoryAsync masterRepositoryAsync;

        public HomeController(ILogger<HomeController> logger,
            IDetailsRepositoryAsync detailsRepositoryAsync,
            IMasterRepositoryAsync masterRepositoryAsync)
        {
            _logger = logger;
            this.detailsRepositoryAsync = detailsRepositoryAsync;
            this.masterRepositoryAsync = masterRepositoryAsync;
        }

        public async Task<IActionResult> Index()
        {
            var list = await masterRepositoryAsync.GetAllAsync(d=>d.Id > 0,e => e.Details);
            return View(list);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> SaveData1([FromBody] List<CheckboxData> data)
        {
            data = data.Where(d => d.CheckboxId != "selectAll").ToList();

            MasterTable masterTable = new MasterTable();
            masterTable.Id = 0;
            masterTable.NumberofItem = data.Count;
            var saved_item = await masterRepositoryAsync.AddAsync(masterTable);
            if (saved_item.Id > 0)
            {
                foreach (var item in data)
                {
                    DetailsTable details = new DetailsTable();
                    details.Id = 0;
                    details.MasterId = saved_item.Id;
                    details.Amount = int.Parse(item.TextboxValue);
                    await detailsRepositoryAsync.AddAsync(details);
                }
            }

            return Json(new { message = "Data 1 saved successfully!" });
        }
    }
    public class CheckboxData
    {
        public string CheckboxId { get; set; }
        public string TextboxValue { get; set; }
    }
}
