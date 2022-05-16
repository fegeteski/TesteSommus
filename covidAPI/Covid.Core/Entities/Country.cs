using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Country
    {
        [Key]
        public Guid Id { get; set; }
        [Column("Country")]
        public string country { get; set; }
        public string CountryCode { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string CityCode { get; set; }
        public float Lat { get; set; }
        public float Lon { get; set; }
        public int Confirmed { get; set; }
        public int Deaths { get; set; }
        public int Recovered { get; set; }
        public int ActiveCases { get; set; }
        public DateTime Date { get; set; }
    }

}
