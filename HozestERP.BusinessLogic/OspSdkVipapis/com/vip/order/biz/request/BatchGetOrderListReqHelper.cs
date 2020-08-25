using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class BatchGetOrderListReqHelper : TBeanSerializer<BatchGetOrderListReq>
	{
		
		public static BatchGetOrderListReqHelper OBJ = new BatchGetOrderListReqHelper();
		
		public static BatchGetOrderListReqHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(BatchGetOrderListReq structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("orderTypeList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<int?> value;
						
						value = new List<int?>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								int elem0;
								elem0 = iprot.ReadI32(); 
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderTypeList(value);
					}
					
					
					
					
					
					if ("dbIndex".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetDbIndex(value);
					}
					
					
					
					
					
					if ("includeDeletedOrder".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetIncludeDeletedOrder(value);
					}
					
					
					
					
					
					if ("orderStatusRange".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.request.RangeParam value;
						
						value = new com.vip.order.common.pojo.order.request.RangeParam();
						com.vip.order.common.pojo.order.request.RangeParamHelper.getInstance().Read(value, iprot);
						
						structs.SetOrderStatusRange(value);
					}
					
					
					
					
					
					if ("orderDateRange".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.request.RangeParam value;
						
						value = new com.vip.order.common.pojo.order.request.RangeParam();
						com.vip.order.common.pojo.order.request.RangeParamHelper.getInstance().Read(value, iprot);
						
						structs.SetOrderDateRange(value);
					}
					
					
					
					
					
					if ("orderTimeRange".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.request.RangeParam value;
						
						value = new com.vip.order.common.pojo.order.request.RangeParam();
						com.vip.order.common.pojo.order.request.RangeParamHelper.getInstance().Read(value, iprot);
						
						structs.SetOrderTimeRange(value);
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
		
		
		public void Write(BatchGetOrderListReq structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrderTypeList() != null) {
				
				oprot.WriteFieldBegin("orderTypeList");
				
				oprot.WriteListBegin();
				foreach(int _item0 in structs.GetOrderTypeList()){
					
					oprot.WriteI32((int)_item0); 
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDbIndex() != null) {
				
				oprot.WriteFieldBegin("dbIndex");
				oprot.WriteI32((int)structs.GetDbIndex()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIncludeDeletedOrder() != null) {
				
				oprot.WriteFieldBegin("includeDeletedOrder");
				oprot.WriteI32((int)structs.GetIncludeDeletedOrder()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderStatusRange() != null) {
				
				oprot.WriteFieldBegin("orderStatusRange");
				
				com.vip.order.common.pojo.order.request.RangeParamHelper.getInstance().Write(structs.GetOrderStatusRange(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderDateRange() != null) {
				
				oprot.WriteFieldBegin("orderDateRange");
				
				com.vip.order.common.pojo.order.request.RangeParamHelper.getInstance().Write(structs.GetOrderDateRange(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderTimeRange() != null) {
				
				oprot.WriteFieldBegin("orderTimeRange");
				
				com.vip.order.common.pojo.order.request.RangeParamHelper.getInstance().Write(structs.GetOrderTimeRange(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(BatchGetOrderListReq bean){
			
			
		}
		
	}
	
}