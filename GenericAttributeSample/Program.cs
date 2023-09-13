using Newtonsoft.Json;
using System;

var person = new Person { FirstName = "Alice", LastName = "Johnson" };
var product = new Product { Name = "Laptop", Price = 1200.50M };

SerializeToJson(person);
SerializeToJson(product);

Console.ReadLine();

void SerializeToJson(object obj)
{
    var wasSerialized = false;
    var attributes = obj.GetType().GetCustomAttributes(
                       typeof(JsonSerializerAttribute<>), inherit: false);  //Check for attribute in object

    if (attributes.Length == 1)
    {
        var serializerType = attributes[0].GetType().GetGenericArguments()[0];
        var serializer = Activator.CreateInstance(serializerType) as IJsonSerializer;
        if (serializer is not null)
        {
            Console.WriteLine(serializer.Serialize(obj));
            wasSerialized = true;
        }
    }

    if (!wasSerialized)
    {
        Console.WriteLine($"Failed to serialize object of type {obj.GetType().Name}");
    }
}

[JsonSerializer<PersonJsonSerializer>]
public class Person
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}

[JsonSerializer<ProductJsonSerializer>]
public class Product
{
    public string? Name { get; set; }
    public decimal Price { get; set; }
}

public interface IJsonSerializer
{
    string Serialize(object obj);
}

public class PersonJsonSerializer : IJsonSerializer
{
    public string Serialize(object obj)
    {
        var person = (Person)obj;
        return JsonConvert.SerializeObject(new
        {
            type = "Person",
            name = $"{person.FirstName} {person.LastName}"
        });
    }
}

public class ProductJsonSerializer : IJsonSerializer
{
    public string Serialize(object obj)
    {
        var product = (Product)obj;
        return JsonConvert.SerializeObject(new
        {
            type = "Product",
            productName = product.Name,
            price = product.Price
        });
    }
}

[AttributeUsage(AttributeTargets.Class)]
public class JsonSerializerAttribute<T> : Attribute where T : IJsonSerializer { }
