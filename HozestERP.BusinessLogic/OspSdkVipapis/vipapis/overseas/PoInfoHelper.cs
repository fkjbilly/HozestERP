using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.overseas{
	
	
	
	public class PoInfoHelper : TBeanSerializer<PoInfo>
	{
		
		public static PoInfoHelper OBJ = new PoInfoHelper();
		
		public static PoInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(PoInfo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("po_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPo_id(value);
					}
					
					
					
					
					
					if ("po_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPo_no(value);
					}
					
					
					
					
					
					if ("po_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPo_type(value);
					}
					
					
					
					
					
					if ("vendor_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendor_code(value);
					}
					
					
					
					
					
					if ("vendor_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendor_name(value);
					}
					
					
					
					
					
					if ("data_status".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetData_status(value);
					}
					
					
					
					
					
					if ("buyer".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBuyer(value);
					}
					
					
					
					
					
					if ("sale_area".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSale_area(value);
					}
					
					
					
					
					
					if ("post_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPost_code(value);
					}
					
					
					
					
					
					if ("consignee".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetConsignee(value);
					}
					
					
					
					
					
					if ("phone".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPhone(value);
					}
					
					
					
					
					
					if ("country".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCountry(value);
					}
					
					
					
					
					
					if ("province".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetProvince(value);
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
					
					
					
					
					
					if ("transfer_date".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransfer_date(value);
					}
					
					
					
					
					
					if ("po_detail_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.overseas.PoDetail> value;
						
						value = new List<vipapis.overseas.PoDetail>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.overseas.PoDetail elem1;
								
								elem1 = new vipapis.overseas.PoDetail();
								vipapis.overseas.PoDetailHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetPo_detail_list(value);
					}
					
					
					
					
					
					if ("total".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetTotal(value);
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
		
		
		public void Write(PoInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetPo_id() != null) {
				
				oprot.WriteFieldBegin("po_id");
				oprot.WriteString(structs.GetPo_id());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPo_no() != null) {
				
				oprot.WriteFieldBegin("po_no");
				oprot.WriteString(structs.GetPo_no());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPo_type() != null) {
				
				oprot.WriteFieldBegin("po_type");
				oprot.WriteString(structs.GetPo_type());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVendor_code() != null) {
				
				oprot.WriteFieldBegin("vendor_code");
				oprot.WriteString(structs.GetVendor_code());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVendor_name() != null) {
				
				oprot.WriteFieldBegin("vendor_name");
				oprot.WriteString(structs.GetVendor_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetData_status() != null) {
				
				oprot.WriteFieldBegin("data_status");
				oprot.WriteString(structs.GetData_status());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBuyer() != null) {
				
				oprot.WriteFieldBegin("buyer");
				oprot.WriteString(structs.GetBuyer());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSale_area() != null) {
				
				oprot.WriteFieldBegin("sale_area");
				oprot.WriteString(structs.GetSale_area());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPost_code() != null) {
				
				oprot.WriteFieldBegin("post_code");
				oprot.WriteString(structs.GetPost_code());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetConsignee() != null) {
				
				oprot.WriteFieldBegin("consignee");
				oprot.WriteString(structs.GetConsignee());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPhone() != null) {
				
				oprot.WriteFieldBegin("phone");
				oprot.WriteString(structs.GetPhone());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCountry() != null) {
				
				oprot.WriteFieldBegin("country");
				oprot.WriteString(structs.GetCountry());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetProvince() != null) {
				
				oprot.WriteFieldBegin("province");
				oprot.WriteString(structs.GetProvince());
				
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
			
			
			if(structs.GetTransfer_date() != null) {
				
				oprot.WriteFieldBegin("transfer_date");
				oprot.WriteString(structs.GetTransfer_date());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPo_detail_list() != null) {
				
				oprot.WriteFieldBegin("po_detail_list");
				
				oprot.WriteListBegin();
				foreach(vipapis.overseas.PoDetail _item0 in structs.GetPo_detail_list()){
					
					
					vipapis.overseas.PoDetailHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTotal() != null) {
				
				oprot.WriteFieldBegin("total");
				oprot.WriteI32((int)structs.GetTotal()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(PoInfo bean){
			
			
		}
		
	}
	
}