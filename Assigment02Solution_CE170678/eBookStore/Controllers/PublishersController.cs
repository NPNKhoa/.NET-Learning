using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace eBookStore.Controllers
{
    public class PublishersController : Controller
    {
        private readonly HttpClient client = null;
        private string PublisherApiUrl = "";

        public PublishersController()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            PublisherApiUrl = "http://localhost:5285/odata/Publishers"; // Adjust API URL if necessary
        }

        // GET: Publishers
        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await client.GetAsync(PublisherApiUrl);
            string data = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            List<Publisher> listPublisher = JsonSerializer.Deserialize<List<Publisher>>(data, options);

            return View(listPublisher);
        }

        // GET: Publishers/Details/5
        public async Task<IActionResult> Details(int id)
        {
            HttpResponseMessage response = await client.GetAsync($"{PublisherApiUrl}/{id}");
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                Publisher publisher = JsonSerializer.Deserialize<Publisher>(data, options);
                return View(publisher);
            }
            return NotFound();
        }

        // GET: Publishers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Publishers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("publisher_name,city,state,country")] Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                var jsonPublisher = JsonSerializer.Serialize(publisher);
                var content = new StringContent(jsonPublisher, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(PublisherApiUrl, content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    ViewBag.Error = error;
                }
            }
            return View(publisher);
        }

        // GET: Publishers/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            HttpResponseMessage data = await client.GetAsync($"{PublisherApiUrl}/{id}");
            if (data.IsSuccessStatusCode)
            {
                string content = await data.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                Publisher publisher = JsonSerializer.Deserialize<Publisher>(content, options);
                return View(publisher);
            }
            return NotFound();
        }

        // POST: Publishers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("publisher_name,city,state,country")] Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var jsonPublisher = JsonSerializer.Serialize(publisher);
                    var content = new StringContent(jsonPublisher, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PutAsync($"{PublisherApiUrl}/{id}", content);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    return View(publisher);
                }
            }
            return View(publisher);
        }

        // GET: Publishers/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            HttpResponseMessage response = await client.GetAsync($"{PublisherApiUrl}/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                Publisher publisher = JsonSerializer.Deserialize<Publisher>(content, options);
                return View(publisher);
            }
            return NotFound();
        }

        // POST: Publishers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync($"{PublisherApiUrl}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
