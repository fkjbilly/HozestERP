using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.haitao.orderservice.service{
	
	
	
	public class HtCarrierSaleOrderResultHelper : TBeanSerializer<HtCarrierSaleOrderResult>
	{
		
		public static HtCarrierSaleOrderResultHelper OBJ = new HtCarrierSaleOrderResultHelper();
		
		public static HtCarrierSaleOrderResultHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(HtCarrierSaleOrderResult structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("saleOrderList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.haitao.orderservice.service.HtSaleOrderChbResult> value;
						
						value = new List<com.vip.haitao.orderservice.service.HtSaleOrderChbResult>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.haitao.orderservice.service.HtSaleOrderChbResult elem1;
								
								elem1 = new com.vip.haitao.orderservice.service.HtSaleOrderChbResult();
								com.vip.haitao.orderservice.service.HtSaleOrderChbResultHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetSaleOrderList(value);
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
		
		
		public void Write(HtCarrierSaleOrderResult structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetHead() != null) {
				
				oprot.WriteFieldBegin("head");
				
				com.vip.haitao.orderservice.service.HeadHelper.getInstance().Write(structs.GetHead(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSaleOrderList() != null) {
				
				oprot.WriteFieldBegin("saleOrderList");
				
				oprot.WriteListBegin();
				foreach(com.vip.haitao.orderservice.service.HtSaleOrderChbResult _item0 in structs.GetSaleOrderList()){
					
					
					com.vip.haitao.orderservice.service.HtSaleOrderChbResultHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(HtCarrierSaleOrderResult bean){
			
			
		}
		
	}
	
}