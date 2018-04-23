using Basic.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Basic.Controllers
{
    public class CategoryAPIController : Controller
    {
        private basicEntities db = new basicEntities();
        //
        // GET: /CategoryAPI/
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetCategory()
        {
            var restResult = new RestModel();
            try
            {
                var categories = new List<APICategory>();
                var data = db.categories.Where(x => x.is_deleted == 0);

                foreach (var item in data)
                {
                    //// Tao obj moi
                    //APICategory viewItem = new APICategory();
                    //viewItem.id = item.id;
                    //viewItem.name = item.name;

                    //categories.Add(viewItem);


                    categories.Add(new APICategory()
                    {
                        id = item.id,
                        name = item.name
                    });
                }

                restResult.data = categories;
                restResult.status = true;
            }
            catch (Exception ex)
            {
                restResult.status = false;
                restResult.message = ex.Message;
            }
            return Json(restResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateCategory(APICategory _category)
        {
            var restResult = new RestModel();
            try
            {
                category updateModel = new Models.category();

                updateModel = db.categories.Find(_category.id);

                updateModel.name = _category.name;

                db.Entry(updateModel).State = EntityState.Modified;
                db.SaveChanges();

                restResult.status = true;
            }
            catch (Exception ex)
            {
                restResult.status = false;
                restResult.message = ex.Message;
            }

            return Json(restResult, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteCategory(APICategory _category)
        {
            var restResult = new RestModel();
            try
            {
                category updateModel = new Models.category();

                updateModel = db.categories.Find(_category.id);

                updateModel.is_deleted = 1;

                db.Entry(updateModel).State = EntityState.Modified;
                db.SaveChanges();

                restResult.status = true;
            }
            catch (Exception ex)
            {
                restResult.status = false;
                restResult.message = ex.Message;
            }

            return Json(restResult, JsonRequestBehavior.AllowGet);
        }

        public JsonResult InsertCategory(APICategory _category)
        {
            var restResult = new RestModel();

            try
            {
                db.categories.Add(new category()
                {
                    name = _category.name,
                    is_deleted = 0
                });
                db.SaveChanges();
                restResult.status = true;
            }
            catch (Exception ex)
            {
                restResult.status = false;
                restResult.message = ex.Message;
            }
            return Json(restResult, JsonRequestBehavior.AllowGet);
        }
    }
}