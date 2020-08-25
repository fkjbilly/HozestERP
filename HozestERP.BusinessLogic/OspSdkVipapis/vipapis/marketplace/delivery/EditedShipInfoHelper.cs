using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.marketplace.delivery{
	
	
	
	public class EditedShipInfoHelper : TBeanSerializer<EditedShipInfo>
	{
		
		public static EditedShipInfoHelper OBJ = new EditedShipInfoHelper();
		
		public static EditedShipInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(EditedShipInfo structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("carrier_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCarrier_code(value);
					}
					
					
					
					
					
					if ("carrier_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCarrier_name(value);
					}
					
					
					
					
					
					if ("package_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetPackage_type(value);
					}
					
					
					
					
					
					if ("create_by".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCreate_by(value);
					}
					
					
					
					
					
					if ("edited_packages".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.marketplace.delivery.EditedPackage> value;
						
						value = new List<vipapis.marketplace.delivery.EditedPackage>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.marketplace.delivery.EditedPackage elem0;
								
								elem0 = new vipapis.marketplace.delivery.EditedPackage();
								vipapis.marketplace.delivery.EditedPackageHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetEdited_packages(value);
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
		
		
		public void Write(EditedShipInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrder_id() != null) {
				
				oprot.WriteFieldBegin("order_id");
				oprot.WriteString(structs.GetOrder_id());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("order_id can not be null!");
			}
			
			
			if(structs.GetCarrier_code() != null) {
				
				oprot.WriteFieldBegin("carrier_code");
				oprot.WriteString(structs.GetCarrier_code());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("carrier_code can not be null!");
			}
			
			
			if(structs.GetCarrier_name() != null) {
				
				oprot.WriteFieldBegin("carrier_name");
				oprot.WriteString(structs.GetCarrier_name());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("carrier_name can not be null!");
			}
			
			
			if(structs.GetPackage_type() != null) {
				
				oprot.WriteFieldBegin("package_type");
				oprot.WriteI32((int)structs.GetPackage_type()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("package_type can not be null!");
			}
			
			
			if(structs.GetCreate_by() != null) {
				
				oprot.WriteFieldBegin("create_by");
				oprot.WriteString(structs.GetCreate_by());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetEdited_packages() != null) {
				
				oprot.WriteFieldBegin("edited_packages");
				
				oprot.WriteListBegin();
				foreach(vipapis.marketplace.delivery.EditedPackage _item0 in structs.GetEdited_packages()){
					
					
					vipapis.marketplace.delivery.EditedPackageHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("edited_packages can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(EditedShipInfo bean){
			
			
		}
		
	}
	
}