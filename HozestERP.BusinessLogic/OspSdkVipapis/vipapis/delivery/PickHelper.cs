using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.delivery{
	
	
	
	public class PickHelper : TBeanSerializer<Pick>
	{
		
		public static PickHelper OBJ = new PickHelper();
		
		public static PickHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(Pick structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("pick_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPick_no(value);
					}
					
					
					
					
					
					if ("co_mode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCo_mode(value);
					}
					
					
					
					
					
					if ("sell_site".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSell_site(value);
					}
					
					
					
					
					
					if ("order_cate".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrder_cate(value);
					}
					
					
					
					
					
					if ("pick_num".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetPick_num(value);
					}
					
					
					
					
					
					if ("create_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCreate_time(value);
					}
					
					
					
					
					
					if ("first_export_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetFirst_export_time(value);
					}
					
					
					
					
					
					if ("export_num".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetExport_num(value);
					}
					
					
					
					
					
					if ("delivery_status".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetDelivery_status(value);
					}
					
					
					
					
					
					if ("store_sn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStore_sn(value);
					}
					
					
					
					
					
					if ("delivery_num".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetDelivery_num(value);
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
		
		
		public void Write(Pick structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetPo_no() != null) {
				
				oprot.WriteFieldBegin("po_no");
				oprot.WriteString(structs.GetPo_no());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPick_no() != null) {
				
				oprot.WriteFieldBegin("pick_no");
				oprot.WriteString(structs.GetPick_no());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCo_mode() != null) {
				
				oprot.WriteFieldBegin("co_mode");
				oprot.WriteString(structs.GetCo_mode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSell_site() != null) {
				
				oprot.WriteFieldBegin("sell_site");
				oprot.WriteString(structs.GetSell_site());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrder_cate() != null) {
				
				oprot.WriteFieldBegin("order_cate");
				oprot.WriteString(structs.GetOrder_cate());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPick_num() != null) {
				
				oprot.WriteFieldBegin("pick_num");
				oprot.WriteI32((int)structs.GetPick_num()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCreate_time() != null) {
				
				oprot.WriteFieldBegin("create_time");
				oprot.WriteString(structs.GetCreate_time());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFirst_export_time() != null) {
				
				oprot.WriteFieldBegin("first_export_time");
				oprot.WriteString(structs.GetFirst_export_time());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetExport_num() != null) {
				
				oprot.WriteFieldBegin("export_num");
				oprot.WriteI32((int)structs.GetExport_num()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDelivery_status() != null) {
				
				oprot.WriteFieldBegin("delivery_status");
				oprot.WriteI32((int)structs.GetDelivery_status()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStore_sn() != null) {
				
				oprot.WriteFieldBegin("store_sn");
				oprot.WriteString(structs.GetStore_sn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDelivery_num() != null) {
				
				oprot.WriteFieldBegin("delivery_num");
				oprot.WriteI32((int)structs.GetDelivery_num()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(Pick bean){
			
			
		}
		
	}
	
}