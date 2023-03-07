using DataAccess.Repositories;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class ReservationsController : Controller
    {
        private BooksRepository _br;
        private UserManager<IdentityUser> _userManager;
        public ReservationsController(BooksRepository br, UserManager<IdentityUser> userManager) 
        { 
            _br = br;
            _userManager =  userManager;
        }
        [HttpGet]
        public IActionResult Reserve()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [AutoValidateAntiforgeryToken]
        public IActionResult Reserve(ReservationViewModel r)
        {

            if (ModelState.IsValid) 
            {
                //string id = _userManager.GetUserId(User);            
                string id = User.Claims.ElementAt(0).Value;
                if (id == null) 
                {
                    RedirectToAction("Reserve");
                }
                Reservation res = new Reservation()
                {
                    Isbn_Fk = r.Isbn,
                    From = r.From,
                    To = r.To,
                    User_Fk = id,
                };

                try 
                {
                    _br.Reserve(res);   
                }
                catch(Exception ex) 
                {
                    //Log
                    TempData["Error"] = "Error Reserving The Book. Contact Admin";
                }
            }

            return View(r);
        }
    }
}
