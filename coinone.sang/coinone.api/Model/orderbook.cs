using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coinone.api.Model
{
    public class orderbook : _Model_interface
    {
        private _en_currency _currency = _en_currency.btc ;
        /// <summary>
        /// 
        /// </summary>
        public _en_currency currency 
        {
            get 
            {
                return _currency ;
            }
            set 
            {
                _currency = value; 
            }
        }
 

        public Dictionary<string, string> To_Dictionary()
        {
            Dictionary<string, string> dic_rtn = new Dictionary<string, string>();
            dic_rtn.Add("currency", currency.ToString());

            return dic_rtn;
        }

        public string To_WebData()
        {
            return string.Format("{0}={1}", "currency", currency.ToString());
       }
    }
}
