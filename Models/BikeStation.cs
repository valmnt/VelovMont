﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VeloVMONT.Models
{
    public class BikeStation
    {
        public BikeStation()
        {

        }

        public BikeStation(BikeStationBordeaux bikestationBordeaux)
        {
            this.gid = bikestationBordeaux.id.ToString();
            this.available_bikes = bikestationBordeaux.bike_count_total.ToString();
            this.lng = bikestationBordeaux.longitude;
            this.lat = bikestationBordeaux.latitude;
            this.available_bike_stands = bikestationBordeaux.slot_count.ToString();
            this.name = bikestationBordeaux.name;

        }

        public string number { get; set; }
        public string pole { get; set; }
        public string available_bikes { get; set; }
        public string code_insee { get; set; }
        public string lng { get; set; }
        public string availability { get; set; }
        public string availabilitycode { get; set; }
        public string etat { get; set; }
        public string startdate { get; set; }
        public string langue { get; set; }
        public string bike_stands { get; set; }
        public string last_update { get; set; }
        public string available_bike_stands { get; set; }
        public string gid { get; set; }
        public string titre { get; set; }
        public string status { get; set; }
        public string commune { get; set; }
        public string description { get; set; }
        public string nature { get; set; }
        public string bonus { get; set; }
        public string address2 { get; set; }
        public string address { get; set; }
        public string lat { get; set; }
        public string last_update_fme { get; set; }
        public string enddate { get; set; }
        public string name { get; set; }
        public string banking { get; set; }
        public string nmarrond { get; set; }
    }
}
