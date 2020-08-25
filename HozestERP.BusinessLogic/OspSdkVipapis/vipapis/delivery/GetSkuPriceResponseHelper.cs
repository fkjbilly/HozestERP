using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.delivery{
	
	
	
	public class GetSkuPriceResponseHelper : TBeanSerializer<GetSkuPriceResponse>
	{
		
		public static GetSkuPriceResponseHelper OBJ = new GetSkuPriceResponseHelper();
		
		public static GetSkuPriceResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetSkuPriceResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("price_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.delivery.PriceInfo> value;
						
						value = new List<vipapis.delivery.PriceInfo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.delivery.PriceInfo elem0;
								
								elem0 = new vipapis.delivery.PriceInfo();
								vipapis.delivery.PriceInfoHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetPrice_list(value);
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
		
		
		public void Write(GetSkuPriceResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetPrice_list() != null) {
				
				oprot.WriteFieldBegin("price_list");
				
				oprot.WriteListBegin();
				foreach(vipapis.delivery.PriceInfo _item0 in structs.GetPrice_list()){
					
					
					vipapis.delivery.PriceInfoHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("price_list can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetSkuPriceResponse bean){
			
			
		}
		
	}
	
}