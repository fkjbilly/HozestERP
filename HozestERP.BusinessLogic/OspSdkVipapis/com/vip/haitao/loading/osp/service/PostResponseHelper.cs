using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.haitao.loading.osp.service{
	
	
	
	public class PostResponseHelper : TBeanSerializer<PostResponse>
	{
		
		public static PostResponseHelper OBJ = new PostResponseHelper();
		
		public static PostResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(PostResponse structs, Protocol iprot){
			
			
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
						com.vip.haitao.loading.osp.service.PostBody value;
						
						value = new com.vip.haitao.loading.osp.service.PostBody();
						com.vip.haitao.loading.osp.service.PostBodyHelper.getInstance().Read(value, iprot);
						
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
		
		
		public void Write(PostResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetHeader() != null) {
				
				oprot.WriteFieldBegin("header");
				
				com.vip.haitao.loading.osp.service.PostHeaderHelper.getInstance().Write(structs.GetHeader(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("header can not be null!");
			}
			
			
			if(structs.GetBody() != null) {
				
				oprot.WriteFieldBegin("body");
				
				com.vip.haitao.loading.osp.service.PostBodyHelper.getInstance().Write(structs.GetBody(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(PostResponse bean){
			
			
		}
		
	}
	
}