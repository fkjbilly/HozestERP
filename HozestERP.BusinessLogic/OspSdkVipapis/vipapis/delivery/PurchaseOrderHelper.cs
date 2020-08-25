using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.delivery{
	
	
	
	public class PurchaseOrderHelper : TBeanSerializer<PurchaseOrder>
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
					
					
					
					
					
					if ("trade_mode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTrade_mode(value);
					}
					
					
					
					
					
					if ("schedule_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSchedule_id(value);
					}
					
					
					
					
					
					if ("vendor_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendor_name(value);
					}
					
					
					
					
					
					if ("brand_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBrand_name(value);
					}
					
					
					
					
					
					if ("warehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouse(value);
					}
					
					
					
					
					
					if ("schedule_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSchedule_name(value);
					}
					
					
					
					
					
					if ("po_start_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPo_start_time(value);
					}
					
					
					
					
					
					if ("unpick_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.delivery.UnpickInfo> value;
						
						value = new List<vipapis.delivery.UnpickInfo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.delivery.UnpickInfo elem1;
								
								elem1 = new vipapis.delivery.UnpickInfo();
								vipapis.delivery.UnpickInfoHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetUnpick_list(value);
					}
					
					
					
					
					
					if ("cooperation_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCooperation_no(value);
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
			
			
			if(structs.GetTrade_mode() != null) {
				
				oprot.WriteFieldBegin("trade_mode");
				oprot.WriteString(structs.GetTrade_mode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSchedule_id() != null) {
				
				oprot.WriteFieldBegin("schedule_id");
				oprot.WriteString(structs.GetSchedule_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVendor_name() != null) {
				
				oprot.WriteFieldBegin("vendor_name");
				oprot.WriteString(structs.GetVendor_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBrand_name() != null) {
				
				oprot.WriteFieldBegin("brand_name");
				oprot.WriteString(structs.GetBrand_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWarehouse() != null) {
				
				oprot.WriteFieldBegin("warehouse");
				oprot.WriteString(structs.GetWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSchedule_name() != null) {
				
				oprot.WriteFieldBegin("schedule_name");
				oprot.WriteString(structs.GetSchedule_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPo_start_time() != null) {
				
				oprot.WriteFieldBegin("po_start_time");
				oprot.WriteString(structs.GetPo_start_time());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUnpick_list() != null) {
				
				oprot.WriteFieldBegin("unpick_list");
				
				oprot.WriteListBegin();
				foreach(vipapis.delivery.UnpickInfo _item0 in structs.GetUnpick_list()){
					
					
					vipapis.delivery.UnpickInfoHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCooperation_no() != null) {
				
				oprot.WriteFieldBegin("cooperation_no");
				oprot.WriteString(structs.GetCooperation_no());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(PurchaseOrder bean){
			
			
		}
		
	}
	
}