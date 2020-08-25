using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.sales{
	
	
	
	public class SalesHelper : TBeanSerializer<Sales>
	{
		
		public static SalesHelper OBJ = new SalesHelper();
		
		public static SalesHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(Sales structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("sales_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						long value;
						value = iprot.ReadI64(); 
						
						structs.SetSales_no(value);
					}
					
					
					
					
					
					if ("name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetName(value);
					}
					
					
					
					
					
					if ("sale_st".Equals(schemeField.Trim())){
						
						needSkip = false;
						long value;
						value = iprot.ReadI64(); 
						
						structs.SetSale_st(value);
					}
					
					
					
					
					
					if ("sale_et".Equals(schemeField.Trim())){
						
						needSkip = false;
						long value;
						value = iprot.ReadI64(); 
						
						structs.SetSale_et(value);
					}
					
					
					
					
					
					if ("warehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouse(value);
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
		
		
		public void Write(Sales structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSales_no() != null) {
				
				oprot.WriteFieldBegin("sales_no");
				oprot.WriteI64((long)structs.GetSales_no()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("sales_no can not be null!");
			}
			
			
			if(structs.GetName() != null) {
				
				oprot.WriteFieldBegin("name");
				oprot.WriteString(structs.GetName());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("name can not be null!");
			}
			
			
			if(structs.GetSale_st() != null) {
				
				oprot.WriteFieldBegin("sale_st");
				oprot.WriteI64((long)structs.GetSale_st()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("sale_st can not be null!");
			}
			
			
			if(structs.GetSale_et() != null) {
				
				oprot.WriteFieldBegin("sale_et");
				oprot.WriteI64((long)structs.GetSale_et()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("sale_et can not be null!");
			}
			
			
			if(structs.GetWarehouse() != null) {
				
				oprot.WriteFieldBegin("warehouse");
				oprot.WriteString(structs.GetWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(Sales bean){
			
			
		}
		
	}
	
}