using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.haitao.orderservice.service{
	
	
	
	public class HtSaleTransferBatchNoResultHelper : TBeanSerializer<HtSaleTransferBatchNoResult>
	{
		
		public static HtSaleTransferBatchNoResultHelper OBJ = new HtSaleTransferBatchNoResultHelper();
		
		public static HtSaleTransferBatchNoResultHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(HtSaleTransferBatchNoResult structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("orders".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.haitao.orderservice.service.Order> value;
						
						value = new List<com.vip.haitao.orderservice.service.Order>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.haitao.orderservice.service.Order elem2;
								
								elem2 = new com.vip.haitao.orderservice.service.Order();
								com.vip.haitao.orderservice.service.OrderHelper.getInstance().Read(elem2, iprot);
								
								value.Add(elem2);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrders(value);
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
		
		
		public void Write(HtSaleTransferBatchNoResult structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetHead() != null) {
				
				oprot.WriteFieldBegin("head");
				
				com.vip.haitao.orderservice.service.HeadHelper.getInstance().Write(structs.GetHead(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrders() != null) {
				
				oprot.WriteFieldBegin("orders");
				
				oprot.WriteListBegin();
				foreach(com.vip.haitao.orderservice.service.Order _item0 in structs.GetOrders()){
					
					
					com.vip.haitao.orderservice.service.OrderHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(HtSaleTransferBatchNoResult bean){
			
			
		}
		
	}
	
}