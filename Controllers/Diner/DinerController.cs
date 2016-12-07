using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
public class DinerController : Controller
{
    // /api/diner
    [HttpGet]
    public IEnumerable<Meal> Get()
    {
        using (var db = new DinerDbContext())
        {
            return db.Meals.Include(m => m.Ingredients).ToList();
        }
    }

    // /api/diner/{title}
    [Route("{title}")]
    public Meal GetMeal(string title) 
    {
        using (var db = new DinerDbContext()) 
        {
            return db.Meals.Where(meal => meal.Title.Equals(title)).Include(m => m.Ingredients).First();
        }
    }

    [HttpPost]
    public IActionResult Create([FromBody] Meal item)
    {
        if (item == null)
            return BadRequest();

        using (var db = new DinerDbContext()) 
        {
            if (db.Meals.Where(m => m.Title.Equals(item.Title)).Count() > 0)
                return BadRequest($"Gerecht met {item.Title} al toegevoegd");
            db.Meals.Add(item);
            db.SaveChanges();
        }
        return Ok();
    }

    [HttpPut("{title}")]
    public IActionResult Update(string title, [FromBody] Meal item) 
    {
        if (item == null || title == null)
            return BadRequest();
        
        using (var db = new DinerDbContext())
        {
            var meal = db.Meals.FirstOrDefault(m => m.Title.Equals(title));
            if (meal == null)
                return BadRequest();
            
            var meal2 = db.Meals.FirstOrDefault(m => m.Title.Equals(item.Title));
            if (meal2 != null && !title.Equals(item.Title))
                return BadRequest("Mag geen twee dezelfde gerechten toevoegen");
            
            meal.Chef = item.Chef;
            meal.Title = item.Title;
            meal.ExtraInfo = item.ExtraInfo;
            
            db.SaveChanges();
        }
        
        return Ok();
    }
}