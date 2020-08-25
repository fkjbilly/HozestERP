using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	public class OutShipContainerResultHelper : TBeanSerializer<OutShipContainerResult>
	{
		
		public static OutShipContainerResultHelper OBJ = new OutShipContainerResultHelper();
		
		public static OutShipContainerResultHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OutShipContainerResult structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("TOTE_NBR".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTOTE_NBR(value);
					}
					
					
					
					
					
					if ("PACKING_CODE".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPACKING_CODE(value);
					}
					
					
					
					
					
					if ("DEST_LOCN".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetDEST_LOCN(value);
					}
					
					
					
					
					
					if ("WCS_DEST_LOCN".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWCS_DEST_LOCN(value);
					}
					
					
					
					
					
					if ("CAGE_CODE".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCAGE_CODE(value);
					}
					
					
					
					
					
					if ("INDUCTION".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetINDUCTION(value);
					}
					
					
					
					
					
					if ("ACTUAL_SORT_TIME".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetACTUAL_SORT_TIME(value);
					}
					
					
					
					
					
					if ("FAIL_REASON".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetFAIL_REASON(value);
					}
					
					
					
					
					
					if ("RECIRCCOUNT".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetRECIRCCOUNT(value);
					}
					
					
					
					
					
					if ("CUBE".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCUBE(value);
					}
					
					
					
					
					
					if ("WEIGHT".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWEIGHT(value);
					}
					
					
					
					
					
					if ("TPS_MSGID".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTPS_MSGID(value);
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
		
		
		public void Write(OutShipContainerResult structs, Protocol oprot){
			
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
			
			
			if(structs.GetTOTE_NBR() != null) {
				
				oprot.WriteFieldBegin("TOTE_NBR");
				oprot.WriteString(structs.GetTOTE_NBR());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("TOTE_NBR can not be null!");
			}
			
			
			if(structs.GetPACKING_CODE() != null) {
				
				oprot.WriteFieldBegin("PACKING_CODE");
				oprot.WriteString(structs.GetPACKING_CODE());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("PACKING_CODE can not be null!");
			}
			
			
			if(structs.GetDEST_LOCN() != null) {
				
				oprot.WriteFieldBegin("DEST_LOCN");
				oprot.WriteString(structs.GetDEST_LOCN());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("DEST_LOCN can not be null!");
			}
			
			
			if(structs.GetWCS_DEST_LOCN() != null) {
				
				oprot.WriteFieldBegin("WCS_DEST_LOCN");
				oprot.WriteString(structs.GetWCS_DEST_LOCN());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("WCS_DEST_LOCN can not be null!");
			}
			
			
			if(structs.GetCAGE_CODE() != null) {
				
				oprot.WriteFieldBegin("CAGE_CODE");
				oprot.WriteString(structs.GetCAGE_CODE());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("CAGE_CODE can not be null!");
			}
			
			
			if(structs.GetINDUCTION() != null) {
				
				oprot.WriteFieldBegin("INDUCTION");
				oprot.WriteString(structs.GetINDUCTION());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("INDUCTION can not be null!");
			}
			
			
			if(structs.GetACTUAL_SORT_TIME() != null) {
				
				oprot.WriteFieldBegin("ACTUAL_SORT_TIME");
				oprot.WriteString(structs.GetACTUAL_SORT_TIME());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("ACTUAL_SORT_TIME can not be null!");
			}
			
			
			if(structs.GetFAIL_REASON() != null) {
				
				oprot.WriteFieldBegin("FAIL_REASON");
				oprot.WriteString(structs.GetFAIL_REASON());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRECIRCCOUNT() != null) {
				
				oprot.WriteFieldBegin("RECIRCCOUNT");
				oprot.WriteI32((int)structs.GetRECIRCCOUNT()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("RECIRCCOUNT can not be null!");
			}
			
			
			if(structs.GetCUBE() != null) {
				
				oprot.WriteFieldBegin("CUBE");
				oprot.WriteString(structs.GetCUBE());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("CUBE can not be null!");
			}
			
			
			if(structs.GetWEIGHT() != null) {
				
				oprot.WriteFieldBegin("WEIGHT");
				oprot.WriteString(structs.GetWEIGHT());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("WEIGHT can not be null!");
			}
			
			
			if(structs.GetTPS_MSGID() != null) {
				
				oprot.WriteFieldBegin("TPS_MSGID");
				oprot.WriteString(structs.GetTPS_MSGID());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("TPS_MSGID can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OutShipContainerResult bean){
			
			
		}
		
	}
	
}