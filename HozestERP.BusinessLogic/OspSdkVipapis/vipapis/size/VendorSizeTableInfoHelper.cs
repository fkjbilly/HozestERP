using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.size{
	
	
	
	public class VendorSizeTableInfoHelper : TBeanSerializer<VendorSizeTableInfo>
	{
		
		public static VendorSizeTableInfoHelper OBJ = new VendorSizeTableInfoHelper();
		
		public static VendorSizeTableInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(VendorSizeTableInfo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("sizetable_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetSizetable_id(value);
					}
					
					
					
					
					
					if ("sizetable_name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSizetable_name(value);
					}
					
					
					
					
					
					if ("sizedetails".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.size.VendorSizeDetail> value;
						
						value = new List<vipapis.size.VendorSizeDetail>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.size.VendorSizeDetail elem0;
								
								elem0 = new vipapis.size.VendorSizeDetail();
								vipapis.size.VendorSizeDetailHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetSizedetails(value);
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
		
		
		public void Write(VendorSizeTableInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSizetable_id() != null) {
				
				oprot.WriteFieldBegin("sizetable_id");
				oprot.WriteI64((long)structs.GetSizetable_id()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSizetable_name() != null) {
				
				oprot.WriteFieldBegin("sizetable_name");
				oprot.WriteString(structs.GetSizetable_name());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSizedetails() != null) {
				
				oprot.WriteFieldBegin("sizedetails");
				
				oprot.WriteListBegin();
				foreach(vipapis.size.VendorSizeDetail _item0 in structs.GetSizedetails()){
					
					
					vipapis.size.VendorSizeDetailHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(VendorSizeTableInfo bean){
			
			
		}
		
	}
	
}