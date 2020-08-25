using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class ReceptionConfirmDeliveredReqHelper : TBeanSerializer<ReceptionConfirmDeliveredReq>
	{
		
		public static ReceptionConfirmDeliveredReqHelper OBJ = new ReceptionConfirmDeliveredReqHelper();
		
		public static ReceptionConfirmDeliveredReqHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ReceptionConfirmDeliveredReq structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("orderId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetOrderId(value);
					}
					
					
					
					
					
					if ("userId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetUserId(value);
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
		
		
		public void Write(ReceptionConfirmDeliveredReq structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrderSn() != null) {
				
				oprot.WriteFieldBegin("orderSn");
				oprot.WriteString(structs.GetOrderSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderId() != null) {
				
				oprot.WriteFieldBegin("orderId");
				oprot.WriteI64((long)structs.GetOrderId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUserId() != null) {
				
				oprot.WriteFieldBegin("userId");
				oprot.WriteI64((long)structs.GetUserId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ReceptionConfirmDeliveredReq bean){
			
			
		}
		
	}
	
}