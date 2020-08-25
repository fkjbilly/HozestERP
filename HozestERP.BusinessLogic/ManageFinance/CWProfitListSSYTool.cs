
/******************************************************************
** Copyright (c) 2005 -2015 XXXXX科技有限公司软件研发部
** 创建人:樊开健
** 创建日期:2015-06-02 15:24:28
** 修改人:
** 修改日期:
** 描 述: 
 *          
** 版 本:1.0
**----------------------------------------------------------------------------
******************************************************************/
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using HozestERP.BusinessLogic.Codes;
using HozestERP.BusinessLogic.Infrastructure;
using HozestERP.BusinessLogic.ManageBusiness;
using HozestERP.BusinessLogic.ManageProject;
using HozestERP.BusinessLogic.ManageInventory;

namespace HozestERP.BusinessLogic.ManageFinance
{
    public class CWProfitListSSYTool : BaseEntity
    {
        public CWProfitModel GetAuxiliaryParameters(CWProfitModel model, int ProjectId, int NickId, string year, string month)
        {
            model.ReturnMoney = GetProfitValue(114, ProjectId, NickId, year, month, -1);
            model.ReturnCost = GetProfitValue(115, ProjectId, NickId, year, month, -1);
            return model;
        }

        public decimal GetProfitValue(int FinancialFieldId, int ProjectId, int NickId, string Year, string Month, int Department)
        {
            decimal value = 0;
            var cwProfitList = IoC.Resolve<ICWProfitService>().GetCWProfitListByData(FinancialFieldId, ProjectId, NickId, Department, Year, Month);
            if (cwProfitList != null && cwProfitList.Count > 0)
            {
                value = (decimal)cwProfitList.Sum(x => x.CountMoney);
            }
            return value;
        }

