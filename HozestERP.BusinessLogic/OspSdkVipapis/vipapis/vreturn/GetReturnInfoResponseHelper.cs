using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.vreturn{
	
	
	
	public class GetReturnInfoResponseHelper : TBeanSerializer<GetReturnInfoResponse>
	{
		
		public static GetReturnInfoResponseHelper OBJ = new GetReturnInfoResponseHelper();
		
		public static GetReturnInfoResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetReturnInfoResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("returnInfos".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.vreturn.ReturnInfo> value;
						
						value = new List<vipapis.vreturn.ReturnInfo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.vreturn.ReturnInfo elem0;
								
								elem0 = new vipapis.vreturn.ReturnInfo();
								vipapis.vreturn.ReturnInfoHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetReturnInfos(value);
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
		
		
		public void Write(GetReturnInfoResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetReturnInfos() != null) {
				
				oprot.WriteFieldBegin("returnInfos");
				
				oprot.WriteListBegin();
				foreach(vipapis.vreturn.ReturnInfo _item0 in structs.GetReturnInfos()){
					
					
					vipapis.vreturn.ReturnInfoHelper.getInstance().Write(_item0, oprot);
					
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
		
		
		public void Validate(GetReturnInfoResponse bean){
			
			
		}
		
	}
	
}