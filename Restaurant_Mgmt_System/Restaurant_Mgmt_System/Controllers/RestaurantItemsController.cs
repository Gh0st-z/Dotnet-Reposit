using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

public class RestaurantItemsController : Controller
{
    private readonly RestaurantContext _context;

    public RestaurantItemsController(RestaurantContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var restaurantItems = _context.RestaurantItems.ToList();
        return View(restaurantItems);
    }

    [HttpPost]
    public IActionResult CreateItem(RestaurantItem restaurantItem, IFormFile itemImage)
    {
        if (ModelState.IsValid)
        {
            // Check if an image file was uploaded
            if (itemImage != null && itemImage.Length > 0)
            {
                // Generate a unique filename for the image
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(itemImage.FileName);

                // Specify the path to store the image file
                var imagePath = Path.Combine("wwwroot", "images", fileName);

                // Save the image file to the server
                using (var fileStream = new FileStream(imagePath, FileMode.Create))
                {
                    itemImage.CopyTo(fileStream);
                }

                // Store the file path in the ItemImage property
                restaurantItem.ItemImage = "/images/" + fileName;
            }

            restaurantItem.CreatedDate = DateTime.Now;
            _context.Add(restaurantItem);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        return View(restaurantItem);
    }

    public IActionResult Edit(int id)
    {
        var restaurantItem = _context.RestaurantItems.FirstOrDefault(item => item.ItemId == id);
        if (restaurantItem == null)
        {
            return NotFound();
        }
        return View(restaurantItem);
    }

    [HttpPost]
    public IActionResult Edit(int id, RestaurantItem restaurantItem)
    {
        if (id != restaurantItem.ItemId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(restaurantItem);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantItemExists(restaurantItem.ItemId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("Index");
        }
        return View(restaurantItem);
    }

    public IActionResult Details(int id)
    {
        var restaurantItem = _context.RestaurantItems.FirstOrDefault(item => item.ItemId == id);
        if (restaurantItem == null)
        {
            return NotFound();
        }
        return View(restaurantItem);
    }

    public IActionResult Delete(int id)
    {
        var restaurantItem = _context.RestaurantItems.FirstOrDefault(item => item.ItemId == id);
        if (restaurantItem == null)
        {
            return NotFound();
        }
        return View(restaurantItem);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var restaurantItem = _context.RestaurantItems.Find(id);
        _context.RestaurantItems.Remove(restaurantItem);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    private bool RestaurantItemExists(int id)
    {
        return _context.RestaurantItems.Any(item => item.ItemId == id);
    }
}
