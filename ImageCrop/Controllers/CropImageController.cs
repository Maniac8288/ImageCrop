using ImageCrop.Scripts.Components.CropImage.Models;
using System.Web.Mvc;
namespace ImageCrop.Controllers
{
    /// <summary>
    /// Контролер для обрезание изображения
    /// </summary>
    public class CropImageController : Controller
    {
        /// <summary>
        /// Путь для изображения
        /// </summary>
        const string PathCrop = "~/Scripts/Components/CropImage/Img/";

        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Обрезка Изображения
        /// </summary>
        /// <param name="Crop"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Crop(CropModel Crop)
        {
            string map = Server.MapPath(PathCrop);
            CropImage.Upload(Crop.file, map);
            if (Crop.CorH != 0 && Crop.CorW != 0 && Crop.CorX != 0 && Crop.CorY != 0)
            {
                CropImage.Trimming(Crop, map);
                return Json("Успешно обрезано");
            }
            return Json("Успешно сохранена");
        }
    }
}