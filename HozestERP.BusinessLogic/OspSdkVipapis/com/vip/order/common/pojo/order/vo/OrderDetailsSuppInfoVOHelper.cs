using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.common.pojo.order.vo{
	
	
	
	public class OrderDetailsSuppInfoVOHelper : TBeanSerializer<OrderDetailsSuppInfoVO>
	{
		
		public static OrderDetailsSuppInfoVOHelper OBJ = new OrderDetailsSuppInfoVOHelper();
		
		public static OrderDetailsSuppInfoVOHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderDetailsSuppInfoVO structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("payTypeName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPayTypeName(value);
					}
					
					
					
					
					
					if ("realPayTypeName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRealPayTypeName(value);
					}
					
					
					
					
					
					if ("mulPayTypeName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMulPayTypeName(value);
					}
					
					
					
					
					
					if ("orderStatusName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrderStatusName(value);
					}
					
					
					
					
					
					if ("haitaoStatusName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetHaitaoStatusName(value);
					}
					
					
					
					
					
					if ("orderTypeName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrderTypeName(value);
					}
					
					
					
					
					
					if ("payStatusName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPayStatusName(value);
					}
					
					
					
					
					
					if ("areaFlagName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAreaFlagName(value);
					}
					
					
					
					
					
					if ("virtualIntegral".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVirtualIntegral(value);
					}
					
					
					
					
					
					if ("clientType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetClientType(value);
					}
					
					
					
					
					
					if ("isCartSplitOrder".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetIsCartSplitOrder(value);
					}
					
					
					
					
					
					if ("splitOrders".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSplitOrders(value);
					}
					
					
					
					
					
					if ("originSns".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOriginSns(value);
					}
					
					
					
					
					
					if ("oxoSubSns".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOxoSubSns(value);
					}
					
					
					
					
					
					if ("totalPacketRefundMoney".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTotalPacketRefundMoney(value);
					}
					
					
					
					
					
					if ("totalPacketMoney".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTotalPacketMoney(value);
					}
					
					
					
					
					
					if ("lastPayType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetLastPayType(value);
					}
					
					
					
					
					
					if ("needSplit".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetNeedSplit(value);
					}
					
					
					
					
					
					if ("splitParentSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSplitParentSn(value);
					}
					
					
					
					
					
					if ("splitChildrenSns".Equals(schemeField.Trim())){
						
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
						
						structs.SetSplitChildrenSns(value);
					}
					
					
					
					
					
					if ("exchangeOriginOrdersn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetExchangeOriginOrdersn(value);
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
		
		
		public void Write(OrderDetailsSuppInfoVO structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetPayTypeName() != null) {
				
				oprot.WriteFieldBegin("payTypeName");
				oprot.WriteString(structs.GetPayTypeName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRealPayTypeName() != null) {
				
				oprot.WriteFieldBegin("realPayTypeName");
				oprot.WriteString(structs.GetRealPayTypeName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMulPayTypeName() != null) {
				
				oprot.WriteFieldBegin("mulPayTypeName");
				oprot.WriteString(structs.GetMulPayTypeName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderStatusName() != null) {
				
				oprot.WriteFieldBegin("orderStatusName");
				oprot.WriteString(structs.GetOrderStatusName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetHaitaoStatusName() != null) {
				
				oprot.WriteFieldBegin("haitaoStatusName");
				oprot.WriteString(structs.GetHaitaoStatusName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderTypeName() != null) {
				
				oprot.WriteFieldBegin("orderTypeName");
				oprot.WriteString(structs.GetOrderTypeName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPayStatusName() != null) {
				
				oprot.WriteFieldBegin("payStatusName");
				oprot.WriteString(structs.GetPayStatusName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAreaFlagName() != null) {
				
				oprot.WriteFieldBegin("areaFlagName");
				oprot.WriteString(structs.GetAreaFlagName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVirtualIntegral() != null) {
				
				oprot.WriteFieldBegin("virtualIntegral");
				oprot.WriteString(structs.GetVirtualIntegral());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetClientType() != null) {
				
				oprot.WriteFieldBegin("clientType");
				oprot.WriteI32((int)structs.GetClientType()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIsCartSplitOrder() != null) {
				
				oprot.WriteFieldBegin("isCartSplitOrder");
				oprot.WriteI32((int)structs.GetIsCartSplitOrder()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSplitOrders() != null) {
				
				oprot.WriteFieldBegin("splitOrders");
				oprot.WriteString(structs.GetSplitOrders());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOriginSns() != null) {
				
				oprot.WriteFieldBegin("originSns");
				oprot.WriteString(structs.GetOriginSns());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOxoSubSns() != null) {
				
				oprot.WriteFieldBegin("oxoSubSns");
				oprot.WriteString(structs.GetOxoSubSns());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTotalPacketRefundMoney() != null) {
				
				oprot.WriteFieldBegin("totalPacketRefundMoney");
				oprot.WriteString(structs.GetTotalPacketRefundMoney());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTotalPacketMoney() != null) {
				
				oprot.WriteFieldBegin("totalPacketMoney");
				oprot.WriteString(structs.GetTotalPacketMoney());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetLastPayType() != null) {
				
				oprot.WriteFieldBegin("lastPayType");
				oprot.WriteI32((int)structs.GetLastPayType()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetNeedSplit() != null) {
				
				oprot.WriteFieldBegin("needSplit");
				oprot.WriteI32((int)structs.GetNeedSplit()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSplitParentSn() != null) {
				
				oprot.WriteFieldBegin("splitParentSn");
				oprot.WriteString(structs.GetSplitParentSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSplitChildrenSns() != null) {
				
				oprot.WriteFieldBegin("splitChildrenSns");
				
				oprot.WriteListBegin();
				foreach(string _item0 in structs.GetSplitChildrenSns()){
					
					oprot.WriteString(_item0);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetExchangeOriginOrdersn() != null) {
				
				oprot.WriteFieldBegin("exchangeOriginOrdersn");
				oprot.WriteString(structs.GetExchangeOriginOrdersn());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderDetailsSuppInfoVO bean){
			
			
		}
		
	}
	
}