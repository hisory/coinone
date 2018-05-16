using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coinone.api.Model
{
    public interface _Model_interface
    {

        /// <summary>
        /// 클래스 내용을 Dictionary 형태로 Return
        /// </summary>
        /// <returns></returns>
        Dictionary<string, string> To_Dictionary();


        /// <summary>
        /// 클래스 내용을 key=value&key=value 형태로 Return
        /// </summary>
        /// <returns></returns>
        string To_WebData();
    }
}