        public CWProfitModel GetValue(CWProfitModel model, string year, string month, int FinancialFieldID, int ProjectId, int NickId, List<CWStaffSpending> CWStaffSpendingList, string cbNickId, string cbProjectTypeId)
        {
            decimal value = 0;
            if (CWStaffSpendingList != null)
            {
                var a = CWStaffSpendingList.Where(x => x.FinancialFieldId == FinancialFieldID);
                if (a.Count() > 0)
                {
                    value = (decimal)(a.ToList())[0].CountMoney;
                }
            }

            //营业收入
            if (FinancialFieldID == 64)
            {
                model.BusinessIncome = value;
                if (value != 0)
                {
                    return model;
                }
                model.BusinessIncome = GetProfitValue(FinancialFieldID, ProjectId, NickId, year, month, -1);
                value = model.BusinessIncome;
            }

            //进货成本
            if (FinancialFieldID == 78)
            {
                model.PurchaseCost = value;
                if (value != 0)
                {
                    return model;
                }
                model.PurchaseCost = GetProfitValue(FinancialFieldID, ProjectId, NickId, year, month, -1);
                value = model.PurchaseCost;
            }

            //赠品成本
            if (FinancialFieldID == 79)
            {
                model.PremiumsCost = value;
                if (value != 0)
                {
                    return model;
                }
                model.PremiumsCost = GetProfitValue(FinancialFieldID, ProjectId, NickId, year, month, -1);
                value = model.PremiumsCost;
            }

            //广告费用
            if (FinancialFieldID == 148)//86
            {
                model.AdvertisementFEE = value;
                if (value != 0)
                {
                    return model;
                }
                model.AdvertisementFEE = GetProfitValue(FinancialFieldID, ProjectId, NickId, year, month, -1);
                value = model.AdvertisementFEE;
            }
            //平台费用
            if (FinancialFieldID == 107)
            {
                model.PlatformFee = value;
                if (value != 0)
                {
                    return model;
                }
                model.PlatformFee = GetProfitValue(FinancialFieldID, ProjectId, NickId, year, month, -1);
                value = model.PlatformFee;
            }
            //刷拍成本
            if (FinancialFieldID == 109)
            {
                model.TakeBrush = value;
                if (value != 0)
                {
                    return model;
                }
                model.TakeBrush = GetProfitValue(FinancialFieldID, ProjectId, NickId, year, month, -1);
                value = model.TakeBrush;
            }
            //返现成本
            if (FinancialFieldID == 110)
            {
                model.Cashback = value;
                if (value != 0)
                {
                    return model;
                }
                model.Cashback = GetProfitValue(FinancialFieldID, ProjectId, NickId, year, month, -1);
                value = model.Cashback;
            }
            //运费
            if (FinancialFieldID == 108)
            {
                if (ProjectId == -1)
                {
                    model.Freight = 0;
                }
                else
                {
                    List<int> IDs = new List<int>();
                    IDs.Add(108);
                    decimal Freight = (decimal)GetAllResult(IDs, year, month, ProjectId, -1, -1).Sum(x => x.CountMoney);
                    if (Freight == 0)
                    {
                        //根据店铺项目 查询运费比例 
                        var xmproject = IoC.Resolve<IXMProjectService>().GetXMProjectById(ProjectId);
                        if (xmproject != null)
                        {
                            if (xmproject.ShipmentProportion != null)
                            {
                                decimal ShipmentProportion = xmproject.ShipmentProportion.Value / 100;
                                model.Freight = Math.Round((model.BusinessIncome - model.ReturnMoney) * ShipmentProportion, 2);
                            }
                        }
                    }
                    else if (cbNickId != "-1")
                    {
                        IDs.Clear();
                        IDs.Add(64);//收入
                        List<int> nickIdList = new List<int>();

                        #region 获取店铺
                        List<int> nicklist = new List<int>();
                        var nickList = IoC.Resolve<IXMNickService>().GetXMNickListByProjectId(ProjectId, Convert.ToInt32(cbProjectTypeId));
                        if (nickList.Count > 0)
                        {
                            nicklist = nickList.Select(p => p.nick_id).ToList();
                            nickIdList = nicklist;
                        }
                        #endregion

                        decimal BusinessIncomeTotal = 0;
                        foreach (int id in nickIdList)
                        {
                            decimal BusinessIncome = (decimal)GetAllResult(IDs, year, month, ProjectId, -1, id).Sum(x => x.CountMoney);
                            if (BusinessIncome == 0)
                            {
                                BusinessIncome = GetProfitValue(64, ProjectId, id, year, month, -1);
                            }
                            BusinessIncomeTotal += BusinessIncome;
                        }
                        if (BusinessIncomeTotal != 0)
                        {
                            model.Freight = Math.Round(Freight * model.BusinessIncome / BusinessIncomeTotal, 2);
                        }
                        else
                        {
                            model.Freight = 0;
                        }
                    }
                    else
                    {
                        model.Freight = Freight;
                    }
                }
            }
            //运营部门人员工资
            if (FinancialFieldID == 89)
            {
                model.CountMoneySum1 = value;
                if (value != 0)
                {
                    return model;
                }
            }
            //运营部门人员社保
            if (FinancialFieldID == 90)
            {
                model.CountMoneySum2 = value;
                if (value != 0)
                {
                    return model;
                }
            }
            //运营部门人员奖金
            if (FinancialFieldID == 91)
            {
                model.CountMoneySum3 = value;
                if (value != 0)
                {
                    return model;
                }
            }
            //运营部门销售奖金
            if (FinancialFieldID == 111)
            {
                model.CountMoneySum4 = value;
                if (value != 0)
                {
                    return model;
                }
            }
            //差旅费
            if (FinancialFieldID == 98)
            {
                model.CountMoneySum5 = value;
                if (value != 0)
                {
                    return model;
                }
            }
            //办公费用
            if (FinancialFieldID == 101)
            {
                model.CountMoneySum6 = value;
                if (value != 0)
                {
                    return model;
                }
            }
            //其他费用
            if (FinancialFieldID == 100)
            {
                model.CountMoneySum7 = value;
                if (value != 0)
                {
                    return model;
                }
            }
            //固定资产折旧
            if (FinancialFieldID == 112)
            {
                model.CountMoneySum8 = value;
                if (value != 0)
                {
                    return model;
                }
            }
            //摊销费用
            if (FinancialFieldID == 113)
            {
                model.CountMoneySum9 = value;
                if (value != 0)
                {
                    return model;
                }
            }
            //广告费补贴
            if (FinancialFieldID == 71)
            {
                model.CountMoneySum10 = value;
                if (value != 0)
                {
                    return model;
                }
            }
            //增值税
            if (FinancialFieldID == 67)
            {
                model.ZZSMoney = value;
                if (value != 0)
                {
                    return model;
                }
                else
                {
                    model.ZZSMoney = Math.Round((model.BusinessIncome - model.ReturnMoney - (model.PurchaseCost - model.ReturnCost)) / (decimal)1.17 * (decimal)0.17 - model.Freight / (decimal)1.06 * (decimal)0.06, 2);
                    value = model.ZZSMoney;
                    return model;
                }
            }
            //营业成本=进货成本+赠品成本+平台成本费用+运费+刷拍成本+返现成本+广告费
            if (FinancialFieldID == 66)
            {
                model.YYCBMoney = value;
                if (value != 0)
                {
                    return model;
                }
                else
                {
                    model.YYCBMoney = Convert.ToDecimal(model.PurchaseCost - model.ReturnCost) + Convert.ToDecimal(model.PremiumsCost) + model.PlatformFee + model.Freight + Convert.ToDecimal(model.TakeBrush) + Convert.ToDecimal(model.Cashback) + Convert.ToDecimal(model.AdvertisementFEE);
                    value = model.YYCBMoney;
                    return model;
                }
            }
            //毛利=营业收入-增值税-营业成本
            if (FinancialFieldID == 68)
            {
                model.MLMoney = value;
                if (value != 0)
                {
                    return model;
                }
                else
                {
                    model.MLMoney = Math.Round(model.BusinessIncome - model.ReturnMoney - Convert.ToDecimal(model.ZZSMoney) - Convert.ToDecimal(model.YYCBMoney));
                    value = model.MLMoney;
                    return model;
                }
            }
            //直接人工=运营部门人员工资+运营部门人员社保+运营部门人员奖金
            if (FinancialFieldID == 69)
            {
                model.ZJRGMoney = value;
                if (value != 0)
                {
                    return model;
                }
                else
                {
                    model.ZJRGMoney = Math.Round(model.CountMoneySum1 + model.CountMoneySum2 + model.CountMoneySum3, 2);
                    value = model.ZJRGMoney;
                    return model;
                }
            }
            //营业费用=运营部门销售奖金+差旅费+办公费用+其他费用+固定资产折旧+摊销费用
            if (FinancialFieldID == 70)
            {
                model.YYFYMoney = value;
                if (value != 0)
                {
                    return model;
                }
                else
                {
                    model.YYFYMoney = Math.Round(model.CountMoneySum4 + model.CountMoneySum5 + model.CountMoneySum6 + model.CountMoneySum7 + model.CountMoneySum8 + model.CountMoneySum9, 2);
                    value = model.YYFYMoney;
                    return model;
                }
            }
            //营业税金及附加=增值税*0.12+营业收入/1.17*0.001
            if (FinancialFieldID == 72)
            {
                model.YYSJMoney = value;
                if (value != 0)
                {
                    return model;
                }
                else
                {
                    model.YYSJMoney = Math.Round(Convert.ToDecimal(model.ZZSMoney) * (decimal)0.12 + model.BusinessIncome / (decimal)1.17 * (decimal)0.001, 2);
                    value = model.YYSJMoney;
                    return model;
                }
            }
            //税前利润=毛利-直接人工-营业费用-营业税金及附加-广告费补贴-平台其他费用
            if (FinancialFieldID == 73)
            {
                model.SQLRMoney = value;
                if (value == 0)
                {
                    model.SQLRMoney = Math.Round(Convert.ToDecimal(model.MLMoney) - Convert.ToDecimal(model.ZJRGMoney)
                - Convert.ToDecimal(model.YYFYMoney) - Convert.ToDecimal(model.YYSJMoney) - Convert.ToDecimal(model.CountMoneySum10), 2);
                    value = model.SQLRMoney;
                }
                model.IncomeTax = Math.Round(model.SQLRMoney / 4, 2);
            }
            return model;
        }

