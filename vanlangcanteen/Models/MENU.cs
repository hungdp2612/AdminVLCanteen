//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace vanlangcanteen.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MENU
    {
        public MENU()
        {
            this.ORDER_DETAIL = new HashSet<ORDER_DETAIL>();
        }
    
        public int ID { get; set; }
        public int FOOD_ID { get; set; }
        public int ACCOUNT_ID { get; set; }
        public System.DateTime DATE { get; set; }
        public int QUANTITY { get; set; }
        public int PRICE { get; set; }
        public bool STATUS { get; set; }
    
        public virtual ACCOUNT ACCOUNT { get; set; }
        public virtual FOOD FOOD { get; set; }
        public virtual ICollection<ORDER_DETAIL> ORDER_DETAIL { get; set; }
    }
}
