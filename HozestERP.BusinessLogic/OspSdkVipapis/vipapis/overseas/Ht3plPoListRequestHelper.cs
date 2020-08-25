using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.overseas{
	
	
	
	public class Ht3plPoListRequestHelper : TBeanSerializer<Ht3plPoListRequest>
	{
		
		public static Ht3plPoListRequestHelper OBJ = new Ht3plPoListRequestHelper();
		
		public static Ht3plPoListRequestHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(Ht3plPoListRequest structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("batch_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBatch_no(value);
					}
					
					
					
					
					
					if ("start_po_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetStart_po_id(value);
					}
					
					
					
					
					
					if ("num".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetNum(value);
					}
					
					
					
					
					
					if ("sale_area".Equals(schemeField.Trim())){
						
						needSkip = false;
						vipapis.common.SaleArea? value;
						
						value = vipapis.common.SaleAreaUtil.FindByName(iprot.ReadString());
						
						structs.SetSale_area(value);
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
		
		
		public void Write(Ht3plPoListRequest structs, Protocol oprot){
			
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
			
			
			if(structs.GetBatch_no() != null) {
				
				oprot.WriteFieldBegin("batch_no");
				oprot.WriteString(structs.GetBatch_no());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("batch_no can not be null!");
			}
			
			
			if(structs.GetStart_po_id() != null) {
				
				oprot.WriteFieldBegin("start_po_id");
				oprot.WriteI32((int)structs.GetStart_po_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("start_po_id can not be null!");
			}
			
			
			if(structs.GetNum() != null) {
				
				oprot.WriteFieldBegin("num");
				oprot.WriteI32((int)structs.GetNum()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("num can not be null!");
			}
			
			
			if(structs.GetSale_area() != null) {
				
				oprot.WriteFieldBegin("sale_area");
				oprot.WriteString(structs.GetSale_area().ToString());  
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("sale_area can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(Ht3plPoListRequest bean){
			
			
		}
		
	}
	
}