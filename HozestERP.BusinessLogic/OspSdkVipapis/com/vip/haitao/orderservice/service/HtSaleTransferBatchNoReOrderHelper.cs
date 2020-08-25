using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.haitao.orderservice.service{
	
	
	
	public class HtSaleTransferBatchNoReOrderHelper : TBeanSerializer<HtSaleTransferBatchNoReOrder>
	{
		
		public static HtSaleTransferBatchNoReOrderHelper OBJ = new HtSaleTransferBatchNoReOrderHelper();
		
		public static HtSaleTransferBatchNoReOrderHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(HtSaleTransferBatchNoReOrder structs, Protocol iprot){
			
			
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
						string value;
						value = iprot.ReadString();
						
						structs.SetBrandId(value);
					}
					
					
					
					
					
					if ("weight".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
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
		
		
		public void Write(HtSaleTransferBatchNoReOrder structs, Protocol oprot){
			
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
				oprot.WriteString(structs.GetBrandId());
				
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
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(HtSaleTransferBatchNoReOrder bean){
			
			
		}
		
	}
	
}