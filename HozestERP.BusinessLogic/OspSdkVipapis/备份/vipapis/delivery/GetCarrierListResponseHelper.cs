using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.delivery{
	
	
	
	public class GetCarrierListResponseHelper : BeanSerializer<GetCarrierListResponse>
	{
		
		public static GetCarrierListResponseHelper OBJ = new GetCarrierListResponseHelper();
		
		public static GetCarrierListResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetCarrierListResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("carriers".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.delivery.Carrier> value;
						
						value = new List<vipapis.delivery.Carrier>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.delivery.Carrier elem1;
								
								elem1 = new vipapis.delivery.Carrier();
								vipapis.delivery.CarrierHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetCarriers(value);
					}
					
					
					
					
					
					if ("total".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetTotal(value);
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
		
		
		public void Write(GetCarrierListResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetCarriers() != null) {
				
				oprot.WriteFieldBegin("carriers");
				
				oprot.WriteListBegin();
				foreach(vipapis.delivery.Carrier _item0 in structs.GetCarriers()){
					
					
					vipapis.delivery.CarrierHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTotal() != null) {
				
				oprot.WriteFieldBegin("total");
				oprot.WriteI32((int)structs.GetTotal()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetCarrierListResponse bean){
			
			
		}
		
	}
	
}