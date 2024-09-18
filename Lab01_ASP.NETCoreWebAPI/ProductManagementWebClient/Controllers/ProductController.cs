using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;


public class ProductController : Controller
{
    private readonly HttpClient client = null;
    private string ProductApiUrl = "";

    public ProductController()
    {
        client = new HttpClient();
        var contentType = new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json");
        client.DefaultRequestHeaders.Accept.Add(contentType);
        ProductApiUrl = "https://localhost:7152/api/products";  // URL của API
    }

    // GET: ProductController/Index
    public async Task<ActionResult> Index()
    {
        HttpResponseMessage response = await client.GetAsync(ProductApiUrl);
        string strData = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        List<Products> listProducts = JsonSerializer.Deserialize<List<Products>>(strData, options);
        return View(listProducts);
    }

    // GET: ProductController/Details/:id
    public async Task<ActionResult> Details(int id)
    {
        HttpResponseMessage response = await client.GetAsync($"{ProductApiUrl}/{id}");
        if (response.IsSuccessStatusCode)
        {
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            Products product = JsonSerializer.Deserialize<Products>(strData, options);
            return View(product);
        }
        return NotFound();
    }

    // GET: ProductController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: ProductController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(Products product)
    {
        try
        {
            string jsonData = JsonSerializer.Serialize(product);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(ProductApiUrl, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(product);  // Nếu có lỗi, trả lại view để hiển thị thông báo lỗi
            }
        }
        catch
        {
            return View(product);
        }
    }

    // GET: ProductController/Edit/:id
    public async Task<ActionResult> Edit(int id)
    {
        HttpResponseMessage response = await client.GetAsync($"{ProductApiUrl}/{id}");
        if (response.IsSuccessStatusCode)
        {
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            Products product = JsonSerializer.Deserialize<Products>(strData, options);
            return View(product);
        }
        return NotFound();
    }

    // POST: ProductController/Edit/:id
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(int id, Products product)
    {
        try
        {
            string jsonData = JsonSerializer.Serialize(product);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync($"{ProductApiUrl}/{id}", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(product);
            }
        }
        catch
        {
            return View(product);
        }
    }

    // GET: ProductController/Delete/:id
    public async Task<ActionResult> Delete(int id)
    {
        HttpResponseMessage response = await client.GetAsync($"{ProductApiUrl}/{id}");
        if (response.IsSuccessStatusCode)
        {
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            Products product = JsonSerializer.Deserialize<Products>(strData, options);
            return View(product);
        }
        return NotFound();
    }

    // POST: ProductController/Delete/:id
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> DeleteConfirmed(int id)
    {
        try
        {
            HttpResponseMessage response = await client.DeleteAsync($"{ProductApiUrl}/{id}");
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
