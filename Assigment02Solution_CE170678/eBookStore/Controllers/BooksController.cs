using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace eBookStore.Controllers
{
    public class BooksController : Controller
    {
        private readonly HttpClient client = null;
        private string BookApiUrl = "";

        public BooksController()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            BookApiUrl = "http://localhost:5285/odata/Books"; // Adjust API URL if necessary
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await client.GetAsync(BookApiUrl);
            string data = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            List<Book> listBook = JsonSerializer.Deserialize<List<Book>>(data, options);

            return View(listBook);
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int id)
        {
            HttpResponseMessage response = await client.GetAsync($"{BookApiUrl}/{id}");
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                Book book = JsonSerializer.Deserialize<Book>(data, options);



                return View(book);
            }
            return NotFound();
        }

        public async Task<IActionResult> AddAuthor(int id)
        {
            HttpResponseMessage response2 = await client.GetAsync($"{BookApiUrl}/authors");
            string data2 = await response2.Content.ReadAsStringAsync();
            var options2 = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            List<Author> listAuthor = JsonSerializer.Deserialize<List<Author>>(data2, options2);
            ViewBag.author_id = new SelectList(
                listAuthor.Select(a => new { a.author_id, FullName = a.first_name + " " + a.last_name }),
                "author_id",
                "FullName"
            );
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAuthor(int id, BookAuthor bookAuthor)
        {
            if (ModelState.IsValid)
            {
                bookAuthor.book_id = id;

                var jsonBook = JsonSerializer.Serialize(bookAuthor);
                var content = new StringContent(jsonBook, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("http://localhost:5285/api/bookauthors", content);

                Console.WriteLine(response);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    ViewBag.Error = errorMessage;
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    ViewBag.Error = "An error occurred: " + error;
                }
            }

            var errors = ModelState.Values.SelectMany(v => v.Errors);

            foreach (var error in errors)
            {
                Console.WriteLine(error.ErrorMessage);
            }

            return View(bookAuthor);
        }

        // GET: Books/Create
        public async Task<IActionResult> Create()
        {
            HttpResponseMessage response2 = await client.GetAsync($"{BookApiUrl}/publishers");
            string data2 = await response2.Content.ReadAsStringAsync();
            var options2 = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            List<Publisher> listPublisher = JsonSerializer.Deserialize<List<Publisher>>(data2, options2);
            ViewBag.pub_id = new SelectList(listPublisher, "pub_id", "publisher_name");
            return View();
        }



        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("title,type,price,advance,royalty,ytd_sales,notes,published_date,pub_id")] Book book)
        {
            if (ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                var jsonBook = JsonSerializer.Serialize(book);
                var content = new StringContent(jsonBook, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(BookApiUrl, content);
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
            Console.WriteLine("sai o day ne");
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            HttpResponseMessage data = await client.GetAsync($"{BookApiUrl}/{id}");
            if (data.IsSuccessStatusCode)
            {
                string content = await data.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                Book book = JsonSerializer.Deserialize<Book>(content, options);
                return View(book);
            }
            return NotFound();
        }

        // POST: Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("title,type,price,advance,royalty,ytd_sales,notes,published_date,pub_id")] Book book)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var jsonBook = JsonSerializer.Serialize(book);
                    var content = new StringContent(jsonBook, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PutAsync($"{BookApiUrl}/{id}", content);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    return View(book);
                }
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            HttpResponseMessage response = await client.GetAsync($"{BookApiUrl}/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                Book book = JsonSerializer.Deserialize<Book>(content, options);
                return View(book);
            }
            return NotFound();
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync($"{BookApiUrl}/{id}");
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
