using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.arplatform.face.service{
	
	
	
	public class CompareResponseHelper : TBeanSerializer<CompareResponse>
	{
		
		public static CompareResponseHelper OBJ = new CompareResponseHelper();
		
		public static CompareResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(CompareResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("token".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetToken(value);
					}
					
					
					
					
					
					if ("resultList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.arplatform.face.service.CompareResult> value;
						
						value = new List<com.vip.arplatform.face.service.CompareResult>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.arplatform.face.service.CompareResult elem0;
								
								elem0 = new com.vip.arplatform.face.service.CompareResult();
								com.vip.arplatform.face.service.CompareResultHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetResultList(value);
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
		
		
		public void Write(CompareResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetToken() != null) {
				
				oprot.WriteFieldBegin("token");
				oprot.WriteString(structs.GetToken());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("token can not be null!");
			}
			
			
			if(structs.GetResultList() != null) {
				
				oprot.WriteFieldBegin("resultList");
				
				oprot.WriteListBegin();
				foreach(com.vip.arplatform.face.service.CompareResult _item0 in structs.GetResultList()){
					
					
					com.vip.arplatform.face.service.CompareResultHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("resultList can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(CompareResponse bean){
			
			
		}
		
	}
	
}