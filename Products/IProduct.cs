using System;
using System.Collections.Generic;

namespace Products
{
    public interface IProduct
    {
        int Id { get; set; }
        string Name { get; set; }
        string Brand { get; set; }
        string BrandGroup { get; set; }
        string Image { get; set; }
        double Price { get; set; }
        double PriceMsrp { get; set; }
        string Category { get; set; }
        string Url { get; set; }
        string Description { get; set; }
        int AverageRating { get; set; }
        int VoteCount { get; set; }

        Dictionary<string,string> ToDictionary(); 

    }
}
