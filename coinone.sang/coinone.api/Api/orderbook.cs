using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using coinone.api.Model_Success;
using Newtonsoft.Json;
namespace coinone.api.Api
{
    public class orderbook : coinone.api.Api._Base 
    {

        /// <summary>
        /// 거래되는 모든 화폐 최근 거래 내역을 가져온다.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, orderbook_Result> orderbook_all_currency()
        {

            Dictionary<string, orderbook_Result>  dic_obResult = new Dictionary<string, orderbook_Result>();
            foreach (var item in Enum.GetValues(typeof(api._en_currency)))
            {
               string sRtn = this.Get_Sync_Api(url: "/orderbook/"
                                , data: "currency=" + item.ToString()
                                , method: api.Api._Base.web_method.GET);

               orderbook_Result obResult = new orderbook_Result();


               if (!IsJsonValidation(sRtn))
               {
                    continue;
               }
                
               obResult = JsonConvert.DeserializeObject<orderbook_Result>(sRtn);

                //System.Threading.Thread.Sleep(1000);
               if (obResult != null && obResult.result.Equals("success") && obResult.currency.ToString() == item.ToString())
               {
                   dic_obResult.Add(item.ToString(), obResult);
               }
            }


            return dic_obResult;
        }
    }
}
