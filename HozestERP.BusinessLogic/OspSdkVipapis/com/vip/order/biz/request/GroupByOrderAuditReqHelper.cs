using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class GroupByOrderAuditReqHelper : TBeanSerializer<GroupByOrderAuditReq>
	{
		
		public static GroupByOrderAuditReqHelper OBJ = new GroupByOrderAuditReqHelper();
		
		public static GroupByOrderAuditReqHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GroupByOrderAuditReq structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("groupByOrderAuditParamSet".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.biz.request.GroupByOrderAuditParam> value;
						
						value = new List<com.vip.order.biz.request.GroupByOrderAuditParam>();
						iprot.ReadSetBegin();
						while(true){
							
							try{
								
								com.vip.order.biz.request.GroupByOrderAuditParam elem0;
								
								elem0 = new com.vip.order.biz.request.GroupByOrderAuditParam();
								com.vip.order.biz.request.GroupByOrderAuditParamHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadSetEnd();
						
						structs.SetGroupByOrderAuditParamSet(value);
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
		
		
		public void Write(GroupByOrderAuditReq structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetGroupByOrderAuditParamSet() != null) {
				
				oprot.WriteFieldBegin("groupByOrderAuditParamSet");
				
				oprot.WriteSetBegin();
				foreach(com.vip.order.biz.request.GroupByOrderAuditParam _item0 in structs.GetGroupByOrderAuditParamSet()){
					
					
					com.vip.order.biz.request.GroupByOrderAuditParamHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteSetEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GroupByOrderAuditReq bean){
			
			
		}
		
	}
	
}