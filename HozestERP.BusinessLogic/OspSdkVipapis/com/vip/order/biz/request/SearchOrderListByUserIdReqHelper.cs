using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class SearchOrderListByUserIdReqHelper : TBeanSerializer<SearchOrderListByUserIdReq>
	{
		
		public static SearchOrderListByUserIdReqHelper OBJ = new SearchOrderListByUserIdReqHelper();
		
		public static SearchOrderListByUserIdReqHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(SearchOrderListByUserIdReq structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("keyword".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetKeyword(value);
					}
					
					
					
					
					
					if ("vipclubList".Equals(schemeField.Trim())){
						
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
						
						structs.SetVipclubList(value);
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
		
		
		public void Write(SearchOrderListByUserIdReq structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetUserId() != null) {
				
				oprot.WriteFieldBegin("userId");
				oprot.WriteI64((long)structs.GetUserId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetKeyword() != null) {
				
				oprot.WriteFieldBegin("keyword");
				oprot.WriteString(structs.GetKeyword());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVipclubList() != null) {
				
				oprot.WriteFieldBegin("vipclubList");
				
				oprot.WriteListBegin();
				foreach(string _item0 in structs.GetVipclubList()){
					
					oprot.WriteString(_item0);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(SearchOrderListByUserIdReq bean){
			
			
		}
		
	}
	
}