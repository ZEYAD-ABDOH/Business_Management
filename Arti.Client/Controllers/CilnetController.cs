using Arti.Client.Models;
using Microsoft.AspNetCore.Mvc;
using ProjectArti.Api.Model;
using System.Data;
using System.Net.Http;

namespace Arti.Client.Controllers
{
    public class CilnetController : Controller
    {

        private readonly HttpClient _httpClient;
        Uri GetUri = new("https://localhost:7281/api/Clients");

        public CilnetController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.Timeout = TimeSpan.FromSeconds(20);
        }
        public async Task<IActionResult> Index()
        {
            List<Client.Models.Client> clients = new();
            try
            {
                var resq = await _httpClient.GetAsync(GetUri);
                if (resq.IsSuccessStatusCode)
                {
                    clients = await resq.Content.ReadFromJsonAsync<List<Client.Models.Client>>() ?? new();
                    if (clients == null || !clients.Any())
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
            return View(clients);

        }

        public IActionResult Create()
        {

            TempData["ADDS"] = "اضافة جديدة";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Userlogin userlogin)
        {
            var resp = await _httpClient.PostAsJsonAsync(GetUri + "/" + "login", userlogin);
            if (resp.IsSuccessStatusCode)

            {
                TempData["Erorr"] = "تم تسجيل الدخول بنجاح ";
                var respToken = await resp.Content.ReadFromJsonAsync<TokenResponse>();
                var token = respToken.token;
                var role = respToken.role;
                if (!string.IsNullOrWhiteSpace(token))
                {

                    HttpContext.Session.SetString("Auth", token);
                    HttpContext.Session.SetString("Role", token);

                  
                }
                var userRole = HttpContext.Session.GetString("Role");
                if (userRole == "Admin")
                {
                    return RedirectToAction("Index", "Company");
                }
                else if (userRole == "User")
                {
                    return RedirectToAction("Index", "BusinessType");
                }
            }


            ViewBag.error = "Erorr";
            return View(userlogin);



        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Client.Models.Client client)
        {



         

            TempData["ADDS"] = " تمت الاضافة ";


            var file = HttpContext.Request.Form.Files;

            if (file.Count() > 0)
            {
                string imagesName = Guid.NewGuid().ToString() + Path.GetExtension(file[0].FileName);
                FileStream pathFileStream = new FileStream(Path.Combine(@"wwwroot/", "images", imagesName), FileMode.Create);
                file[0].CopyTo(pathFileStream);
                client.Images = imagesName;


            }

            try
            {
                var res = await _httpClient.PostAsJsonAsync<Client.Models.Client>(GetUri, client);

                if (res.IsSuccessStatusCode)
                {

                    var data = await res.Content.ReadFromJsonAsync<Client.Models.Client>();



                    return RedirectToAction(nameof(Index));

                }
                else if (res.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return View(client);
                }


            }
            catch (Exception)

            {
                ViewBag.errer = ".حدث خطاء عير متوقع ";

            }

            return View(client);
        }


        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var res = await _httpClient.GetAsync(GetUri + "/" + id);
                if (res.IsSuccessStatusCode)
                {
                    var data = await res.Content.ReadFromJsonAsync<Client.Models.Client>();
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

        public async Task<IActionResult> Edit(int id, Client.Models.Client client)
        {

            var file = HttpContext.Request.Form.Files;

            if (file.Count() > 0)
            {
                string imagesName = Guid.NewGuid().ToString() + Path.GetExtension(file[0].FileName);
                FileStream pathFileStream = new FileStream(Path.Combine(@"wwwroot/", "images", imagesName), FileMode.Create);
                file[0].CopyTo(pathFileStream);
                client.Images = imagesName;


            }

            try
            {
                var res = await _httpClient.PutAsJsonAsync<Client.Models.Client>(GetUri + "/" + id, client);
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
                var data = await response.Content.ReadFromJsonAsync<Client.Models.Client>();
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
    }


}
