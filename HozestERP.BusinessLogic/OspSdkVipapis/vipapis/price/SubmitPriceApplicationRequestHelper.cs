using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.price{
	
	
	
	public class SubmitPriceApplicationRequestHelper : TBeanSerializer<SubmitPriceApplicationRequest>
	{
		
		public static SubmitPriceApplicationRequestHelper OBJ = new SubmitPriceApplicationRequestHelper();
		
		public static SubmitPriceApplicationRequestHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(SubmitPriceApplicationRequest structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("effective_start_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						System.DateTime value;
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
					
					
					
					
					
					if ("vendor_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetVendor_id(value);
					}
					
					
					
					
					
					if ("cooperation_nos".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<string> value;
						
						value = new List<string>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								string elem0;
								elem0 = iprot.ReadString();
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetCooperation_nos(value);
					}
					
					
					
					
					
					if ("price_details".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.price.SubmitPriceApplicationDetail> value;
						
						value = new List<vipapis.price.SubmitPriceApplicationDetail>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.price.SubmitPriceApplicationDetail elem1;
								
								elem1 = new vipapis.price.SubmitPriceApplicationDetail();
								vipapis.price.SubmitPriceApplicationDetailHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
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
		
		
		public void Write(SubmitPriceApplicationRequest structs, Protocol oprot){
			
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
			
			
			if(structs.GetEffective_start_time() != null) {
				
				oprot.WriteFieldBegin("effective_start_time");
				oprot.WriteI64(Osp.Sdk.Util.TimeUtil.ToUnixTime((System.DateTime)structs.GetEffective_start_time())); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("effective_start_time can not be null!");
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
			
			
			if(structs.GetVendor_id() != null) {
				
				oprot.WriteFieldBegin("vendor_id");
				oprot.WriteI32((int)structs.GetVendor_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("vendor_id can not be null!");
			}
			
			
			if(structs.GetCooperation_nos() != null) {
				
				oprot.WriteFieldBegin("cooperation_nos");
				
				oprot.WriteListBegin();
				foreach(string _item0 in structs.GetCooperation_nos()){
					
					oprot.WriteString(_item0);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("cooperation_nos can not be null!");
			}
			
			
			if(structs.GetPrice_details() != null) {
				
				oprot.WriteFieldBegin("price_details");
				
				oprot.WriteListBegin();
				foreach(vipapis.price.SubmitPriceApplicationDetail _item0 in structs.GetPrice_details()){
					
					
					vipapis.price.SubmitPriceApplicationDetailHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("price_details can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(SubmitPriceApplicationRequest bean){
			
			
		}
		
	}
	
}