using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace Form.Models.Domain
{
    public class Employee
    {
        public Guid Id { get; set; }    
        public string EventName { get; set; }
        public string NamaVendor { get; set; }

        public string No_Kontak { get; set; }

        public DateTime Periode { get; set; }

        public string nilai { get; set; }

        public string selesai { get; set; }

    }
}
