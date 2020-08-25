using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class SearchOrderLogsReqHelper : TBeanSerializer<SearchOrderLogsReq>
	{
		
		public static SearchOrderLogsReqHelper OBJ = new SearchOrderLogsReqHelper();
		
		public static SearchOrderLogsReqHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(SearchOrderLogsReq structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("orderList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.OrderVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.OrderVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.OrderVO elem0;
								
								elem0 = new com.vip.order.common.pojo.order.vo.OrderVO();
								com.vip.order.common.pojo.order.vo.OrderVOHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderList(value);
					}
					
					
					
					
					
					if ("userNameList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<string> value;
						
						value = new List<string>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								string elem2;
								elem2 = iprot.ReadString();
								
								value.Add(elem2);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetUserNameList(value);
					}
					
					
					
					
					
					if ("operateTypeRange".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.request.RangeParam value;
						
						value = new com.vip.order.common.pojo.order.request.RangeParam();
						com.vip.order.common.pojo.order.request.RangeParamHelper.getInstance().Read(value, iprot);
						
						structs.SetOperateTypeRange(value);
					}
					
					
					
					
					
					if ("dateRange".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.request.RangeParam value;
						
						value = new com.vip.order.common.pojo.order.request.RangeParam();
						com.vip.order.common.pojo.order.request.RangeParamHelper.getInstance().Read(value, iprot);
						
						structs.SetDateRange(value);
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
		
		
		public void Write(SearchOrderLogsReq structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrderList() != null) {
				
				oprot.WriteFieldBegin("orderList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.OrderVO _item0 in structs.GetOrderList()){
					
					
					com.vip.order.common.pojo.order.vo.OrderVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUserNameList() != null) {
				
				oprot.WriteFieldBegin("userNameList");
				
				oprot.WriteListBegin();
				foreach(string _item0 in structs.GetUserNameList()){
					
					oprot.WriteString(_item0);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOperateTypeRange() != null) {
				
				oprot.WriteFieldBegin("operateTypeRange");
				
				com.vip.order.common.pojo.order.request.RangeParamHelper.getInstance().Write(structs.GetOperateTypeRange(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDateRange() != null) {
				
				oprot.WriteFieldBegin("dateRange");
				
				com.vip.order.common.pojo.order.request.RangeParamHelper.getInstance().Write(structs.GetDateRange(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(SearchOrderLogsReq bean){
			
			
		}
		
	}
	
}