using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using Newtonsoft.Json;
namespace coinone.api.Model_Success
{
    public class orderbook_Result : _base_Success
    {


        public double timestamp = 0;

        public DateTime timeinfo
        {
            get 
            {
                System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                dtDateTime = dtDateTime.AddSeconds(timestamp).ToLocalTime();
                return dtDateTime;            
            }
        
        }
        
        
        public _en_currency currency ;
  
        public List<_price> bid ;
        public decimal bid_qty_sum
        {
            get
            {
                return bid.Sum(item => item.qty);
            }
        }
        public decimal bid_price_sum
        {
            get
            {
                return bid.Sum(item => item.price);
            }
        }
        public decimal bid_price_avg
        {
            get
            {
                if (bid_qty_sum == 0 || bid_price_sum == 0)
                { return 0; }


                return bid_price_sum / bid_qty_sum ;
            }
        }

 
        public List<_price> ask ;
        public decimal ask_qty_sum
        {
            get
            {
                return ask.Sum(item => item.qty);
            }
        }
        public decimal ask_price_sum
        {
            get
            {
                return ask.Sum(item => item.price);
            }
        }
        public decimal ask_price_avg
        {
            get
            {
                if (ask_qty_sum == 0 || ask_price_sum == 0)
                { return 0; }


                return ask_price_sum / ask_qty_sum;
            }
        }

 
  
    }
}
