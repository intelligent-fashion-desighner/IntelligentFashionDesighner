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
        public ActionResult UploadFile(IEnumerable<HttpPostedFileBase> files, FileViewModel model)
        {
            //ViewBag.mes = model.noOfImages;
            foreach (var file in files)
            {
                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/Images"), fileName);
                    file.SaveAs(path);
                }
            }
            return RedirectToAction("DownloadFile", "Home", new { model.noOfImages });
        }



        public ActionResult DownloadFile(int noOfImages)
        {
            var fileNames = Directory.GetFiles((Server.MapPath("~/Content/Images")));
            //System.IO.FileInfo[] fileNames = dir.GetFiles("*.*");
            FileViewModel fileView = new FileViewModel();
            fileView.noOfImages = noOfImages;
            foreach (var file in fileNames)
            {
                var onefileName = Path.Combine(Server.MapPath("~/Content/Images"), file);
                string vPath = onefileName.Replace(@"D:\IntelligentFashionDesighner\IntelligentFashionDesighner", "").Replace(@"\", "/");
                fileView.namesOfFiles.Add(vPath);
            }
            return View(fileView);
        }
        public FileResult Download(string ImageName)
        {
            var FileVirtualPath = "~" + ImageName;
            return File(FileVirtualPath, "application/force-download", Path.GetFileName(FileVirtualPath));
        }
        public ActionResult GenerateBlock()
        {
            return View();
        }
        public ActionResult GenerateBlockUpload()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GenerateBlockUpload(IEnumerable<HttpPostedFileBase> files, FileViewModel model)
        {
            //ViewBag.mes = model.noOfImages;
            foreach (var file in files)
            {
                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/Images"), fileName);
                    file.SaveAs(path);
                }
            }
            return RedirectToAction("GenerateBlockDownload", "Home");
        }
        public ActionResult GenerateBlockDownload()
        {
            return View();
        }
       
        public FileResult GenerateBlockDownloadFile(string ImageName)
        {
            var FileVirtualPath = ImageName;
            return File(FileVirtualPath, "application/force-download", Path.GetFileName(FileVirtualPath));
        }
        public ActionResult ViewAll()
        {
            var fileNames = Directory.GetFiles((Server.MapPath("~/Content/Images")));
            //System.IO.FileInfo[] fileNames = dir.GetFiles("*.*");
            FileViewModel fileView = new FileViewModel();
            foreach (var file in fileNames)
            {
                var onefileName = Path.Combine(Server.MapPath("~/Content/Images"), file);
                string vPath = onefileName.Replace(@"D:\IntelligentFashionDesighner\IntelligentFashionDesighner", "").Replace(@"\", "/");
                fileView.namesOfFiles.Add(vPath);
            }
            return View(fileView);
        }
        public FileResult ViewAllDownLoad(string ImageName)
        {
            var FileVirtualPath = ImageName;
            return File(FileVirtualPath, "application/force-download", Path.GetFileName(FileVirtualPath));
        }
    }
}