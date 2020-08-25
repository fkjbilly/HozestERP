using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HozestERP.BusinessLogic.ManageProtal
{
    public class UnSetMinPriceProduct
    {
        public int Id { get; set; }

        public string ManufacturersCode { get; set; }

        public string ProductName { get; set; }

        public int? BrandTypeId { get; set; }

        public string BrandTypeCodeName
        {
            get
            {
                string result = "";
                if (this.BrandTypeId != null)
                {
                    var list = IoC.Resolve<ICodeService>().GetCodeListInfoByCodeID(this.BrandTypeId.Value);
                    if (list != null)
                    {
                        result = list.CodeName;
                    }
                }
                return result;
            }
        }
    }
}
