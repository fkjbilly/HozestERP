using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class MergeOrderReqHelper : TBeanSerializer<MergeOrderReq>
	{
		
		public static MergeOrderReqHelper OBJ = new MergeOrderReqHelper();
		
		public static MergeOrderReqHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(MergeOrderReq structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("userId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetUserId(value);
					}
					
					
					
					
					
					if ("mainOrderId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetMainOrderId(value);
					}
					
					
					
					
					
					if ("orderIdList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<long?> value;
						
						value = new List<long?>();
						iprot.ReadListBegin();
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
						
						iprot.ReadListEnd();
						
						structs.SetOrderIdList(value);
					}
					
					
					
					
					
					if ("mainOrderSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMainOrderSn(value);
					}
					
					
					
					
					
					if ("orderSnList".Equals(schemeField.Trim())){
						
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
						
						structs.SetOrderSnList(value);
					}
					
					
					
					
					
					if ("customerSrc".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCustomerSrc(value);
					}
					
					
					
					
					
					if ("codType".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCodType(value);
					}
					
					
					
					
					
					if ("codAppAccount".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCodAppAccount(value);
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
		
		
		public void Write(MergeOrderReq structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetUserId() != null) {
				
				oprot.WriteFieldBegin("userId");
				oprot.WriteI64((long)structs.GetUserId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMainOrderId() != null) {
				
				oprot.WriteFieldBegin("mainOrderId");
				oprot.WriteI64((long)structs.GetMainOrderId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderIdList() != null) {
				
				oprot.WriteFieldBegin("orderIdList");
				
				oprot.WriteListBegin();
				foreach(long _item0 in structs.GetOrderIdList()){
					
					oprot.WriteI64((long)_item0); 
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMainOrderSn() != null) {
				
				oprot.WriteFieldBegin("mainOrderSn");
				oprot.WriteString(structs.GetMainOrderSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderSnList() != null) {
				
				oprot.WriteFieldBegin("orderSnList");
				
				oprot.WriteListBegin();
				foreach(string _item0 in structs.GetOrderSnList()){
					
					oprot.WriteString(_item0);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCustomerSrc() != null) {
				
				oprot.WriteFieldBegin("customerSrc");
				oprot.WriteString(structs.GetCustomerSrc());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCodType() != null) {
				
				oprot.WriteFieldBegin("codType");
				oprot.WriteString(structs.GetCodType());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCodAppAccount() != null) {
				
				oprot.WriteFieldBegin("codAppAccount");
				oprot.WriteString(structs.GetCodAppAccount());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(MergeOrderReq bean){
			
			
		}
		
	}
	
}