        public List<CWStaffSpending> GetAllResult(List<int> FinancialFieldList, string year, string month, int ProjectId, int DepartmentType, int NickId)
        {
            DateTime Begin = DateTime.Parse(year + "/" + month + "/01");
            DateTime End = Begin.AddMonths(1);
            List<CWStaffSpending> list = new List<CWStaffSpending>();
            List<int?> financialFieldList = new List<int?>();
            foreach (int a in FinancialFieldList)
            {
                int? b=a;
                financialFieldList.Add(b);
            }
            var StaffSpendingList = IoC.Resolve<ICWStaffSpendingService>().GetCWStaffSpendingListbyData(financialFieldList, year, month, ProjectId, DepartmentType, NickId);
            var FinancialCapitalFlowList = IoC.Resolve<IXMFinancialCapitalFlowService>().GetListByFinancialFieldList(Begin.ToString(), End.ToString(), DepartmentType, ProjectId, financialFieldList);
            foreach (int FinancialFieldId in FinancialFieldList)
            {
                var staffSpendingList = StaffSpendingList.Where(x => x.FinancialFieldId == FinancialFieldId);
                if (staffSpendingList.Count() > 0)
                {
                    CWStaffSpending item = new CWStaffSpending();
                    item.FinancialFieldId = FinancialFieldId;
                    item.CountMoney = staffSpendingList.Sum(x => x.CountMoney);
                    list.Add(item);
                }
                else
                {
                    var financialCapitalFlowList = FinancialCapitalFlowList.Where(x => x.BudgetType == FinancialFieldId);
                    if (financialCapitalFlowList.Count() > 0)
                    {
                        CWStaffSpending item = new CWStaffSpending();
                        item.FinancialFieldId = FinancialFieldId;
                        item.CountMoney = financialCapitalFlowList.Sum(x => x.Amount);
                        list.Add(item);
                    }
                }
            }

            return list;
        }

