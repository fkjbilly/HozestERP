using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.address{
	
	
	
	public class ProvinceWarehouseHelper : BeanSerializer<ProvinceWarehouse>
	{
		
		public static ProvinceWarehouseHelper OBJ = new ProvinceWarehouseHelper();
		
		public static ProvinceWarehouseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ProvinceWarehouse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("warehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouse(value);
					}
					
					
					
					
					
					if ("children".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.address.City> value;
						
						value = new List<vipapis.address.City>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.address.City elem0;
								
								elem0 = new vipapis.address.City();
								vipapis.address.CityHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetChildren(value);
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
		
		
		public void Write(ProvinceWarehouse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetWarehouse() != null) {
				
				oprot.WriteFieldBegin("warehouse");
				oprot.WriteString(structs.GetWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("warehouse can not be null!");
			}
			
			
			if(structs.GetChildren() != null) {
				
				oprot.WriteFieldBegin("children");
				
				oprot.WriteListBegin();
				foreach(vipapis.address.City _item0 in structs.GetChildren()){
					
					
					vipapis.address.CityHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("children can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ProvinceWarehouse bean){
			
			
		}
		
	}
	
}