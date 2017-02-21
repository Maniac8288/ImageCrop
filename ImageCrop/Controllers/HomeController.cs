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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        /// <summary>
        /// С   
        /// </summary>
        /// <returns></returns>
        public class Cordinats
        {
            public int CorX { get; set; }
            public int CorY { get; set; }
            public int CorW { get; set; }
            public int CorH { get; set; }
            public string nameimg { get; set; }
        }

        [HttpPost]
        public JsonResult Upload()
        {
            if (Request.Files == null)
            {
                return Json("Не удалось загрузить файл");
            }
            var upload = Request.Files[0];
            var path = Server.MapPath("~/Files/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            // получаем имя файла
            string fileName = Path.GetFileName(upload.FileName);
            // сохраняем файл в папку Files в проекте
            upload.SaveAs(Server.MapPath("~/Files/" + fileName));
            return Json(fileName);
        }
        [HttpPost]
        public JsonResult Crop(Cordinats cor)
        {
            // получаем имя файла
            string sourseFile = Request.MapPath("~/Files/" + cor.nameimg);
            Image oImage = Image.FromFile(sourseFile);
            var bmp = new Bitmap(cor.CorW, cor.CorH, oImage.PixelFormat);
            var g = Graphics.FromImage(bmp);
            g.DrawImage(oImage, new Rectangle(0, 0, cor.CorW, cor.CorH),
                new Rectangle(cor.CorX, cor.CorY, cor.CorW, cor.CorH), GraphicsUnit.Pixel);
            System.Drawing.Imaging.ImageFormat frm = oImage.RawFormat;
            oImage.Dispose();
            string destFile = Request.MapPath("~/Files/" + cor.nameimg);
            bmp.Save(destFile, frm);


            return Json("Успешно обрезано");
        }


    }
}