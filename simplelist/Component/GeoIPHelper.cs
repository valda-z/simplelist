using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace simplelist.Component
{
    public class GeoIPHelper
    {
        public class Names
        {
            public string en { get; set; }
            public string ru { get; set; }
        }

        public class City
        {
            public int GeoNameID { get; set; }
            public Names Names { get; set; }
        }

        public class Names2
        {
            public string fr { get; set; }
            public string ja { get; set; }
            public string __invalid_name__pt_BR { get; set; }
            public string ru { get; set; }
            public string __invalid_name__zh_CN { get; set; }
            public string de { get; set; }
            public string en { get; set; }
            public string es { get; set; }
        }

        public class Continent
        {
            public string Code { get; set; }
            public int GeoNameID { get; set; }
            public Names2 Names { get; set; }
        }

        public class Names3
        {
            public string ru { get; set; }
            public string __invalid_name__zh_CN { get; set; }
            public string de { get; set; }
            public string en { get; set; }
            public string es { get; set; }
            public string fr { get; set; }
            public string ja { get; set; }
            public string __invalid_name__pt_BR { get; set; }
        }

        public class Country
        {
            public int GeoNameID { get; set; }
            public string IsoCode { get; set; }
            public Names3 Names { get; set; }
        }

        public class Location
        {
            public double Latitude { get; set; }
            public double Longitude { get; set; }
            public int MetroCode { get; set; }
            public string TimeZone { get; set; }
        }

        public class Postal
        {
            public string Code { get; set; }
        }

        public class Names4
        {
            public string ja { get; set; }
            public string __invalid_name__pt_BR { get; set; }
            public string ru { get; set; }
            public string __invalid_name__zh_CN { get; set; }
            public string de { get; set; }
            public string en { get; set; }
            public string es { get; set; }
            public string fr { get; set; }
        }

        public class RegisteredCountry
        {
            public int GeoNameID { get; set; }
            public string IsoCode { get; set; }
            public Names4 Names { get; set; }
        }

        public class RepresentedCountry
        {
            public int GeoNameID { get; set; }
            public string IsoCode { get; set; }
            public object Names { get; set; }
            public string Type { get; set; }
        }

        public class Names5
        {
            public string de { get; set; }
            public string en { get; set; }
            public string fr { get; set; }
        }

        public class Subdivision
        {
            public int GeoNameID { get; set; }
            public string IsoCode { get; set; }
            public Names5 Names { get; set; }
        }

        public class Traits
        {
            public bool IsAnonymousProxy { get; set; }
            public bool IsSatelliteProvider { get; set; }
        }

        public class Data
        {
            public City City { get; set; }
            public Continent Continent { get; set; }
            public Country Country { get; set; }
            public Location Location { get; set; }
            public Postal Postal { get; set; }
            public RegisteredCountry RegisteredCountry { get; set; }
            public RepresentedCountry RepresentedCountry { get; set; }
            public List<Subdivision> Subdivisions { get; set; }
            public Traits Traits { get; set; }
        }

        public class RootObject
        {
            public Data Data { get; set; }
        }
    }
}