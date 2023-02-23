namespace DenmarkExcursionsAPI.Models.Domain
{
    public class Region
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Area { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public long Population { get; set; }

        // Navigation Properties:
        // Le decimos a Entity Framework la conexion que estos
        // Objetos tienen entre si
        public IEnumerable<Walk> Walks { get; set; } // Le decimos a Entity Framework que una Region puede tener varios Walks en el (One to Many)


    }
}
