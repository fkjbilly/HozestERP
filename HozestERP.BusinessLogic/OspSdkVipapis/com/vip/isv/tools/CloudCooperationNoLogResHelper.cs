using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.isv.tools{
	
	
	
	public class CloudCooperationNoLogResHelper : TBeanSerializer<CloudCooperationNoLogRes>
	{
		
		public static CloudCooperationNoLogResHelper OBJ = new CloudCooperationNoLogResHelper();
		
		public static CloudCooperationNoLogResHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(CloudCooperationNoLogRes structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("cloudCooperationNoLogDos".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.isv.tools.CloudCooperationNoLogDo> value;
						
						value = new List<com.vip.isv.tools.CloudCooperationNoLogDo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.isv.tools.CloudCooperationNoLogDo elem0;
								
								elem0 = new com.vip.isv.tools.CloudCooperationNoLogDo();
								com.vip.isv.tools.CloudCooperationNoLogDoHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetCloudCooperationNoLogDos(value);
					}
					
					
					
					
					
					if ("totalCount".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetTotalCount(value);
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
		
		
		public void Write(CloudCooperationNoLogRes structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetCloudCooperationNoLogDos() != null) {
				
				oprot.WriteFieldBegin("cloudCooperationNoLogDos");
				
				oprot.WriteListBegin();
				foreach(com.vip.isv.tools.CloudCooperationNoLogDo _item0 in structs.GetCloudCooperationNoLogDos()){
					
					
					com.vip.isv.tools.CloudCooperationNoLogDoHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTotalCount() != null) {
				
				oprot.WriteFieldBegin("totalCount");
				oprot.WriteI32((int)structs.GetTotalCount()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(CloudCooperationNoLogRes bean){
			
			
		}
		
	}
	
}