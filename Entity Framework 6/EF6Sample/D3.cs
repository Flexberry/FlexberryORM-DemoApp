
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace EF6Sample
{

using System;
    using System.Collections.Generic;
    
public partial class D3
{

    public D3()
    {

        this.D31 = new HashSet<D31>();

        this.D32 = new HashSet<D32>();

        this.D33 = new HashSet<D33>();

    }


    public System.Guid primaryKey { get; set; }

    public string Name { get; set; }

    public System.Guid D0 { get; set; }

    public string S1 { get; set; }

    public string S2 { get; set; }

    public string S3 { get; set; }

    public string S4 { get; set; }

    public string S5 { get; set; }



    public virtual D0 D01 { get; set; }

    public virtual ICollection<D31> D31 { get; set; }

    public virtual ICollection<D32> D32 { get; set; }

    public virtual ICollection<D33> D33 { get; set; }

}

}
