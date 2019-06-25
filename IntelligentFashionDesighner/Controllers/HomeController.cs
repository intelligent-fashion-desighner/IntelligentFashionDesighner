using IntelligentFashionDesighner.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntelligentFashionDesighner.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string[] filePaths = Directory.GetFiles(Server.MapPath("~/Content/Images/"));
            List<ImageSlider> files = new List<ImageSlider>();
            foreach (string filePath in filePaths)
            {
                string fileName = Path.GetFileName(filePath);
                files.Add(new ImageSlider
                {
                    title = fileName.Split('.')[0].ToString(),
                    src = "~/Content/Images/" + fileName
                });
            }
            return View(files);
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
        public ActionResult UploadFile()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UploadFile(FileViewModel images)
        {
            foreach(var image in images.Files)
            if (image.ContentLength > 0)
            {
                var fileName = Path.GetFileName(image.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Images"),fileName);
                image.SaveAs(path);
            }
            return RedirectToAction("UploadFile");
        }
        

        public ActionResult DownloadFile()
        {
            var dir = new System.IO.DirectoryInfo(Server.MapPath("~/Content/Images/"));
            System.IO.FileInfo[] fileNames = dir.GetFiles("*.*");
            List<string> items = new List<string>();
            foreach (var file in fileNames)
            {
                items.Add( Path.Combine(Server.MapPath("~/Content/Images"), file.Name));
            }
            return View(items);
        }
        public FileResult Download(string ImageName)
        {
            var FileVirtualPath = ImageName;
            return File(FileVirtualPath, "application/force-download", Path.GetFileName(FileVirtualPath));
        }
    }
}