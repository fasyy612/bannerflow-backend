using System;

namespace BannerflowApi.Models
{
    public class Banner
    {
     public int Id { get; set; }
     public string Html { get; set; }
     public DateTime Created { get; set; }
     public DateTime? Modified { get; set; }
    }
}