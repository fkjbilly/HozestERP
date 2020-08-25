using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.price{
	
	
	
	public class GetPriceApplicationResponseHelper : TBeanSerializer<GetPriceApplicationResponse>
	{
		
		public static GetPriceApplicationResponseHelper OBJ = new GetPriceApplicationResponseHelper();
		
		public static GetPriceApplicationResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetPriceApplicationResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("application_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetApplication_id(value);
					}
					
					
					
					
					
					if ("total".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetTotal(value);
					}
					
					
					
					
					
					if ("status".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStatus(value);
					}
					
					
					
					
					
					if ("exception_status".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetException_status(value);
					}
					
					
					
					
					
					if ("effective_start_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						System.DateTime? value;
						value = Osp.Sdk.Util.TimeUtil.FromUnixTime(iprot.ReadI64()); 
						
						structs.SetEffective_start_time(value);
					}
					
					
					
					
					
					if ("effective_end_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						System.DateTime? value;
						value = Osp.Sdk.Util.TimeUtil.FromUnixTime(iprot.ReadI64()); 
						
						structs.SetEffective_end_time(value);
					}
					
					
					
					
					
					if ("memo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMemo(value);
					}
					
					
					
					
					
					if ("price_details".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.price.PriceApplicationDetail> value;
						
						value = new List<vipapis.price.PriceApplicationDetail>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.price.PriceApplicationDetail elem0;
								
								elem0 = new vipapis.price.PriceApplicationDetail();
								vipapis.price.PriceApplicationDetailHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetPrice_details(value);
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
		
		
		public void Write(GetPriceApplicationResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetApplication_id() != null) {
				
				oprot.WriteFieldBegin("application_id");
				oprot.WriteString(structs.GetApplication_id());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("application_id can not be null!");
			}
			
			
			if(structs.GetTotal() != null) {
				
				oprot.WriteFieldBegin("total");
				oprot.WriteI32((int)structs.GetTotal()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStatus() != null) {
				
				oprot.WriteFieldBegin("status");
				oprot.WriteString(structs.GetStatus());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetException_status() != null) {
				
				oprot.WriteFieldBegin("exception_status");
				oprot.WriteString(structs.GetException_status());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetEffective_start_time() != null) {
				
				oprot.WriteFieldBegin("effective_start_time");
				oprot.WriteI64(Osp.Sdk.Util.TimeUtil.ToUnixTime((System.DateTime)structs.GetEffective_start_time())); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetEffective_end_time() != null) {
				
				oprot.WriteFieldBegin("effective_end_time");
				oprot.WriteI64(Osp.Sdk.Util.TimeUtil.ToUnixTime((System.DateTime)structs.GetEffective_end_time())); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMemo() != null) {
				
				oprot.WriteFieldBegin("memo");
				oprot.WriteString(structs.GetMemo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPrice_details() != null) {
				
				oprot.WriteFieldBegin("price_details");
				
				oprot.WriteListBegin();
				foreach(vipapis.price.PriceApplicationDetail _item0 in structs.GetPrice_details()){
					
					
					vipapis.price.PriceApplicationDetailHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetPriceApplicationResponse bean){
			
			
		}
		
	}
	
}