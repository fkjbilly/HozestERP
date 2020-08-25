using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class SearchOrderDetailReqHelper : TBeanSerializer<SearchOrderDetailReq>
	{
		
		public static SearchOrderDetailReqHelper OBJ = new SearchOrderDetailReqHelper();
		
		public static SearchOrderDetailReqHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(SearchOrderDetailReq structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("orderSnList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<string> value;
						
						value = new List<string>();
						iprot.ReadListBegin();
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
						
						iprot.ReadListEnd();
						
						structs.SetOrderSnList(value);
					}
					
					
					
					
					
					if ("idList".Equals(schemeField.Trim())){
						
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
						
						structs.SetIdList(value);
					}
					
					
					
					
					
					if ("orderCategory".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetOrderCategory(value);
					}
					
					
					
					
					
					if ("couponId".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCouponId(value);
					}
					
					
					
					
					
					if ("specialCondition".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSpecialCondition(value);
					}
					
					
					
					
					
					if ("returnFields".Equals(schemeField.Trim())){
						
						needSkip = false;
						Dictionary<string, string> value;
						
						value = new Dictionary<string, string>();
						iprot.ReadMapBegin();
						while(true){
							
							try{
								
								string _key2;
								string _val2;
								_key2 = iprot.ReadString();
								
								_val2 = iprot.ReadString();
								
								value.Add(_key2, _val2);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadMapEnd();
						
						structs.SetReturnFields(value);
					}
					
					
					
					
					
					if ("snType".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSnType(value);
					}
					
					
					
					
					
					if ("isDisplay".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetIsDisplay(value);
					}
					
					
					
					
					
					if ("vipclub".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVipclub(value);
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
		
		
		public void Write(SearchOrderDetailReq structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetUserId() != null) {
				
				oprot.WriteFieldBegin("userId");
				oprot.WriteI64((long)structs.GetUserId()); 
				
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
			
			
			if(structs.GetIdList() != null) {
				
				oprot.WriteFieldBegin("idList");
				
				oprot.WriteListBegin();
				foreach(long _item0 in structs.GetIdList()){
					
					oprot.WriteI64((long)_item0); 
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderCategory() != null) {
				
				oprot.WriteFieldBegin("orderCategory");
				oprot.WriteI32((int)structs.GetOrderCategory()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCouponId() != null) {
				
				oprot.WriteFieldBegin("couponId");
				oprot.WriteString(structs.GetCouponId());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSpecialCondition() != null) {
				
				oprot.WriteFieldBegin("specialCondition");
				oprot.WriteString(structs.GetSpecialCondition());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReturnFields() != null) {
				
				oprot.WriteFieldBegin("returnFields");
				
				oprot.WriteMapBegin();
				foreach(KeyValuePair< string, string > _ir0 in structs.GetReturnFields()){
					
					string _key0 = _ir0.Key;
					string _value0 = _ir0.Value;
					oprot.WriteString(_key0);
					
					oprot.WriteString(_value0);
					
				}
				
				oprot.WriteMapEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSnType() != null) {
				
				oprot.WriteFieldBegin("snType");
				oprot.WriteString(structs.GetSnType());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIsDisplay() != null) {
				
				oprot.WriteFieldBegin("isDisplay");
				oprot.WriteI32((int)structs.GetIsDisplay()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVipclub() != null) {
				
				oprot.WriteFieldBegin("vipclub");
				oprot.WriteString(structs.GetVipclub());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(SearchOrderDetailReq bean){
			
			
		}
		
	}
	
}