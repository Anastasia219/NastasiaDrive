//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp1.datas
{
    using System;
    using System.Collections.Generic;
    
    public partial class toy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public toy()
        {
            this.ToyOrder = new HashSet<ToyOrder>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] MainImage { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<int> TypeId { get; set; }
        public Nullable<bool> IsDelete { get; set; }
    
        public virtual Type Type { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ToyOrder> ToyOrder { get; set; }
    }
}
