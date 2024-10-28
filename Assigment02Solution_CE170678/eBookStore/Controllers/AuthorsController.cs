using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace eBookStore.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly HttpClient client = null;
        private string AuthorApiUrl = "";
        public AuthorsController()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            AuthorApiUrl = "http://localhost:5285/odata/Authors";
        }

        // GET: Authors
        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await client.GetAsync(AuthorApiUrl);
            string data = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            List<Author> listAuthor = JsonSerializer.Deserialize<List<Author>>(data, options);


            return View(listAuthor);
        }

        // GET: Authors/Details/5
        public async Task<IActionResult> Details(int id)
        {
            HttpResponseMessage response = await client.GetAsync($"{AuthorApiUrl}/{id}");
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                Author Author = JsonSerializer.Deserialize<Author>(data, options);
                return View(Author);
            }
            return NotFound();
        }

        // GET: Authors/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: Authors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("last_name,first_name,phone,address,city,state,zip,email_address")] Author Author)
        {
            if (ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                var jsonAuthor = JsonSerializer.Serialize(Author);
                var content = new StringContent(jsonAuthor, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(AuthorApiUrl, content);
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
            Console.WriteLine("loi roi");
            return View(Author);
        }

        // GET: Authors/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HttpResponseMessage data = await client.GetAsync($"{AuthorApiUrl}/{id}");
            if (data.IsSuccessStatusCode)
            {

                string content = await data.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                Author Author = JsonSerializer.Deserialize<Author>(content, options);
                return View(Author);
            }
            return NotFound();

        }

        // POST: Authors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("last_name,first_name,phone,address,city,state,zip,email_address")] Author Author)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    var jsonAuthor = JsonSerializer.Serialize(Author);
                    var content = new StringContent(jsonAuthor, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PutAsync($"{AuthorApiUrl}/{id}", content);
                    Console.WriteLine("Response: " + response);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    return View(Author);

                }
            }

            return View(Author);
        }

        // GET: Authors/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HttpResponseMessage response = await client.GetAsync($"{AuthorApiUrl}/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                Author Author = JsonSerializer.Deserialize<Author>(content, options);
                return View(Author);

            }
            return NotFound();
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync($"{AuthorApiUrl}/{id}");
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
