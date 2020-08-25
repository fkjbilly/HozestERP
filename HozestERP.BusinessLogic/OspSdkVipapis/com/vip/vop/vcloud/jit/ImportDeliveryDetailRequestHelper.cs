using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.vop.vcloud.jit{
	
	
	
	public class ImportDeliveryDetailRequestHelper : TBeanSerializer<ImportDeliveryDetailRequest>
	{
		
		public static ImportDeliveryDetailRequestHelper OBJ = new ImportDeliveryDetailRequestHelper();
		
		public static ImportDeliveryDetailRequestHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ImportDeliveryDetailRequest structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("vendorId".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetVendorId(value);
					}
					
					
					
					
					
					if ("poNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPoNo(value);
					}
					
					
					
					
					
					if ("storageNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStorageNo(value);
					}
					
					
					
					
					
					if ("deliveryDetails".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.vop.vcloud.jit.DeliveryDetail> value;
						
						value = new List<com.vip.vop.vcloud.jit.DeliveryDetail>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.vop.vcloud.jit.DeliveryDetail elem0;
								
								elem0 = new com.vip.vop.vcloud.jit.DeliveryDetail();
								com.vip.vop.vcloud.jit.DeliveryDetailHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetDeliveryDetails(value);
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
		
		
		public void Write(ImportDeliveryDetailRequest structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetVendorId() != null) {
				
				oprot.WriteFieldBegin("vendorId");
				oprot.WriteI32((int)structs.GetVendorId()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("vendorId can not be null!");
			}
			
			
			if(structs.GetPoNo() != null) {
				
				oprot.WriteFieldBegin("poNo");
				oprot.WriteString(structs.GetPoNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStorageNo() != null) {
				
				oprot.WriteFieldBegin("storageNo");
				oprot.WriteString(structs.GetStorageNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDeliveryDetails() != null) {
				
				oprot.WriteFieldBegin("deliveryDetails");
				
				oprot.WriteListBegin();
				foreach(com.vip.vop.vcloud.jit.DeliveryDetail _item0 in structs.GetDeliveryDetails()){
					
					
					com.vip.vop.vcloud.jit.DeliveryDetailHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ImportDeliveryDetailRequest bean){
			
			
		}
		
	}
	
}