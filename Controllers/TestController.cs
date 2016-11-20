using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
public class TestController : Controller
{
    private static IEnumerable<TestClass> data = new List<TestClass>
    {
        new TestClass{
            Id = 0,
            Value = "TestValue1"
        },
        new TestClass{
            Id = 1,
            Value = "TestValue2"
        },
    };

    // /api/test
    [HttpGet]
    public IEnumerable<TestClass> Get()
    {
        return data;
    }

    // /api/test/1
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var product = data.FirstOrDefault((p) => p.Id == id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }
}

public class TestClass {
    public int Id {get;set;}
    public string Value {get;set;}
}