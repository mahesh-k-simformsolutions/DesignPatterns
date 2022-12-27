using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Data.Entity;
using RepositoryPattern.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPattern.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Category> categories = _categoryRepository.GetAll();
            return View(categories.ToList());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category product = await _categoryRepository.GetById(id.GetValueOrDefault());
            return product == null ? NotFound() : View(product);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Category_PK,Name,Description")] Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.Add(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category category = await _categoryRepository.GetById(id.GetValueOrDefault());
            return category == null ? NotFound() : View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Category_PK,Name,Description")] Category category)
        {
            if (id != category.Category_PK)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _categoryRepository.Update(category);
                }
                catch (DbUpdateConcurrencyException)
                {
                    Category categoryInDb = await _categoryRepository.GetById(id);
                    if (categoryInDb == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category category = await _categoryRepository.GetById(id.GetValueOrDefault());
            return category == null ? NotFound() : View(category);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Category category = await _categoryRepository.GetById(id);
            _categoryRepository.Remove(category);
            return RedirectToAction(nameof(Index));
        }
    }
}
