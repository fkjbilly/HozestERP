using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class GetOrderGoodsReqHelper : TBeanSerializer<GetOrderGoodsReq>
	{
		
		public static GetOrderGoodsReqHelper OBJ = new GetOrderGoodsReqHelper();
		
		public static GetOrderGoodsReqHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetOrderGoodsReq structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("userIdSet".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<long?> value;
						
						value = new List<long?>();
						iprot.ReadSetBegin();
						while(true){
							
							try{
								
								long elem0;
								elem0 = iprot.ReadI64(); 
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadSetEnd();
						
						structs.SetUserIdSet(value);
					}
					
					
					
					
					
					if ("orderIdSet".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<long?> value;
						
						value = new List<long?>();
						iprot.ReadSetBegin();
						while(true){
							
							try{
								
								long elem1;
								elem1 = iprot.ReadI64(); 
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadSetEnd();
						
						structs.SetOrderIdSet(value);
					}
					
					
					
					
					
					if ("orderSnSet".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<string> value;
						
						value = new List<string>();
						iprot.ReadSetBegin();
						while(true){
							
							try{
								
								string elem2;
								elem2 = iprot.ReadString();
								
								value.Add(elem2);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadSetEnd();
						
						structs.SetOrderSnSet(value);
					}
					
					
					
					
					
					if ("userName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUserName(value);
					}
					
					
					
					
					
					if ("saleType".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<int?> value;
						
						value = new List<int?>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								int elem3;
								elem3 = iprot.ReadI32(); 
								
								value.Add(elem3);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetSaleType(value);
					}
					
					
					
					
					
					if ("typeList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<int?> value;
						
						value = new List<int?>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								int elem4;
								elem4 = iprot.ReadI32(); 
								
								value.Add(elem4);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetTypeList(value);
					}
					
					
					
					
					
					if ("vipclub".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVipclub(value);
					}
					
					
					
					
					
					if ("statusRange".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.request.RangeParam value;
						
						value = new com.vip.order.common.pojo.order.request.RangeParam();
						com.vip.order.common.pojo.order.request.RangeParamHelper.getInstance().Read(value, iprot);
						
						structs.SetStatusRange(value);
					}
					
					
					
					
					
					if ("payStatus".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetPayStatus(value);
					}
					
					
					
					
					
					if ("buyer".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBuyer(value);
					}
					
					
					
					
					
					if ("transportSN".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransportSN(value);
					}
					
					
					
					
					
					if ("transportId".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetTransportId(value);
					}
					
					
					
					
					
					if ("mobile".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMobile(value);
					}
					
					
					
					
					
					if ("queryRange".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetQueryRange(value);
					}
					
					
					
					
					
					if ("orderTimeRange".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.request.RangeParam value;
						
						value = new com.vip.order.common.pojo.order.request.RangeParam();
						com.vip.order.common.pojo.order.request.RangeParamHelper.getInstance().Read(value, iprot);
						
						structs.SetOrderTimeRange(value);
					}
					
					
					
					
					
					if ("updateTimeRange".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.request.RangeParam value;
						
						value = new com.vip.order.common.pojo.order.request.RangeParam();
						com.vip.order.common.pojo.order.request.RangeParamHelper.getInstance().Read(value, iprot);
						
						structs.SetUpdateTimeRange(value);
					}
					
					
					
					
					
					if ("payTypeRange".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.request.RangeParam value;
						
						value = new com.vip.order.common.pojo.order.request.RangeParam();
						com.vip.order.common.pojo.order.request.RangeParamHelper.getInstance().Read(value, iprot);
						
						structs.SetPayTypeRange(value);
					}
					
					
					
					
					
					if ("moneyRange".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.request.RangeParam value;
						
						value = new com.vip.order.common.pojo.order.request.RangeParam();
						com.vip.order.common.pojo.order.request.RangeParamHelper.getInstance().Read(value, iprot);
						
						structs.SetMoneyRange(value);
					}
					
					
					
					
					
					if ("allotTimes".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAllotTimes(value);
					}
					
					
					
					
					
					if ("orderFlag".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetOrderFlag(value);
					}
					
					
					
					
					
					if ("statusFlag".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetStatusFlag(value);
					}
					
					
					
					
					
					if ("wmsFlag".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetWmsFlag(value);
					}
					
					
					
					
					
					if ("isHold".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetIsHold(value);
					}
					
					
					
					
					
					if ("isSpecial".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetIsSpecial(value);
					}
					
					
					
					
					
					if ("specialCondition".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.biz.request.SpecialCondition value;
						
						value = new com.vip.order.biz.request.SpecialCondition();
						com.vip.order.biz.request.SpecialConditionHelper.getInstance().Read(value, iprot);
						
						structs.SetSpecialCondition(value);
					}
					
					
					
					
					
					if ("warehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouse(value);
					}
					
					
					
					
					
					if ("orderGoodsCondition".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.biz.request.OrderGoodsCondition value;
						
						value = new com.vip.order.biz.request.OrderGoodsCondition();
						com.vip.order.biz.request.OrderGoodsConditionHelper.getInstance().Read(value, iprot);
						
						structs.SetOrderGoodsCondition(value);
					}
					
					
					
					
					
					if ("vipclubList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<string> value;
						
						value = new List<string>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								string elem12;
								elem12 = iprot.ReadString();
								
								value.Add(elem12);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetVipclubList(value);
					}
					
					
					
					
					if(needSkip){
						
						ProtocolUtil.skip(iprot);
					}
					
					iprot.ReadFieldEnd();
				}
				
				iprot.ReadStructEnd();
				Validate(structs);
			}
			else{
				
				throw new OspException();
			}
			
			
		}
		
		
		public void Write(GetOrderGoodsReq structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetUserIdSet() != null) {
				
				oprot.WriteFieldBegin("userIdSet");
				
				oprot.WriteSetBegin();
				foreach(long _item0 in structs.GetUserIdSet()){
					
					oprot.WriteI64((long)_item0); 
					
				}
				
				oprot.WriteSetEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderIdSet() != null) {
				
				oprot.WriteFieldBegin("orderIdSet");
				
				oprot.WriteSetBegin();
				foreach(long _item0 in structs.GetOrderIdSet()){
					
					oprot.WriteI64((long)_item0); 
					
				}
				
				oprot.WriteSetEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderSnSet() != null) {
				
				oprot.WriteFieldBegin("orderSnSet");
				
				oprot.WriteSetBegin();
				foreach(string _item0 in structs.GetOrderSnSet()){
					
					oprot.WriteString(_item0);
					
				}
				
				oprot.WriteSetEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUserName() != null) {
				
				oprot.WriteFieldBegin("userName");
				oprot.WriteString(structs.GetUserName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSaleType() != null) {
				
				oprot.WriteFieldBegin("saleType");
				
				oprot.WriteListBegin();
				foreach(int _item0 in structs.GetSaleType()){
					
					oprot.WriteI32((int)_item0); 
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTypeList() != null) {
				
				oprot.WriteFieldBegin("typeList");
				
				oprot.WriteListBegin();
				foreach(int _item0 in structs.GetTypeList()){
					
					oprot.WriteI32((int)_item0); 
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVipclub() != null) {
				
				oprot.WriteFieldBegin("vipclub");
				oprot.WriteString(structs.GetVipclub());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStatusRange() != null) {
				
				oprot.WriteFieldBegin("statusRange");
				
				com.vip.order.common.pojo.order.request.RangeParamHelper.getInstance().Write(structs.GetStatusRange(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPayStatus() != null) {
				
				oprot.WriteFieldBegin("payStatus");
				oprot.WriteI32((int)structs.GetPayStatus()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBuyer() != null) {
				
				oprot.WriteFieldBegin("buyer");
				oprot.WriteString(structs.GetBuyer());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTransportSN() != null) {
				
				oprot.WriteFieldBegin("transportSN");
				oprot.WriteString(structs.GetTransportSN());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTransportId() != null) {
				
				oprot.WriteFieldBegin("transportId");
				oprot.WriteI32((int)structs.GetTransportId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMobile() != null) {
				
				oprot.WriteFieldBegin("mobile");
				oprot.WriteString(structs.GetMobile());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetQueryRange() != null) {
				
				oprot.WriteFieldBegin("queryRange");
				oprot.WriteI32((int)structs.GetQueryRange()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderTimeRange() != null) {
				
				oprot.WriteFieldBegin("orderTimeRange");
				
				com.vip.order.common.pojo.order.request.RangeParamHelper.getInstance().Write(structs.GetOrderTimeRange(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUpdateTimeRange() != null) {
				
				oprot.WriteFieldBegin("updateTimeRange");
				
				com.vip.order.common.pojo.order.request.RangeParamHelper.getInstance().Write(structs.GetUpdateTimeRange(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPayTypeRange() != null) {
				
				oprot.WriteFieldBegin("payTypeRange");
				
				com.vip.order.common.pojo.order.request.RangeParamHelper.getInstance().Write(structs.GetPayTypeRange(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMoneyRange() != null) {
				
				oprot.WriteFieldBegin("moneyRange");
				
				com.vip.order.common.pojo.order.request.RangeParamHelper.getInstance().Write(structs.GetMoneyRange(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAllotTimes() != null) {
				
				oprot.WriteFieldBegin("allotTimes");
				oprot.WriteString(structs.GetAllotTimes());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderFlag() != null) {
				
				oprot.WriteFieldBegin("orderFlag");
				oprot.WriteI32((int)structs.GetOrderFlag()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStatusFlag() != null) {
				
				oprot.WriteFieldBegin("statusFlag");
				oprot.WriteI32((int)structs.GetStatusFlag()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWmsFlag() != null) {
				
				oprot.WriteFieldBegin("wmsFlag");
				oprot.WriteI32((int)structs.GetWmsFlag()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIsHold() != null) {
				
				oprot.WriteFieldBegin("isHold");
				oprot.WriteI32((int)structs.GetIsHold()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIsSpecial() != null) {
				
				oprot.WriteFieldBegin("isSpecial");
				oprot.WriteI32((int)structs.GetIsSpecial()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSpecialCondition() != null) {
				
				oprot.WriteFieldBegin("specialCondition");
				
				com.vip.order.biz.request.SpecialConditionHelper.getInstance().Write(structs.GetSpecialCondition(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWarehouse() != null) {
				
				oprot.WriteFieldBegin("warehouse");
				oprot.WriteString(structs.GetWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderGoodsCondition() != null) {
				
				oprot.WriteFieldBegin("orderGoodsCondition");
				
				com.vip.order.biz.request.OrderGoodsConditionHelper.getInstance().Write(structs.GetOrderGoodsCondition(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVipclubList() != null) {
				
				oprot.WriteFieldBegin("vipclubList");
				
				oprot.WriteListBegin();
				foreach(string _item0 in structs.GetVipclubList()){
					
					oprot.WriteString(_item0);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetOrderGoodsReq bean){
			
			
		}
		
	}
	
}