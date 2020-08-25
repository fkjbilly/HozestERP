using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.response{
	
	
	
	public class BatchModifyOrderInvoiceRespHelper : TBeanSerializer<BatchModifyOrderInvoiceResp>
	{
		
		public static BatchModifyOrderInvoiceRespHelper OBJ = new BatchModifyOrderInvoiceRespHelper();
		
		public static BatchModifyOrderInvoiceRespHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(BatchModifyOrderInvoiceResp structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("result".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.result.Result value;
						
						value = new com.vip.order.common.pojo.order.result.Result();
						com.vip.order.common.pojo.order.result.ResultHelper.getInstance().Read(value, iprot);
						
						structs.SetResult(value);
					}
					
					
					
					
					
					if ("detailList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.ModifyOrderInvoiceRespVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.ModifyOrderInvoiceRespVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.ModifyOrderInvoiceRespVO elem1;
								
								elem1 = new com.vip.order.common.pojo.order.vo.ModifyOrderInvoiceRespVO();
								com.vip.order.common.pojo.order.vo.ModifyOrderInvoiceRespVOHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetDetailList(value);
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
		
		
		public void Write(BatchModifyOrderInvoiceResp structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetResult() != null) {
				
				oprot.WriteFieldBegin("result");
				
				com.vip.order.common.pojo.order.result.ResultHelper.getInstance().Write(structs.GetResult(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDetailList() != null) {
				
				oprot.WriteFieldBegin("detailList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.ModifyOrderInvoiceRespVO _item0 in structs.GetDetailList()){
					
					
					com.vip.order.common.pojo.order.vo.ModifyOrderInvoiceRespVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(BatchModifyOrderInvoiceResp bean){
			
			
		}
		
	}
	
}