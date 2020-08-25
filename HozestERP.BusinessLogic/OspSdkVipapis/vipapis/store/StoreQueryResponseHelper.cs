using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.store{
	
	
	
	public class StoreQueryResponseHelper : TBeanSerializer<StoreQueryResponse>
	{
		
		public static StoreQueryResponseHelper OBJ = new StoreQueryResponseHelper();
		
		public static StoreQueryResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(StoreQueryResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("total".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetTotal(value);
					}
					
					
					
					
					
					if ("storeInfos".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.store.StoreInfo> value;
						
						value = new List<vipapis.store.StoreInfo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.store.StoreInfo elem0;
								
								elem0 = new vipapis.store.StoreInfo();
								vipapis.store.StoreInfoHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetStoreInfos(value);
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
		
		
		public void Write(StoreQueryResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetTotal() != null) {
				
				oprot.WriteFieldBegin("total");
				oprot.WriteI32((int)structs.GetTotal()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("total can not be null!");
			}
			
			
			if(structs.GetStoreInfos() != null) {
				
				oprot.WriteFieldBegin("storeInfos");
				
				oprot.WriteListBegin();
				foreach(vipapis.store.StoreInfo _item0 in structs.GetStoreInfos()){
					
					
					vipapis.store.StoreInfoHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(StoreQueryResponse bean){
			
			
		}
		
	}
	
}