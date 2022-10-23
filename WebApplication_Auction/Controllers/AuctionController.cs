using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectApp.Core;
using ProjectApp.Core.Interfaces;
using ProjectApp.ViewModels;
using WebApplication_Auction.Areas.Identity.Data.Core;
using WebApplication_Auction.Areas.Identity.Data.Core.Interfaces;
using WebApplication_Auction.ViewModels;

namespace ProjectApp.Controllers
{
    [Authorize]
    public class AuctionController : Controller
    {
        private readonly IAuctionService _auctionService;

        private readonly IUserService _userService;

        public AuctionController(IAuctionService auctionService, IUserService userService)
        {
            _auctionService = auctionService;
            _userService = userService;
        }

        // GET: ProjectsController
        public ActionResult Index()
        {
            List<Auction> auctions = _auctionService.GetAllOnGoing();
            List<AuctionVM> auctionVMs = new();
            foreach (var auction in auctions)
            {
                auctionVMs.Add(AuctionVM.FromAuction(auction));
            }
            return View(auctionVMs);
        }

        public ActionResult OnGoingAuctions()
        {
            string userName = User.Identity.Name; // should be unique
            List<Auction> auctions = _auctionService.GetAllBidOnByUserName(userName);
            List<AuctionVM> auctionVMs = new();
            foreach (var auction in auctions)
            {
                auctionVMs.Add(AuctionVM.FromAuction(auction));
            }
            return View(auctionVMs);
        }

        // GET: ProjectsController/Details/5
        public ActionResult Details(int id)
        {
            Auction project = _auctionService.GetById(id);
            if (project == null) return NotFound();

            AuctionDetailsVM detailsVM = AuctionDetailsVM.FromAuction(project);
            return View(detailsVM);
        }
         
        // GET: ProjectsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjectsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateAuctionVM vm)
        {
            if(ModelState.IsValid)
            {
                Auction project = new Auction()
                {
                    Title = vm.Title,
                    Description = vm.Description,
                    ExpirationDate = vm.ExpirationDate,
                    StartingPrice = vm.StartingPrice,
                    UserName = User.Identity.Name
                };
                _auctionService.Add(project);
                return RedirectToAction("Index");
            }
            return View(vm);
        }



        // GET: ProjectsController/Edit/5
        public ActionResult Edit(int id)
        {
          return View();
        }

        // POST: ProjectsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditAuctionVM vm)
        {
          try
          {
              _auctionService.Update(id, vm.Description);
               return RedirectToAction("Index");
            }
          catch
          {
              return View(vm);
          }
        }

        public ActionResult AddBid(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBid(int id, CreateBidVM vm)
        {
            if (ModelState.IsValid)
            {
                Bid bid = new Bid()
                {
                    Amount = vm.Amount,
                    UserName = User.Identity.Name // gör en get
                };

                _auctionService.AddBid(id, bid);
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ViewAllUsers()
        {
            List<User> users = _userService.GetAllUsers();
            List<UserVM> userVMs = new();
            foreach (var user in users)
            {
                userVMs.Add(UserVM.FromUser(user));
            }
            return View(userVMs);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ViewAllAuctionsByUser(string username)
        {
            List<Auction> auctions = _auctionService.GetAllByUserName(username);
            List<AuctionVM> auctionVMs = new();
            foreach (var auction in auctions)
            {
                auctionVMs.Add(AuctionVM.FromAuction(auction));
            }
            return View(auctionVMs);
        }


        // GET: ProjectsController/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            Auction project = _auctionService.GetById(id);
            if (project == null) return NotFound();

            AuctionDetailsVM detailsVM = AuctionDetailsVM.FromAuction(project);
            return View(detailsVM);
        }

        // POST: ProjectsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, AuctionDetailsVM vm)
        {
          try
          {
                _auctionService.Delete(id);
                return RedirectToAction("ViewAllAuctionsByUser");
            }
          catch
          {
              return View();
          }
        }


        [Authorize(Roles = "Admin")]
        public ActionResult DeleteUser(string userName)
        {
            // check if current user tries to delete them self!
            if (userName.Equals(User.Identity.Name)) return BadRequest();

            try
            {
                Console.WriteLine("userName: " + userName);
                _userService.Delete(userName);
                _auctionService.DeleteByUserName(userName);
                return RedirectToAction("ViewAllUsers");
            }
            catch
            {
                return View();
            }
        }

    }
}
