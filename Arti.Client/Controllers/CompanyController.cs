using Arti.Client.Models;
using Microsoft.AspNetCore.Mvc;

namespace Arti.Client.Controllers
{
    public class CompanyController : Controller
    {
        private readonly HttpClient _httpClient;
        Uri GetUri = new("https://localhost:7281/api/Companies");
        public CompanyController(HttpClient httpClient)
        {
         _httpClient = httpClient;
          _httpClient.Timeout = TimeSpan.FromSeconds(20);
        }
        public async Task<IActionResult> Index()
        {
            List<Company> company = new();
            try
            {
                var resq = await _httpClient.GetAsync(GetUri);
                if (resq.IsSuccessStatusCode)
                {
                    company = await resq.Content.ReadFromJsonAsync<List<Company>>() ?? new();
                    if (company == null || !company.Any())
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
            return View(company);
        }
        public IActionResult Create()
        {


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Company company)
        {

            try
            {
                var res = await _httpClient.PostAsJsonAsync<Company>(GetUri, company);

                if (res.IsSuccessStatusCode)
                {

                    var data = await res.Content.ReadFromJsonAsync<Company>();


                    return RedirectToAction(nameof(Index));
                }
                else if (res.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return View(company);
                }


            }
            catch (Exception)

            {
                ViewBag.errer = ".حدث خطاء عير متوقع ";

            }
            return View(company);
        }


        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var res = await _httpClient.GetAsync(GetUri + "/" + id);
                if (res.IsSuccessStatusCode)
                {
                    var data = await res.Content.ReadFromJsonAsync<Company>();
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

        public async Task<IActionResult> Edit(int id, Company company)
        {

            try
            {
                var res = await _httpClient.PutAsJsonAsync<Company>(GetUri + "/" + id, company);
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
                var data = await response.Content.ReadFromJsonAsync<Company>();
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
