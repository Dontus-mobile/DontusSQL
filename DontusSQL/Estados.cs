//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DontusSQL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Estados
    {
        public string SiglaEstado { get; set; }
        public string NomeEstado { get; set; }
        public string NomeCapital { get; set; }
        public int IdRegiao { get; set; }
    
        public virtual Regioes Regioes { get; set; }
    }
}