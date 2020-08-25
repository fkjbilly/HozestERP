using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.domain.inventory{
	
	
	
	public class ChannelInventoryQueryConditionHelper : TBeanSerializer<ChannelInventoryQueryCondition>
	{
		
		public static ChannelInventoryQueryConditionHelper OBJ = new ChannelInventoryQueryConditionHelper();
		
		public static ChannelInventoryQueryConditionHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ChannelInventoryQueryCondition structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("warehouse_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.domain.inventory.WarehouseCode? value;
						
						value = com.vip.domain.inventory.WarehouseCodeUtil.FindByName(iprot.ReadString());
						
						structs.SetWarehouse_code(value);
					}
					
					
					
					
					
					if ("channel".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.domain.inventory.ChannelInventoryChannel? value;
						
						value = com.vip.domain.inventory.ChannelInventoryChannelUtil.FindByName(iprot.ReadString());
						
						structs.SetChannel(value);
					}
					
					
					
					
					
					if ("grade".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.domain.inventory.ChannelInventoryGrade?> value;
						
						value = new List<com.vip.domain.inventory.ChannelInventoryGrade?>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.domain.inventory.ChannelInventoryGrade? elem1;
								
								elem1 = com.vip.domain.inventory.ChannelInventoryGradeUtil.FindByName(iprot.ReadString());
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetGrade(value);
					}
					
					
					
					
					
					if ("status".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.domain.inventory.ChannelInventoryStatus? value;
						
						value = com.vip.domain.inventory.ChannelInventoryStatusUtil.FindByName(iprot.ReadString());
						
						structs.SetStatus(value);
					}
					
					
					
					
					
					if ("item_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetItem_code(value);
					}
					
					
					
					
					
					if ("brand_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBrand_code(value);
					}
					
					
					
					
					
					if ("in_vip_sales_plan".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.domain.inventory.ChannelInventoryInVipSalesPlan? value;
						
						value = com.vip.domain.inventory.ChannelInventoryInVipSalesPlanUtil.FindByName(iprot.ReadString());
						
						structs.SetIn_vip_sales_plan(value);
					}
					
					
					
					
					
					if ("pageToward".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetPageToward(value);
					}
					
					
					
					
					
					if ("backwardId".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBackwardId(value);
					}
					
					
					
					
					
					if ("forwardId".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetForwardId(value);
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
		
		
		public void Write(ChannelInventoryQueryCondition structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetWarehouse_code() != null) {
				
				oprot.WriteFieldBegin("warehouse_code");
				oprot.WriteString(structs.GetWarehouse_code().ToString());  
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("warehouse_code can not be null!");
			}
			
			
			if(structs.GetChannel() != null) {
				
				oprot.WriteFieldBegin("channel");
				oprot.WriteString(structs.GetChannel().ToString());  
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("channel can not be null!");
			}
			
			
			if(structs.GetGrade() != null) {
				
				oprot.WriteFieldBegin("grade");
				
				oprot.WriteListBegin();
				foreach(com.vip.domain.inventory.ChannelInventoryGrade? _item0 in structs.GetGrade()){
					
					oprot.WriteString(_item0.ToString());  
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("grade can not be null!");
			}
			
			
			if(structs.GetStatus() != null) {
				
				oprot.WriteFieldBegin("status");
				oprot.WriteString(structs.GetStatus().ToString());  
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetItem_code() != null) {
				
				oprot.WriteFieldBegin("item_code");
				oprot.WriteString(structs.GetItem_code());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBrand_code() != null) {
				
				oprot.WriteFieldBegin("brand_code");
				oprot.WriteString(structs.GetBrand_code());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIn_vip_sales_plan() != null) {
				
				oprot.WriteFieldBegin("in_vip_sales_plan");
				oprot.WriteString(structs.GetIn_vip_sales_plan().ToString());  
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPageToward() != null) {
				
				oprot.WriteFieldBegin("pageToward");
				oprot.WriteI32((int)structs.GetPageToward()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBackwardId() != null) {
				
				oprot.WriteFieldBegin("backwardId");
				oprot.WriteString(structs.GetBackwardId());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetForwardId() != null) {
				
				oprot.WriteFieldBegin("forwardId");
				oprot.WriteString(structs.GetForwardId());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ChannelInventoryQueryCondition bean){
			
			
		}
		
	}
	
}