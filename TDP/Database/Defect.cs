//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TDP.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class Defect
    {
        public int DFId { get; set; }
        public System.DateTime DFDate { get; set; }
        public string DFName { get; set; }
        public string DFTName { get; set; }
        public string DFPlace { get; set; }
        public string DFSize { get; set; }
        public int DFCount { get; set; }
    
        public virtual DefectType DefectType { get; set; }
        public virtual Detail Detail { get; set; }
    }
}
