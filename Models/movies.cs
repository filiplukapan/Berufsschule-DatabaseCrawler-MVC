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
    
    public partial class movies
    {
        public int movie_id { get; set; }
        public string movie_title { get; set; }
        public string director { get; set; }
        public int year { get; set; }
        public Nullable<int> genre_id { get; set; }
    }
}
