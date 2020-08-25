using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.haitao.orderservice.service{
	
	
	
	public class HtSaleOrderCancellationResultHelper : TBeanSerializer<HtSaleOrderCancellationResult>
	{
		
		public static HtSaleOrderCancellationResultHelper OBJ = new HtSaleOrderCancellationResultHelper();
		
		public static HtSaleOrderCancellationResultHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(HtSaleOrderCancellationResult structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("cancelledSaleOrderList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.haitao.orderservice.service.HtCancelledSaleOrderResultModel> value;
						
						value = new List<com.vip.haitao.orderservice.service.HtCancelledSaleOrderResultModel>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.haitao.orderservice.service.HtCancelledSaleOrderResultModel elem2;
								
								elem2 = new com.vip.haitao.orderservice.service.HtCancelledSaleOrderResultModel();
								com.vip.haitao.orderservice.service.HtCancelledSaleOrderResultModelHelper.getInstance().Read(elem2, iprot);
								
								value.Add(elem2);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetCancelledSaleOrderList(value);
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
		
		
		public void Write(HtSaleOrderCancellationResult structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetHead() != null) {
				
				oprot.WriteFieldBegin("head");
				
				com.vip.haitao.orderservice.service.HeadHelper.getInstance().Write(structs.GetHead(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCancelledSaleOrderList() != null) {
				
				oprot.WriteFieldBegin("cancelledSaleOrderList");
				
				oprot.WriteListBegin();
				foreach(com.vip.haitao.orderservice.service.HtCancelledSaleOrderResultModel _item0 in structs.GetCancelledSaleOrderList()){
					
					
					com.vip.haitao.orderservice.service.HtCancelledSaleOrderResultModelHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(HtSaleOrderCancellationResult bean){
			
			
		}
		
	}
	
}