using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShowOff.Core.Model;
using ShowOff.Core.Repository;

namespace ShowOff.Controllers
{
    [Authorize]
    public class ItemController : Controller
    {
        private IItemRepository _itemRepository;
        private IItemTypeRepository _itemTypeRepository;
        private IItemImageRepository _itemImageRepository;

        public ItemController(IItemRepository itemRepository, IItemTypeRepository itemTypeRepository, IItemImageRepository itemImageRepository)
        {
            _itemRepository = itemRepository;
            _itemTypeRepository = itemTypeRepository;
            _itemImageRepository = itemImageRepository;
        }

        //
        // GET: /Item/
        
        public ActionResult Index()
        {
            var items = _itemRepository.GetAll();

            return View(items);
        }

        //
        // GET: /Item/Details/5

        public ActionResult Details(int id)
        {
            var item = _itemRepository.GetById(id);
            
            return View(item);
        }

        //
        // GET: /Item/Create

        public ActionResult Create()
        {
            var types = _itemTypeRepository.GetAll().OrderBy(x => x.DisplayName);

            ViewData["Types"] = new SelectList(types, "id", "displayname");

            var item = new Item();

            return View(item);
        } 

        //
        // POST: /Item/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var item = new Item();

            try
            {
                // bind
                TryUpdateModel(item);

                // set the rest
                item.Type = _itemTypeRepository.GetById(Convert.ToInt32(collection["Type"]));
                item.CreatedDate = DateTime.Now;
                item.ModifiedDate = DateTime.Now;

                // save
                _itemRepository.Add(item);
                _itemRepository.Save();

                return RedirectToAction("Edit", new {id = item.ID});
            }
            catch
            {
                return View(item);
            }
        }

        //
        // GET: /Item/Edit/5
 
        public ActionResult Edit(int id)
        {
            var item = _itemRepository.GetById(id);

            return View(item);
        }

        //
        // POST: /Item/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var item = _itemRepository.GetById(id);
            try
            {
                TryUpdateModel(item);

                item.ModifiedDate = DateTime.Now;

                _itemRepository.Update(item);
                _itemRepository.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(item);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var item = _itemRepository.GetById(id);

            return View(item);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            var item = _itemRepository.GetById(id);

            _itemRepository.Delete(item);
            _itemRepository.Save();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AddImage(int id)
        {
            if(Request.Files[0] == null)
                throw new ApplicationException("No file found.");

            string filePath = _itemImageRepository.SaveImageFile(Request.Files[0].FileName, Request.Files[0].InputStream);
            string thumbFilePath = _itemImageRepository.CreateThumb(filePath);

            string fileName = Path.GetFileName(filePath);
            string thumbFileName = Path.GetFileName(thumbFilePath);

            var item = _itemRepository.GetById(id);
            var itemImage = new ItemImage() {Filename = fileName, ThumbFilename = thumbFileName};

            item.Images.Add(itemImage);

            if (item.Images.Count == 1)
                item.CoverImage = itemImage;
            
            _itemRepository.Update(item);
            _itemRepository.Save();

            return RedirectToAction("Edit", new { id = id });
        }

        [HttpPost]
        public ActionResult SetDefaultImage(int id, int imageID)
        {
            var item = _itemRepository.GetById(id);
            var image = _itemImageRepository.GetById(imageID);

            item.CoverImage = image;

            _itemRepository.Update(item);
            _itemRepository.Save();

            return RedirectToAction("Edit", new { id = id });
        }

        [HttpPost]
        public ActionResult DeleteImage(int id, int imageID)
        {
            var item = _itemRepository.GetById(id);
            var image = _itemImageRepository.GetById(imageID);

            if (item.CoverImage.ID == imageID)
                throw new ApplicationException("Can not delete Cover Image.");

            _itemImageRepository.Delete(image);
            _itemImageRepository.Save();

            return RedirectToAction("Edit", new { id = id });
        }
    }
}