        public CWProfitModel AccumulationValue(CWProfitModel a, CWProfitModel b)
        {
            a.CountMoneySum1 += b.CountMoneySum1;
            a.CountMoneySum2 += b.CountMoneySum2;
            a.CountMoneySum3 += b.CountMoneySum3;
            a.CountMoneySum4 += b.CountMoneySum4;
            a.CountMoneySum5 += b.CountMoneySum5;
            a.CountMoneySum6 += b.CountMoneySum6;
            a.CountMoneySum7 += b.CountMoneySum7;
            a.CountMoneySum8 += b.CountMoneySum8;
            a.CountMoneySum9 += b.CountMoneySum9;
            a.CountMoneySum10 += b.CountMoneySum10;

            a.OperatingPerformance += b.OperatingPerformance;
            a.BusinessIncome += b.BusinessIncome;
            a.ReturnMoney += b.ReturnMoney;
            a.PurchaseCost += b.PurchaseCost;
            a.ReturnCost += b.ReturnCost;
            a.PremiumsCost += b.PremiumsCost;
            a.TakeBrush += b.TakeBrush;
            a.Cashback += b.Cashback;
            a.AdvertisementFEE += b.AdvertisementFEE;
            a.PlatformFee += b.PlatformFee;
            a.Freight += b.Freight;
            a.ZZSMoney += b.ZZSMoney;
            a.YYCBMoney += b.YYCBMoney;
            a.MLMoney += b.MLMoney;
            a.ZJRGMoney += b.ZJRGMoney;
            a.YYFYMoney += b.YYFYMoney;
            a.YYSJMoney += b.YYSJMoney;
            a.SQLRMoney += b.SQLRMoney;
            a.Wages += b.Wages;
            a.SocialSecurity += b.SocialSecurity;
            a.Bonus += b.Bonus;
            a.Subsidy += b.Subsidy;
            a.SalesIncentive += b.SalesIncentive;
            a.WelfareFunds += b.WelfareFunds;
            a.MarketFees += b.MarketFees;
            a.ServerRentalFee += b.ServerRentalFee;
            a.IncomeTax += b.IncomeTax;
            a.DirectSellingNetProfit += b.DirectSellingNetProfit;
            a.ServiceIncome += b.ServiceIncome;
            return a;
        }

