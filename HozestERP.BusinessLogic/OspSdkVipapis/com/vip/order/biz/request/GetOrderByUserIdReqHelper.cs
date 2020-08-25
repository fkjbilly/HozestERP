using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class GetOrderByUserIdReqHelper : TBeanSerializer<GetOrderByUserIdReq>
	{
		
		public static GetOrderByUserIdReqHelper OBJ = new GetOrderByUserIdReqHelper();
		
		public static GetOrderByUserIdReqHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetOrderByUserIdReq structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("userId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetUserId(value);
					}
					
					
					
					
					
					if ("orderIdList".Equals(schemeField.Trim())){
						
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
						
						structs.SetOrderIdList(value);
					}
					
					
					
					
					
					if ("orderSnList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<string> value;
						
						value = new List<string>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								string elem1;
								elem1 = iprot.ReadString();
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderSnList(value);
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
					
					
					
					
					
					if ("saleType".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<int?> value;
						
						value = new List<int?>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								int elem2;
								elem2 = iprot.ReadI32(); 
								
								value.Add(elem2);
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
								
								int elem4;
								elem4 = iprot.ReadI32(); 
								
								value.Add(elem4);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderModelList(value);
					}
					
					
					
					
					
					if ("vipclubList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<string> value;
						
						value = new List<string>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								string elem5;
								elem5 = iprot.ReadString();
								
								value.Add(elem5);
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
					
					
					
					
					
					if ("deliveryTypeList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<int?> value;
						
						value = new List<int?>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								int elem11;
								elem11 = iprot.ReadI32(); 
								
								value.Add(elem11);
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
								
								int elem12;
								elem12 = iprot.ReadI32(); 
								
								value.Add(elem12);
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
		
		
		public void Write(GetOrderByUserIdReq structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetUserId() != null) {
				
				oprot.WriteFieldBegin("userId");
				oprot.WriteI64((long)structs.GetUserId()); 
				
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
		
		
		public void Validate(GetOrderByUserIdReq bean){
			
			
		}
		
	}
	
}