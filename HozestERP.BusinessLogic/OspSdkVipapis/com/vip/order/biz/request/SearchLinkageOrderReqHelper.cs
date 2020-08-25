using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class SearchLinkageOrderReqHelper : TBeanSerializer<SearchLinkageOrderReq>
	{
		
		public static SearchLinkageOrderReqHelper OBJ = new SearchLinkageOrderReqHelper();
		
		public static SearchLinkageOrderReqHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(SearchLinkageOrderReq structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("orderSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrderSn(value);
					}
					
					
					
					
					
					if ("userId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetUserId(value);
					}
					
					
					
					
					
					if ("cancelOrderPrivilegeReq".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.biz.request.CancelOrderPrivilegeReq value;
						
						value = new com.vip.order.biz.request.CancelOrderPrivilegeReq();
						com.vip.order.biz.request.CancelOrderPrivilegeReqHelper.getInstance().Read(value, iprot);
						
						structs.SetCancelOrderPrivilegeReq(value);
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
		
		
		public void Write(SearchLinkageOrderReq structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrderSn() != null) {
				
				oprot.WriteFieldBegin("orderSn");
				oprot.WriteString(structs.GetOrderSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUserId() != null) {
				
				oprot.WriteFieldBegin("userId");
				oprot.WriteI64((long)structs.GetUserId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCancelOrderPrivilegeReq() != null) {
				
				oprot.WriteFieldBegin("cancelOrderPrivilegeReq");
				
				com.vip.order.biz.request.CancelOrderPrivilegeReqHelper.getInstance().Write(structs.GetCancelOrderPrivilegeReq(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(SearchLinkageOrderReq bean){
			
			
		}
		
	}
	
}