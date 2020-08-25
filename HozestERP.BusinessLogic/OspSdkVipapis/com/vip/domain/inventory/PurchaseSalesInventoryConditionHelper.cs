using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.domain.inventory{
	
	
	
	public class PurchaseSalesInventoryConditionHelper : TBeanSerializer<PurchaseSalesInventoryCondition>
	{
		
		public static PurchaseSalesInventoryConditionHelper OBJ = new PurchaseSalesInventoryConditionHelper();
		
		public static PurchaseSalesInventoryConditionHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(PurchaseSalesInventoryCondition structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("query_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.domain.inventory.PurchaseSalesInventoryQueryType? value;
						
						value = com.vip.domain.inventory.PurchaseSalesInventoryQueryTypeUtil.FindByName(iprot.ReadString());
						
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
					
					
					
					
					
					if ("start_date".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStart_date(value);
					}
					
					
					
					
					
					if ("end_date".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetEnd_date(value);
					}
					
					
					
					
					
					if ("item_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetItem_code(value);
					}
					
					
					
					
					
					if ("pay_category".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPay_category(value);
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
		
		
		public void Write(PurchaseSalesInventoryCondition structs, Protocol oprot){
			
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
			
			
			if(structs.GetStart_date() != null) {
				
				oprot.WriteFieldBegin("start_date");
				oprot.WriteString(structs.GetStart_date());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("start_date can not be null!");
			}
			
			
			if(structs.GetEnd_date() != null) {
				
				oprot.WriteFieldBegin("end_date");
				oprot.WriteString(structs.GetEnd_date());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("end_date can not be null!");
			}
			
			
			if(structs.GetItem_code() != null) {
				
				oprot.WriteFieldBegin("item_code");
				oprot.WriteString(structs.GetItem_code());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPay_category() != null) {
				
				oprot.WriteFieldBegin("pay_category");
				oprot.WriteString(structs.GetPay_category());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(PurchaseSalesInventoryCondition bean){
			
			
		}
		
	}
	
}