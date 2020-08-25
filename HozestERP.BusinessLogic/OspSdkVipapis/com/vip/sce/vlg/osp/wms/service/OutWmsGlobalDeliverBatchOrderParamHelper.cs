using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	public class OutWmsGlobalDeliverBatchOrderParamHelper : TBeanSerializer<OutWmsGlobalDeliverBatchOrderParam>
	{
		
		public static OutWmsGlobalDeliverBatchOrderParamHelper OBJ = new OutWmsGlobalDeliverBatchOrderParamHelper();
		
		public static OutWmsGlobalDeliverBatchOrderParamHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OutWmsGlobalDeliverBatchOrderParam structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("brandId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long value;
						value = iprot.ReadI64(); 
						
						structs.SetBrandId(value);
					}
					
					
					
					
					
					if ("weight".Equals(schemeField.Trim())){
						
						needSkip = false;
						double value;
						value = iprot.ReadDouble();
						
						structs.SetWeight(value);
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
		
		
		public void Write(OutWmsGlobalDeliverBatchOrderParam structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrderSn() != null) {
				
				oprot.WriteFieldBegin("orderSn");
				oprot.WriteString(structs.GetOrderSn());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("orderSn can not be null!");
			}
			
			
			if(structs.GetBrandId() != null) {
				
				oprot.WriteFieldBegin("brandId");
				oprot.WriteI64((long)structs.GetBrandId()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("brandId can not be null!");
			}
			
			
			if(structs.GetWeight() != null) {
				
				oprot.WriteFieldBegin("weight");
				oprot.WriteDouble((double)structs.GetWeight());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("weight can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OutWmsGlobalDeliverBatchOrderParam bean){
			
			
		}
		
	}
	
}