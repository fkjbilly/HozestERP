using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class SearchOrderReqHelper : TBeanSerializer<SearchOrderReq>
	{
		
		public static SearchOrderReqHelper OBJ = new SearchOrderReqHelper();
		
		public static SearchOrderReqHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(SearchOrderReq structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("userIdList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<long?> value;
						
						value = new List<long?>();
						iprot.ReadListBegin();
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
						
						iprot.ReadListEnd();
						
						structs.SetUserIdList(value);
					}
					
					
					
					
					
					if ("orderIdList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<long?> value;
						
						value = new List<long?>();
						iprot.ReadListBegin();
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
						
						iprot.ReadListEnd();
						
						structs.SetOrderIdList(value);
					}
					
					
					
					
					
					if ("orderSnList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<string> value;
						
						value = new List<string>();
						iprot.ReadListBegin();
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
						
						iprot.ReadListEnd();
						
						structs.SetOrderSnList(value);
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
					
					
					
					
					
					if ("typeRange".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.request.RangeParam value;
						
						value = new com.vip.order.common.pojo.order.request.RangeParam();
						com.vip.order.common.pojo.order.request.RangeParamHelper.getInstance().Read(value, iprot);
						
						structs.SetTypeRange(value);
					}
					
					
					
					
					
					if ("orderModelList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<int?> value;
						
						value = new List<int?>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								int elem5;
								elem5 = iprot.ReadI32(); 
								
								value.Add(elem5);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderModelList(value);
					}
					
					
					
					
					
					if ("warehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouse(value);
					}
					
					
					
					
					
					if ("vipclubList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<string> value;
						
						value = new List<string>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								string elem6;
								elem6 = iprot.ReadString();
								
								value.Add(elem6);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetVipclubList(value);
					}
					
					
					
					
					
					if ("statusRange".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.request.RangeParam value;
						
						value = new com.vip.order.common.pojo.order.request.RangeParam();
						com.vip.order.common.pojo.order.request.RangeParamHelper.getInstance().Read(value, iprot);
						
						structs.SetStatusRange(value);
					}
					
					
					
					
					
					if ("subStatusRange".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.request.RangeParam value;
						
						value = new com.vip.order.common.pojo.order.request.RangeParam();
						com.vip.order.common.pojo.order.request.RangeParamHelper.getInstance().Read(value, iprot);
						
						structs.SetSubStatusRange(value);
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
					
					
					
					
					
					if ("transportSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransportSn(value);
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
					
					
					
					
					
					if ("tel".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTel(value);
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
					
					
					
					
					
					if ("orderDateRange".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.request.RangeParam value;
						
						value = new com.vip.order.common.pojo.order.request.RangeParam();
						com.vip.order.common.pojo.order.request.RangeParamHelper.getInstance().Read(value, iprot);
						
						structs.SetOrderDateRange(value);
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
					
					
					
					
					
					if ("walletAmountRange".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.request.RangeParam value;
						
						value = new com.vip.order.common.pojo.order.request.RangeParam();
						com.vip.order.common.pojo.order.request.RangeParamHelper.getInstance().Read(value, iprot);
						
						structs.SetWalletAmountRange(value);
					}
					
					
					
					
					
					if ("couponIdList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<string> value;
						
						value = new List<string>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								string elem14;
								elem14 = iprot.ReadString();
								
								value.Add(elem14);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetCouponIdList(value);
					}
					
					
					
					
					
					if ("invoiceTypeList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<string> value;
						
						value = new List<string>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								string elem15;
								elem15 = iprot.ReadString();
								
								value.Add(elem15);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetInvoiceTypeList(value);
					}
					
					
					
					
					
					if ("allotTimeRange".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.request.RangeParam value;
						
						value = new com.vip.order.common.pojo.order.request.RangeParam();
						com.vip.order.common.pojo.order.request.RangeParamHelper.getInstance().Read(value, iprot);
						
						structs.SetAllotTimeRange(value);
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
					
					
					
					
					
					if ("wmsFlagList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<int?> value;
						
						value = new List<int?>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								int elem17;
								elem17 = iprot.ReadI32(); 
								
								value.Add(elem17);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetWmsFlagList(value);
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
					
					
					
					
					
					if ("isDisplay".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetIsDisplay(value);
					}
					
					
					
					
					
					if ("orderSourceTypeRange".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.request.RangeParam value;
						
						value = new com.vip.order.common.pojo.order.request.RangeParam();
						com.vip.order.common.pojo.order.request.RangeParamHelper.getInstance().Read(value, iprot);
						
						structs.SetOrderSourceTypeRange(value);
					}
					
					
					
					
					
					if ("specialCondition".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.biz.request.SpecialCondition value;
						
						value = new com.vip.order.biz.request.SpecialCondition();
						com.vip.order.biz.request.SpecialConditionHelper.getInstance().Read(value, iprot);
						
						structs.SetSpecialCondition(value);
					}
					
					
					
					
					
					if ("amountRange".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.request.RangeParam value;
						
						value = new com.vip.order.common.pojo.order.request.RangeParam();
						com.vip.order.common.pojo.order.request.RangeParamHelper.getInstance().Read(value, iprot);
						
						structs.SetAmountRange(value);
					}
					
					
					
					
					
					if ("orderCategory".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetOrderCategory(value);
					}
					
					
					
					
					
					if ("snType".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSnType(value);
					}
					
					
					
					
					
					if ("auditTimeRange".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.request.RangeParam value;
						
						value = new com.vip.order.common.pojo.order.request.RangeParam();
						com.vip.order.common.pojo.order.request.RangeParamHelper.getInstance().Read(value, iprot);
						
						structs.SetAuditTimeRange(value);
					}
					
					
					
					
					
					if ("isFirst".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetIsFirst(value);
					}
					
					
					
					
					
					if ("isLock".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetIsLock(value);
					}
					
					
					
					
					
					if ("ip".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetIp(value);
					}
					
					
					
					
					
					if ("operator".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOperator(value);
					}
					
					
					
					
					
					if ("deliveryTypeList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<int?> value;
						
						value = new List<int?>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								int elem22;
								elem22 = iprot.ReadI32(); 
								
								value.Add(elem22);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetDeliveryTypeList(value);
					}
					
					
					
					
					
					if ("compensateFlagList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<int?> value;
						
						value = new List<int?>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								int elem23;
								elem23 = iprot.ReadI32(); 
								
								value.Add(elem23);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetCompensateFlagList(value);
					}
					
					
					
					
					
					if ("storeId".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStoreId(value);
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
		
		
		public void Write(SearchOrderReq structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetUserIdList() != null) {
				
				oprot.WriteFieldBegin("userIdList");
				
				oprot.WriteListBegin();
				foreach(long _item0 in structs.GetUserIdList()){
					
					oprot.WriteI64((long)_item0); 
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderIdList() != null) {
				
				oprot.WriteFieldBegin("orderIdList");
				
				oprot.WriteListBegin();
				foreach(long _item0 in structs.GetOrderIdList()){
					
					oprot.WriteI64((long)_item0); 
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderSnList() != null) {
				
				oprot.WriteFieldBegin("orderSnList");
				
				oprot.WriteListBegin();
				foreach(string _item0 in structs.GetOrderSnList()){
					
					oprot.WriteString(_item0);
					
				}
				
				oprot.WriteListEnd();
				
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
			
			
			if(structs.GetTypeRange() != null) {
				
				oprot.WriteFieldBegin("typeRange");
				
				com.vip.order.common.pojo.order.request.RangeParamHelper.getInstance().Write(structs.GetTypeRange(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderModelList() != null) {
				
				oprot.WriteFieldBegin("orderModelList");
				
				oprot.WriteListBegin();
				foreach(int _item0 in structs.GetOrderModelList()){
					
					oprot.WriteI32((int)_item0); 
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWarehouse() != null) {
				
				oprot.WriteFieldBegin("warehouse");
				oprot.WriteString(structs.GetWarehouse());
				
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
			
			
			if(structs.GetStatusRange() != null) {
				
				oprot.WriteFieldBegin("statusRange");
				
				com.vip.order.common.pojo.order.request.RangeParamHelper.getInstance().Write(structs.GetStatusRange(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSubStatusRange() != null) {
				
				oprot.WriteFieldBegin("subStatusRange");
				
				com.vip.order.common.pojo.order.request.RangeParamHelper.getInstance().Write(structs.GetSubStatusRange(), oprot);
				
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
			
			
			if(structs.GetTransportSn() != null) {
				
				oprot.WriteFieldBegin("transportSn");
				oprot.WriteString(structs.GetTransportSn());
				
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
			
			
			if(structs.GetTel() != null) {
				
				oprot.WriteFieldBegin("tel");
				oprot.WriteString(structs.GetTel());
				
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
			
			
			if(structs.GetOrderDateRange() != null) {
				
				oprot.WriteFieldBegin("orderDateRange");
				
				com.vip.order.common.pojo.order.request.RangeParamHelper.getInstance().Write(structs.GetOrderDateRange(), oprot);
				
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
			
			
			if(structs.GetWalletAmountRange() != null) {
				
				oprot.WriteFieldBegin("walletAmountRange");
				
				com.vip.order.common.pojo.order.request.RangeParamHelper.getInstance().Write(structs.GetWalletAmountRange(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCouponIdList() != null) {
				
				oprot.WriteFieldBegin("couponIdList");
				
				oprot.WriteListBegin();
				foreach(string _item0 in structs.GetCouponIdList()){
					
					oprot.WriteString(_item0);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetInvoiceTypeList() != null) {
				
				oprot.WriteFieldBegin("invoiceTypeList");
				
				oprot.WriteListBegin();
				foreach(string _item0 in structs.GetInvoiceTypeList()){
					
					oprot.WriteString(_item0);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAllotTimeRange() != null) {
				
				oprot.WriteFieldBegin("allotTimeRange");
				
				com.vip.order.common.pojo.order.request.RangeParamHelper.getInstance().Write(structs.GetAllotTimeRange(), oprot);
				
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
			
			
			if(structs.GetWmsFlagList() != null) {
				
				oprot.WriteFieldBegin("wmsFlagList");
				
				oprot.WriteListBegin();
				foreach(int _item0 in structs.GetWmsFlagList()){
					
					oprot.WriteI32((int)_item0); 
					
				}
				
				oprot.WriteListEnd();
				
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
			
			
			if(structs.GetIsDisplay() != null) {
				
				oprot.WriteFieldBegin("isDisplay");
				oprot.WriteI32((int)structs.GetIsDisplay()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderSourceTypeRange() != null) {
				
				oprot.WriteFieldBegin("orderSourceTypeRange");
				
				com.vip.order.common.pojo.order.request.RangeParamHelper.getInstance().Write(structs.GetOrderSourceTypeRange(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSpecialCondition() != null) {
				
				oprot.WriteFieldBegin("specialCondition");
				
				com.vip.order.biz.request.SpecialConditionHelper.getInstance().Write(structs.GetSpecialCondition(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAmountRange() != null) {
				
				oprot.WriteFieldBegin("amountRange");
				
				com.vip.order.common.pojo.order.request.RangeParamHelper.getInstance().Write(structs.GetAmountRange(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderCategory() != null) {
				
				oprot.WriteFieldBegin("orderCategory");
				oprot.WriteI32((int)structs.GetOrderCategory()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSnType() != null) {
				
				oprot.WriteFieldBegin("snType");
				oprot.WriteString(structs.GetSnType());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAuditTimeRange() != null) {
				
				oprot.WriteFieldBegin("auditTimeRange");
				
				com.vip.order.common.pojo.order.request.RangeParamHelper.getInstance().Write(structs.GetAuditTimeRange(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIsFirst() != null) {
				
				oprot.WriteFieldBegin("isFirst");
				oprot.WriteI32((int)structs.GetIsFirst()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIsLock() != null) {
				
				oprot.WriteFieldBegin("isLock");
				oprot.WriteI32((int)structs.GetIsLock()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIp() != null) {
				
				oprot.WriteFieldBegin("ip");
				oprot.WriteString(structs.GetIp());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOperator() != null) {
				
				oprot.WriteFieldBegin("operator");
				oprot.WriteString(structs.GetOperator());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDeliveryTypeList() != null) {
				
				oprot.WriteFieldBegin("deliveryTypeList");
				
				oprot.WriteListBegin();
				foreach(int _item0 in structs.GetDeliveryTypeList()){
					
					oprot.WriteI32((int)_item0); 
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCompensateFlagList() != null) {
				
				oprot.WriteFieldBegin("compensateFlagList");
				
				oprot.WriteListBegin();
				foreach(int _item0 in structs.GetCompensateFlagList()){
					
					oprot.WriteI32((int)_item0); 
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStoreId() != null) {
				
				oprot.WriteFieldBegin("storeId");
				oprot.WriteString(structs.GetStoreId());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(SearchOrderReq bean){
			
			
		}
		
	}
	
}