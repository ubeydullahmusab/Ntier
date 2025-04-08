using DL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Core.Controllers
{
    public class KisiController : Controller
    {
        public readonly HttpClient _httpClient;
        public KisiController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ApiClient");
        }
        public IActionResult GetKisi()
        {

            return View();

        }
        public IActionResult KisiGuncelle(Kisi kisi)
        {

            return View(kisi);

        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("GetKisiler"); // API'deki 'Ornek' endpointi
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var json = JsonSerializer.Deserialize<List<Kisi>>(data, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return View(json); // Veriyi View'e gönder

            }
            return View("Error");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Guncelle(int id)
        {
            var response = await _httpClient.GetAsync($"GetKisi/{id}");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var json = JsonSerializer.Deserialize<Kisi>(data, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return RedirectToAction("KisiGuncelle", json);

            }
            return View("Error");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Kisi model)
        {
            if (model == null || model.Id <= 0)
            {
                return BadRequest("Geçersiz veri!");
            }
            var json = JsonSerializer.Serialize(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"UpdateKisi/{model.Id}", content);
            if (response.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");

            }
            return View("Error");

        }
        [HttpPost]
        public async Task<IActionResult> Kaydet(Kisi? model)
        {
            if (model == null)
            {
                return BadRequest("Geçersiz veri!");
            }
            var json = JsonSerializer.Serialize(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"AddKisi", content);
            if (response.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");

            }
            return View("Error");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Sil(decimal id)
        {
            var response = await _httpClient.DeleteAsync($"DeleteKisi/{id}");
            if (response.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");

            }
            return View("Error");
        }
    }
}
