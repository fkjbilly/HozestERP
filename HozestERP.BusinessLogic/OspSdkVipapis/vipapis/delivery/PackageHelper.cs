using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.delivery{
	
	
	
	public class PackageHelper : TBeanSerializer<Package>
	{
		
		public static PackageHelper OBJ = new PackageHelper();
		
		public static PackageHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(Package structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("package_product_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.delivery.PackageProduct> value;
						
						value = new List<vipapis.delivery.PackageProduct>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.delivery.PackageProduct elem1;
								
								elem1 = new vipapis.delivery.PackageProduct();
								vipapis.delivery.PackageProductHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetPackage_product_list(value);
					}
					
					
					
					
					
					if ("transport_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransport_no(value);
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
		
		
		public void Write(Package structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetPackage_product_list() != null) {
				
				oprot.WriteFieldBegin("package_product_list");
				
				oprot.WriteListBegin();
				foreach(vipapis.delivery.PackageProduct _item0 in structs.GetPackage_product_list()){
					
					
					vipapis.delivery.PackageProductHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("package_product_list can not be null!");
			}
			
			
			if(structs.GetTransport_no() != null) {
				
				oprot.WriteFieldBegin("transport_no");
				oprot.WriteString(structs.GetTransport_no());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("transport_no can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(Package bean){
			
			
		}
		
	}
	
}