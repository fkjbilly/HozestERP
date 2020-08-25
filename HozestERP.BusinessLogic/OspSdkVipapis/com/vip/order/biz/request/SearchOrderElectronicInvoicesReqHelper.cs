using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class SearchOrderElectronicInvoicesReqHelper : TBeanSerializer<SearchOrderElectronicInvoicesReq>
	{
		
		public static SearchOrderElectronicInvoicesReqHelper OBJ = new SearchOrderElectronicInvoicesReqHelper();
		
		public static SearchOrderElectronicInvoicesReqHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(SearchOrderElectronicInvoicesReq structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("userIdList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<long?> value;
						
						value = new List<long?>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								long elem0;
								elem0 = iprot.ReadI64(); 
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetUserIdList(value);
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
					
					
					
					
					
					if ("idList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<long?> value;
						
						value = new List<long?>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								long elem3;
								elem3 = iprot.ReadI64(); 
								
								value.Add(elem3);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetIdList(value);
					}
					
					
					
					
					
					if ("statusList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<int?> value;
						
						value = new List<int?>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								int elem4;
								elem4 = iprot.ReadI32(); 
								
								value.Add(elem4);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetStatusList(value);
					}
					
					
					
					
					
					if ("fpFm".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetFpFm(value);
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
		
		
		public void Write(SearchOrderElectronicInvoicesReq structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetUserIdList() != null) {
				
				oprot.WriteFieldBegin("userIdList");
				
				oprot.WriteListBegin();
				foreach(long _item0 in structs.GetUserIdList()){
					
					oprot.WriteI64((long)_item0); 
					
				}
				
				oprot.WriteListEnd();
				
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
			
			
			if(structs.GetStatusList() != null) {
				
				oprot.WriteFieldBegin("statusList");
				
				oprot.WriteListBegin();
				foreach(int _item0 in structs.GetStatusList()){
					
					oprot.WriteI32((int)_item0); 
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFpFm() != null) {
				
				oprot.WriteFieldBegin("fpFm");
				oprot.WriteString(structs.GetFpFm());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(SearchOrderElectronicInvoicesReq bean){
			
			
		}
		
	}
	
}