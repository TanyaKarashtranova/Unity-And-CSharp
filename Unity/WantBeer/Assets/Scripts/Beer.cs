using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

public class Beer
{
    [JsonProperty(PropertyName = "id")]
    public int Id { get; set; }
    [JsonProperty(PropertyName = "image_url")]
    public string Image { get; set; }
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }
    [JsonProperty(PropertyName = "tagline")]
    public string Tagline { get; set; }
    [JsonProperty(PropertyName = "description")]
    public string Description { get; set; }
    [JsonProperty(PropertyName = "first_brewed")]
    public string FirstBrewed { get; set; }
    [JsonProperty(PropertyName = "abv")]
    private float? _abv;
    public float? Abv 
    {
        get { return _abv.GetValueOrDefault(0f); }
        set { _abv = value; }    
    }
    [JsonProperty(PropertyName = "ibu")]
    private float? _ibu;
    public float? Ibu
    {
        get { return _ibu.GetValueOrDefault(0f); }
        set { _ibu = value; }
    }
    [JsonProperty(PropertyName = "ebc")]
    private float? _ebc;
    public float? Ebc
    {
        get { return _ebc.GetValueOrDefault(0f); }
        set { _ebc = value; }
    }
    [JsonProperty(PropertyName = "ingredients")]
    public Ingredients IngredientsList { get; set; }
    [JsonProperty(PropertyName = "food_pairing")]
    public List<string> Foods { get; set; }
    [JsonProperty(PropertyName = "brewers_tips")]
    public string BrewersTips { get; set; }
    [JsonProperty(PropertyName = "contributed_by")]
    public string ContributedBy { get; set; }
    public List<string> baseInformationList = new List<string>();

 }

public class Ingredients
{
    [JsonProperty(PropertyName = "malt")]
    public List<Malt> Malt { get; set; }
    [JsonProperty(PropertyName = "hops")]
    public List<Hops> Hops { get; set; }
    [JsonProperty(PropertyName = "yeast")]
    public string Yeast { get; set; }
}
public class Malt
{
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }
    [JsonProperty(PropertyName = "amount")]
    public Volume Amount { get; set; }
}

public class Hops
{
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }
    [JsonProperty(PropertyName = "amount")]
    public Volume Amount { get; set; }
}

public class Volume
{
    [JsonProperty(PropertyName = "value")]
    public double Value { get; set; }
    [JsonProperty(PropertyName = "unit")]
    public string Unit { get; set; }
}


