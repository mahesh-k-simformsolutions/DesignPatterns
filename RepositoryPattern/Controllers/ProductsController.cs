using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Data;
using RepositoryPattern.Data.Entity;
using RepositoryPattern.Repository;

namespace RepositoryPattern.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductsController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            this._categoryRepository = categoryRepository;
        }

        public async Task<IActionResult> Index()
        {
            var products = _productRepository.GetAll();
            return View(products.ToList());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productRepository.GetById(id.GetValueOrDefault());
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public IActionResult Create()
        {
            ViewData["Category_FK"] = new SelectList(_categoryRepository.GetAll(), "Category_PK", "Category_PK");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Product_PK,ProductName,Description,Image,Price,Discount,Category_FK")] Product product)
        {
            if (ModelState.IsValid)
            {
                _productRepository.Add(product);
                return RedirectToAction(nameof(Index));
            }
            ViewData["Category_FK"] = new SelectList(_categoryRepository.GetAll(), "Category_PK", "Category_PK", product.Category_FK);
            return View(product);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productRepository.GetById(id.GetValueOrDefault());
            if (product == null)
            {
                return NotFound();
            }
            ViewData["Category_FK"] = new SelectList(_categoryRepository.GetAll(), "Category_PK", "Category_PK", product.Category_FK);
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Product_PK,ProductName,Description,Image,Price,Discount,Category_FK")] Product product)
        {
            if (id != product.Product_PK)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _productRepository.Update(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    var productInDb = await _productRepository.GetById(id);
                    if (productInDb == null)
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
            ViewData["Category_FK"] = new SelectList(_categoryRepository.GetAll(), "Category_PK", "Category_PK", product.Category_FK);
            return View(product);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productRepository.GetById(id.GetValueOrDefault());
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _productRepository.GetById(id);
            _productRepository.Remove(product);
            return RedirectToAction(nameof(Index));
        }
    }
}
