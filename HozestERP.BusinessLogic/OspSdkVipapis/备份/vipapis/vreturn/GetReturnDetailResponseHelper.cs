using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.vreturn{
	
	
	
	public class GetReturnDetailResponseHelper : BeanSerializer<GetReturnDetailResponse>
	{
		
		public static GetReturnDetailResponseHelper OBJ = new GetReturnDetailResponseHelper();
		
		public static GetReturnDetailResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetReturnDetailResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("returnDeliveryInfos".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.vreturn.ReturnDeliveryInfo> value;
						
						value = new List<vipapis.vreturn.ReturnDeliveryInfo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.vreturn.ReturnDeliveryInfo elem0;
								
								elem0 = new vipapis.vreturn.ReturnDeliveryInfo();
								vipapis.vreturn.ReturnDeliveryInfoHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetReturnDeliveryInfos(value);
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
		
		
		public void Write(GetReturnDetailResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetReturnDeliveryInfos() != null) {
				
				oprot.WriteFieldBegin("returnDeliveryInfos");
				
				oprot.WriteListBegin();
				foreach(vipapis.vreturn.ReturnDeliveryInfo _item0 in structs.GetReturnDeliveryInfos()){
					
					
					vipapis.vreturn.ReturnDeliveryInfoHelper.getInstance().Write(_item0, oprot);
					
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
		
		
		public void Validate(GetReturnDetailResponse bean){
			
			
		}
		
	}
	
}