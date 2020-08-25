using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.domain.inventory{
	
	
	
	public class CreatePoRequestHelper : TBeanSerializer<CreatePoRequest>
	{
		
		public static CreatePoRequestHelper OBJ = new CreatePoRequestHelper();
		
		public static CreatePoRequestHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(CreatePoRequest structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("clientPoNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetClientPoNo(value);
					}
					
					
					
					
					
					if ("warehouseCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouseCode(value);
					}
					
					
					
					
					
					if ("channel".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.domain.inventory.ChannelInventoryChannel? value;
						
						value = com.vip.domain.inventory.ChannelInventoryChannelUtil.FindByName(iprot.ReadString());
						
						structs.SetChannel(value);
					}
					
					
					
					
					
					if ("contacter".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetContacter(value);
					}
					
					
					
					
					
					if ("contacterTel".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetContacterTel(value);
					}
					
					
					
					
					
					if ("contacterMobie".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetContacterMobie(value);
					}
					
					
					
					
					
					if ("country".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCountry(value);
					}
					
					
					
					
					
					if ("state".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetState(value);
					}
					
					
					
					
					
					if ("city".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCity(value);
					}
					
					
					
					
					
					if ("district".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetDistrict(value);
					}
					
					
					
					
					
					if ("addrDetail".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAddrDetail(value);
					}
					
					
					
					
					
					if ("email".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetEmail(value);
					}
					
					
					
					
					
					if ("weight".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWeight(value);
					}
					
					
					
					
					
					if ("volume".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVolume(value);
					}
					
					
					
					
					
					if ("remark".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRemark(value);
					}
					
					
					
					
					
					if ("createUser".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCreateUser(value);
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
		
		
		public void Write(CreatePoRequest structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetClientPoNo() != null) {
				
				oprot.WriteFieldBegin("clientPoNo");
				oprot.WriteString(structs.GetClientPoNo());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("clientPoNo can not be null!");
			}
			
			
			if(structs.GetWarehouseCode() != null) {
				
				oprot.WriteFieldBegin("warehouseCode");
				oprot.WriteString(structs.GetWarehouseCode());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("warehouseCode can not be null!");
			}
			
			
			if(structs.GetChannel() != null) {
				
				oprot.WriteFieldBegin("channel");
				oprot.WriteString(structs.GetChannel().ToString());  
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("channel can not be null!");
			}
			
			
			if(structs.GetContacter() != null) {
				
				oprot.WriteFieldBegin("contacter");
				oprot.WriteString(structs.GetContacter());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("contacter can not be null!");
			}
			
			
			if(structs.GetContacterTel() != null) {
				
				oprot.WriteFieldBegin("contacterTel");
				oprot.WriteString(structs.GetContacterTel());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetContacterMobie() != null) {
				
				oprot.WriteFieldBegin("contacterMobie");
				oprot.WriteString(structs.GetContacterMobie());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCountry() != null) {
				
				oprot.WriteFieldBegin("country");
				oprot.WriteString(structs.GetCountry());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("country can not be null!");
			}
			
			
			if(structs.GetState() != null) {
				
				oprot.WriteFieldBegin("state");
				oprot.WriteString(structs.GetState());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("state can not be null!");
			}
			
			
			if(structs.GetCity() != null) {
				
				oprot.WriteFieldBegin("city");
				oprot.WriteString(structs.GetCity());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("city can not be null!");
			}
			
			
			if(structs.GetDistrict() != null) {
				
				oprot.WriteFieldBegin("district");
				oprot.WriteString(structs.GetDistrict());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("district can not be null!");
			}
			
			
			if(structs.GetAddrDetail() != null) {
				
				oprot.WriteFieldBegin("addrDetail");
				oprot.WriteString(structs.GetAddrDetail());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("addrDetail can not be null!");
			}
			
			
			if(structs.GetEmail() != null) {
				
				oprot.WriteFieldBegin("email");
				oprot.WriteString(structs.GetEmail());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("email can not be null!");
			}
			
			
			if(structs.GetWeight() != null) {
				
				oprot.WriteFieldBegin("weight");
				oprot.WriteString(structs.GetWeight());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVolume() != null) {
				
				oprot.WriteFieldBegin("volume");
				oprot.WriteString(structs.GetVolume());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRemark() != null) {
				
				oprot.WriteFieldBegin("remark");
				oprot.WriteString(structs.GetRemark());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCreateUser() != null) {
				
				oprot.WriteFieldBegin("createUser");
				oprot.WriteString(structs.GetCreateUser());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("createUser can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(CreatePoRequest bean){
			
			
		}
		
	}
	
}