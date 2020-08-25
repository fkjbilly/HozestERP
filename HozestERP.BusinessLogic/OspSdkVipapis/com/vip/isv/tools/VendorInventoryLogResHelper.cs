using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.isv.tools{
	
	
	
	public class VendorInventoryLogResHelper : TBeanSerializer<VendorInventoryLogRes>
	{
		
		public static VendorInventoryLogResHelper OBJ = new VendorInventoryLogResHelper();
		
		public static VendorInventoryLogResHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(VendorInventoryLogRes structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("vendorInventoryLogDos".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.isv.tools.VendorInventoryLogDo> value;
						
						value = new List<com.vip.isv.tools.VendorInventoryLogDo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.isv.tools.VendorInventoryLogDo elem0;
								
								elem0 = new com.vip.isv.tools.VendorInventoryLogDo();
								com.vip.isv.tools.VendorInventoryLogDoHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetVendorInventoryLogDos(value);
					}
					
					
					
					
					
					if ("totalCount".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetTotalCount(value);
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
		
		
		public void Write(VendorInventoryLogRes structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetVendorInventoryLogDos() != null) {
				
				oprot.WriteFieldBegin("vendorInventoryLogDos");
				
				oprot.WriteListBegin();
				foreach(com.vip.isv.tools.VendorInventoryLogDo _item0 in structs.GetVendorInventoryLogDos()){
					
					
					com.vip.isv.tools.VendorInventoryLogDoHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTotalCount() != null) {
				
				oprot.WriteFieldBegin("totalCount");
				oprot.WriteI32((int)structs.GetTotalCount()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("totalCount can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(VendorInventoryLogRes bean){
			
			
		}
		
	}
	
}