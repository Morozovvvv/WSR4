//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Magazin
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.OrderProducts = new HashSet<OrderProduct>();
        }
    
        public string ProductArticleNumber { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductCategory { get; set; }
        public string ProductPhoto { get; set; }
        public int ProductManufacturer { get; set; }
        public decimal ProductCost { get; set; }
        public Nullable<byte> ProductDiscountAmount { get; set; }
        public Nullable<byte> ProductCurrentDiscount { get; set; }
        public int ProductQuantityInStock { get; set; }
        public int ProductStatus { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
        public virtual Status Status { get; set; }
    }
}
