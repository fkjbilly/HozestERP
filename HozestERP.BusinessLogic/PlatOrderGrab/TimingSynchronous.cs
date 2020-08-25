using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HozestERP.BusinessLogic.Data;
using HozestERP.BusinessLogic.Caching;
using JdSdk;
using Newtonsoft.Json;
using System.Net;
using Top.Api.Domain;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ErrorLog;
using HozestERP.BusinessLogic.CustomerManagement;
using JdSdk.Domain;
using Top.Api;
using Top.Api.Request;
using Top.Api.Response;
using JdSdk.Request;
using JdSdk.Response;
using JdSdk.Domains;
using HozestERP.Common;
using System.Runtime.Caching;
using Newtonsoft.Json.Linq;
using HozestERP.BusinessLogic.ManageProject;

namespace HozestERP.BusinessLogic.PlatOrderGrab
{
    public class TimingSynchronous : ITimingSynchronous
    {
        /// <summary>
        /// 定时同步各平台订单信息
        /// </summary>
        public void TimingGetOrderInfo()
        {
            //同步数据
            var query = from p in this._context.XMOrderInfoApps
                        where p.IsEnabled == false
                        select p;
            foreach (XMOrderInfoApp xm in query.ToList())
            {
                //京东
                if (xm.PlatformTypeId == 251 || xm.PlatformTypeId == 382)
                {
                    try
                    {
                        this.SynchronousJDOrderData(startdate, enddate, "", ref InsertCount, ref UpdateCount, xm);
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }
                //天猫
                else if (xm.PlatformTypeId == 250 || xm.PlatformTypeId == 381)
                {
                    try
                    {
                        //this.SynchronousTMOrderData(startdate, enddate, "", ref InsertCount, ref UpdateCount, xm);
                        this.SynchronousTMTradesSoldIncrementGetList(startdate, enddate, "", ref InsertCount, ref UpdateCount, xm);
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }
                //一号店
                else if (xm.PlatformTypeId == 375)
                {
                    try
                    {
                        //this.SynchronousYHDOrderData(startdate, enddate, ref InsertCount, ref UpdateCount, xm);
                        this.SynchronousYHDTradesSoldIncrementData(startdate, enddate, ref InsertCount, ref UpdateCount, xm);
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }
                //苏宁易购
                else if (xm.PlatformTypeId == 383)
                {
                    try
                    {
                        this.SynchronousSuningOrderData(startdate, enddate, ref InsertCount, ref UpdateCount, xm);
                        // this.SynchronousSuningOrdData(startdate, enddate, ref InsertCount, ref UpdateCount, xm);
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }
                //唯品会
                else if (xm.PlatformTypeId == 259)
                {
                    try
                    {
                        this.SynchronousVPHOrderData(startdate, enddate, ref InsertCount, ref UpdateCount, xm);
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }

                }
            }
        }
    }
}
