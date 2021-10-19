using System;

namespace Models
{
    public class MovingMaterials
    {
        public int Id { get; set; }
        
        public string DocumentId { get; set; }
        
        public int MaterialId { get; set; }
        
        public decimal Price { get; set; }
        
        public string SupplierName { get; set; }
        
        public DateTime TransDate { get; set; }
    }
}