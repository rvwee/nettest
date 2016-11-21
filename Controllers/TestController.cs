using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
public class TestController : Controller
{
    private static IEnumerable<Test> data = new List<Test>
    {
        new Test{
            Id = 0,
            Key = "key1",
            Value = "TestValue1",
            Description = "This is some description"
        },
        new Test{
            Id = 1,
            Key = "key2",
            Value = "TestValue2",
            Description = "This is some other description"
        },
    };

    // /api/test
    [HttpGet]
    public IEnumerable<Test> Get()
    {
        return GetDataMultiplied(data, 6);
    }

    private static IEnumerable<Test> GetDataMultiplied(IEnumerable<Test> dataToMultiply, int multiplication) 
    {
        IEnumerable<Test> result = dataToMultiply;
        for (var i = 0; i <= multiplication; i++) 
        {
            result = result.Concat(result);
        }

        return result;
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

public class Test {
    public int Id {get;set;}
    public string Key {get;set;}
    public string Value {get;set;}
    public string Description {get;set;}
}