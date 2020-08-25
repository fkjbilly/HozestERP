using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.request{
	
	
	
	public class GetRdcReqHelper : TBeanSerializer<GetRdcReq>
	{
		
		public static GetRdcReqHelper OBJ = new GetRdcReqHelper();
		
		public static GetRdcReqHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetRdcReq structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("warehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouse(value);
					}
					
					
					
					
					
					if ("merItemNoList".Equals(schemeField.Trim())){
						
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
						
						structs.SetMerItemNoList(value);
					}
					
					
					
					
					
					if ("merItemNoWarehouseMap".Equals(schemeField.Trim())){
						
						needSkip = false;
						Dictionary<long?, List<string>> value;
						
						value = new Dictionary<long?, List<string>>();
						iprot.ReadMapBegin();
						while(true){
							
							try{
								
								long _key1;
								List<string> _val1;
								_key1 = iprot.ReadI64(); 
								
								
								_val1 = new List<string>();
								iprot.ReadListBegin();
								while(true){
									
									try{
										
										string elem2;
										elem2 = iprot.ReadString();
										
										_val1.Add(elem2);
									}
									catch(Exception e){
										
										
										break;
									}
								}
								
								iprot.ReadListEnd();
								
								value.Add(_key1, _val1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadMapEnd();
						
						structs.SetMerItemNoWarehouseMap(value);
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
		
		
		public void Write(GetRdcReq structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetWarehouse() != null) {
				
				oprot.WriteFieldBegin("warehouse");
				oprot.WriteString(structs.GetWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMerItemNoList() != null) {
				
				oprot.WriteFieldBegin("merItemNoList");
				
				oprot.WriteListBegin();
				foreach(long _item0 in structs.GetMerItemNoList()){
					
					oprot.WriteI64((long)_item0); 
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMerItemNoWarehouseMap() != null) {
				
				oprot.WriteFieldBegin("merItemNoWarehouseMap");
				
				oprot.WriteMapBegin();
				foreach(KeyValuePair< long?, List<string> > _ir0 in structs.GetMerItemNoWarehouseMap()){
					
					long? _key0 = _ir0.Key;
					List<string> _value0 = _ir0.Value;
					oprot.WriteI64((long)_key0); 
					
					
					oprot.WriteListBegin();
					foreach(string _item1 in _value0){
						
						oprot.WriteString(_item1);
						
					}
					
					oprot.WriteListEnd();
					
				}
				
				oprot.WriteMapEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetRdcReq bean){
			
			
		}
		
	}
	
}