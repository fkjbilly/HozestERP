using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace HozestERP.Web
{
    /// <summary>
    /// ISearchPage 的摘要说明
    /// </summary>
    public interface ISearchPage
    {
        /// <summary>
        /// 页面事件加载
        /// </summary>
        void SetTrigger();

        /// <summary>
        /// 页面初始化
        /// </summary>
        void Face_Init();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramPageIndex"></param>
        /// <param name="paramPageSize"></param>
        void BindGrid(int paramPageIndex, int paramPageSize);

    }
}
