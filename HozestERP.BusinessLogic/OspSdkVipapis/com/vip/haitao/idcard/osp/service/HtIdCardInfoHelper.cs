using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.haitao.idcard.osp.service{
	
	
	
	public class HtIdCardInfoHelper : TBeanSerializer<HtIdCardInfo>
	{
		
		public static HtIdCardInfoHelper OBJ = new HtIdCardInfoHelper();
		
		public static HtIdCardInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(HtIdCardInfo structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("idCardType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetIdCardType(value);
					}
					
					
					
					
					
					if ("imageFront".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetImageFront(value);
					}
					
					
					
					
					
					if ("imageBack".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetImageBack(value);
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
		
		
		public void Write(HtIdCardInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrderSn() != null) {
				
				oprot.WriteFieldBegin("orderSn");
				oprot.WriteString(structs.GetOrderSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIdCardType() != null) {
				
				oprot.WriteFieldBegin("idCardType");
				oprot.WriteI32((int)structs.GetIdCardType()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetImageFront() != null) {
				
				oprot.WriteFieldBegin("imageFront");
				oprot.WriteString(structs.GetImageFront());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetImageBack() != null) {
				
				oprot.WriteFieldBegin("imageBack");
				oprot.WriteString(structs.GetImageBack());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(HtIdCardInfo bean){
			
			
		}
		
	}
	
}