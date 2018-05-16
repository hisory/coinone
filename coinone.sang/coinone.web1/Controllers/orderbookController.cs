using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using coinone.api.Model_Success;
using coinone.api.Api;
namespace coinone.web1.Controllers
{
    public class orderbookController : Controller
    {
        // GET: /orderbook/

        public ActionResult Index()
        {
            orderbook ob = new orderbook();
            Dictionary<string, orderbook_Result> dic_obResult = ob.orderbook_all_currency();
            
            if (dic_obResult.Count > 0 ){
                ViewBag.ErrorInfo = "";
            }
            else{
                ViewBag.ErrorInfo = "화폐 거래 내역을 가져오는데 오류가 발생했습니다.";
            }
            ViewBag.dic_obResult = dic_obResult;
            

            return View();
        }


    }
}
