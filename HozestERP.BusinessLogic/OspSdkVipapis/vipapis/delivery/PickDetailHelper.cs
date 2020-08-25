using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.delivery{
	
	
	
	public class PickDetailHelper : TBeanSerializer<PickDetail>
	{
		
		public static PickDetailHelper OBJ = new PickDetailHelper();
		
		public static PickDetailHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(PickDetail structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("export_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetExport_time(value);
					}
					
					
					
					
					
					if ("export_num".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetExport_num(value);
					}
					
					
					
					
					
					if ("warehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouse(value);
					}
					
					
					
					
					
					if ("order_cate".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrder_cate(value);
					}
					
					
					
					
					
					if ("pick_product_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.delivery.PickProduct> value;
						
						value = new List<vipapis.delivery.PickProduct>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.delivery.PickProduct elem0;
								
								elem0 = new vipapis.delivery.PickProduct();
								vipapis.delivery.PickProductHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetPick_product_list(value);
					}
					
					
					
					
					
					if ("total".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetTotal(value);
					}
					
					
					
					
					
					if ("store_sn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStore_sn(value);
					}
					
					
					
					
					
					if ("jit_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetJit_type(value);
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
		
		
		public void Write(PickDetail structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetPo_no() != null) {
				
				oprot.WriteFieldBegin("po_no");
				oprot.WriteString(structs.GetPo_no());
				
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
			
			
			if(structs.GetExport_time() != null) {
				
				oprot.WriteFieldBegin("export_time");
				oprot.WriteString(structs.GetExport_time());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetExport_num() != null) {
				
				oprot.WriteFieldBegin("export_num");
				oprot.WriteI32((int)structs.GetExport_num()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWarehouse() != null) {
				
				oprot.WriteFieldBegin("warehouse");
				oprot.WriteString(structs.GetWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrder_cate() != null) {
				
				oprot.WriteFieldBegin("order_cate");
				oprot.WriteString(structs.GetOrder_cate());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPick_product_list() != null) {
				
				oprot.WriteFieldBegin("pick_product_list");
				
				oprot.WriteListBegin();
				foreach(vipapis.delivery.PickProduct _item0 in structs.GetPick_product_list()){
					
					
					vipapis.delivery.PickProductHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTotal() != null) {
				
				oprot.WriteFieldBegin("total");
				oprot.WriteI32((int)structs.GetTotal()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStore_sn() != null) {
				
				oprot.WriteFieldBegin("store_sn");
				oprot.WriteString(structs.GetStore_sn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetJit_type() != null) {
				
				oprot.WriteFieldBegin("jit_type");
				oprot.WriteI32((int)structs.GetJit_type()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(PickDetail bean){
			
			
		}
		
	}
	
}