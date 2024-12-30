﻿using Arti.Client.Models;
using Microsoft.AspNetCore.Mvc;

namespace Arti.Client.Controllers
{
    public class CraftsmanController : Controller
    {
        private readonly HttpClient _httpClient;
        Uri GetUri = new("https://localhost:7281/api/Craftsmen");
        public CraftsmanController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.Timeout = TimeSpan.FromSeconds(20);
        }
        public async Task<IActionResult> Index()
        {
            List<Craftsman> craftsman = new();
            try
            {
                var resq = await _httpClient.GetAsync(GetUri);
                if (resq.IsSuccessStatusCode)
                {
                    craftsman = await resq.Content.ReadFromJsonAsync<List<Craftsman>>() ?? new();
                    if (craftsman == null || !craftsman.Any())
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
            return View(craftsman);
        }
        public IActionResult Create()
        {


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Craftsman craftsman)
        {

            TempData["ADDS"] = " تمت الاضافة ";


            var file = HttpContext.Request.Form.Files;

            if (file.Count() > 0)
            {
                string imagesName = Guid.NewGuid().ToString() + Path.GetExtension(file[0].FileName);
                FileStream pathFileStream = new FileStream(Path.Combine(@"wwwroot/", "images", imagesName), FileMode.Create);
                file[0].CopyTo(pathFileStream);
                craftsman.Images = imagesName;

            }

            try
            {
                var res = await _httpClient.PostAsJsonAsync<Craftsman>(GetUri, craftsman);

                if (res.IsSuccessStatusCode)
                {

                    var data = await res.Content.ReadFromJsonAsync<Craftsman>();


                    return RedirectToAction(nameof(Index));
                }
                else if (res.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return View(craftsman);
                }


            }
            catch (Exception)

            {
                ViewBag.errer = ".حدث خطاء عير متوقع ";

            }
            return View(craftsman);
        }


        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var res = await _httpClient.GetAsync(GetUri + "/" + id);
                if (res.IsSuccessStatusCode)
                {
                    var data = await res.Content.ReadFromJsonAsync<Craftsman>();
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

        public async Task<IActionResult> Edit(int id, Craftsman craftsman)
        {

            var file = HttpContext.Request.Form.Files;

            if (file.Count() > 0)
            {
                string imagesName = Guid.NewGuid().ToString() + Path.GetExtension(file[0].FileName);
                FileStream pathFileStream = new FileStream(Path.Combine(@"wwwroot/", "images", imagesName), FileMode.Create);
                file[0].CopyTo(pathFileStream);
                craftsman.Images = imagesName;


            }
            try
            {
                var res = await _httpClient.PutAsJsonAsync<Craftsman>(GetUri + "/" + id, craftsman);
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
                var data = await response.Content.ReadFromJsonAsync<Craftsman>();
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
