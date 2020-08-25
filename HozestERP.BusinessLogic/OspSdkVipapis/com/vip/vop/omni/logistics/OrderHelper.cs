using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.vop.omni.logistics{
	
	
	
	public class OrderHelper : TBeanSerializer<Order>
	{
		
		public static OrderHelper OBJ = new OrderHelper();
		
		public static OrderHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(Order structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("order_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrder_id(value);
					}
					
					
					
					
					
					if ("package_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetPackage_no(value);
					}
					
					
					
					
					
					if ("packages".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.vop.omni.logistics.Package> value;
						
						value = new List<com.vip.vop.omni.logistics.Package>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.vop.omni.logistics.Package elem0;
								
								elem0 = new com.vip.vop.omni.logistics.Package();
								com.vip.vop.omni.logistics.PackageHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetPackages(value);
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
		
		
		public void Write(Order structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrder_id() != null) {
				
				oprot.WriteFieldBegin("order_id");
				oprot.WriteString(structs.GetOrder_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPackage_no() != null) {
				
				oprot.WriteFieldBegin("package_no");
				oprot.WriteI32((int)structs.GetPackage_no()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPackages() != null) {
				
				oprot.WriteFieldBegin("packages");
				
				oprot.WriteListBegin();
				foreach(com.vip.vop.omni.logistics.Package _item0 in structs.GetPackages()){
					
					
					com.vip.vop.omni.logistics.PackageHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(Order bean){
			
			
		}
		
	}
	
}