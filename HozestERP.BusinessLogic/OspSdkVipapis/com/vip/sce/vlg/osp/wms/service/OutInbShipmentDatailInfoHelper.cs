using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	public class OutInbShipmentDatailInfoHelper : TBeanSerializer<OutInbShipmentDatailInfo>
	{
		
		public static OutInbShipmentDatailInfoHelper OBJ = new OutInbShipmentDatailInfoHelper();
		
		public static OutInbShipmentDatailInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OutInbShipmentDatailInfo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("Id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetId(value);
					}
					
					
					
					
					
					if ("gCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGCode(value);
					}
					
					
					
					
					
					if ("custGoodsno".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCustGoodsno(value);
					}
					
					
					
					
					
					if ("ciqGoodsno".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCiqGoodsno(value);
					}
					
					
					
					
					
					if ("qty".Equals(schemeField.Trim())){
						
						needSkip = false;
						double value;
						value = iprot.ReadDouble();
						
						structs.SetQty(value);
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
		
		
		public void Write(OutInbShipmentDatailInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetId() != null) {
				
				oprot.WriteFieldBegin("Id");
				oprot.WriteString(structs.GetId());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("Id can not be null!");
			}
			
			
			if(structs.GetGCode() != null) {
				
				oprot.WriteFieldBegin("gCode");
				oprot.WriteString(structs.GetGCode());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("gCode can not be null!");
			}
			
			
			if(structs.GetCustGoodsno() != null) {
				
				oprot.WriteFieldBegin("custGoodsno");
				oprot.WriteString(structs.GetCustGoodsno());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("custGoodsno can not be null!");
			}
			
			
			if(structs.GetCiqGoodsno() != null) {
				
				oprot.WriteFieldBegin("ciqGoodsno");
				oprot.WriteString(structs.GetCiqGoodsno());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("ciqGoodsno can not be null!");
			}
			
			
			if(structs.GetQty() != null) {
				
				oprot.WriteFieldBegin("qty");
				oprot.WriteDouble((double)structs.GetQty());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("qty can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OutInbShipmentDatailInfo bean){
			
			
		}
		
	}
	
}