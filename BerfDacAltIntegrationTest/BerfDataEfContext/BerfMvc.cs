//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BerfDacAltIntegrationTest.BerfDataEfContext
{
    using System;
    using System.Collections.Generic;
    
    public partial class BerfMvc
    {
        public System.Guid id { get; set; }
        public System.Guid renderId { get; set; }
        public System.Guid sessionId { get; set; }
        public string action { get; set; }
        public string controller { get; set; }
        public string area { get; set; }
        public System.DateTime actionStart { get; set; }
        public System.DateTime actionEnd { get; set; }
        public System.DateTime resultStart { get; set; }
        public System.DateTime resultEnd { get; set; }
        public double actionDuration { get; set; }
        public double resultDuration { get; set; }
        public System.DateTime created { get; set; }
        public string clientIP { get; set; }
        public string userName { get; set; }
        public string userAgent { get; set; }
        public string browser { get; set; }
        public string browserVersion { get; set; }
        public string hostMachineName { get; set; }
        public string headers { get; set; }
    }
}
