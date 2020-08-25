using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.domain.inventory{
	
	
	
	public class InboundConditionHelper : TBeanSerializer<InboundCondition>
	{
		
		public static InboundConditionHelper OBJ = new InboundConditionHelper();
		
		public static InboundConditionHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(InboundCondition structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("query_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.domain.inventory.InboundQueryType? value;
						
						value = com.vip.domain.inventory.InboundQueryTypeUtil.FindByName(iprot.ReadString());
						
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
					
					
					
					
					
					if ("start_created_date".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStart_created_date(value);
					}
					
					
					
					
					
					if ("end_created_date".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetEnd_created_date(value);
					}
					
					
					
					
					
					if ("start_inbound_date".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStart_inbound_date(value);
					}
					
					
					
					
					
					if ("end_inbound_date".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetEnd_inbound_date(value);
					}
					
					
					
					
					
					if ("item_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetItem_code(value);
					}
					
					
					
					
					
					if ("inbound_status".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.domain.inventory.InboundStatus? value;
						
						value = com.vip.domain.inventory.InboundStatusUtil.FindByName(iprot.ReadString());
						
						structs.SetInbound_status(value);
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
		
		
		public void Write(InboundCondition structs, Protocol oprot){
			
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
			
			
			if(structs.GetStart_created_date() != null) {
				
				oprot.WriteFieldBegin("start_created_date");
				oprot.WriteString(structs.GetStart_created_date());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetEnd_created_date() != null) {
				
				oprot.WriteFieldBegin("end_created_date");
				oprot.WriteString(structs.GetEnd_created_date());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStart_inbound_date() != null) {
				
				oprot.WriteFieldBegin("start_inbound_date");
				oprot.WriteString(structs.GetStart_inbound_date());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetEnd_inbound_date() != null) {
				
				oprot.WriteFieldBegin("end_inbound_date");
				oprot.WriteString(structs.GetEnd_inbound_date());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetItem_code() != null) {
				
				oprot.WriteFieldBegin("item_code");
				oprot.WriteString(structs.GetItem_code());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetInbound_status() != null) {
				
				oprot.WriteFieldBegin("inbound_status");
				oprot.WriteString(structs.GetInbound_status().ToString());  
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(InboundCondition bean){
			
			
		}
		
	}
	
}