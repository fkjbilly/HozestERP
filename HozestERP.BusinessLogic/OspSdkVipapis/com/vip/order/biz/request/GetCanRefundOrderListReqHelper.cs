using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class GetCanRefundOrderListReqHelper : TBeanSerializer<GetCanRefundOrderListReq>
	{
		
		public static GetCanRefundOrderListReqHelper OBJ = new GetCanRefundOrderListReqHelper();
		
		public static GetCanRefundOrderListReqHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetCanRefundOrderListReq structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("orderSnSet".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<string> value;
						
						value = new List<string>();
						iprot.ReadSetBegin();
						while(true){
							
							try{
								
								string elem0;
								elem0 = iprot.ReadString();
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadSetEnd();
						
						structs.SetOrderSnSet(value);
					}
					
					
					
					
					
					if ("userIdSet".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<long?> value;
						
						value = new List<long?>();
						iprot.ReadSetBegin();
						while(true){
							
							try{
								
								long elem1;
								elem1 = iprot.ReadI64(); 
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadSetEnd();
						
						structs.SetUserIdSet(value);
					}
					
					
					
					
					
					if ("orderTimeRange".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.request.RangeParam value;
						
						value = new com.vip.order.common.pojo.order.request.RangeParam();
						com.vip.order.common.pojo.order.request.RangeParamHelper.getInstance().Read(value, iprot);
						
						structs.SetOrderTimeRange(value);
					}
					
					
					
					
					
					if ("requirement".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.biz.request.ResultRequirementMap value;
						
						value = new com.vip.order.biz.request.ResultRequirementMap();
						com.vip.order.biz.request.ResultRequirementMapHelper.getInstance().Read(value, iprot);
						
						structs.SetRequirement(value);
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
		
		
		public void Write(GetCanRefundOrderListReq structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrderSnSet() != null) {
				
				oprot.WriteFieldBegin("orderSnSet");
				
				oprot.WriteSetBegin();
				foreach(string _item0 in structs.GetOrderSnSet()){
					
					oprot.WriteString(_item0);
					
				}
				
				oprot.WriteSetEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUserIdSet() != null) {
				
				oprot.WriteFieldBegin("userIdSet");
				
				oprot.WriteSetBegin();
				foreach(long _item0 in structs.GetUserIdSet()){
					
					oprot.WriteI64((long)_item0); 
					
				}
				
				oprot.WriteSetEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderTimeRange() != null) {
				
				oprot.WriteFieldBegin("orderTimeRange");
				
				com.vip.order.common.pojo.order.request.RangeParamHelper.getInstance().Write(structs.GetOrderTimeRange(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRequirement() != null) {
				
				oprot.WriteFieldBegin("requirement");
				
				com.vip.order.biz.request.ResultRequirementMapHelper.getInstance().Write(structs.GetRequirement(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetCanRefundOrderListReq bean){
			
			
		}
		
	}
	
}