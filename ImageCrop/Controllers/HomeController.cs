using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;

namespace ImageCrop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index( FormCollection form)
        {
            var x = Convert.ToInt32(form["X"]);
            var y = Convert.ToInt32(form["Y"]);
            var w = Convert.ToInt32(form["W"]);
            var h = Convert.ToInt32(form["H"]);
            string sourseFile = Request.MapPath("~/Image/funny_cat_v1.jpg");
            Image oImage = Image.FromFile(sourseFile);
            var bmp = new Bitmap(w, h, oImage.PixelFormat);
            var g = Graphics.FromImage(bmp);
            g.DrawImage(oImage, new Rectangle(0, 0, w, h),
                new Rectangle(x, y, w, h), GraphicsUnit.Pixel);
            System.Drawing.Imaging.ImageFormat frm = oImage.RawFormat;
            oImage.Dispose();
            string destFile = Request.MapPath("~/Upload/funny_cat_v1.jpg");
            bmp.Save(destFile, frm);
            return RedirectToAction("Index");
        }
        

      
    }
}