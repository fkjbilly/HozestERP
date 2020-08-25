using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.haitao.loading.osp.service{
	
	
	
	public class GetBodyHelper : TBeanSerializer<GetBody>
	{
		
		public static GetBodyHelper OBJ = new GetBodyHelper();
		
		public static GetBodyHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetBody structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("returnList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.haitao.loading.osp.service.OutRLHandleResultDetail> value;
						
						value = new List<com.vip.haitao.loading.osp.service.OutRLHandleResultDetail>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.haitao.loading.osp.service.OutRLHandleResultDetail elem0;
								
								elem0 = new com.vip.haitao.loading.osp.service.OutRLHandleResultDetail();
								com.vip.haitao.loading.osp.service.OutRLHandleResultDetailHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetReturnList(value);
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
		
		
		public void Write(GetBody structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetReturnList() != null) {
				
				oprot.WriteFieldBegin("returnList");
				
				oprot.WriteListBegin();
				foreach(com.vip.haitao.loading.osp.service.OutRLHandleResultDetail _item0 in structs.GetReturnList()){
					
					
					com.vip.haitao.loading.osp.service.OutRLHandleResultDetailHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetBody bean){
			
			
		}
		
	}
	
}