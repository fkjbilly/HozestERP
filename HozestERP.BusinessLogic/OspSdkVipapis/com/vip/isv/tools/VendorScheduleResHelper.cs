using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.isv.tools{
	
	
	
	public class VendorScheduleResHelper : TBeanSerializer<VendorScheduleRes>
	{
		
		public static VendorScheduleResHelper OBJ = new VendorScheduleResHelper();
		
		public static VendorScheduleResHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(VendorScheduleRes structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("vendorScheduleDos".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.isv.tools.VendorScheduleDo> value;
						
						value = new List<com.vip.isv.tools.VendorScheduleDo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.isv.tools.VendorScheduleDo elem0;
								
								elem0 = new com.vip.isv.tools.VendorScheduleDo();
								com.vip.isv.tools.VendorScheduleDoHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetVendorScheduleDos(value);
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
		
		
		public void Write(VendorScheduleRes structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetVendorScheduleDos() != null) {
				
				oprot.WriteFieldBegin("vendorScheduleDos");
				
				oprot.WriteListBegin();
				foreach(com.vip.isv.tools.VendorScheduleDo _item0 in structs.GetVendorScheduleDos()){
					
					
					com.vip.isv.tools.VendorScheduleDoHelper.getInstance().Write(_item0, oprot);
					
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
		
		
		public void Validate(VendorScheduleRes bean){
			
			
		}
		
	}
	
}