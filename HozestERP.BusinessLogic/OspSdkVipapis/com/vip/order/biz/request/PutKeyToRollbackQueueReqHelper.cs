using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class PutKeyToRollbackQueueReqHelper : TBeanSerializer<PutKeyToRollbackQueueReq>
	{
		
		public static PutKeyToRollbackQueueReqHelper OBJ = new PutKeyToRollbackQueueReqHelper();
		
		public static PutKeyToRollbackQueueReqHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(PutKeyToRollbackQueueReq structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("keySet".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<string> value;
						
						value = new List<string>();
						iprot.ReadSetBegin();
						while(true){
							
							try{
								
								string elem0;
								elem0 = iprot.ReadString();
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadSetEnd();
						
						structs.SetKeySet(value);
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
		
		
		public void Write(PutKeyToRollbackQueueReq structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetKeySet() != null) {
				
				oprot.WriteFieldBegin("keySet");
				
				oprot.WriteSetBegin();
				foreach(string _item0 in structs.GetKeySet()){
					
					oprot.WriteString(_item0);
					
				}
				
				oprot.WriteSetEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(PutKeyToRollbackQueueReq bean){
			
			
		}
		
	}
	
}