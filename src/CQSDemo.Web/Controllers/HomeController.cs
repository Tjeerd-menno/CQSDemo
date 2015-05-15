using CQSDemo.Relaties;
using CQSDemo.Relaties.Models;
using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CQSDemo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRelatieOpBSNQuery _relatieOpBSNQuery;

        public HomeController(IRelatieOpBSNQuery relatieOpBSNQuery)
        {
            _relatieOpBSNQuery = relatieOpBSNQuery;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Relatie(string bsn)
        {
            Relatie relatie = _relatieOpBSNQuery.Execute(bsn);

            if (relatie == null)
            {
                return HttpNotFound();
            }

            return View(relatie);
        }
    }
}
