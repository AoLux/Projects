using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CarServices.Models
{
    public class CarModel
    {

        [DisplayName("Šifra auta")]
        public int id_car { get; set; }


        [DisplayName("Naziv auta")]
        public string Car_name { get; set; }

    }
}