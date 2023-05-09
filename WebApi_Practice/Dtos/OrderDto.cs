namespace WebApi_Practice.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public int CustomerId { get; set; }

        public int ProductId { get; set; }
    }
}
