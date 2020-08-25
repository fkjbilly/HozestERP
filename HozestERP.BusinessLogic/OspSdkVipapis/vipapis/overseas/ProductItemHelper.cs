using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.overseas{
	
	
	
	public class ProductItemHelper : TBeanSerializer<ProductItem>
	{
		
		public static ProductItemHelper OBJ = new ProductItemHelper();
		
		public static ProductItemHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ProductItem structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("transfer_detail_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransfer_detail_id(value);
					}
					
					
					
					
					
					if ("line_num".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetLine_num(value);
					}
					
					
					
					
					
					if ("barcode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBarcode(value);
					}
					
					
					
					
					
					if ("no_po".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetNo_po(value);
					}
					
					
					
					
					
					if ("warehouse_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouse_type(value);
					}
					
					
					
					
					
					if ("grade".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGrade(value);
					}
					
					
					
					
					
					if ("po_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPo_no(value);
					}
					
					
					
					
					
					if ("num".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetNum(value);
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
		
		
		public void Write(ProductItem structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetTransfer_detail_id() != null) {
				
				oprot.WriteFieldBegin("transfer_detail_id");
				oprot.WriteString(structs.GetTransfer_detail_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetLine_num() != null) {
				
				oprot.WriteFieldBegin("line_num");
				oprot.WriteString(structs.GetLine_num());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBarcode() != null) {
				
				oprot.WriteFieldBegin("barcode");
				oprot.WriteString(structs.GetBarcode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetNo_po() != null) {
				
				oprot.WriteFieldBegin("no_po");
				oprot.WriteString(structs.GetNo_po());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWarehouse_type() != null) {
				
				oprot.WriteFieldBegin("warehouse_type");
				oprot.WriteString(structs.GetWarehouse_type());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("warehouse_type can not be null!");
			}
			
			
			if(structs.GetGrade() != null) {
				
				oprot.WriteFieldBegin("grade");
				oprot.WriteString(structs.GetGrade());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("grade can not be null!");
			}
			
			
			if(structs.GetPo_no() != null) {
				
				oprot.WriteFieldBegin("po_no");
				oprot.WriteString(structs.GetPo_no());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("po_no can not be null!");
			}
			
			
			if(structs.GetNum() != null) {
				
				oprot.WriteFieldBegin("num");
				oprot.WriteI32((int)structs.GetNum()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ProductItem bean){
			
			
		}
		
	}
	
}