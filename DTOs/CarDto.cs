namespace AvtoElon.API.Demo.DTOs
{
    public class CarDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string CarBody { get; set; } = string.Empty;
        public string Transmission { get; set; } = string.Empty;
        public int Year { get; set; }
        public string City { get; set; } = string.Empty;
        public string? Definition { get; set; }
        public decimal Mileage { get; set; }
    }
}
