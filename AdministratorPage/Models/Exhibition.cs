//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdministratorPage.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Exhibition
    {
        public int id { get; set; }
        public string author { get; set; }
        public string description { get; set; }
        public string showimage { get; set; }
        public string coverimage { get; set; }
        public Nullable<int> typeid { get; set; }
        public string resourceaddress { get; set; }
        public string name { get; set; }
    }
}