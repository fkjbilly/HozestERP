using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HozestERP.Web
{
    public interface IDetailEditPage
    {

        void BindGrid(int PageIndex, int PageSize);
    }
}