        public List<CWStaffSpendingMapping> GetCompleteData(List<CWStaffSpendingMapping> list, CWProfitModel MonthData, CWProfitModel YearData)
        {
            foreach (CWStaffSpendingMapping info in list)
            {
                if (info.FinancialFieldId == 63)
                {
                    info.MonthTotal = MonthData.OperatingPerformance;
                    info.YearTotal = YearData.OperatingPerformance;
                }
                if (info.FinancialFieldId == 64)
                {
                    info.MonthTotal = MonthData.BusinessIncome;
                    info.YearTotal = YearData.BusinessIncome;
                }
                if (info.FinancialFieldId == 78)
                {
                    info.MonthTotal = MonthData.PurchaseCost;
                    info.YearTotal = YearData.PurchaseCost;
                }
                if (info.FinancialFieldId == 79)
                {
                    info.MonthTotal = MonthData.PremiumsCost;
                    info.YearTotal = YearData.PremiumsCost;
                }
                if (info.FinancialFieldId == 109)
                {
                    info.MonthTotal = MonthData.TakeBrush;
                    info.YearTotal = YearData.TakeBrush;
                }
                if (info.FinancialFieldId == 110)
                {
                    info.MonthTotal = MonthData.Cashback;
                    info.YearTotal = YearData.Cashback;
                }

                if (info.FinancialFieldId == 86)
                {
                    info.MonthTotal = MonthData.AdvertisementFEE;
                    info.YearTotal = YearData.AdvertisementFEE;
                }
                if (info.FinancialFieldId == 107)
                {
                    info.MonthTotal = MonthData.PlatformFee;
                    info.YearTotal = YearData.PlatformFee;
                }
                if (info.FinancialFieldId == 108)
                {
                    info.MonthTotal = MonthData.Freight;
                    info.YearTotal = YearData.Freight;
                }
                if (info.FinancialFieldId == 67)
                {
                    info.MonthTotal = MonthData.ZZSMoney;
                    info.YearTotal = YearData.ZZSMoney;
                }
                if (info.FinancialFieldId == 66)
                {
                    info.MonthTotal = MonthData.YYCBMoney;
                    info.YearTotal = YearData.YYCBMoney;
                }
                if (info.FinancialFieldId == 68)
                {
                    info.MonthTotal = MonthData.MLMoney;
                    info.YearTotal = YearData.MLMoney;
                }
                if (info.FinancialFieldId == 89)
                {
                    info.MonthTotal = MonthData.CountMoneySum1;
                    info.YearTotal = YearData.CountMoneySum1;
                }
                if (info.FinancialFieldId == 90)
                {
                    info.MonthTotal = MonthData.CountMoneySum2;
                    info.YearTotal = YearData.CountMoneySum2;
                }
                if (info.FinancialFieldId == 91)
                {
                    info.MonthTotal = MonthData.CountMoneySum3;
                    info.YearTotal = YearData.CountMoneySum3;
                }
                if (info.FinancialFieldId == 111)
                {
                    info.MonthTotal = MonthData.CountMoneySum4;
                    info.YearTotal = YearData.CountMoneySum4;
                }
                if (info.FinancialFieldId == 98)
                {
                    info.MonthTotal = MonthData.CountMoneySum5;
                    info.YearTotal = YearData.CountMoneySum5;
                }
                if (info.FinancialFieldId == 101)
                {
                    info.MonthTotal = MonthData.CountMoneySum6;
                    info.YearTotal = YearData.CountMoneySum6;
                }
                if (info.FinancialFieldId == 100)
                {
                    info.MonthTotal = MonthData.CountMoneySum7;
                    info.YearTotal = YearData.CountMoneySum7;
                }
                if (info.FinancialFieldId == 112)
                {
                    info.MonthTotal = MonthData.CountMoneySum8;
                    info.YearTotal = YearData.CountMoneySum8;
                }
                if (info.FinancialFieldId == 113)
                {
                    info.MonthTotal = MonthData.CountMoneySum9;
                    info.YearTotal = YearData.CountMoneySum9;
                }

                if (info.FinancialFieldId == 71)
                {
                    info.MonthTotal = MonthData.CountMoneySum10;
                    info.YearTotal = YearData.CountMoneySum10;
                }
                if (info.FinancialFieldId == 69)
                {
                    info.MonthTotal = MonthData.ZJRGMoney;
                    info.YearTotal = YearData.ZJRGMoney;
                }
                if (info.FinancialFieldId == 70)
                {
                    info.MonthTotal = MonthData.YYFYMoney;
                    info.YearTotal = YearData.YYFYMoney;
                }
                if (info.FinancialFieldId == 72)
                {
                    info.MonthTotal = MonthData.YYSJMoney;
                    info.YearTotal = YearData.YYSJMoney;
                }
                if (info.FinancialFieldId == 73)
                {
                    info.MonthTotal = MonthData.SQLRMoney;
                    info.YearTotal = YearData.SQLRMoney;
                }
                if (info.FinancialFieldId == 93)
                {
                    info.MonthTotal = MonthData.Wages;
                    info.YearTotal = YearData.Wages;
                }
                if (info.FinancialFieldId == 94)
                {
                    info.MonthTotal = MonthData.SocialSecurity;
                    info.YearTotal = YearData.SocialSecurity;
                }
                if (info.FinancialFieldId == 95)
                {
                    info.MonthTotal = MonthData.Bonus;
                    info.YearTotal = YearData.Bonus;
                }
                if (info.FinancialFieldId == 96)
                {
                    info.MonthTotal = MonthData.Subsidy;
                    info.YearTotal = YearData.Subsidy;
                }
                if (info.FinancialFieldId == 97)
                {
                    info.MonthTotal = MonthData.SalesIncentive;
                    info.YearTotal = YearData.SalesIncentive;
                }
                if (info.FinancialFieldId == 99)
                {
                    info.MonthTotal = MonthData.WelfareFunds;
                    info.YearTotal = YearData.WelfareFunds;
                }
                if (info.FinancialFieldId == 103)
                {
                    info.MonthTotal = MonthData.MarketFees;
                    info.YearTotal = YearData.MarketFees;
                }

                if (info.FinancialFieldId == 105)
                {
                    info.MonthTotal = MonthData.ServerRentalFee;
                    info.YearTotal = YearData.ServerRentalFee;
                }
                if (info.FinancialFieldId == 106)
                {
                    info.MonthTotal = MonthData.IncomeTax;
                    info.YearTotal = YearData.IncomeTax;
                }
                if (info.FinancialFieldId == 74)
                {
                    info.MonthTotal = MonthData.DirectSellingNetProfit;
                    info.YearTotal = YearData.DirectSellingNetProfit;
                }
                if (info.FinancialFieldId == 75)
                {
                    info.MonthTotal = MonthData.ServiceIncome;
                    info.YearTotal = YearData.ServiceIncome;
                }
            }
            return list;
        }

