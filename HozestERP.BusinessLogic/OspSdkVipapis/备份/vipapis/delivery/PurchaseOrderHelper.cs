using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.delivery{
	
	
	
	public class PurchaseOrderHelper : BeanSerializer<PurchaseOrder>
	{
		
		public static PurchaseOrderHelper OBJ = new PurchaseOrderHelper();
		
		public static PurchaseOrderHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(PurchaseOrder structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("po_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPo_no(value);
					}
					
					
					
					
					
					if ("co_mode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCo_mode(value);
					}
					
					
					
					
					
					if ("sell_st_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSell_st_time(value);
					}
					
					
					
					
					
					if ("sell_et_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSell_et_time(value);
					}
					
					
					
					
					
					if ("stock".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStock(value);
					}
					
					
					
					
					
					if ("sales_volume".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSales_volume(value);
					}
					
					
					
					
					
					if ("not_pick".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetNot_pick(value);
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
		
		
		public void Write(PurchaseOrder structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetPo_no() != null) {
				
				oprot.WriteFieldBegin("po_no");
				oprot.WriteString(structs.GetPo_no());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCo_mode() != null) {
				
				oprot.WriteFieldBegin("co_mode");
				oprot.WriteString(structs.GetCo_mode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSell_st_time() != null) {
				
				oprot.WriteFieldBegin("sell_st_time");
				oprot.WriteString(structs.GetSell_st_time());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSell_et_time() != null) {
				
				oprot.WriteFieldBegin("sell_et_time");
				oprot.WriteString(structs.GetSell_et_time());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStock() != null) {
				
				oprot.WriteFieldBegin("stock");
				oprot.WriteString(structs.GetStock());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSales_volume() != null) {
				
				oprot.WriteFieldBegin("sales_volume");
				oprot.WriteString(structs.GetSales_volume());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetNot_pick() != null) {
				
				oprot.WriteFieldBegin("not_pick");
				oprot.WriteString(structs.GetNot_pick());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(PurchaseOrder bean){
			
			
		}
		
	}
	
}