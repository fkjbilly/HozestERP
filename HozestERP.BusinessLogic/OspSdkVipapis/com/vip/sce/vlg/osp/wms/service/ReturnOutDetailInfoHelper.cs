using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	public class ReturnOutDetailInfoHelper : TBeanSerializer<ReturnOutDetailInfo>
	{
		
		public static ReturnOutDetailInfoHelper OBJ = new ReturnOutDetailInfoHelper();
		
		public static ReturnOutDetailInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ReturnOutDetailInfo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("transaction_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransaction_id(value);
					}
					
					
					
					
					
					if ("item_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetItem_code(value);
					}
					
					
					
					
					
					if ("item_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetItem_name(value);
					}
					
					
					
					
					
					if ("type".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetType(value);
					}
					
					
					
					
					
					if ("grade".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGrade(value);
					}
					
					
					
					
					
					if ("po".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPo(value);
					}
					
					
					
					
					
					if ("company_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCompany_code(value);
					}
					
					
					
					
					
					if ("sales_status".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSales_status(value);
					}
					
					
					
					
					
					if ("sales_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSales_no(value);
					}
					
					
					
					
					
					if ("qty".Equals(schemeField.Trim())){
						
						needSkip = false;
						double value;
						value = iprot.ReadDouble();
						
						structs.SetQty(value);
					}
					
					
					
					
					
					if ("box_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBox_id(value);
					}
					
					
					
					
					
					if ("serial_sn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSerial_sn(value);
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
		
		
		public void Write(ReturnOutDetailInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetTransaction_id() != null) {
				
				oprot.WriteFieldBegin("transaction_id");
				oprot.WriteString(structs.GetTransaction_id());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("transaction_id can not be null!");
			}
			
			
			if(structs.GetItem_code() != null) {
				
				oprot.WriteFieldBegin("item_code");
				oprot.WriteString(structs.GetItem_code());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("item_code can not be null!");
			}
			
			
			if(structs.GetItem_name() != null) {
				
				oprot.WriteFieldBegin("item_name");
				oprot.WriteString(structs.GetItem_name());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("item_name can not be null!");
			}
			
			
			if(structs.GetType() != null) {
				
				oprot.WriteFieldBegin("type");
				oprot.WriteString(structs.GetType());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("type can not be null!");
			}
			
			
			if(structs.GetGrade() != null) {
				
				oprot.WriteFieldBegin("grade");
				oprot.WriteString(structs.GetGrade());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("grade can not be null!");
			}
			
			
			if(structs.GetPo() != null) {
				
				oprot.WriteFieldBegin("po");
				oprot.WriteString(structs.GetPo());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("po can not be null!");
			}
			
			
			if(structs.GetCompany_code() != null) {
				
				oprot.WriteFieldBegin("company_code");
				oprot.WriteString(structs.GetCompany_code());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("company_code can not be null!");
			}
			
			
			if(structs.GetSales_status() != null) {
				
				oprot.WriteFieldBegin("sales_status");
				oprot.WriteString(structs.GetSales_status());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("sales_status can not be null!");
			}
			
			
			if(structs.GetSales_no() != null) {
				
				oprot.WriteFieldBegin("sales_no");
				oprot.WriteString(structs.GetSales_no());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("sales_no can not be null!");
			}
			
			
			if(structs.GetQty() != null) {
				
				oprot.WriteFieldBegin("qty");
				oprot.WriteDouble((double)structs.GetQty());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("qty can not be null!");
			}
			
			
			if(structs.GetBox_id() != null) {
				
				oprot.WriteFieldBegin("box_id");
				oprot.WriteString(structs.GetBox_id());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("box_id can not be null!");
			}
			
			
			if(structs.GetSerial_sn() != null) {
				
				oprot.WriteFieldBegin("serial_sn");
				oprot.WriteString(structs.GetSerial_sn());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("serial_sn can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ReturnOutDetailInfo bean){
			
			
		}
		
	}
	
}