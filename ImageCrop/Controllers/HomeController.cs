using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;
using System.Net;
using System.IO;

namespace ImageCrop.Controllers
{
    
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ImageCrop()
        {
            return View();
        }

        public ActionResult Test()
        {
            return View();
        }
        /// <summary>
        /// Путь для изображения
        /// </summary>
        const string PathCrop = "~/Scripts/Components/CropImage/Img/";
        /// <summary>
        /// Обрезка Изображения
        /// </summary>
        /// <param name="Crop"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Crop(CropModel Crop)
        {
            string map = Server.MapPath(PathCrop);
            CropImage.Trimming(Crop, map);
            return Json("Успешно сохранена");
        }
    }
}