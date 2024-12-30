using Arti.Client.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Arti.Client.Controllers
{
    public class BusinessTypeController : Controller
    {
        private readonly HttpClient _httpClient;
        Uri GetUri = new("https://localhost:7281/api/BusinessTypes");
        public BusinessTypeController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.Timeout = TimeSpan.FromSeconds(20);
        }
        public async Task<IActionResult> Index()
        {
            List<BusinessType> businessTypes = new List<BusinessType>();

          var tokenBeare=  HttpContext.Session.GetString("Auth");

            if (string.IsNullOrWhiteSpace(tokenBeare))
            {
                ViewBag.error = "يرجى عملية التسجيل ";
                return View(new List<BusinessType>());
            }
            try
            {
                //token حق  Header تضمين في  

                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenBeare);
                var resq = await _httpClient.GetAsync(GetUri);
                if (resq.IsSuccessStatusCode)
                {
                    businessTypes = await resq.Content.ReadFromJsonAsync<List<BusinessType>>() ?? new List<BusinessType>();
                    if (businessTypes == null || !businessTypes.Any())
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
            return View(businessTypes);

        }


        public  IActionResult Create()
        {


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BusinessType businessType )
        {
            var userRole = HttpContext.Session.GetString("Role");
            if (userRole == "User")
            {
                ViewBag.errerq = " لا يمكن  الاضافة ";
                return RedirectToAction(nameof(Index));
            }

            try
            {
                var res = await _httpClient.PostAsJsonAsync<BusinessType>(GetUri, businessType);
                if (res.IsSuccessStatusCode)
                {

                    var data = await res.Content.ReadFromJsonAsync<BusinessType>();


                    return RedirectToAction(nameof(Index));
                }
                else if (res.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return View(businessType);
                }

            }
            catch (Exception)

            {
                ViewBag.errer = ".حدث خطاء عير متوقع ";

            }
            return View(businessType);
        }




        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var res = await _httpClient.GetAsync(GetUri + "/" + id);
                if (res.IsSuccessStatusCode)
                {
                    var data = await res.Content.ReadFromJsonAsync< BusinessType  > ();
                    return View(data);
                }

            }
            catch (Exception)
            {
                ViewBag.errer = ".حدث خطاء عير متوقع ";
            }

            return View("error");

        }

        [HttpPost]

        public async Task<IActionResult> Edit(int id, BusinessType businessType)
        {

            try
            {
                var res = await _httpClient.PutAsJsonAsync<BusinessType>(GetUri + "/" + id, businessType);
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




        public async Task<IActionResult> Delete(int id)
        {
            var respones = await _httpClient.GetFromJsonAsync<BusinessType>(GetUri + "/" + id);
            return View(respones);
        }

        public async Task<IActionResult> DeleteOk(int id)
        {

            var respones = await _httpClient.DeleteAsync(GetUri + "/" + id);

            if (respones.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));

            }
            return View(respones);

        }

    }
}
