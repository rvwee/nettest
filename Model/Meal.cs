using System.Collections.Generic;

public class Meal 
{
    public int Id {get;set;}
    public string Title {get;set;}
    public string Chef {get;set;}
    public string ExtraInfo {get;set;}
    public List<Ingredient> Ingredients { get; set; }
}