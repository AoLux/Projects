using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CarServices.Models
{
    public class ServiceModel
    {
        [DisplayName("Naziv auta")]
        public string Car_name { get; set; }

        [DisplayName("Šifra servisa")]
#pragma warning disable IDE1006 // Naming Styles
        public int id_service { get; set; }
#pragma warning restore IDE1006 // Naming Styles

        [DisplayName("Vrsta servisa")]
        public  string Service_name { get; set; }

        [DisplayName("Prioritet")]
        public int Priority { get; set; }

        [DisplayName("Opis")]
        public string Description { get; set; }


        public string Status { get; set; }

        [DisplayName("Datum servisa")]
        public DateTime Service_date { get; set; }
        public int id_car { get; set; }


    }
}