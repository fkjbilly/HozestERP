using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.overseas{
	
	
	
	public class ReturnOutInfoHelper : TBeanSerializer<ReturnOutInfo>
	{
		
		public static ReturnOutInfoHelper OBJ = new ReturnOutInfoHelper();
		
		public static ReturnOutInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ReturnOutInfo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("transaction_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransaction_id(value);
					}
					
					
					
					
					
					if ("vendor_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendor_code(value);
					}
					
					
					
					
					
					if ("return_sn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReturn_sn(value);
					}
					
					
					
					
					
					if ("out_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOut_time(value);
					}
					
					
					
					
					
					if ("total_cases".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetTotal_cases(value);
					}
					
					
					
					
					
					if ("total_skus".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetTotal_skus(value);
					}
					
					
					
					
					
					if ("total_num".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetTotal_num(value);
					}
					
					
					
					
					
					if ("order_detail_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.overseas.ReturnOutDetail> value;
						
						value = new List<vipapis.overseas.ReturnOutDetail>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.overseas.ReturnOutDetail elem1;
								
								elem1 = new vipapis.overseas.ReturnOutDetail();
								vipapis.overseas.ReturnOutDetailHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrder_detail_list(value);
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
		
		
		public void Write(ReturnOutInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetTransaction_id() != null) {
				
				oprot.WriteFieldBegin("transaction_id");
				oprot.WriteString(structs.GetTransaction_id());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("transaction_id can not be null!");
			}
			
			
			if(structs.GetVendor_code() != null) {
				
				oprot.WriteFieldBegin("vendor_code");
				oprot.WriteString(structs.GetVendor_code());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("vendor_code can not be null!");
			}
			
			
			if(structs.GetReturn_sn() != null) {
				
				oprot.WriteFieldBegin("return_sn");
				oprot.WriteString(structs.GetReturn_sn());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("return_sn can not be null!");
			}
			
			
			if(structs.GetOut_time() != null) {
				
				oprot.WriteFieldBegin("out_time");
				oprot.WriteString(structs.GetOut_time());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("out_time can not be null!");
			}
			
			
			if(structs.GetTotal_cases() != null) {
				
				oprot.WriteFieldBegin("total_cases");
				oprot.WriteI32((int)structs.GetTotal_cases()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("total_cases can not be null!");
			}
			
			
			if(structs.GetTotal_skus() != null) {
				
				oprot.WriteFieldBegin("total_skus");
				oprot.WriteI32((int)structs.GetTotal_skus()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("total_skus can not be null!");
			}
			
			
			if(structs.GetTotal_num() != null) {
				
				oprot.WriteFieldBegin("total_num");
				oprot.WriteI32((int)structs.GetTotal_num()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("total_num can not be null!");
			}
			
			
			if(structs.GetOrder_detail_list() != null) {
				
				oprot.WriteFieldBegin("order_detail_list");
				
				oprot.WriteListBegin();
				foreach(vipapis.overseas.ReturnOutDetail _item0 in structs.GetOrder_detail_list()){
					
					
					vipapis.overseas.ReturnOutDetailHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("order_detail_list can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ReturnOutInfo bean){
			
			
		}
		
	}
	
}