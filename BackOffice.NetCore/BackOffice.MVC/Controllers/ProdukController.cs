using BackOffice.MVC.Models;
using BackOffice.MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackOffice.MVC.Controllers;

public class ProdukController : Controller
{
    private readonly IApiClient _apiClient;

    public ProdukController(IApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<IActionResult> Index()
    {
        if (string.IsNullOrEmpty(_apiClient.GetAuthToken()))
            return RedirectToAction("Login", "Account");

        var produk = await _apiClient.GetAsync<List<Produk>>("api/produk");
        return View(produk ?? new List<Produk>());
    }

    public IActionResult Create()
    {
        if (string.IsNullOrEmpty(_apiClient.GetAuthToken()))
            return RedirectToAction("Login", "Account");

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Produk produk)
    {
        if (!ModelState.IsValid)
            return View(produk);

        var result = await _apiClient.PostAsync<Produk>("api/produk", produk);
        if (result != null)
            return RedirectToAction(nameof(Index));

        ModelState.AddModelError("", "Failed to create product");
        return View(produk);
    }

    public async Task<IActionResult> Edit(string id)
    {
        if (string.IsNullOrEmpty(_apiClient.GetAuthToken()))
            return RedirectToAction("Login", "Account");

        var produk = await _apiClient.GetAsync<Produk>($"api/produk/{id}");
        if (produk == null)
            return NotFound();

        return View(produk);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(string id, Produk produk)
    {
        if (!ModelState.IsValid)
            return View(produk);

        var result = await _apiClient.PutAsync<object>($"api/produk/{id}", produk);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Delete(string id)
    {
        var result = await _apiClient.DeleteAsync($"api/produk/{id}");
        return RedirectToAction(nameof(Index));
    }
}

// Made with Bob
