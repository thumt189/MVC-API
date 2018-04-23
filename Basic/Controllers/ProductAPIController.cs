using Basic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Basic.Controllers
{
    public class ProductAPIController : Controller
    {
        private basicEntities db = new basicEntities();
        //
        // GET: /ProductAPI/
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetProduct()
        {
            var restResult = new RestModel();

            try
            {
                var products = new List<APIProduct>();
                var data = db.products.Where(x => x.is_deleted == 0);
                foreach (var item in data)
                {
                    products.Add(new APIProduct()
                    {
                        id = item.id,
                        cat_id = item.category.id,
                        cat_name = item.category.name,
                        name = item.name,
                        price = item.price,
                        img = item.img,
                        note = item.note
                    });
                }

                var categories = new List<APICategory>();
                var cat = db.categories.Where(x => x.is_deleted == 0);
                foreach (var item in cat)
                {
                    categories.Add(new APICategory()
                    {
                        id = item.id,
                        name = item.name
                    });
                }

                restResult.data = products;
                restResult.other_data = categories;

                restResult.status = true;
                
            }
            catch (Exception ex)
            {
                restResult.status = false;
                restResult.message = ex.Message;
            }

            return Json(restResult, JsonRequestBehavior.AllowGet);

        }

        public JsonResult UpdateProduct(APIProduct _product)
        {
            var restResult = new RestModel();

            try
            {
                product updateModel = new product();
                updateModel = db.products.Find(_product.id);

                updateModel.cat_id = _product.cat_id;
                updateModel.name = _product.name;
                updateModel.price = _product.price;
                updateModel.img = _product.img;
                updateModel.note = _product.note;

                db.Entry(updateModel).State = System.Data.Entity.EntityState.Modified;
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

        public JsonResult DeleteProduct(APIProduct _product)
        {
            var restResult = new RestModel();

            try
            {
                product updateModel = new product();
                updateModel = db.products.Find(_product.id);

                updateModel.is_deleted = 1;

                db.Entry(updateModel).State = System.Data.Entity.EntityState.Modified;
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

        public JsonResult InsertProduct(APIProduct _product)
        {
            var restResult = new RestModel();

            try
            {
                db.products.Add(new product()
                {
                    cat_id = _product.cat_id,
                    name = _product.name,
                    price = _product.price,
                    img = _product.img,
                    note = _product.note,
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