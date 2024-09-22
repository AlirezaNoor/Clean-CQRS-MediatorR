using System.ComponentModel.DataAnnotations;
using OnlineShop.Domain.Common;

namespace OnlineShop.Domain.Entities.Categories;

public class Category:BaseEntity
{
      
    public string Name { get; set; }
    public string Des { get; set; }
}