using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	public class OutOubShipmentDatailInfoHelper : TBeanSerializer<OutOubShipmentDatailInfo>
	{
		
		public static OutOubShipmentDatailInfoHelper OBJ = new OutOubShipmentDatailInfoHelper();
		
		public static OutOubShipmentDatailInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OutOubShipmentDatailInfo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("barCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBarCode(value);
					}
					
					
					
					
					
					if ("gCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGCode(value);
					}
					
					
					
					
					
					if ("qty".Equals(schemeField.Trim())){
						
						needSkip = false;
						double value;
						value = iprot.ReadDouble();
						
						structs.SetQty(value);
					}
					
					
					
					
					
					if ("zCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetZCode(value);
					}
					
					
					
					
					
					if ("batchNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBatchNo(value);
					}
					
					
					
					
					
					if ("blNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBlNo(value);
					}
					
					
					
					
					
					if ("poNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPoNo(value);
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
		
		
		public void Write(OutOubShipmentDatailInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetBarCode() != null) {
				
				oprot.WriteFieldBegin("barCode");
				oprot.WriteString(structs.GetBarCode());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("barCode can not be null!");
			}
			
			
			if(structs.GetGCode() != null) {
				
				oprot.WriteFieldBegin("gCode");
				oprot.WriteString(structs.GetGCode());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("gCode can not be null!");
			}
			
			
			if(structs.GetQty() != null) {
				
				oprot.WriteFieldBegin("qty");
				oprot.WriteDouble((double)structs.GetQty());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("qty can not be null!");
			}
			
			
			if(structs.GetZCode() != null) {
				
				oprot.WriteFieldBegin("zCode");
				oprot.WriteString(structs.GetZCode());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("zCode can not be null!");
			}
			
			
			if(structs.GetBatchNo() != null) {
				
				oprot.WriteFieldBegin("batchNo");
				oprot.WriteString(structs.GetBatchNo());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("batchNo can not be null!");
			}
			
			
			if(structs.GetBlNo() != null) {
				
				oprot.WriteFieldBegin("blNo");
				oprot.WriteString(structs.GetBlNo());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("blNo can not be null!");
			}
			
			
			if(structs.GetPoNo() != null) {
				
				oprot.WriteFieldBegin("poNo");
				oprot.WriteString(structs.GetPoNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OutOubShipmentDatailInfo bean){
			
			
		}
		
	}
	
}