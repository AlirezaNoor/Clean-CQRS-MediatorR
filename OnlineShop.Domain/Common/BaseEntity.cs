namespace OnlineShop.Domain.Common;

public class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreateDate { get; set; }

    public BaseEntity()
    {
        CreateDate = DateTime.Now.ToUniversalTime();
    }
}