//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace databaseCrawlerFinal.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class products
    {
        public int product_id { get; set; }
        public string product_name { get; set; }
        public string product_category { get; set; }
        public decimal product_price { get; set; }
        public string product_sku { get; set; }
        public string short_description { get; set; }
        public string idx_sku { get; set; }
        public string idx_names { get; set; }
        public string idx_sku_three { get; set; }
    }
}
