using OnlineShop.Application.Dto.Common;

namespace OnlineShop.Application.Dto.Catgory;

public class UpdateCategoryDto:BaseDto
{
    public string Name { get; set; }
    public string Des { get; set; }
}