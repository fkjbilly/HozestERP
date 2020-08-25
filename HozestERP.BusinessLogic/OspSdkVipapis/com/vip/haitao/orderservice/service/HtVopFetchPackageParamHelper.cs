using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.haitao.orderservice.service{
	
	
	
	public class HtVopFetchPackageParamHelper : TBeanSerializer<HtVopFetchPackageParam>
	{
		
		public static HtVopFetchPackageParamHelper OBJ = new HtVopFetchPackageParamHelper();
		
		public static HtVopFetchPackageParamHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(HtVopFetchPackageParam structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("requestTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRequestTime(value);
					}
					
					
					
					
					
					if ("userId".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUserId(value);
					}
					
					
					
					
					
					if ("customsCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCustomsCode(value);
					}
					
					
					
					
					
					if ("subBillNumerList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.haitao.orderservice.service.VopOrderVo> value;
						
						value = new List<com.vip.haitao.orderservice.service.VopOrderVo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.haitao.orderservice.service.VopOrderVo elem0;
								
								elem0 = new com.vip.haitao.orderservice.service.VopOrderVo();
								com.vip.haitao.orderservice.service.VopOrderVoHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetSubBillNumerList(value);
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
		
		
		public void Write(HtVopFetchPackageParam structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetRequestTime() != null) {
				
				oprot.WriteFieldBegin("requestTime");
				oprot.WriteString(structs.GetRequestTime());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("requestTime can not be null!");
			}
			
			
			if(structs.GetUserId() != null) {
				
				oprot.WriteFieldBegin("userId");
				oprot.WriteString(structs.GetUserId());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("userId can not be null!");
			}
			
			
			if(structs.GetCustomsCode() != null) {
				
				oprot.WriteFieldBegin("customsCode");
				oprot.WriteString(structs.GetCustomsCode());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("customsCode can not be null!");
			}
			
			
			if(structs.GetSubBillNumerList() != null) {
				
				oprot.WriteFieldBegin("subBillNumerList");
				
				oprot.WriteListBegin();
				foreach(com.vip.haitao.orderservice.service.VopOrderVo _item0 in structs.GetSubBillNumerList()){
					
					
					com.vip.haitao.orderservice.service.VopOrderVoHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(HtVopFetchPackageParam bean){
			
			
		}
		
	}
	
}