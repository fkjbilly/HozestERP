using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.normal{
	
	
	
	public class ScheduleProductRequestHelper : TBeanSerializer<ScheduleProductRequest>
	{
		
		public static ScheduleProductRequestHelper OBJ = new ScheduleProductRequestHelper();
		
		public static ScheduleProductRequestHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ScheduleProductRequest structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("vendor_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetVendor_id(value);
					}
					
					
					
					
					
					if ("warehouse_supplier".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouse_supplier(value);
					}
					
					
					
					
					
					if ("scheduleProductList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.normal.ScheduleProduct> value;
						
						value = new List<vipapis.normal.ScheduleProduct>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.normal.ScheduleProduct elem1;
								
								elem1 = new vipapis.normal.ScheduleProduct();
								vipapis.normal.ScheduleProductHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetScheduleProductList(value);
					}
					
					
					
					
					
					if ("st_create_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetSt_create_time(value);
					}
					
					
					
					
					
					if ("et_create_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetEt_create_time(value);
					}
					
					
					
					
					
					if ("limit".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetLimit(value);
					}
					
					
					
					
					
					if ("page".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetPage(value);
					}
					
					
					
					
					
					if ("cooperation_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetCooperation_no(value);
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
		
		
		public void Write(ScheduleProductRequest structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetVendor_id() != null) {
				
				oprot.WriteFieldBegin("vendor_id");
				oprot.WriteI32((int)structs.GetVendor_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("vendor_id can not be null!");
			}
			
			
			if(structs.GetWarehouse_supplier() != null) {
				
				oprot.WriteFieldBegin("warehouse_supplier");
				oprot.WriteString(structs.GetWarehouse_supplier());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetScheduleProductList() != null) {
				
				oprot.WriteFieldBegin("scheduleProductList");
				
				oprot.WriteListBegin();
				foreach(vipapis.normal.ScheduleProduct _item0 in structs.GetScheduleProductList()){
					
					
					vipapis.normal.ScheduleProductHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSt_create_time() != null) {
				
				oprot.WriteFieldBegin("st_create_time");
				oprot.WriteI64((long)structs.GetSt_create_time()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetEt_create_time() != null) {
				
				oprot.WriteFieldBegin("et_create_time");
				oprot.WriteI64((long)structs.GetEt_create_time()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetLimit() != null) {
				
				oprot.WriteFieldBegin("limit");
				oprot.WriteI32((int)structs.GetLimit()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPage() != null) {
				
				oprot.WriteFieldBegin("page");
				oprot.WriteI32((int)structs.GetPage()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCooperation_no() != null) {
				
				oprot.WriteFieldBegin("cooperation_no");
				oprot.WriteI32((int)structs.GetCooperation_no()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ScheduleProductRequest bean){
			
			
		}
		
	}
	
}