        public CWProfitModel B2BOrB2C(CWProfitModel model, int FinancialFieldID, List<int?> NickIdList, string year, string month, int ProjectId, int DepartmentType, List<CWStaffSpending> CWStaffSpendingList)
        {
            decimal value = 0;
            var a = CWStaffSpendingList.Where(x => x.FinancialFieldId == FinancialFieldID);
            if (a.Count() > 0)
            {
                value = (decimal)(a.ToList())[0].CountMoney;
            }

            //营业业绩额
            if (FinancialFieldID == 63)
            {
                model.OperatingPerformance = value;
                if (value != 0)
                {
                    return model;
                }

                if (DepartmentType == 6)
                {
                    model.OperatingPerformance = GetProfitValue(FinancialFieldID, -1, -1, year, month, DepartmentType);
                }
                else
                {
                    model.OperatingPerformance = model.ServiceIncome;
                }
                value = model.OperatingPerformance;
            }
            //营业成本
            if (FinancialFieldID == 66)
            {
                model.YYCBMoney = value;
                if (value != 0)
                {
                    return model;
                }
                model.YYCBMoney = GetProfitValue(FinancialFieldID, -1, -1, year, month, DepartmentType);
                value = model.YYCBMoney;
            }
            //增值税
            if (FinancialFieldID == 67)
            {
                model.ZZSMoney = value;
                if (value != 0)
                {
                    return model;
                }
                model.ZZSMoney = Math.Round((model.OperatingPerformance / (decimal)1.06) * (decimal)0.06, 2);
                value = model.ZZSMoney;
            }
            //毛利
            if (FinancialFieldID == 68)
            {
                model.MLMoney = value;
                if (value != 0)
                {
                    return model;
                }
                model.MLMoney = Math.Round((model.OperatingPerformance - model.YYCBMoney - model.ZZSMoney), 2);
                value = model.MLMoney;
            }
            //营业税金及附加
            if (FinancialFieldID == 72)
            {
                model.YYSJMoney = value;
                if (value != 0)
                {
                    return model;
                }
                model.YYSJMoney = Math.Round(model.ZZSMoney * (decimal)0.12 + model.OperatingPerformance / (decimal)1.06 * (decimal)0.001, 2);
                value = model.YYSJMoney;
            }
            //税前利润=毛利-营业费用-营业税金及附加
            if (FinancialFieldID == 73)
            {
                model.SQLRMoney = value;
                if (value != 0)
                {
                    return model;
                }
                model.SQLRMoney += Math.Round((model.MLMoney - model.YYSJMoney - model.YYFYMoney), 2);
                value = model.SQLRMoney;
                model.IncomeTax = Math.Round(model.SQLRMoney / 4, 2);
            }
            //营业费用=工资+社保+奖金+补贴+销售激励+福利费+市场费+服务器租赁费+办公费用+其他费用+差旅费
            if (FinancialFieldID == 70)
            {
                model.YYFYMoney = value;
                if (value != 0)
                {
                    return model;
                }
                else
                {
                    model.YYFYMoney = Math.Round(model.Wages + model.SocialSecurity + model.Bonus + model.Subsidy + model.SalesIncentive + model.WelfareFunds + model.MarketFees + model.ServerRentalFee + model.CountMoneySum6 + model.CountMoneySum7 + model.CountMoneySum5, 2);
                    value = model.YYFYMoney;
                    return model;
                }
            }
            //直销净利润
            if (FinancialFieldID == 74)
            {
                model.DirectSellingNetProfit = value;
                if (value != 0)
                {
                    return model;
                }
                else
                {
                    model.DirectSellingNetProfit = Math.Round(model.SQLRMoney - model.IncomeTax, 2);
                    value = model.DirectSellingNetProfit;
                    return model;
                }
            }
            //工资
            if (FinancialFieldID == 93)
            {
                model.Wages = value;
                if (value != 0)
                {
                    return model;
                }
            }
            //社保
            if (FinancialFieldID == 94)
            {
                model.SocialSecurity = value;
                if (value != 0)
                {
                    return model;
                }
            }
            //奖金
            if (FinancialFieldID == 95)
            {
                model.Bonus = value;
                if (value != 0)
                {
                    return model;
                }
            }
            //补贴
            if (FinancialFieldID == 96)
            {
                model.Subsidy = value;
                if (value != 0)
                {
                    return model;
                }
            }
            //销售激励
            if (FinancialFieldID == 97)
            {
                model.SalesIncentive = value;
                if (value != 0)
                {
                    return model;
                }
            }
            //福利费
            if (FinancialFieldID == 99)
            {
                model.WelfareFunds = value;
                if (value != 0)
                {
                    return model;
                }
            }
            //市场费
            if (FinancialFieldID == 103)
            {
                model.MarketFees = value;
                if (value != 0)
                {
                    return model;
                }
            }
            //服务器租赁费
            if (FinancialFieldID == 105)
            {
                model.ServerRentalFee = value;
                if (value != 0)
                {
                    return model;
                }
            }
            //办公费用
            if (FinancialFieldID == 101)
            {
                model.CountMoneySum6 = value;
                if (value != 0)
                {
                    return model;
                }
            }
            //其他费用
            if (FinancialFieldID == 100)
            {
                model.CountMoneySum7 = value;
                if (value != 0)
                {
                    return model;
                }
            }
            //服务收入
            if (FinancialFieldID == 75)
            {
                model.ServiceIncome = value;
                if (DepartmentType == 197)
                {
                    if (value != 0)
                    {
                        return model;
                    }
                    model.ServiceIncome = GetProfitValue(FinancialFieldID, -1, -1, year, month, DepartmentType);
                    value = model.ServiceIncome;
                }
            }
            //差旅费
            if (FinancialFieldID == 98)
            {
                model.CountMoneySum5 = value;
                if (value != 0)
                {
                    return model;
                }
            }
            return model;
        }

