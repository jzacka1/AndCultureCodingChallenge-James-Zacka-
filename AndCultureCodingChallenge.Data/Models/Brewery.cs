using System;
using System.Collections.Generic;

namespace AndCultureCodingChallenge.Data.Models
{
    public partial class Brewery
    {
        public string ObdbId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string BreweryType { get; set; } = null!;
        public string? Street { get; set; }
        public string? Address2 { get; set; }
        public string? Address3 { get; set; }
        public string City { get; set; } = null!;
        public string? State { get; set; }
        public string? CountyProvince { get; set; }
        public string PostalCode { get; set; } = null!;
        public string? WebsiteUrl { get; set; }
        public string? Phone { get; set; }
        public string Country { get; set; } = null!;
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
        public string? Tags { get; set; }
    }
}
