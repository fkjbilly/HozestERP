using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.domain.inventory{
	
	
	
	public class PoObjectHelper : TBeanSerializer<PoObject>
	{
		
		public static PoObjectHelper OBJ = new PoObjectHelper();
		
		public static PoObjectHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(PoObject structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("systemPoNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSystemPoNo(value);
					}
					
					
					
					
					
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
					
					
					
					
					
					if ("poStatus".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPoStatus(value);
					}
					
					
					
					
					
					if ("saleArea".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSaleArea(value);
					}
					
					
					
					
					
					if ("zip".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetZip(value);
					}
					
					
					
					
					
					if ("warehouseContacter".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouseContacter(value);
					}
					
					
					
					
					
					if ("warehouseContacterTel".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouseContacterTel(value);
					}
					
					
					
					
					
					if ("warehouseContacterMobie".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouseContacterMobie(value);
					}
					
					
					
					
					
					if ("warehouseCountry".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouseCountry(value);
					}
					
					
					
					
					
					if ("warehouseState".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouseState(value);
					}
					
					
					
					
					
					if ("warehouseCity".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouseCity(value);
					}
					
					
					
					
					
					if ("warehouseDistrict".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouseDistrict(value);
					}
					
					
					
					
					
					if ("warehouseAddress".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouseAddress(value);
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
					
					
					
					
					
					if ("address".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAddress(value);
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
					
					
					
					
					
					if ("itemTotal".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetItemTotal(value);
					}
					
					
					
					
					
					if ("onRacksTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOnRacksTime(value);
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
					
					
					
					
					
					if ("createdDtmLoc".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCreatedDtmLoc(value);
					}
					
					
					
					
					
					if ("updatedUser".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUpdatedUser(value);
					}
					
					
					
					
					
					if ("updatedDtmLoc".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUpdatedDtmLoc(value);
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
		
		
		public void Write(PoObject structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSystemPoNo() != null) {
				
				oprot.WriteFieldBegin("systemPoNo");
				oprot.WriteString(structs.GetSystemPoNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetClientPoNo() != null) {
				
				oprot.WriteFieldBegin("clientPoNo");
				oprot.WriteString(structs.GetClientPoNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWarehouseCode() != null) {
				
				oprot.WriteFieldBegin("warehouseCode");
				oprot.WriteString(structs.GetWarehouseCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPoStatus() != null) {
				
				oprot.WriteFieldBegin("poStatus");
				oprot.WriteString(structs.GetPoStatus());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSaleArea() != null) {
				
				oprot.WriteFieldBegin("saleArea");
				oprot.WriteString(structs.GetSaleArea());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetZip() != null) {
				
				oprot.WriteFieldBegin("zip");
				oprot.WriteString(structs.GetZip());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWarehouseContacter() != null) {
				
				oprot.WriteFieldBegin("warehouseContacter");
				oprot.WriteString(structs.GetWarehouseContacter());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWarehouseContacterTel() != null) {
				
				oprot.WriteFieldBegin("warehouseContacterTel");
				oprot.WriteString(structs.GetWarehouseContacterTel());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWarehouseContacterMobie() != null) {
				
				oprot.WriteFieldBegin("warehouseContacterMobie");
				oprot.WriteString(structs.GetWarehouseContacterMobie());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWarehouseCountry() != null) {
				
				oprot.WriteFieldBegin("warehouseCountry");
				oprot.WriteString(structs.GetWarehouseCountry());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWarehouseState() != null) {
				
				oprot.WriteFieldBegin("warehouseState");
				oprot.WriteString(structs.GetWarehouseState());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWarehouseCity() != null) {
				
				oprot.WriteFieldBegin("warehouseCity");
				oprot.WriteString(structs.GetWarehouseCity());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWarehouseDistrict() != null) {
				
				oprot.WriteFieldBegin("warehouseDistrict");
				oprot.WriteString(structs.GetWarehouseDistrict());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWarehouseAddress() != null) {
				
				oprot.WriteFieldBegin("warehouseAddress");
				oprot.WriteString(structs.GetWarehouseAddress());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetChannel() != null) {
				
				oprot.WriteFieldBegin("channel");
				oprot.WriteString(structs.GetChannel().ToString());  
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetContacter() != null) {
				
				oprot.WriteFieldBegin("contacter");
				oprot.WriteString(structs.GetContacter());
				
				oprot.WriteFieldEnd();
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
			
			
			if(structs.GetState() != null) {
				
				oprot.WriteFieldBegin("state");
				oprot.WriteString(structs.GetState());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCity() != null) {
				
				oprot.WriteFieldBegin("city");
				oprot.WriteString(structs.GetCity());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDistrict() != null) {
				
				oprot.WriteFieldBegin("district");
				oprot.WriteString(structs.GetDistrict());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetAddress() != null) {
				
				oprot.WriteFieldBegin("address");
				oprot.WriteString(structs.GetAddress());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetEmail() != null) {
				
				oprot.WriteFieldBegin("email");
				oprot.WriteString(structs.GetEmail());
				
				oprot.WriteFieldEnd();
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
			
			
			if(structs.GetItemTotal() != null) {
				
				oprot.WriteFieldBegin("itemTotal");
				oprot.WriteI32((int)structs.GetItemTotal()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("itemTotal can not be null!");
			}
			
			
			if(structs.GetOnRacksTime() != null) {
				
				oprot.WriteFieldBegin("onRacksTime");
				oprot.WriteString(structs.GetOnRacksTime());
				
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
			
			
			if(structs.GetCreatedDtmLoc() != null) {
				
				oprot.WriteFieldBegin("createdDtmLoc");
				oprot.WriteString(structs.GetCreatedDtmLoc());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUpdatedUser() != null) {
				
				oprot.WriteFieldBegin("updatedUser");
				oprot.WriteString(structs.GetUpdatedUser());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUpdatedDtmLoc() != null) {
				
				oprot.WriteFieldBegin("updatedDtmLoc");
				oprot.WriteString(structs.GetUpdatedDtmLoc());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(PoObject bean){
			
			
		}
		
	}
	
}