using System.IO;
using System.Web;
using System.Drawing;
namespace ImageCrop.Scripts.Components.CropImage.Models

{
    /// <summary>
    /// Описывает методы для обрезки фотографии
    /// </summary>
    public class CropImage
    {
        /// <summary>
        /// Загрузка изображения на сервер
        /// </summary>
        /// <param name="file">Изображение</param>
        /// <param name="mapPath">Путь для изображение</param>
        public static void Upload(HttpPostedFileBase file, string mapPath)
        {
            if (file != null)
            {
                var Fullpath = Path.Combine(mapPath, file.FileName);
                if (!Directory.Exists(mapPath))
                {
                    Directory.CreateDirectory(mapPath);
                }
                file.SaveAs(Fullpath);
            }
        }
        /// <summary>
        /// Обрезка изображения
        /// </summary>
        /// <param name="Crop">Изображение с кординатами</param>
        /// <param name="PathCrop">Путь для изображения</param>
        public static void Trimming(CropModel Crop, string PathCrop)
        {

            string sourseFile = Path.Combine(PathCrop, Crop.file.FileName);
            Image oImage = Image.FromFile(sourseFile);
            var bmp = new Bitmap(Crop.CorW, Crop.CorH, oImage.PixelFormat);
            var g = Graphics.FromImage(bmp);
            g.DrawImage(oImage, new Rectangle(0, 0, Crop.CorW, Crop.CorH),
            new Rectangle(Crop.CorX, Crop.CorY, Crop.CorW, Crop.CorH), GraphicsUnit.Pixel);
            System.Drawing.Imaging.ImageFormat frm = oImage.RawFormat;
            oImage.Dispose();
            bmp.Save(sourseFile, frm);
        }
    }
}