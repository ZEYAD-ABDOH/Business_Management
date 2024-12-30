using Arti.Client.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace Arti.Client.Controllers
{
    public class PropertyController : Controller
    {
        private readonly HttpClient _httpClient;
        Uri GetUri = new("https://localhost:7281/api/Properties");
        public PropertyController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.Timeout = TimeSpan.FromSeconds(20);
        }
        public async Task<IActionResult> Index()
        {
            List<Property > property = new List<Property>();

            

            try
            {
                //token حق  Header تضمين في  

              
                var resq = await _httpClient.GetAsync(GetUri);
                if (resq.IsSuccessStatusCode)
                {
                    property = await resq.Content.ReadFromJsonAsync<List<Property>>() ?? new List<Property>();
                    if (property == null || !property.Any())
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
            return View(property);

        }


        public IActionResult Create()
        {


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Property property)
        {
            var userRole = HttpContext.Session.GetString("Role");
            if (userRole == "User")
            {
                ViewBag.errerq = " لا يمكن  الاضافة ";
                return RedirectToAction(nameof(Index));
            }

            try
            {
                var res = await _httpClient.PostAsJsonAsync<Property>(GetUri, property);
                if (res.IsSuccessStatusCode)
                {

                    var data = await res.Content.ReadFromJsonAsync<Property>();


                    return RedirectToAction(nameof(Index));
                }
                else if (res.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return View(property);
                }

            }
            catch (Exception)

            {
                ViewBag.errer = ".حدث خطاء عير متوقع ";

            }
            return View(property);
        }




        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var res = await _httpClient.GetAsync(GetUri + "/" + id);
                if (res.IsSuccessStatusCode)
                {
                    var data = await res.Content.ReadFromJsonAsync<Property>();
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

        public async Task<IActionResult> Edit(int id, Property property)
        {

            try
            {
                var res = await _httpClient.PutAsJsonAsync<Property>(GetUri + "/" + id, property);
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
            var response = await _httpClient.GetAsync(GetUri + "/" + id);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<Property>();
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
            return View();

        }

    }
}

