using Arti.Client.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace Arti.Client.Controllers
{
    public class JobApplicationController : Controller
    {
        private readonly HttpClient _httpClient;
        Uri GetUri = new("https://localhost:7281/api/JobApplications");
        public JobApplicationController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.Timeout = TimeSpan.FromSeconds(20);
        }
        public async Task<IActionResult> Index()
        {
            List<JobApplication> job = new();
            try
            {
                var resq = await _httpClient.GetAsync(GetUri);
                if (resq.IsSuccessStatusCode)
                {
                    job = await resq.Content.ReadFromJsonAsync<List<JobApplication>>() ?? new();
                    if (job == null || !job.Any())
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
            return View(job);
        }
        public IActionResult Create()
        {


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(JobApplication jobApplication)
        {

            try
            {
                var res = await _httpClient.PostAsJsonAsync<JobApplication>(GetUri, jobApplication);

                if (res.IsSuccessStatusCode)
                {

                    var data = await res.Content.ReadFromJsonAsync<JobApplication>();


                    return RedirectToAction(nameof(Index));
                }
                else if (res.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return View(jobApplication);
                }


            }
            catch (Exception)

            {
                ViewBag.errer = ".حدث خطاء عير متوقع ";

            }
            return View(jobApplication);
        }


        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var res = await _httpClient.GetAsync(GetUri + "/" + id);
                if (res.IsSuccessStatusCode)
                {
                    var data = await res.Content.ReadFromJsonAsync<JobApplication>();
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

        public async Task<IActionResult> Edit(int id, JobApplication jobApplication)
        {

            try
            {
                var res = await _httpClient.PutAsJsonAsync<JobApplication>(GetUri + "/" + id, jobApplication);
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
                var data = await response.Content.ReadFromJsonAsync<JobApplication>();
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
