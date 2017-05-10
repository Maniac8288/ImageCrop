using System.Web;

namespace ImageCrop.Scripts.Components.CropImage.Models
{
    /// <summary>
    /// Класс описывающию модель для обрезки фотографии
    /// </summary>
    /// <returns></returns>
    public class CropModel
    {
        /// <summary>
        /// Кордината "X"
        /// </summary>
        public int CorX { get; set; }
        /// <summary>
        /// Кордината "Y"
        /// </summary>
        public int CorY { get; set; }
        /// <summary>
        /// Кординаты по ширине 
        /// </summary>
        public int CorW { get; set; }
        /// <summary>
        /// Кординаты по высоте
        /// </summary>
        public int CorH { get; set; }
        /// <summary>
        /// Фотография
        /// </summary>
        public HttpPostedFileBase file { get; set; }
    }
}