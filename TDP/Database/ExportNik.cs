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
    
    public partial class ExportNik
    {
        public int ENId { get; set; }
        public string ENName { get; set; }
        public string ENSize { get; set; }
        public int ENCount { get; set; }
        public double ENPMass { get; set; }
        public double ENKMass { get; set; }
        public double ENKMassBrutto { get; set; }
    
        public virtual Detail Detail { get; set; }
    }
}