        public CWProfitModel AddOfflineData(CWProfitModel MonthData, List<int> nickIdList, string Year, string Month)
        {
            DateTime begin = DateTime.Parse(Year + "/" + Month + "/01");
            DateTime end = begin.AddMonths(1).AddSeconds(-1);
            decimal BusinessIncome = 0;
            decimal PurchaseCost = 0;

            List<JDSelfModel> List = new List<JDSelfModel>();
            List<XMJDSaleRejectedProductDetail> RejectedList = new List<XMJDSaleRejectedProductDetail>();
            List<XMSaleReturnProductDetails> ReturnList = new List<XMSaleReturnProductDetails>();

            var wareHousesList = IoC.Resolve<IXMWareHousesService>().GetXMWarehouseListByNickIds(nickIdList);
            List<int> WareHousesList = wareHousesList.Select(x => x.Id).ToList();
            List<int?> WarehousesList = WareHousesList.Select<int, int?>(q => Convert.ToInt32(q)).ToList();
            var SaleList = IoC.Resolve<IXMSaleDeliveryProductDetailsService>().GetXMSaleDeliveryListJDSelf(begin, end, WareHousesList);//线下无订单的销售出库数据
            if (nickIdList.Contains(29))
            {
                RejectedList = IoC.Resolve<IXMJDSaleRejectedProductDetailService>().GetXMJDSaleRejectedProductDetailListJDSelf(begin, end);//京东自营退货
            }
            if ((nickIdList.Contains(29) && nickIdList.Count > 1) || !nickIdList.Contains(29))
            {
                ReturnList = IoC.Resolve<IXMSaleReturnProductDetailsService>().GetXMSaleReturnProductDetailsListByDate(begin, end, WarehousesList);
            }
            var InventoryList = IoC.Resolve<IXMInventoryInfoService>().GetXMInventoryInfoListByWfIds(WareHousesList);//京东自营库存

            GetJDProductsPriceList(ref List, SaleList, RejectedList, ReturnList, InventoryList, WareHousesList);

            if (SaleList.Count > 0)
            {
                foreach (XMSaleDeliveryProductDetails sale in SaleList)
                {
                    BusinessIncome += (decimal)(sale.ProductMoney == null ? 0 : sale.ProductMoney);

                    decimal cost = GetCost(List, sale.XM_SaleDelivery.WareHouseId, sale.PlatformMerchantCode);
                    PurchaseCost += cost * decimal.Parse(sale.SaleCount.ToString());
                }
            }
            if (RejectedList.Count > 0)
            {
                foreach (XMJDSaleRejectedProductDetail rejected in RejectedList)
                {
                    BusinessIncome -= (decimal)(rejected.RejectionMoney == null ? 0 : rejected.RejectionMoney);

                    decimal cost = GetCost(List, -1, rejected.PlatformMerchantCode);
                    PurchaseCost -= cost * decimal.Parse(rejected.RejectionCount.ToString());
                }
            }
            if (ReturnList.Count > 0)
            {
                foreach (XMSaleReturnProductDetails rejected in ReturnList)
                {
                    BusinessIncome -= (decimal)(rejected.RejectionsaleMoney == null ? 0 : rejected.RejectionsaleMoney);

                    string PlatformMerchantCode = "";
                    if (rejected.DeliveryProductsDetailID != null)
                    {
                        var ProductDetail = IoC.Resolve<IXMSaleDeliveryProductDetailsService>().GetXMSaleDeliveryProductDetailsById(rejected.DeliveryProductsDetailID.Value);
                        if (ProductDetail != null)
                        {
                            PlatformMerchantCode = ProductDetail.PlatformMerchantCode;
                        }
                    }
                    decimal cost = GetCost(List, (int)rejected.XM_SaleReturn.WarehouseId, PlatformMerchantCode);
                    PurchaseCost -= cost * decimal.Parse(rejected.RejectionProdcutsCount.ToString());
                }
            }

            MonthData.BusinessIncome += BusinessIncome;
            MonthData.PurchaseCost += PurchaseCost;
            return MonthData;
        }

        public decimal GetCost(List<JDSelfModel> List, int WareHouseId, string PlatformMerchantCode)
        {
            decimal cost = 0;
            var list = List.Where(x => (WareHouseId == -1 || x.WareHousesID == WareHouseId) && x.PlatformMerchantCode == PlatformMerchantCode).ToList();
            if (list != null && list.Count > 0)
            {
                cost = list[0].CostPrice;
            }

            return cost;
        }

