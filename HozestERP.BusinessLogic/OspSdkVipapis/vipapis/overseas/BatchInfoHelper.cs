using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.overseas{
	
	
	
	public class BatchInfoHelper : TBeanSerializer<BatchInfo>
	{
		
		public static BatchInfoHelper OBJ = new BatchInfoHelper();
		
		public static BatchInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(BatchInfo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("vendor_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendor_id(value);
					}
					
					
					
					
					
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
					
					
					
					
					
					if ("trade_mode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTrade_mode(value);
					}
					
					
					
					
					
					if ("pallet".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPallet(value);
					}
					
					
					
					
					
					if ("schedule_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSchedule_id(value);
					}
					
					
					
					
					
					if ("product_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.overseas.BatchDetailInfo> value;
						
						value = new List<vipapis.overseas.BatchDetailInfo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.overseas.BatchDetailInfo elem0;
								
								elem0 = new vipapis.overseas.BatchDetailInfo();
								vipapis.overseas.BatchDetailInfoHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetProduct_list(value);
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
		
		
		public void Write(BatchInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetVendor_id() != null) {
				
				oprot.WriteFieldBegin("vendor_id");
				oprot.WriteString(structs.GetVendor_id());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("vendor_id can not be null!");
			}
			
			
			if(structs.GetPo_no() != null) {
				
				oprot.WriteFieldBegin("po_no");
				oprot.WriteString(structs.GetPo_no());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("po_no can not be null!");
			}
			
			
			if(structs.GetCo_mode() != null) {
				
				oprot.WriteFieldBegin("co_mode");
				oprot.WriteString(structs.GetCo_mode());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("co_mode can not be null!");
			}
			
			
			if(structs.GetTrade_mode() != null) {
				
				oprot.WriteFieldBegin("trade_mode");
				oprot.WriteString(structs.GetTrade_mode());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("trade_mode can not be null!");
			}
			
			
			if(structs.GetPallet() != null) {
				
				oprot.WriteFieldBegin("pallet");
				oprot.WriteString(structs.GetPallet());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSchedule_id() != null) {
				
				oprot.WriteFieldBegin("schedule_id");
				oprot.WriteString(structs.GetSchedule_id());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("schedule_id can not be null!");
			}
			
			
			if(structs.GetProduct_list() != null) {
				
				oprot.WriteFieldBegin("product_list");
				
				oprot.WriteListBegin();
				foreach(vipapis.overseas.BatchDetailInfo _item0 in structs.GetProduct_list()){
					
					
					vipapis.overseas.BatchDetailInfoHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("product_list can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(BatchInfo bean){
			
			
		}
		
	}
	
}