using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class BatchModifyOrderInvoiceReqHelper : TBeanSerializer<BatchModifyOrderInvoiceReq>
	{
		
		public static BatchModifyOrderInvoiceReqHelper OBJ = new BatchModifyOrderInvoiceReqHelper();
		
		public static BatchModifyOrderInvoiceReqHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(BatchModifyOrderInvoiceReq structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("orderInvoiceList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.OrderInvoiceVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.OrderInvoiceVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.OrderInvoiceVO elem0;
								
								elem0 = new com.vip.order.common.pojo.order.vo.OrderInvoiceVO();
								com.vip.order.common.pojo.order.vo.OrderInvoiceVOHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderInvoiceList(value);
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
		
		
		public void Write(BatchModifyOrderInvoiceReq structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrderInvoiceList() != null) {
				
				oprot.WriteFieldBegin("orderInvoiceList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.OrderInvoiceVO _item0 in structs.GetOrderInvoiceList()){
					
					
					com.vip.order.common.pojo.order.vo.OrderInvoiceVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(BatchModifyOrderInvoiceReq bean){
			
			
		}
		
	}
	
}