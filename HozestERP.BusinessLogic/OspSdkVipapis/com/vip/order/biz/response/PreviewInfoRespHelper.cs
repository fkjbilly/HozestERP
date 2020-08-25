using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.biz.response{
	
	
	
	public class PreviewInfoRespHelper : TBeanSerializer<PreviewInfoResp>
	{
		
		public static PreviewInfoRespHelper OBJ = new PreviewInfoRespHelper();
		
		public static PreviewInfoRespHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(PreviewInfoResp structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("virtualMoney".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVirtualMoney(value);
					}
					
					
					
					
					
					if ("totalPacketMoney".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTotalPacketMoney(value);
					}
					
					
					
					
					
					if ("total".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTotal(value);
					}
					
					
					
					
					
					if ("surplus".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSurplus(value);
					}
					
					
					
					
					
					if ("money".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMoney(value);
					}
					
					
					
					
					
					if ("favourableMoney".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetFavourableMoney(value);
					}
					
					
					
					
					
					if ("favourableId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetFavourableId(value);
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
		
		
		public void Write(PreviewInfoResp structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetVirtualMoney() != null) {
				
				oprot.WriteFieldBegin("virtualMoney");
				oprot.WriteString(structs.GetVirtualMoney());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTotalPacketMoney() != null) {
				
				oprot.WriteFieldBegin("totalPacketMoney");
				oprot.WriteString(structs.GetTotalPacketMoney());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTotal() != null) {
				
				oprot.WriteFieldBegin("total");
				oprot.WriteString(structs.GetTotal());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSurplus() != null) {
				
				oprot.WriteFieldBegin("surplus");
				oprot.WriteString(structs.GetSurplus());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMoney() != null) {
				
				oprot.WriteFieldBegin("money");
				oprot.WriteString(structs.GetMoney());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFavourableMoney() != null) {
				
				oprot.WriteFieldBegin("favourableMoney");
				oprot.WriteString(structs.GetFavourableMoney());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFavourableId() != null) {
				
				oprot.WriteFieldBegin("favourableId");
				oprot.WriteI64((long)structs.GetFavourableId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(PreviewInfoResp bean){
			
			
		}
		
	}
	
}