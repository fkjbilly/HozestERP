using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.dvd{
	
	
	
	public class AreaOccupiedOrderHelper : TBeanSerializer<AreaOccupiedOrder>
	{
		
		public static AreaOccupiedOrderHelper OBJ = new AreaOccupiedOrderHelper();
		
		public static AreaOccupiedOrderHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(AreaOccupiedOrder structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("create_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCreate_time(value);
					}
					
					
					
					
					
					if ("province_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetProvince_code(value);
					}
					
					
					
					
					
					if ("province".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetProvince(value);
					}
					
					
					
					
					
					if ("city_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCity_code(value);
					}
					
					
					
					
					
					if ("city".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCity(value);
					}
					
					
					
					
					
					if ("district_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetDistrict_code(value);
					}
					
					
					
					
					
					if ("district".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetDistrict(value);
					}
					
					
					
					
					
					if ("area_warehouse_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetArea_warehouse_id(value);
					}
					
					
					
					
					
					if ("sale_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetSale_type(value);
					}
					
					
					
					
					
					if ("order_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetOrder_type(value);
					}
					
					
					
					
					
					if ("order_details".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.dvd.AreaOccupiedOrderDetail> value;
						
						value = new List<vipapis.dvd.AreaOccupiedOrderDetail>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.dvd.AreaOccupiedOrderDetail elem1;
								
								elem1 = new vipapis.dvd.AreaOccupiedOrderDetail();
								vipapis.dvd.AreaOccupiedOrderDetailHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrder_details(value);
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
		
		
		public void Write(AreaOccupiedOrder structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrder_id() != null) {
				
				oprot.WriteFieldBegin("order_id");
				oprot.WriteString(structs.GetOrder_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCreate_time() != null) {
				
				oprot.WriteFieldBegin("create_time");
				oprot.WriteString(structs.GetCreate_time());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetProvince_code() != null) {
				
				oprot.WriteFieldBegin("province_code");
				oprot.WriteString(structs.GetProvince_code());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetProvince() != null) {
				
				oprot.WriteFieldBegin("province");
				oprot.WriteString(structs.GetProvince());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCity_code() != null) {
				
				oprot.WriteFieldBegin("city_code");
				oprot.WriteString(structs.GetCity_code());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCity() != null) {
				
				oprot.WriteFieldBegin("city");
				oprot.WriteString(structs.GetCity());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDistrict_code() != null) {
				
				oprot.WriteFieldBegin("district_code");
				oprot.WriteString(structs.GetDistrict_code());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDistrict() != null) {
				
				oprot.WriteFieldBegin("district");
				oprot.WriteString(structs.GetDistrict());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetArea_warehouse_id() != null) {
				
				oprot.WriteFieldBegin("area_warehouse_id");
				oprot.WriteString(structs.GetArea_warehouse_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSale_type() != null) {
				
				oprot.WriteFieldBegin("sale_type");
				oprot.WriteI32((int)structs.GetSale_type()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrder_type() != null) {
				
				oprot.WriteFieldBegin("order_type");
				oprot.WriteI32((int)structs.GetOrder_type()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrder_details() != null) {
				
				oprot.WriteFieldBegin("order_details");
				
				oprot.WriteListBegin();
				foreach(vipapis.dvd.AreaOccupiedOrderDetail _item0 in structs.GetOrder_details()){
					
					
					vipapis.dvd.AreaOccupiedOrderDetailHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(AreaOccupiedOrder bean){
			
			
		}
		
	}
	
}