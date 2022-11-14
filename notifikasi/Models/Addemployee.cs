using System.ComponentModel.DataAnnotations.Schema;

namespace Form.Models
{
    public class Addemployee
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
