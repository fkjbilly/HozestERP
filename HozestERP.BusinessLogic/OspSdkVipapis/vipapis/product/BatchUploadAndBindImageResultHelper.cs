using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.product{
	
	
	
	public class BatchUploadAndBindImageResultHelper : TBeanSerializer<BatchUploadAndBindImageResult>
	{
		
		public static BatchUploadAndBindImageResultHelper OBJ = new BatchUploadAndBindImageResultHelper();
		
		public static BatchUploadAndBindImageResultHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(BatchUploadAndBindImageResult structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("success_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.product.UploadSuccessResult> value;
						
						value = new List<vipapis.product.UploadSuccessResult>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.product.UploadSuccessResult elem0;
								
								elem0 = new vipapis.product.UploadSuccessResult();
								vipapis.product.UploadSuccessResultHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetSuccess_list(value);
					}
					
					
					
					
					
					if ("fail_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.product.UploadFailResult> value;
						
						value = new List<vipapis.product.UploadFailResult>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.product.UploadFailResult elem2;
								
								elem2 = new vipapis.product.UploadFailResult();
								vipapis.product.UploadFailResultHelper.getInstance().Read(elem2, iprot);
								
								value.Add(elem2);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetFail_list(value);
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
		
		
		public void Write(BatchUploadAndBindImageResult structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSuccess_list() != null) {
				
				oprot.WriteFieldBegin("success_list");
				
				oprot.WriteListBegin();
				foreach(vipapis.product.UploadSuccessResult _item0 in structs.GetSuccess_list()){
					
					
					vipapis.product.UploadSuccessResultHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFail_list() != null) {
				
				oprot.WriteFieldBegin("fail_list");
				
				oprot.WriteListBegin();
				foreach(vipapis.product.UploadFailResult _item0 in structs.GetFail_list()){
					
					
					vipapis.product.UploadFailResultHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(BatchUploadAndBindImageResult bean){
			
			
		}
		
	}
	
}