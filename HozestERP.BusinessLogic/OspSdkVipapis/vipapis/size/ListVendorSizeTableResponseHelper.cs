using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.size{
	
	
	
	public class ListVendorSizeTableResponseHelper : TBeanSerializer<ListVendorSizeTableResponse>
	{
		
		public static ListVendorSizeTableResponseHelper OBJ = new ListVendorSizeTableResponseHelper();
		
		public static ListVendorSizeTableResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ListVendorSizeTableResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("sizetables".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.size.VendorSizeTableInfo> value;
						
						value = new List<vipapis.size.VendorSizeTableInfo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.size.VendorSizeTableInfo elem0;
								
								elem0 = new vipapis.size.VendorSizeTableInfo();
								vipapis.size.VendorSizeTableInfoHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetSizetables(value);
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
		
		
		public void Write(ListVendorSizeTableResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSizetables() != null) {
				
				oprot.WriteFieldBegin("sizetables");
				
				oprot.WriteListBegin();
				foreach(vipapis.size.VendorSizeTableInfo _item0 in structs.GetSizetables()){
					
					
					vipapis.size.VendorSizeTableInfoHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ListVendorSizeTableResponse bean){
			
			
		}
		
	}
	
}