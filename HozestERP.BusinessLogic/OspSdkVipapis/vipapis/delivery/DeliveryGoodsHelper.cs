using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.delivery{
	
	
	
	public class DeliveryGoodsHelper : TBeanSerializer<DeliveryGoods>
	{
		
		public static DeliveryGoodsHelper OBJ = new DeliveryGoodsHelper();
		
		public static DeliveryGoodsHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(DeliveryGoods structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("vendor_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendor_type(value);
					}
					
					
					
					
					
					if ("barcode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBarcode(value);
					}
					
					
					
					
					
					if ("box_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBox_no(value);
					}
					
					
					
					
					
					if ("pick_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPick_no(value);
					}
					
					
					
					
					
					if ("amount".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetAmount(value);
					}
					
					
					
					
					
					if ("po_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPo_no(value);
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
		
		
		public void Write(DeliveryGoods structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetVendor_type() != null) {
				
				oprot.WriteFieldBegin("vendor_type");
				oprot.WriteString(structs.GetVendor_type());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("vendor_type can not be null!");
			}
			
			
			if(structs.GetBarcode() != null) {
				
				oprot.WriteFieldBegin("barcode");
				oprot.WriteString(structs.GetBarcode());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("barcode can not be null!");
			}
			
			
			if(structs.GetBox_no() != null) {
				
				oprot.WriteFieldBegin("box_no");
				oprot.WriteString(structs.GetBox_no());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("box_no can not be null!");
			}
			
			
			if(structs.GetPick_no() != null) {
				
				oprot.WriteFieldBegin("pick_no");
				oprot.WriteString(structs.GetPick_no());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("pick_no can not be null!");
			}
			
			
			if(structs.GetAmount() != null) {
				
				oprot.WriteFieldBegin("amount");
				oprot.WriteI32((int)structs.GetAmount()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("amount can not be null!");
			}
			
			
			if(structs.GetPo_no() != null) {
				
				oprot.WriteFieldBegin("po_no");
				oprot.WriteString(structs.GetPo_no());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("po_no can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(DeliveryGoods bean){
			
			
		}
		
	}
	
}