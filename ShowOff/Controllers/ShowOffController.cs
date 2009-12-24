using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShowOff.Core.Repository;

namespace ShowOff.Controllers
{
    public class ShowOffController : Controller
    {
        private IItemRepository _itemRepository;

        public ShowOffController() : this(null) { }

        public ShowOffController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository ?? new ItemRepository();
        }

        //
        // GET: /ShowOff/

        public ActionResult Index()
        {
            var items = _itemRepository.GetAll();

            return View(items);
        }

        //
        // GET: /ShowOff/Details/5

        public ActionResult Details(int id)
        {
            var item = _itemRepository.GetById(id);

            return View(item);
        }
    }
}
