//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Marikina.Data_Access
{
    using System;
    using System.Collections.Generic;
    
    public partial class @event
    {
        public int event_id { get; set; }
        public string event_name { get; set; }
        public string event_desc { get; set; }
        public Nullable<System.DateTime> event_expiration_datetime { get; set; }
        public string event_image_name { get; set; }
        public byte[] event_image { get; set; }
        public Nullable<int> event_image_size { get; set; }
        public string event_status { get; set; }
        public string event_location { get; set; }
    }
}
