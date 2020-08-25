using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.delivery{
	
	
	
	public class GetRestockStorageInfoResponseHelper : TBeanSerializer<GetRestockStorageInfoResponse>
	{
		
		public static GetRestockStorageInfoResponseHelper OBJ = new GetRestockStorageInfoResponseHelper();
		
		public static GetRestockStorageInfoResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetRestockStorageInfoResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("total".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetTotal(value);
					}
					
					
					
					
					
					if ("restock_storage_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.delivery.RestockStorageInfo> value;
						
						value = new List<vipapis.delivery.RestockStorageInfo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.delivery.RestockStorageInfo elem0;
								
								elem0 = new vipapis.delivery.RestockStorageInfo();
								vipapis.delivery.RestockStorageInfoHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetRestock_storage_list(value);
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
		
		
		public void Write(GetRestockStorageInfoResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetTotal() != null) {
				
				oprot.WriteFieldBegin("total");
				oprot.WriteI32((int)structs.GetTotal()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRestock_storage_list() != null) {
				
				oprot.WriteFieldBegin("restock_storage_list");
				
				oprot.WriteListBegin();
				foreach(vipapis.delivery.RestockStorageInfo _item0 in structs.GetRestock_storage_list()){
					
					
					vipapis.delivery.RestockStorageInfoHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetRestockStorageInfoResponse bean){
			
			
		}
		
	}
	
}