using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.address{
	
	
	
	public class AddressHelper : TBeanSerializer<Address>
	{
		
		public static AddressHelper OBJ = new AddressHelper();
		
		public static AddressHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(Address structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("address_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAddress_code(value);
					}
					
					
					
					
					
					if ("address_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAddress_name(value);
					}
					
					
					
					
					
					if ("full_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetFull_name(value);
					}
					
					
					
					
					
					if ("parent_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetParent_code(value);
					}
					
					
					
					
					
					if ("has_children".Equals(schemeField.Trim())){
						
						needSkip = false;
						byte value;
						value = iprot.ReadByte(); 
						
						structs.SetHas_children(value);
					}
					
					
					
					
					
					if ("is_directly".Equals(schemeField.Trim())){
						
						needSkip = false;
						byte value;
						value = iprot.ReadByte(); 
						
						structs.SetIs_directly(value);
					}
					
					
					
					
					
					if ("postage".Equals(schemeField.Trim())){
						
						needSkip = false;
						double value;
						value = iprot.ReadDouble();
						
						structs.SetPostage(value);
					}
					
					
					
					
					
					if ("is_cod".Equals(schemeField.Trim())){
						
						needSkip = false;
						byte value;
						value = iprot.ReadByte(); 
						
						structs.SetIs_cod(value);
					}
					
					
					
					
					
					if ("is_pos".Equals(schemeField.Trim())){
						
						needSkip = false;
						byte value;
						value = iprot.ReadByte(); 
						
						structs.SetIs_pos(value);
					}
					
					
					
					
					
					if ("is_big".Equals(schemeField.Trim())){
						
						needSkip = false;
						byte value;
						value = iprot.ReadByte(); 
						
						structs.SetIs_big(value);
					}
					
					
					
					
					
					if ("is_app".Equals(schemeField.Trim())){
						
						needSkip = false;
						byte value;
						value = iprot.ReadByte(); 
						
						structs.SetIs_app(value);
					}
					
					
					
					
					
					if ("cod_fee".Equals(schemeField.Trim())){
						
						needSkip = false;
						double value;
						value = iprot.ReadDouble();
						
						structs.SetCod_fee(value);
					}
					
					
					
					
					
					if ("is_service".Equals(schemeField.Trim())){
						
						needSkip = false;
						byte value;
						value = iprot.ReadByte(); 
						
						structs.SetIs_service(value);
					}
					
					
					
					
					
					if ("is_ems".Equals(schemeField.Trim())){
						
						needSkip = false;
						byte value;
						value = iprot.ReadByte(); 
						
						structs.SetIs_ems(value);
					}
					
					
					
					
					
					if ("big_money".Equals(schemeField.Trim())){
						
						needSkip = false;
						double value;
						value = iprot.ReadDouble();
						
						structs.SetBig_money(value);
					}
					
					
					
					
					
					if ("state".Equals(schemeField.Trim())){
						
						needSkip = false;
						byte value;
						value = iprot.ReadByte(); 
						
						structs.SetState(value);
					}
					
					
					
					
					
					if ("post_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPost_code(value);
					}
					
					
					
					
					
					if ("more_carrier".Equals(schemeField.Trim())){
						
						needSkip = false;
						byte value;
						value = iprot.ReadByte(); 
						
						structs.SetMore_carrier(value);
					}
					
					
					
					
					
					if ("carrier_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCarrier_name(value);
					}
					
					
					
					
					
					if ("delivery".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetDelivery(value);
					}
					
					
					
					
					
					if ("warehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouse(value);
					}
					
					
					
					
					
					if ("is_support_air_embargo".Equals(schemeField.Trim())){
						
						needSkip = false;
						byte value;
						value = iprot.ReadByte(); 
						
						structs.SetIs_support_air_embargo(value);
					}
					
					
					
					
					
					if ("addr_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetAddr_type(value);
					}
					
					
					
					
					
					if ("area_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetArea_type(value);
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
		
		
		public void Write(Address structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetAddress_code() != null) {
				
				oprot.WriteFieldBegin("address_code");
				oprot.WriteString(structs.GetAddress_code());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("address_code can not be null!");
			}
			
			
			if(structs.GetAddress_name() != null) {
				
				oprot.WriteFieldBegin("address_name");
				oprot.WriteString(structs.GetAddress_name());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("address_name can not be null!");
			}
			
			
			if(structs.GetFull_name() != null) {
				
				oprot.WriteFieldBegin("full_name");
				oprot.WriteString(structs.GetFull_name());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("full_name can not be null!");
			}
			
			
			if(structs.GetParent_code() != null) {
				
				oprot.WriteFieldBegin("parent_code");
				oprot.WriteString(structs.GetParent_code());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetHas_children() != null) {
				
				oprot.WriteFieldBegin("has_children");
				oprot.WriteByte((byte)structs.GetHas_children()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("has_children can not be null!");
			}
			
			
			if(structs.GetIs_directly() != null) {
				
				oprot.WriteFieldBegin("is_directly");
				oprot.WriteByte((byte)structs.GetIs_directly()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("is_directly can not be null!");
			}
			
			
			if(structs.GetPostage() != null) {
				
				oprot.WriteFieldBegin("postage");
				oprot.WriteDouble((double)structs.GetPostage());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("postage can not be null!");
			}
			
			
			if(structs.GetIs_cod() != null) {
				
				oprot.WriteFieldBegin("is_cod");
				oprot.WriteByte((byte)structs.GetIs_cod()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("is_cod can not be null!");
			}
			
			
			if(structs.GetIs_pos() != null) {
				
				oprot.WriteFieldBegin("is_pos");
				oprot.WriteByte((byte)structs.GetIs_pos()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("is_pos can not be null!");
			}
			
			
			if(structs.GetIs_big() != null) {
				
				oprot.WriteFieldBegin("is_big");
				oprot.WriteByte((byte)structs.GetIs_big()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("is_big can not be null!");
			}
			
			
			if(structs.GetIs_app() != null) {
				
				oprot.WriteFieldBegin("is_app");
				oprot.WriteByte((byte)structs.GetIs_app()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("is_app can not be null!");
			}
			
			
			if(structs.GetCod_fee() != null) {
				
				oprot.WriteFieldBegin("cod_fee");
				oprot.WriteDouble((double)structs.GetCod_fee());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("cod_fee can not be null!");
			}
			
			
			if(structs.GetIs_service() != null) {
				
				oprot.WriteFieldBegin("is_service");
				oprot.WriteByte((byte)structs.GetIs_service()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("is_service can not be null!");
			}
			
			
			if(structs.GetIs_ems() != null) {
				
				oprot.WriteFieldBegin("is_ems");
				oprot.WriteByte((byte)structs.GetIs_ems()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("is_ems can not be null!");
			}
			
			
			if(structs.GetBig_money() != null) {
				
				oprot.WriteFieldBegin("big_money");
				oprot.WriteDouble((double)structs.GetBig_money());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("big_money can not be null!");
			}
			
			
			if(structs.GetState() != null) {
				
				oprot.WriteFieldBegin("state");
				oprot.WriteByte((byte)structs.GetState()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("state can not be null!");
			}
			
			
			if(structs.GetPost_code() != null) {
				
				oprot.WriteFieldBegin("post_code");
				oprot.WriteString(structs.GetPost_code());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("post_code can not be null!");
			}
			
			
			if(structs.GetMore_carrier() != null) {
				
				oprot.WriteFieldBegin("more_carrier");
				oprot.WriteByte((byte)structs.GetMore_carrier()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("more_carrier can not be null!");
			}
			
			
			if(structs.GetCarrier_name() != null) {
				
				oprot.WriteFieldBegin("carrier_name");
				oprot.WriteString(structs.GetCarrier_name());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("carrier_name can not be null!");
			}
			
			
			if(structs.GetDelivery() != null) {
				
				oprot.WriteFieldBegin("delivery");
				oprot.WriteString(structs.GetDelivery());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("delivery can not be null!");
			}
			
			
			if(structs.GetWarehouse() != null) {
				
				oprot.WriteFieldBegin("warehouse");
				oprot.WriteString(structs.GetWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("warehouse can not be null!");
			}
			
			
			if(structs.GetIs_support_air_embargo() != null) {
				
				oprot.WriteFieldBegin("is_support_air_embargo");
				oprot.WriteByte((byte)structs.GetIs_support_air_embargo()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("is_support_air_embargo can not be null!");
			}
			
			
			if(structs.GetAddr_type() != null) {
				
				oprot.WriteFieldBegin("addr_type");
				oprot.WriteI32((int)structs.GetAddr_type()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("addr_type can not be null!");
			}
			
			
			if(structs.GetArea_type() != null) {
				
				oprot.WriteFieldBegin("area_type");
				oprot.WriteString(structs.GetArea_type());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("area_type can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(Address bean){
			
			
		}
		
	}
	
}