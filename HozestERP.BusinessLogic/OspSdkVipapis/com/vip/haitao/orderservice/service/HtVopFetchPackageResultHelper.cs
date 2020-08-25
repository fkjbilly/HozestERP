using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.haitao.orderservice.service{
	
	
	
	public class HtVopFetchPackageResultHelper : TBeanSerializer<HtVopFetchPackageResult>
	{
		
		public static HtVopFetchPackageResultHelper OBJ = new HtVopFetchPackageResultHelper();
		
		public static HtVopFetchPackageResultHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(HtVopFetchPackageResult structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("head".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.haitao.orderservice.service.Head value;
						
						value = new com.vip.haitao.orderservice.service.Head();
						com.vip.haitao.orderservice.service.HeadHelper.getInstance().Read(value, iprot);
						
						structs.SetHead(value);
					}
					
					
					
					
					
					if ("interBatchNos".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.haitao.orderservice.service.ForwordToHtsOrderVo> value;
						
						value = new List<com.vip.haitao.orderservice.service.ForwordToHtsOrderVo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.haitao.orderservice.service.ForwordToHtsOrderVo elem2;
								
								elem2 = new com.vip.haitao.orderservice.service.ForwordToHtsOrderVo();
								com.vip.haitao.orderservice.service.ForwordToHtsOrderVoHelper.getInstance().Read(elem2, iprot);
								
								value.Add(elem2);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetInterBatchNos(value);
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
		
		
		public void Write(HtVopFetchPackageResult structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetHead() != null) {
				
				oprot.WriteFieldBegin("head");
				
				com.vip.haitao.orderservice.service.HeadHelper.getInstance().Write(structs.GetHead(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetInterBatchNos() != null) {
				
				oprot.WriteFieldBegin("interBatchNos");
				
				oprot.WriteListBegin();
				foreach(com.vip.haitao.orderservice.service.ForwordToHtsOrderVo _item0 in structs.GetInterBatchNos()){
					
					
					com.vip.haitao.orderservice.service.ForwordToHtsOrderVoHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(HtVopFetchPackageResult bean){
			
			
		}
		
	}
	
}