using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.overseas{
	
	
	
	public class OrderDetailHelper : TBeanSerializer<OrderDetail>
	{
		
		public static OrderDetailHelper OBJ = new OrderDetailHelper();
		
		public static OrderDetailHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderDetail structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("order_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrder_no(value);
					}
					
					
					
					
					
					if ("order_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrder_id(value);
					}
					
					
					
					
					
					if ("po_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPo_no(value);
					}
					
					
					
					
					
					if ("barcode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBarcode(value);
					}
					
					
					
					
					
					if ("v_goods_regist_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetV_goods_regist_no(value);
					}
					
					
					
					
					
					if ("num".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetNum(value);
					}
					
					
					
					
					
					if ("HTS_line_money".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetHTS_line_money(value);
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
		
		
		public void Write(OrderDetail structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrder_no() != null) {
				
				oprot.WriteFieldBegin("order_no");
				oprot.WriteString(structs.GetOrder_no());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("order_no can not be null!");
			}
			
			
			if(structs.GetOrder_id() != null) {
				
				oprot.WriteFieldBegin("order_id");
				oprot.WriteString(structs.GetOrder_id());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("order_id can not be null!");
			}
			
			
			if(structs.GetPo_no() != null) {
				
				oprot.WriteFieldBegin("po_no");
				oprot.WriteString(structs.GetPo_no());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("po_no can not be null!");
			}
			
			
			if(structs.GetBarcode() != null) {
				
				oprot.WriteFieldBegin("barcode");
				oprot.WriteString(structs.GetBarcode());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("barcode can not be null!");
			}
			
			
			if(structs.GetV_goods_regist_no() != null) {
				
				oprot.WriteFieldBegin("v_goods_regist_no");
				oprot.WriteString(structs.GetV_goods_regist_no());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("v_goods_regist_no can not be null!");
			}
			
			
			if(structs.GetNum() != null) {
				
				oprot.WriteFieldBegin("num");
				oprot.WriteString(structs.GetNum());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("num can not be null!");
			}
			
			
			if(structs.GetHTS_line_money() != null) {
				
				oprot.WriteFieldBegin("HTS_line_money");
				oprot.WriteString(structs.GetHTS_line_money());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("HTS_line_money can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderDetail bean){
			
			
		}
		
	}
	
}