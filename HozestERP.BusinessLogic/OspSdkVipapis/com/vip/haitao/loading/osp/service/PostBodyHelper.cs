using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.haitao.loading.osp.service{
	
	
	
	public class PostBodyHelper : TBeanSerializer<PostBody>
	{
		
		public static PostBodyHelper OBJ = new PostBodyHelper();
		
		public static PostBodyHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(PostBody structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("returnList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<string> value;
						
						value = new List<string>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								string elem1;
								elem1 = iprot.ReadString();
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetReturnList(value);
					}
					
					
					
					
					
					if ("returnErrorList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.haitao.loading.osp.service.PostReturnError> value;
						
						value = new List<com.vip.haitao.loading.osp.service.PostReturnError>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.haitao.loading.osp.service.PostReturnError elem2;
								
								elem2 = new com.vip.haitao.loading.osp.service.PostReturnError();
								com.vip.haitao.loading.osp.service.PostReturnErrorHelper.getInstance().Read(elem2, iprot);
								
								value.Add(elem2);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetReturnErrorList(value);
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
		
		
		public void Write(PostBody structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetReturnList() != null) {
				
				oprot.WriteFieldBegin("returnList");
				
				oprot.WriteListBegin();
				foreach(string _item0 in structs.GetReturnList()){
					
					oprot.WriteString(_item0);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReturnErrorList() != null) {
				
				oprot.WriteFieldBegin("returnErrorList");
				
				oprot.WriteListBegin();
				foreach(com.vip.haitao.loading.osp.service.PostReturnError _item0 in structs.GetReturnErrorList()){
					
					
					com.vip.haitao.loading.osp.service.PostReturnErrorHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(PostBody bean){
			
			
		}
		
	}
	
}