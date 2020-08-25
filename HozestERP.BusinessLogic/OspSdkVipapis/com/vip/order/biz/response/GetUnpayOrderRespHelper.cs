using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.response{
	
	
	
	public class GetUnpayOrderRespHelper : TBeanSerializer<GetUnpayOrderResp>
	{
		
		public static GetUnpayOrderRespHelper OBJ = new GetUnpayOrderRespHelper();
		
		public static GetUnpayOrderRespHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetUnpayOrderResp structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("result".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.result.Result value;
						
						value = new com.vip.order.common.pojo.order.result.Result();
						com.vip.order.common.pojo.order.result.ResultHelper.getInstance().Read(value, iprot);
						
						structs.SetResult(value);
					}
					
					
					
					
					
					if ("unpayOrderSnMap".Equals(schemeField.Trim())){
						
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
						
						structs.SetUnpayOrderSnMap(value);
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
		
		
		public void Write(GetUnpayOrderResp structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetResult() != null) {
				
				oprot.WriteFieldBegin("result");
				
				com.vip.order.common.pojo.order.result.ResultHelper.getInstance().Write(structs.GetResult(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUnpayOrderSnMap() != null) {
				
				oprot.WriteFieldBegin("unpayOrderSnMap");
				
				oprot.WriteMapBegin();
				foreach(KeyValuePair< long?, List<string> > _ir0 in structs.GetUnpayOrderSnMap()){
					
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
		
		
		public void Validate(GetUnpayOrderResp bean){
			
			
		}
		
	}
	
}