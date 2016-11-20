using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer;
using System.IO;
using System.Drawing;
using Newtonsoft.Json;
using SaifQatar.Authorized;
using System.Collections;

namespace SaifQatar.Controllers
{
    [CustomAuthorize]
    public class AdminController : Controller
    {
        SaifDatabaseEntities dbContext;

        [AllowAnonymous]
        public ActionResult Login(UserModel model)
        {
            dbContext = new SaifDatabaseEntities();
            var result = dbContext.AdminLogins.Where(x => x.Username == model.UserName && x.Password == model.Password).Select(x => x).FirstOrDefault();
            if (result != null)
            {
                HttpContext.Session["User"] = result.Username;

                return RedirectToAction("home");
            }
            else if (result == null && (model.UserName != null || model.Password != null))
            {
                ViewBag.ErrorMessage = "Invalid UserName or Password";
                return View();
            }
            else
            {
                return View();
            }
        }

        [AllowAnonymous]
        public ActionResult ResetPassword()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult UpdatePassword(UserModel model)
        {
            if (model != null && !string.IsNullOrEmpty(model.UserName) && !string.IsNullOrEmpty(model.Password))
            {
                var dbContext = new SaifDatabaseEntities();
                var result = dbContext.AdminLogins.Where(x => x.Username == model.UserName).Select(x => x).FirstOrDefault();
                if (result != null)
                {
                    result.Password = model.Password;
                    dbContext.SaveChanges();
                    return RedirectToAction("login");
                }
                else
                {
                    ViewBag.ErrorMessage = "Please enter valid Admin User Name!";
                    return View("resetpassword");
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Please enter valid admin UserName";
                return View("resetpassword");
            }

        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("login");
        }

        public ActionResult Home()
        {
            dbContext = new SaifDatabaseEntities();
            var slider = dbContext.HomeCarousels.Select(x => x.Id);
            ViewBag.sliders = slider;
            return View();
        }

        public ActionResult ShowContent(string id)
        {
            dbContext = new SaifDatabaseEntities();
            int value = Convert.ToInt32(id);
            var result = dbContext.HomeCarousels.Where(x => x.Id == value).Select(x => x).FirstOrDefault();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ChangeContent()
        {
            dbContext = new SaifDatabaseEntities();
            int count = Request.Files.Count;

            var sliderId = Convert.ToInt32(Request.Form.Get("Id"));
            var TopContent = Request.Form.Get("Topcontent");
            var SubContent = Request.Form.Get("Subcontent");
            var image = Request.Files.Get("ImageFile");

            var homeCarosuel = dbContext.HomeCarousels.Where(x => x.Id == sliderId).Select(x => x).FirstOrDefault();
            homeCarosuel.TopContent = TopContent;
            homeCarosuel.SubContent = SubContent;

            if (image != null)
            {
                var originalImage = Image.FromStream(image.InputStream);
                Bitmap bitmapImage = new Bitmap(originalImage, 1920, 960);
                string imagePath = Server.MapPath("~") + "images\\HomePage\\" + image.FileName;
                bitmapImage.Save(imagePath);
                homeCarosuel.ImageSource = "/images/HomePage/" + image.FileName;
            }

            dbContext.SaveChanges();
            ClearCache();
            return Content("success");
        }

        public ActionResult AboutUs()
        {
            return View();
        }

        public ActionResult UpdateAboutUs()
        {
            try
            {
                var dbContext = new SaifDatabaseEntities();
                var Title = HttpUtility.UrlDecode(Request.Form.Get("Title"));
                var Para1 = Request.Form.Get("Para1");
                var Para2 = Request.Form.Get("Para2");
                var Point1 = Request.Form.Get("Point1");
                var Point2 = Request.Form.Get("Point2");
                var Point3 = Request.Form.Get("Point3");
                var Point4 = Request.Form.Get("Point4");
                var Point5 = Request.Form.Get("Point5");
                var Point6 = Request.Form.Get("Point6");
                var Point7 = Request.Form.Get("Point7");
                var Image = Request.Files.Get("Image");

                var query = dbContext.AboutUs.Select(x => x).ToList();
                query[0].Description = Title;
                query[1].Description = Para1;
                query[2].Description = Para2;
                query[3].Description = Point1;
                query[4].Description = Point2;
                query[5].Description = Point3;
                query[6].Description = Point4;
                query[7].Description = Point5;
                query[8].Description = Point6;
                query[9].Description = Point7;

                if (Image != null)
                {
                    Bitmap image = new Bitmap(Image.InputStream);
                    string imagePath = Server.MapPath("~") + "images\\AboutusPage\\" + Image.FileName;
                    image.Save(imagePath);
                    query[7].Description = "/images/AboutusPage/" + Image.FileName;
                }
                dbContext.SaveChanges();
                ClearCache();
            }
            catch (Exception ex)
            {

            }
            return Content("Success");
        }

        public ActionResult UpdateTestimonial(string id)
        {
            var dbContent = new SaifDatabaseEntities();
            var sliderid = Convert.ToInt32(id);
            var content = Request.Form.Get(0);
            var message = Newtonsoft.Json.JsonConvert.DeserializeObject<Testimonial>(content);
            var result = dbContent.Testimonials.Where(x => x.Id == sliderid).Select(x => x).FirstOrDefault();
            result.Testimonial_Description = message.content;
            dbContent.SaveChanges();
            ClearCache();
            return Content("success");
        }

        public ActionResult GetTestimonial(string id)
        {
            var testId = Convert.ToInt32(id);
            var dbContext = new SaifDatabaseEntities();
            var result = dbContext.Testimonials.Where(x => x.Id == testId).Select(x => x.Testimonial_Description).FirstOrDefault();
            return Content(result);
        }

        //[HttpPost]
        public ActionResult AddTestimonial()
        {
            var dbContext = new SaifDatabaseEntities();
            var content = Request.Form.Get(0);
            var text = JsonConvert.DeserializeObject<Testimonial>(content);
            var result = dbContext.Testimonials.Add(new DataAccessLayer.Testimonial
            {
                Testimonial_Description = text.content
            });
            dbContext.SaveChanges();
            ClearCache();
            return Content("success");
        }

        public ActionResult DeleteTestimonial(string id)
        {
            int testid = Convert.ToInt32(id);
            var dbContext = new SaifDatabaseEntities();
            var result = dbContext.Testimonials.Where(x => x.Id == testid).FirstOrDefault();
            dbContext.Testimonials.Remove(result);
            dbContext.SaveChanges();
            ClearCache();
            return Content("deleted");
        }

        public ActionResult Products()
        {
            return View();
        }

        public ActionResult GetProductDetail(string id)
        {
            var dbContext = new SaifDatabaseEntities();
            int productId = Convert.ToInt32(id);
            var detail = dbContext.Products.Where(x => x.Id == productId).Select(x => x).SingleOrDefault();
            return Json(detail, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteProduct(string id)
        {
            int productId = Convert.ToInt32(id);
            var dbContext = new SaifDatabaseEntities();
            var result = dbContext.Products.Where(x => x.Id == productId).Select(x => x).FirstOrDefault();
            dbContext.Products.Remove(result);
            dbContext.SaveChanges();
            ClearCache();
            return Content("deleted");
        }

        public ActionResult AddProduct()
        {
            var dbContext = new SaifDatabaseEntities();
            var title = Request.Form.Get("title");
            var description = Request.Form.Get("description");
            var picture = Request.Files.Get("image");
            var sort = Convert.ToInt32(Request.Form.Get("order"));


            Bitmap image = new Bitmap(picture.InputStream);
            string imagePath = Server.MapPath("~") + "images\\ProductsPage\\" + picture.FileName;
            image.Save(imagePath);

            var result = dbContext.Products.Add(new Product
            {
                ProductName = title,
                ProcuctDescription = description,
                ProductImageUrl = "/images/ProductsPage/" + picture.FileName,
                SortOrder = sort
            });
            dbContext.SaveChanges();
            ClearCache();
            return Content("success");
        }

        public ActionResult UpdateProduct()
        {
            var dbContext = new SaifDatabaseEntities();
            var productId = Convert.ToInt32(Request.Form.Get("id"));
            var title = Request.Form.Get("title");
            var description = Request.Form.Get("description");
            var picture = Request.Files.Get("image");
            var sort = Convert.ToInt32(Request.Form.Get("order"));
            var result = dbContext.Products.Where(x => x.Id == productId).Select(x => x).FirstOrDefault();
            result.ProductName = title;
            result.ProcuctDescription = description;
            result.SortOrder = sort;
            if (picture != null)
            {
                var originalImage = Image.FromStream(picture.InputStream);
                Bitmap image = new Bitmap(originalImage, 564, 252);
                string imagePath = Server.MapPath("~") + "images\\ProductsPage\\" + picture.FileName;
                image.Save(imagePath);
                result.ProductImageUrl = "/images/ProductsPage/" + picture.FileName;
            }
            dbContext.SaveChanges();
            ClearCache();
            return Content("updated");
        }

        public ActionResult Events()
        {
            return View();
        }

        public ActionResult GetEvent(string id)
        {
            var dbContext = new SaifDatabaseEntities();
            int eventId = Convert.ToInt32(id);
            var result = dbContext.Events.Where(x => x.EventId == eventId).Select(x => x).SingleOrDefault();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UpdateEvent()
        {
            var dbContext = new SaifDatabaseEntities();
            var id = Convert.ToInt32(Request.Form.Get("id"));
            var name = Request.Form.Get("name");
            var date = Request.Form.Get("date");
            var title = Request.Form.Get("title");
            var picture = Request.Files.Get("image");

            var result = dbContext.Events.Where(x => x.EventId == id).Select(x => x).FirstOrDefault();
            result.EventName = name;
            result.EventTitle = title;
            result.EventDate = Convert.ToDateTime(date);

            if (picture != null)
            {
                var originalImage = Image.FromStream(picture.InputStream);

                Bitmap image = new Bitmap(picture.InputStream);
                string fileName = picture.FileName.Split('.')[0] + ".jpg";
                var imagePath = Server.MapPath("~") + "images\\EventsPage\\Thumb\\" + fileName;
                image.Save(imagePath);
                result.EventImageURLThumb = "/images/Eventspage/Thumb/" + fileName;

                Bitmap thumbImage = new Bitmap(originalImage, 353, 200);
                string pngName = picture.FileName.Split('.')[0] + ".png";
                var thumbPath = Server.MapPath("~") + "images\\EventsPage\\" + pngName;
                thumbImage.Save(thumbPath);
                result.EventImageURL = "/images/Eventspage/" + pngName;
            }
            dbContext.SaveChanges();
            ClearCache();
            return Content("Success");
        }

        public ActionResult AddEvent()
        {
            var dbContext = new SaifDatabaseEntities();
            var name = Request.Form.Get("name");
            var title = Request.Form.Get("title");
            var date = Convert.ToDateTime(Request.Form.Get("date"));
            var picture = Request.Files.Get("file");

            Bitmap pngImage = new Bitmap(picture.InputStream);
            string pngFile = picture.FileName.Split('.')[0] + ".png";
            var imagepath = Server.MapPath("~") + "images\\EventsPage\\" + pngFile;
            pngImage.Save(imagepath);

            Bitmap jpgImage = new Bitmap(Image.FromStream(picture.InputStream), 353, 200);
            string jpgFile = picture.FileName.Split('.')[0] + ".jpg";
            var imagepathThumb = Server.MapPath("~") + "images\\EventsPage\\Thumb\\" + jpgFile;
            jpgImage.Save(imagepathThumb);

            var result = dbContext.Events.Add(new Event
            {
                EventName = name,
                EventDate = date,
                EventTitle = title,
                EventImageURL = "/images/Eventspage/" + pngFile,
                EventImageURLThumb = "/images/Eventspage/Thumb/" + jpgFile,
                EventDescription = ""
            });

            dbContext.SaveChanges();
            ClearCache();
            return Content("Success");
        }

        public ActionResult DeleteEvent(string id)
        {
            var dbContext = new SaifDatabaseEntities();
            int eventId = Convert.ToInt32(id);
            var result = dbContext.Events.Where(x => x.EventId == eventId).Select(x => x).SingleOrDefault();
            dbContext.Events.Remove(result);
            dbContext.SaveChanges();
            ClearCache();
            return Content("Deleted");
        }

        public ActionResult Gallery()
        {
            return View();
        }

        public ActionResult DeleteGallaryImage(string id)
        {
            var dbContext = new SaifDatabaseEntities();
            int imageId = Convert.ToInt32(id);
            var result = dbContext.Galleries.Where(x => x.ImageId == imageId).Select(x => x).SingleOrDefault();
            dbContext.Galleries.Remove(result);
            dbContext.SaveChanges();
            ClearCache();
            return Content("deleted");
        }

        public ActionResult AddGallaryImage()
        {
            var dbContext = new SaifDatabaseEntities();
            var picture = Request.Files.Get("image");
            string ImageUrl = string.Empty; string ImageUrlThumb = string.Empty;
            if (picture != null)
            {
                var originalImage = Image.FromStream(picture.InputStream);
                Bitmap image = new Bitmap(originalImage, 353, 353);
                var imagePath = Server.MapPath("~") + "images\\GalleryPage\\" + picture.FileName;
                ImageUrl = "/images/GalleryPage/" + picture.FileName;
                ImageUrlThumb = "/images/GalleryPage/" + picture.FileName;
                image.Save(imagePath);
            }
            var result = dbContext.Galleries.Add(new DataAccessLayer.Gallery
            {
                ImageUrl = ImageUrl,
                ImageUrlThumb = ImageUrlThumb,
                ImageDescription = "",
                IsActive = true
            });
            dbContext.SaveChanges();
            ClearCache();
            return Content("success");
        }

        public ActionResult ContactUs()
        {
            return View();
        }

        public ActionResult UpdateContactDetail()
        {
            var dbContext = new SaifDatabaseEntities();
            var data = Request.Form.Get(0);
            var details = Newtonsoft.Json.JsonConvert.DeserializeObject<ContactDetials>(data);
            var result = dbContext.Contacts.Select(x => x).ToList();
            result[0].Number = Convert.ToString(details.tel);
            result[1].Number = Convert.ToString(details.fax);
            result[2].Number = Convert.ToString(details.mobile1);
            result[3].Number = Convert.ToString(details.mobile2);
            result[4].Number = Convert.ToString(details.email);
            var address = dbContext.Addresses.Select(x => x).ToList();
            address[0].Address1 = details.address;
            dbContext.SaveChanges();
            ClearCache();
            return Content("success");
        }

        public ActionResult Downloads()
        {
            return View();
        }

        public ActionResult AddCertificates()
        {
            try
            {
                var dbContext = new SaifDatabaseEntities();
                var name = Request.Form.Get("name");
                var doc = Request.Files.Get(0);

                var imagePath = Server.MapPath("~") + "Documents\\Certificates\\" + doc.FileName;
                FileStream file = new FileStream(imagePath, FileMode.Create, FileAccess.Write);

                doc.InputStream.CopyTo(file);
                file.Close();

                var url = "/Documents/Certificates/" + doc.FileName;
                var result = dbContext.Certificates.Add(new Certificate
                {
                    CertificateName = name,
                    path = url
                });

                dbContext.SaveChanges();
                ClearCache();
            }
            catch (Exception ex)
            {

            }
            return Json("success");
        }

        public ActionResult DeleteCertificate(string id)
        {
            var dbContext = new SaifDatabaseEntities();
            int certiId = Convert.ToInt32(id);
            var result = dbContext.Certificates.Where(x => x.Id == certiId).Select(x => x).SingleOrDefault();
            dbContext.Certificates.Remove(result);
            dbContext.SaveChanges();
            ClearCache();
            return Content("success");
        }

        public ActionResult AddProductPortfolio()
        {
            try
            {
                var dbContext = new SaifDatabaseEntities();
                var name = Request.Form.Get("name");
                var doc = Request.Files.Get(0);

                var imagePath = Server.MapPath("~") + "Documents\\ProductCatalogue\\" + doc.FileName;
                FileStream file = new FileStream(imagePath, FileMode.Create, FileAccess.Write);

                doc.InputStream.CopyTo(file);
                file.Close();

                var url = "/Documents/ProductCatalogue/" + doc.FileName;
                var result = dbContext.ProductCatalogues.Add(new ProductCatalogue
                {
                    ProductName = name,
                    Path = url
                });

                dbContext.SaveChanges();
                ClearCache();
            }
            catch (Exception ex)
            {

            }
            return Json("success");
        }

        public ActionResult DeletePortfolio(string id)
        {
            var dbContext = new SaifDatabaseEntities();
            int productid = Convert.ToInt32(id);
            var result = dbContext.ProductCatalogues.Where(x => x.Id == productid).Select(x => x).SingleOrDefault();
            dbContext.ProductCatalogues.Remove(result);
            dbContext.SaveChanges();
            ClearCache();
            return Content("success");
        }

        public ActionResult UpdateBrochure()
        {
            try
            {
                var dbContext = new SaifDatabaseEntities();
                var name = Request.Form.Get("brochure");
                var doc = Request.Files.Get(0);
                string folderPath = Server.MapPath("~") + "Documents\\CompanyProfile";
                var directory = new DirectoryInfo(folderPath);
                var files = directory.GetFiles();
                foreach (var item in files)
                {
                    item.Delete();
                }
                var imagePath = Server.MapPath("~") + "Documents\\CompanyProfile\\" + doc.FileName;
                FileStream file = new FileStream(imagePath, FileMode.Create, FileAccess.Write);
                doc.InputStream.CopyTo(file);
                file.Close();

                string path = "/Documents/CompanyProfile/" + doc.FileName;
                var result = dbContext.CompanyProfiles.Where(x => x.Id == 1).SingleOrDefault();
                result.Profile_Path = path;
                dbContext.SaveChanges();
                ClearCache();
                return Json("success");
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        private void ClearCache()
        {
            IDictionaryEnumerator cache = HttpContext.Cache.GetEnumerator();
            while(cache.MoveNext())
            {
                HttpContext.Cache.Remove(cache.Key.ToString());
            }
        }
    }

    public class UserModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class Testimonial
    {
        public string content { get; set; }
    }

    public class ContactDetials
    {
        public string address { get; set; }
        public string tel { get; set; }
        public string fax { get; set; }
        public string mobile1 { get; set; }
        public string mobile2 { get; set; }
        public string email { get; set; }
    }
}