using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.delivery{
	
	
	
	public class GetReturnListResponseHelper : TBeanSerializer<GetReturnListResponse>
	{
		
		public static GetReturnListResponseHelper OBJ = new GetReturnListResponseHelper();
		
		public static GetReturnListResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetReturnListResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("dvd_return_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.delivery.DvdReturn> value;
						
						value = new List<vipapis.delivery.DvdReturn>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.delivery.DvdReturn elem0;
								
								elem0 = new vipapis.delivery.DvdReturn();
								vipapis.delivery.DvdReturnHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetDvd_return_list(value);
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
		
		
		public void Write(GetReturnListResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetDvd_return_list() != null) {
				
				oprot.WriteFieldBegin("dvd_return_list");
				
				oprot.WriteListBegin();
				foreach(vipapis.delivery.DvdReturn _item0 in structs.GetDvd_return_list()){
					
					
					vipapis.delivery.DvdReturnHelper.getInstance().Write(_item0, oprot);
					
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
		
		
		public void Validate(GetReturnListResponse bean){
			
			
		}
		
	}
	
}