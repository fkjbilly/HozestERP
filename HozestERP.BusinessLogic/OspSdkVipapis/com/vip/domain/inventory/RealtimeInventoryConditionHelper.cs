using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.domain.inventory{
	
	
	
	public class RealtimeInventoryConditionHelper : TBeanSerializer<RealtimeInventoryCondition>
	{
		
		public static RealtimeInventoryConditionHelper OBJ = new RealtimeInventoryConditionHelper();
		
		public static RealtimeInventoryConditionHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(RealtimeInventoryCondition structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("query_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.domain.inventory.RealtimeInventoryQueryType? value;
						
						value = com.vip.domain.inventory.RealtimeInventoryQueryTypeUtil.FindByName(iprot.ReadString());
						
						structs.SetQuery_type(value);
					}
					
					
					
					
					
					if ("distribution_model".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.domain.inventory.DistributionModel? value;
						
						value = com.vip.domain.inventory.DistributionModelUtil.FindByName(iprot.ReadString());
						
						structs.SetDistribution_model(value);
					}
					
					
					
					
					
					if ("warehouse_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.domain.inventory.WarehouseCode? value;
						
						value = com.vip.domain.inventory.WarehouseCodeUtil.FindByName(iprot.ReadString());
						
						structs.SetWarehouse_code(value);
					}
					
					
					
					
					
					if ("po_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPo_no(value);
					}
					
					
					
					
					
					if ("brand_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBrand_code(value);
					}
					
					
					
					
					
					if ("inventory_location_parameter".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.domain.inventory.RealtimeInventoryLocationParameter? value;
						
						value = com.vip.domain.inventory.RealtimeInventoryLocationParameterUtil.FindByName(iprot.ReadString());
						
						structs.SetInventory_location_parameter(value);
					}
					
					
					
					
					
					if ("commodity_parameter".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.domain.inventory.RealtimeInventoryCommodityParameter? value;
						
						value = com.vip.domain.inventory.RealtimeInventoryCommodityParameterUtil.FindByName(iprot.ReadString());
						
						structs.SetCommodity_parameter(value);
					}
					
					
					
					
					
					if ("item_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetItem_code(value);
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
		
		
		public void Write(RealtimeInventoryCondition structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetQuery_type() != null) {
				
				oprot.WriteFieldBegin("query_type");
				oprot.WriteString(structs.GetQuery_type().ToString());  
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("query_type can not be null!");
			}
			
			
			if(structs.GetDistribution_model() != null) {
				
				oprot.WriteFieldBegin("distribution_model");
				oprot.WriteString(structs.GetDistribution_model().ToString());  
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("distribution_model can not be null!");
			}
			
			
			if(structs.GetWarehouse_code() != null) {
				
				oprot.WriteFieldBegin("warehouse_code");
				oprot.WriteString(structs.GetWarehouse_code().ToString());  
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("warehouse_code can not be null!");
			}
			
			
			if(structs.GetPo_no() != null) {
				
				oprot.WriteFieldBegin("po_no");
				oprot.WriteString(structs.GetPo_no());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBrand_code() != null) {
				
				oprot.WriteFieldBegin("brand_code");
				oprot.WriteString(structs.GetBrand_code());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetInventory_location_parameter() != null) {
				
				oprot.WriteFieldBegin("inventory_location_parameter");
				oprot.WriteString(structs.GetInventory_location_parameter().ToString());  
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("inventory_location_parameter can not be null!");
			}
			
			
			if(structs.GetCommodity_parameter() != null) {
				
				oprot.WriteFieldBegin("commodity_parameter");
				oprot.WriteString(structs.GetCommodity_parameter().ToString());  
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("commodity_parameter can not be null!");
			}
			
			
			if(structs.GetItem_code() != null) {
				
				oprot.WriteFieldBegin("item_code");
				oprot.WriteString(structs.GetItem_code());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(RealtimeInventoryCondition bean){
			
			
		}
		
	}
	
}