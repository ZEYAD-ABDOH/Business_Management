using Arti.Client.Models;

using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Arti.Client.Controllers
{
    public class ApplicantController : Controller
    {
        private readonly HttpClient _httpClient;
        Uri GetUri = new("https://localhost:7281/api/Applicants");

        public ApplicantController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.Timeout = TimeSpan.FromSeconds(20);
        }
        // GET: ApplicantController
        public async Task<IActionResult> Index()
        {
            List<Applicant>applicant  =  new ();
            try
            {
                var resq =await _httpClient
                    .GetAsync(GetUri);
                if (resq.IsSuccessStatusCode)
                {
                    applicant = await resq.Content.ReadFromJsonAsync<List<Applicant>>() ?? new();
                    if (applicant == null || !applicant.Any())
                    {
                        ViewBag.errer = ".لايوجد بيانات ";
                    }
                  

                }

                else
                {
                    ViewBag.errer = ".حدث خطاء اثناء جلب البيانات .";
                }

            }
            catch (Exception)
            {
                ViewBag.errer = ".حدث خطاء عير متوقع ";

            }
            return View(applicant);
        }

 
     

        // GET: ApplicantController/Create
        public IActionResult Create()
        {
           
            return View();
        }

        // POST: ApplicantController/Create
        [HttpPost]
  
        public async Task<IActionResult> Create(Applicant applicant)
        {

           


            var file = HttpContext.Request.Form.Files;

            if (file.Count() > 0)
            {
                string ResumeCV = Guid.NewGuid().ToString() + Path.GetExtension(file[0].FileName);
                FileStream pathFileStream = new FileStream(Path.Combine(@"wwwroot/", "CV", ResumeCV), FileMode.Create);
                file[0].CopyTo(pathFileStream);
                applicant.ResumeCV = ResumeCV;


            }
            else if (file.Count() > 0)
            {
                string imagesName = Guid.NewGuid().ToString() + Path.GetExtension(file[0].FileName);
                FileStream pathFileStream = new FileStream(Path.Combine(@"wwwroot/", "images", imagesName), FileMode.Create);
                file[0].CopyTo(pathFileStream);
                applicant.Images = imagesName;
            }

            var resp = await _httpClient.PostAsJsonAsync(GetUri, applicant);

            try
            {
                if (resp.IsSuccessStatusCode)
                {
                    var data = await resp.Content.ReadFromJsonAsync<Applicant>();

                    TempData["ADDS"] = " تمت الاضافة ";

                    return RedirectToAction(nameof(Index));
                }
                else if (resp.StatusCode== HttpStatusCode.NotFound)
                {
                    return View(applicant);
                }
            }
            catch(Exception)
            {
                ViewBag.errer = ".حدث خطاء عير متوقع ";
                return View();
            }
            return View(applicant);
        }

        // GET: ApplicantController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            TempData["ADDS"] = " يمكنك تعديل  ";
            try
            {
                var res = await _httpClient.GetAsync(GetUri + "/" + id);
                if (res.IsSuccessStatusCode)
                {
                    var data = await res.Content.ReadFromJsonAsync<Applicant>();
                    return View(data);
                }

            }
            catch (Exception)
            {
                ViewBag.errer = ".حدث خطاء عير متوقع ";
            }

            return View("error");
        }

        // POST: ApplicantController/Edit/5
        [HttpPost]
     
        public async  Task<IActionResult> Edit( Applicant applicant,int id)
        {
            TempData["ADDS"] = " تمت  تعديل  ";
            var file = HttpContext.Request.Form.Files;

            if (file.Count() > 0)
            {
                string ResumeCV = Guid.NewGuid().ToString() + Path.GetExtension(file[0].FileName);
                FileStream pathFileStream = new FileStream(Path.Combine(@"wwwroot/", "CV", ResumeCV), FileMode.Create);
                file[0].CopyTo(pathFileStream);
                applicant.ResumeCV = ResumeCV;

            }
            else if (file.Count() > 0)
            {
                string imagesName = Guid.NewGuid().ToString() + Path.GetExtension(file[0].FileName);
                FileStream pathFileStream = new FileStream(Path.Combine(@"wwwroot/", "images", imagesName), FileMode.Create);
                file[0].CopyTo(pathFileStream);
                applicant.Images = imagesName;
            }

            try
            {
                var res = await _httpClient.PutAsJsonAsync<Applicant>(GetUri + "/" + id, applicant);
                if (res.IsSuccessStatusCode)
                {


                    return RedirectToAction(nameof(Index));

                }
                if (res.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return View("In server");
                }
            }
            catch (Exception)
            { ViewBag.errer = ".حدث خطاء عير متوقع "; }

            return View("ther is error ");
        }

        // GET: ApplicantController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _httpClient.GetAsync(GetUri + "/" + id);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<Applicant>();
                return View(data);
            }
            return View(response);
        }

        public async Task<IActionResult> Delete1(int id)
        {
            var respones = await _httpClient.DeleteAsync(GetUri + "/" + id);
            try
            {
                if (respones.IsSuccessStatusCode)
                {

                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    ViewBag.Error = "حدث خطأ غير متوقع أثناء الحذف.";
                    return View("Error"); // عرض صفحة خطأ مخصصة
                }
            }
            catch (Exception)
            {
                ViewBag.errer = ".حدث خطاء عير متوقع ";
            }
            return View(respones);

        }

        // POST: ApplicantController/Delete/5
       
      
       
    }
}
