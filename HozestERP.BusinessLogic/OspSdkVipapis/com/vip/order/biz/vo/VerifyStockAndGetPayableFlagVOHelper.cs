using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.vo{
	
	
	
	public class VerifyStockAndGetPayableFlagVOHelper : TBeanSerializer<VerifyStockAndGetPayableFlagVO>
	{
		
		public static VerifyStockAndGetPayableFlagVOHelper OBJ = new VerifyStockAndGetPayableFlagVOHelper();
		
		public static VerifyStockAndGetPayableFlagVOHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(VerifyStockAndGetPayableFlagVO structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("payResult".Equals(schemeField.Trim())){
						
						needSkip = false;
						bool? value;
						value = iprot.ReadBool();
						
						structs.SetPayResult(value);
					}
					
					
					
					
					
					if ("orderInfoVo".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.vo.OrderInfoVO value;
						
						value = new com.vip.order.common.pojo.order.vo.OrderInfoVO();
						com.vip.order.common.pojo.order.vo.OrderInfoVOHelper.getInstance().Read(value, iprot);
						
						structs.SetOrderInfoVo(value);
					}
					
					
					
					
					
					if ("takeMap".Equals(schemeField.Trim())){
						
						needSkip = false;
						Dictionary<int?, int?> value;
						
						value = new Dictionary<int?, int?>();
						iprot.ReadMapBegin();
						while(true){
							
							try{
								
								int _key1;
								int _val1;
								_key1 = iprot.ReadI32(); 
								
								_val1 = iprot.ReadI32(); 
								
								value.Add(_key1, _val1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadMapEnd();
						
						structs.SetTakeMap(value);
					}
					
					
					
					
					
					if ("noTakeMap".Equals(schemeField.Trim())){
						
						needSkip = false;
						Dictionary<int?, int?> value;
						
						value = new Dictionary<int?, int?>();
						iprot.ReadMapBegin();
						while(true){
							
							try{
								
								int _key2;
								int _val2;
								_key2 = iprot.ReadI32(); 
								
								_val2 = iprot.ReadI32(); 
								
								value.Add(_key2, _val2);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadMapEnd();
						
						structs.SetNoTakeMap(value);
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
		
		
		public void Write(VerifyStockAndGetPayableFlagVO structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetPayResult() != null) {
				
				oprot.WriteFieldBegin("payResult");
				oprot.WriteBool((bool)structs.GetPayResult());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderInfoVo() != null) {
				
				oprot.WriteFieldBegin("orderInfoVo");
				
				com.vip.order.common.pojo.order.vo.OrderInfoVOHelper.getInstance().Write(structs.GetOrderInfoVo(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTakeMap() != null) {
				
				oprot.WriteFieldBegin("takeMap");
				
				oprot.WriteMapBegin();
				foreach(KeyValuePair< int?, int? > _ir0 in structs.GetTakeMap()){
					
					int? _key0 = _ir0.Key;
					int? _value0 = _ir0.Value;
					oprot.WriteI32((int)_key0); 
					
					oprot.WriteI32((int)_value0); 
					
				}
				
				oprot.WriteMapEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetNoTakeMap() != null) {
				
				oprot.WriteFieldBegin("noTakeMap");
				
				oprot.WriteMapBegin();
				foreach(KeyValuePair< int?, int? > _ir0 in structs.GetNoTakeMap()){
					
					int? _key0 = _ir0.Key;
					int? _value0 = _ir0.Value;
					oprot.WriteI32((int)_key0); 
					
					oprot.WriteI32((int)_value0); 
					
				}
				
				oprot.WriteMapEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(VerifyStockAndGetPayableFlagVO bean){
			
			
		}
		
	}
	
}