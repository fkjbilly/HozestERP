using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class RollbackOrderReqHelper : TBeanSerializer<RollbackOrderReq>
	{
		
		public static RollbackOrderReqHelper OBJ = new RollbackOrderReqHelper();
		
		public static RollbackOrderReqHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(RollbackOrderReq structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("userId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetUserId(value);
					}
					
					
					
					
					
					if ("orderSnList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.OrderIdSnVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.OrderIdSnVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.OrderIdSnVO elem0;
								
								elem0 = new com.vip.order.common.pojo.order.vo.OrderIdSnVO();
								com.vip.order.common.pojo.order.vo.OrderIdSnVOHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderSnList(value);
					}
					
					
					
					
					
					if ("failType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetFailType(value);
					}
					
					
					
					
					
					if ("failCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetFailCode(value);
					}
					
					
					
					
					
					if ("failMsg".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetFailMsg(value);
					}
					
					
					
					
					
					if ("createIp".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCreateIp(value);
					}
					
					
					
					
					
					if ("createTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCreateTime(value);
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
		
		
		public void Write(RollbackOrderReq structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetUserId() != null) {
				
				oprot.WriteFieldBegin("userId");
				oprot.WriteI64((long)structs.GetUserId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderSnList() != null) {
				
				oprot.WriteFieldBegin("orderSnList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.OrderIdSnVO _item0 in structs.GetOrderSnList()){
					
					
					com.vip.order.common.pojo.order.vo.OrderIdSnVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFailType() != null) {
				
				oprot.WriteFieldBegin("failType");
				oprot.WriteI32((int)structs.GetFailType()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFailCode() != null) {
				
				oprot.WriteFieldBegin("failCode");
				oprot.WriteI32((int)structs.GetFailCode()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFailMsg() != null) {
				
				oprot.WriteFieldBegin("failMsg");
				oprot.WriteString(structs.GetFailMsg());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCreateIp() != null) {
				
				oprot.WriteFieldBegin("createIp");
				oprot.WriteString(structs.GetCreateIp());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCreateTime() != null) {
				
				oprot.WriteFieldBegin("createTime");
				oprot.WriteString(structs.GetCreateTime());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(RollbackOrderReq bean){
			
			
		}
		
	}
	
}