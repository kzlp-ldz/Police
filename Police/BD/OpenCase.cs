//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Police.BD
{
    using System;
    using System.Collections.Generic;
    
    public partial class OpenCase
    {
        public int ID { get; set; }
        public Nullable<int> IdCase { get; set; }
        public Nullable<int> IdEmployee { get; set; }
    
        public virtual Case Case { get; set; }
        public virtual Employee Employee { get; set; }
    }
}