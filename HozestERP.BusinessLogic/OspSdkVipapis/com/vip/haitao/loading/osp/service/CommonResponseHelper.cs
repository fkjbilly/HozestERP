using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.haitao.loading.osp.service{
	
	
	
	public class CommonResponseHelper : TBeanSerializer<CommonResponse>
	{
		
		public static CommonResponseHelper OBJ = new CommonResponseHelper();
		
		public static CommonResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(CommonResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("responseTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetResponseTime(value);
					}
					
					
					
					
					
					if ("sysResponseCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSysResponseCode(value);
					}
					
					
					
					
					
					if ("sysResponseMsg".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSysResponseMsg(value);
					}
					
					
					
					
					
					if ("failOrders".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.haitao.loading.osp.service.FailOrders> value;
						
						value = new List<com.vip.haitao.loading.osp.service.FailOrders>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.haitao.loading.osp.service.FailOrders elem0;
								
								elem0 = new com.vip.haitao.loading.osp.service.FailOrders();
								com.vip.haitao.loading.osp.service.FailOrdersHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetFailOrders(value);
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
		
		
		public void Write(CommonResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetResponseTime() != null) {
				
				oprot.WriteFieldBegin("responseTime");
				oprot.WriteString(structs.GetResponseTime());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSysResponseCode() != null) {
				
				oprot.WriteFieldBegin("sysResponseCode");
				oprot.WriteString(structs.GetSysResponseCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSysResponseMsg() != null) {
				
				oprot.WriteFieldBegin("sysResponseMsg");
				oprot.WriteString(structs.GetSysResponseMsg());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFailOrders() != null) {
				
				oprot.WriteFieldBegin("failOrders");
				
				oprot.WriteListBegin();
				foreach(com.vip.haitao.loading.osp.service.FailOrders _item0 in structs.GetFailOrders()){
					
					
					com.vip.haitao.loading.osp.service.FailOrdersHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(CommonResponse bean){
			
			
		}
		
	}
	
}