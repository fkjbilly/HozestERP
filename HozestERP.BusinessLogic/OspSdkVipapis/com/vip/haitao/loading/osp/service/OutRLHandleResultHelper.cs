using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.haitao.loading.osp.service{
	
	
	
	public class OutRLHandleResultHelper : TBeanSerializer<OutRLHandleResult>
	{
		
		public static OutRLHandleResultHelper OBJ = new OutRLHandleResultHelper();
		
		public static OutRLHandleResultHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OutRLHandleResult structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("header".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.haitao.loading.osp.service.PostHeader value;
						
						value = new com.vip.haitao.loading.osp.service.PostHeader();
						com.vip.haitao.loading.osp.service.PostHeaderHelper.getInstance().Read(value, iprot);
						
						structs.SetHeader(value);
					}
					
					
					
					
					
					if ("body".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.haitao.loading.osp.service.GetBody value;
						
						value = new com.vip.haitao.loading.osp.service.GetBody();
						com.vip.haitao.loading.osp.service.GetBodyHelper.getInstance().Read(value, iprot);
						
						structs.SetBody(value);
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
		
		
		public void Write(OutRLHandleResult structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetHeader() != null) {
				
				oprot.WriteFieldBegin("header");
				
				com.vip.haitao.loading.osp.service.PostHeaderHelper.getInstance().Write(structs.GetHeader(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBody() != null) {
				
				oprot.WriteFieldBegin("body");
				
				com.vip.haitao.loading.osp.service.GetBodyHelper.getInstance().Write(structs.GetBody(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OutRLHandleResult bean){
			
			
		}
		
	}
	
}