using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectApp.Core;
using ProjectApp.Core.Interfaces;
using ProjectApp.ViewModels;
using WebApplication_Auction.ViewModels;

namespace ProjectApp.Controllers
{
    [Authorize]
    public class AuctionController : Controller
    {
        private readonly IAuctionService _projectService;

        public AuctionController(IAuctionService projectService)
        {
            _projectService = projectService;
        }

        // GET: ProjectsController
        public ActionResult Index()
        {
            string userName = User.Identity.Name; // should be unique
            List<Auction> auctions = _projectService.GetAllByUserName(userName);
            List<AuctionVM> auctionVMs = new();
            foreach(var auction in auctions)
            {
                auctionVMs.Add(AuctionVM.FromAuction(auction));
            }
            return View(auctionVMs);
        }

        // GET: ProjectsController/Details/5
        public ActionResult Details(int id)
        {
            Auction project = _projectService.GetById(id);
            if (project == null) return NotFound();

            // check if current user "owns" this project!
            if (!project.UserName.Equals(User.Identity.Name)) return BadRequest();

            AuctionDetailsVM detailsVM = AuctionDetailsVM.FromProject(project);
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
                _projectService.Add(project);
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
              _projectService.Update(id, vm.Description);
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
                    Amount = vm.Amount
                };

                _projectService.AddBid(id, bid);
                return RedirectToAction("Index");
            }
            return View(vm);
        }


        /*
// GET: ProjectsController/Delete/5
public ActionResult Delete(int id)
{
  return View();
}

// POST: ProjectsController/Delete/5
[HttpPost]
[ValidateAntiForgeryToken]
public ActionResult Delete(int id, IFormCollection collection)
{
  try
  {
      return RedirectToAction(nameof(Index));
  }
  catch
  {
      return View();
  }
}

*/
    }
}
