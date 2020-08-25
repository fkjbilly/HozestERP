using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.response{
	
	
	
	public class GetPrepayOrderStatusRespHelper : TBeanSerializer<GetPrepayOrderStatusResp>
	{
		
		public static GetPrepayOrderStatusRespHelper OBJ = new GetPrepayOrderStatusRespHelper();
		
		public static GetPrepayOrderStatusRespHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetPrepayOrderStatusResp structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("statusVOMap".Equals(schemeField.Trim())){
						
						needSkip = false;
						Dictionary<string, com.vip.order.common.pojo.order.vo.PrepayOrderStatusVO> value;
						
						value = new Dictionary<string, com.vip.order.common.pojo.order.vo.PrepayOrderStatusVO>();
						iprot.ReadMapBegin();
						while(true){
							
							try{
								
								string _key1;
								com.vip.order.common.pojo.order.vo.PrepayOrderStatusVO _val1;
								_key1 = iprot.ReadString();
								
								
								_val1 = new com.vip.order.common.pojo.order.vo.PrepayOrderStatusVO();
								com.vip.order.common.pojo.order.vo.PrepayOrderStatusVOHelper.getInstance().Read(_val1, iprot);
								
								value.Add(_key1, _val1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadMapEnd();
						
						structs.SetStatusVOMap(value);
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
		
		
		public void Write(GetPrepayOrderStatusResp structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetResult() != null) {
				
				oprot.WriteFieldBegin("result");
				
				com.vip.order.common.pojo.order.result.ResultHelper.getInstance().Write(structs.GetResult(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetStatusVOMap() != null) {
				
				oprot.WriteFieldBegin("statusVOMap");
				
				oprot.WriteMapBegin();
				foreach(KeyValuePair< string, com.vip.order.common.pojo.order.vo.PrepayOrderStatusVO > _ir0 in structs.GetStatusVOMap()){
					
					string _key0 = _ir0.Key;
					com.vip.order.common.pojo.order.vo.PrepayOrderStatusVO _value0 = _ir0.Value;
					oprot.WriteString(_key0);
					
					
					com.vip.order.common.pojo.order.vo.PrepayOrderStatusVOHelper.getInstance().Write(_value0, oprot);
					
				}
				
				oprot.WriteMapEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetPrepayOrderStatusResp bean){
			
			
		}
		
	}
	
}