using Domain.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Controllers
{
    public class BrandController(IUnitOfWork unitOfWork) : Controller
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public IActionResult Index()
        {
            return View();
        }
    }
}
