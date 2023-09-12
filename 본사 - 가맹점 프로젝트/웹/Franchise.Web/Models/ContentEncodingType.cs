using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Franchise.Web.Models
{
    /// <summary>
    /// 글 내용 인코딩 처리 방식
    /// </summary>
    public enum ContentEncodingType
    {
        /// <summary>
        /// 입력한 그대로
        /// </summary>
        Text,

        /// <summary>
        /// HTML
        /// </summary>
        Html,

        ///<summary>
        ///HTML + 엔터키(\r\n) 적용
        /// </summary>
        Mixed

    }
}
