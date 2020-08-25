using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.delivery{
	
	
	
	public class GetActualStorageInfoResponseHelper : TBeanSerializer<GetActualStorageInfoResponse>
	{
		
		public static GetActualStorageInfoResponseHelper OBJ = new GetActualStorageInfoResponseHelper();
		
		public static GetActualStorageInfoResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetActualStorageInfoResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("storage_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStorage_no(value);
					}
					
					
					
					
					
					if ("storage_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetStorage_time(value);
					}
					
					
					
					
					
					if ("total".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetTotal(value);
					}
					
					
					
					
					
					if ("actual_storage_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.delivery.ActualStorageInfo> value;
						
						value = new List<vipapis.delivery.ActualStorageInfo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.delivery.ActualStorageInfo elem0;
								
								elem0 = new vipapis.delivery.ActualStorageInfo();
								vipapis.delivery.ActualStorageInfoHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetActual_storage_list(value);
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
		
		
		public void Write(GetActualStorageInfoResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetStorage_no() != null) {
				
				oprot.WriteFieldBegin("storage_no");
				oprot.WriteString(structs.GetStorage_no());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStorage_time() != null) {
				
				oprot.WriteFieldBegin("storage_time");
				oprot.WriteString(structs.GetStorage_time());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTotal() != null) {
				
				oprot.WriteFieldBegin("total");
				oprot.WriteI32((int)structs.GetTotal()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetActual_storage_list() != null) {
				
				oprot.WriteFieldBegin("actual_storage_list");
				
				oprot.WriteListBegin();
				foreach(vipapis.delivery.ActualStorageInfo _item0 in structs.GetActual_storage_list()){
					
					
					vipapis.delivery.ActualStorageInfoHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetActualStorageInfoResponse bean){
			
			
		}
		
	}
	
}