        public void GetJDProductsPriceList(ref List<JDSelfModel> List, List<XMSaleDeliveryProductDetails> SaleList, List<XMJDSaleRejectedProductDetail> RejectedList
            , List<XMSaleReturnProductDetails> ReturnList, List<XMInventoryInfo> InventoryList, List<int> WareHousesList)
        {
            var StorageProductList = IoC.Resolve<IXMStorageProductDetailsService>().GetXMStorageProductDetailsListByWareHousesList(WareHousesList);

            foreach (var sale in SaleList)
            {
                var exist = List.Where(x => x.WareHousesID == sale.XM_SaleDelivery.WareHouseId && x.PlatformMerchantCode == sale.PlatformMerchantCode).ToList();
                if (exist != null && exist.Count > 0)
                {
                    exist[0].SaleCount += (int)sale.SaleCount;
                }
                else
                {
                    JDSelfModel one = new JDSelfModel();
                    one.WareHousesID = sale.XM_SaleDelivery.WareHouseId;
                    one.PlatformMerchantCode = sale.PlatformMerchantCode;
                    one.SaleCount = (int)sale.SaleCount;
                    one.CostPrice = one.RejectedCount = one.InventoryCount = 0;
                    List.Add(one);
                }
            }
            foreach (var rejected in RejectedList)
            {
                var exist = List.Where(x => x.PlatformMerchantCode == rejected.PlatformMerchantCode).ToList();
                if (exist != null && exist.Count > 0)
                {
                    exist[0].RejectedCount += (int)rejected.RejectionCount;
                }
                else
                {
                    JDSelfModel one = new JDSelfModel();
                    one.WareHousesID = -1;
                    one.PlatformMerchantCode = rejected.PlatformMerchantCode;
                    one.RejectedCount = (int)rejected.RejectionCount;
                    one.CostPrice = one.SaleCount = one.InventoryCount = 0;
                    List.Add(one);
                }
            }
            foreach (var rejected in ReturnList)
            {
                string PlatformMerchantCode = "";
                if (rejected.DeliveryProductsDetailID != null)
                {
                    var ProductDetail = IoC.Resolve<IXMSaleDeliveryProductDetailsService>().GetXMSaleDeliveryProductDetailsById(rejected.DeliveryProductsDetailID.Value);
                    if (ProductDetail != null)
                    {
                        PlatformMerchantCode = ProductDetail.PlatformMerchantCode;
                    }
                }

                if (PlatformMerchantCode != "")
                {
                    var exist = List.Where(x => x.PlatformMerchantCode == PlatformMerchantCode && x.WareHousesID == rejected.XM_SaleReturn.WarehouseId).ToList();
                    if (exist != null && exist.Count > 0)
                    {
                        exist[0].RejectedCount += (int)rejected.RejectionProdcutsCount;
                    }
                    else
                    {
                        JDSelfModel one = new JDSelfModel();
                        one.WareHousesID = (int)rejected.XM_SaleReturn.WarehouseId; ;
                        one.PlatformMerchantCode = PlatformMerchantCode;
                        one.RejectedCount = (int)rejected.RejectionProdcutsCount;
                        one.CostPrice = one.SaleCount = one.InventoryCount = 0;
                        List.Add(one);
                    }
                }
            }
            foreach (var inventory in InventoryList)
            {
                var exist = List.Where(x => x.WareHousesID == inventory.WfId && x.PlatformMerchantCode == inventory.PlatformMerchantCode).ToList();
                if (exist != null && exist.Count > 0)
                {
                    exist[0].InventoryCount += (int)inventory.StockNumber;
                }
            }

            foreach (var Info in List)
            {
                if (Info.WareHousesID != -1)
                {
                    var exist = StorageProductList.Where(x => x.PlatformMerchantCode == Info.PlatformMerchantCode && x.XM_Storage.WareHouseId == Info.WareHousesID).ToList();
                    if (exist != null && exist.Count > 0)
                    {
                        decimal TotalMoney = 0;
                        int InventoryRejectedCount = Info.InventoryCount + Info.RejectedCount;
                        int SaleCount = Info.SaleCount;
                        foreach (var StorageProduct in exist)
                        {
                            if (InventoryRejectedCount >= StorageProduct.ProductsCount)
                            {
                                InventoryRejectedCount -= StorageProduct.ProductsCount;
                            }
                            else
                            {
                                int difference = StorageProduct.ProductsCount - InventoryRejectedCount;
                                InventoryRejectedCount = 0;
                                if (SaleCount > difference)
                                {
                                    SaleCount -= difference;
                                    TotalMoney += difference * StorageProduct.ProductsPrice;
                                }
                                else
                                {
                                    TotalMoney += SaleCount * StorageProduct.ProductsPrice;
                                    break;
                                }
                            }
                        }
                        Info.CostPrice = Math.Round(TotalMoney / decimal.Parse(Info.SaleCount.ToString()), 2);
                    }
                }
                else//销售出库中不存在的商品
                {
                    var exist = StorageProductList.Where(x => x.PlatformMerchantCode == Info.PlatformMerchantCode).ToList();
                    if (exist != null && exist.Count > 0)
                    {
                        Info.CostPrice = exist[0].ProductsPrice;
                    }
                    else
                    {
                        Info.CostPrice = 0;
                    }
                }
            }
        }
    }
}
