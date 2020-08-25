using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.price{
	
	
	
	public class UpdatePriceApplicationRequestHelper : TBeanSerializer<UpdatePriceApplicationRequest>
	{
		
		public static UpdatePriceApplicationRequestHelper OBJ = new UpdatePriceApplicationRequestHelper();
		
		public static UpdatePriceApplicationRequestHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(UpdatePriceApplicationRequest structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("vendor_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetVendor_id(value);
					}
					
					
					
					
					
					if ("price_details".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.price.UpdatePriceApplicationDetail> value;
						
						value = new List<vipapis.price.UpdatePriceApplicationDetail>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.price.UpdatePriceApplicationDetail elem1;
								
								elem1 = new vipapis.price.UpdatePriceApplicationDetail();
								vipapis.price.UpdatePriceApplicationDetailHelper.getInstance().Read(elem1, iprot);
								
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
		
		
		public void Write(UpdatePriceApplicationRequest structs, Protocol oprot){
			
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
			
			
			if(structs.GetVendor_id() != null) {
				
				oprot.WriteFieldBegin("vendor_id");
				oprot.WriteI32((int)structs.GetVendor_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("vendor_id can not be null!");
			}
			
			
			if(structs.GetPrice_details() != null) {
				
				oprot.WriteFieldBegin("price_details");
				
				oprot.WriteListBegin();
				foreach(vipapis.price.UpdatePriceApplicationDetail _item0 in structs.GetPrice_details()){
					
					
					vipapis.price.UpdatePriceApplicationDetailHelper.getInstance().Write(_item0, oprot);
					
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
		
		
		public void Validate(UpdatePriceApplicationRequest bean){
			
			
		}
		
	}
	
}