using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	public class OutShipContainerHelper : TBeanSerializer<OutShipContainer>
	{
		
		public static OutShipContainerHelper OBJ = new OutShipContainerHelper();
		
		public static OutShipContainerHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OutShipContainer structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("MSG_ID".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMSG_ID(value);
					}
					
					
					
					
					
					if ("WHSE".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWHSE(value);
					}
					
					
					
					
					
					if ("MSG_TYPE".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMSG_TYPE(value);
					}
					
					
					
					
					
					if ("PRCL_NBR".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPRCL_NBR(value);
					}
					
					
					
					
					
					if ("DEST_LOCN".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetDEST_LOCN(value);
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
		
		
		public void Write(OutShipContainer structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetMSG_ID() != null) {
				
				oprot.WriteFieldBegin("MSG_ID");
				oprot.WriteString(structs.GetMSG_ID());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("MSG_ID can not be null!");
			}
			
			
			if(structs.GetWHSE() != null) {
				
				oprot.WriteFieldBegin("WHSE");
				oprot.WriteString(structs.GetWHSE());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMSG_TYPE() != null) {
				
				oprot.WriteFieldBegin("MSG_TYPE");
				oprot.WriteString(structs.GetMSG_TYPE());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("MSG_TYPE can not be null!");
			}
			
			
			if(structs.GetPRCL_NBR() != null) {
				
				oprot.WriteFieldBegin("PRCL_NBR");
				oprot.WriteString(structs.GetPRCL_NBR());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("PRCL_NBR can not be null!");
			}
			
			
			if(structs.GetDEST_LOCN() != null) {
				
				oprot.WriteFieldBegin("DEST_LOCN");
				oprot.WriteString(structs.GetDEST_LOCN());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("DEST_LOCN can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OutShipContainer bean){
			
			
		}
		
	}
	
}