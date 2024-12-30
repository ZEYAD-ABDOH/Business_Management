using Arti.Client.Models;
using Microsoft.AspNetCore.Mvc;

namespace Arti.Client.Controllers
{
    public class TaskArtiController : Controller
    {
        private readonly HttpClient _httpClient;
        Uri GetUri = new("https://localhost:7281/api/TaskArtis");
        public TaskArtiController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.Timeout = TimeSpan.FromSeconds(20);
        }
        public async Task<IActionResult> Index()
        {
            List<TaskArti> taskArti = new List<TaskArti>();



            try
            {
                //token حق  Header تضمين في  


                var resq = await _httpClient.GetAsync(GetUri);
                if (resq.IsSuccessStatusCode)
                {
                    taskArti = await resq.Content.ReadFromJsonAsync<List<TaskArti>>() ?? new List<TaskArti>();
                    if (taskArti == null || !taskArti.Any())
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
            return View(taskArti);

        }


        public IActionResult Create()
        {


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskArti taskArti)
        {
            var userRole = HttpContext.Session.GetString("Role");
            if (userRole == "User")
            {
                ViewBag.errerq = " لا يمكن  الاضافة ";
                return RedirectToAction(nameof(Index));
            }

            try
            {
                var res = await _httpClient.PostAsJsonAsync<TaskArti>(GetUri, taskArti);
                if (res.IsSuccessStatusCode)
                {

                    var data = await res.Content.ReadFromJsonAsync<TaskArti>();


                    return RedirectToAction(nameof(Index));
                }
                else if (res.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return View(taskArti);
                }

            }
            catch (Exception)

            {
                ViewBag.errer = ".حدث خطاء عير متوقع ";

            }
            return View(taskArti);
        }




        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var res = await _httpClient.GetAsync(GetUri + "/" + id);
                if (res.IsSuccessStatusCode)
                {
                    var data = await res.Content.ReadFromJsonAsync<TaskArti>();
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

        public async Task<IActionResult> Edit(int id, TaskArti taskArti)
        {

            try
            {
                var res = await _httpClient.PutAsJsonAsync<TaskArti>(GetUri + "/" + id, taskArti);
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
                var data = await response.Content.ReadFromJsonAsync<TaskArti>();
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
