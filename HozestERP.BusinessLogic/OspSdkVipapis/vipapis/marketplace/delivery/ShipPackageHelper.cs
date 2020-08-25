using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.marketplace.delivery{
	
	
	
	public class ShipPackageHelper : TBeanSerializer<ShipPackage>
	{
		
		public static ShipPackageHelper OBJ = new ShipPackageHelper();
		
		public static ShipPackageHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ShipPackage structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("transport_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransport_no(value);
					}
					
					
					
					
					
					if ("package_product_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.marketplace.delivery.ShipPackageProduct> value;
						
						value = new List<vipapis.marketplace.delivery.ShipPackageProduct>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.marketplace.delivery.ShipPackageProduct elem1;
								
								elem1 = new vipapis.marketplace.delivery.ShipPackageProduct();
								vipapis.marketplace.delivery.ShipPackageProductHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetPackage_product_list(value);
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
		
		
		public void Write(ShipPackage structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetTransport_no() != null) {
				
				oprot.WriteFieldBegin("transport_no");
				oprot.WriteString(structs.GetTransport_no());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("transport_no can not be null!");
			}
			
			
			if(structs.GetPackage_product_list() != null) {
				
				oprot.WriteFieldBegin("package_product_list");
				
				oprot.WriteListBegin();
				foreach(vipapis.marketplace.delivery.ShipPackageProduct _item0 in structs.GetPackage_product_list()){
					
					
					vipapis.marketplace.delivery.ShipPackageProductHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("package_product_list can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ShipPackage bean){
			
			
		}
		
	}
	
}