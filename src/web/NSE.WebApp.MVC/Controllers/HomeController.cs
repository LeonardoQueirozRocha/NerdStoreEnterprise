using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Models.Error;

namespace NSE.WebApp.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("error/{id:length(3,3)}")]
        public IActionResult Error(int id)
        {
            var errorViewModel = new ErrorViewModel();

            if (id == 500)
            {
                errorViewModel.Message = "Ocorreu um erro! Tente novamente mais tarde ou contate nosso suporte";
                errorViewModel.Title = "Ocorreu um erro!";
                errorViewModel.ErrorCode = id;
            }
            else if (id == 404)
            {
                errorViewModel.Message = "A página que está procurando não existe! <br />Em caso de dúvidas entre em contato com o nosso suporte";
                errorViewModel.Title = "Ops! Página não encontrada.";
                errorViewModel.ErrorCode = id;
            }
            else if (id == 403)
            {
                errorViewModel.Message = "Você não tem permissão para fazer isto.";
                errorViewModel.Title = "Acesso Negado";
                errorViewModel.ErrorCode = id;
            }
            else
            {
                return StatusCode(404);
            }

            return View(errorViewModel);
        }
    }
}