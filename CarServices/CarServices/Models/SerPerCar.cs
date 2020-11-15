using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CarServices.Models
{
    public class SerPerCar
    {
        [DisplayName("Šifra auta")]
        public int id_car { get; set; }


        [DisplayName("Naziv auta")]
        public string Car_name { get; set; }

        [DisplayName("Šifra servisa")]
        public int id_service { get; set; }


        [DisplayName("Vrsta servisa")]
        public string Service_name { get; set; }

        [DisplayName("Prioritet")]
        public int Priority { get; set; }

        [DisplayName("Opis")]
        public string Description { get; set; }

        public string Status { get; set; }

        [DisplayName("Datum servisa")]
        public DateTime Service_date { get; set; }

    }
}