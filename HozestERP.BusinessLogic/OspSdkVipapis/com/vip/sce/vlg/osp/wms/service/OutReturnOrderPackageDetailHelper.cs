using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	public class OutReturnOrderPackageDetailHelper : TBeanSerializer<OutReturnOrderPackageDetail>
	{
		
		public static OutReturnOrderPackageDetailHelper OBJ = new OutReturnOrderPackageDetailHelper();
		
		public static OutReturnOrderPackageDetailHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OutReturnOrderPackageDetail structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("transportNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransportNo(value);
					}
					
					
					
					
					
					if ("custBoxNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCustBoxNo(value);
					}
					
					
					
					
					
					if ("receivingType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetReceivingType(value);
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
		
		
		public void Write(OutReturnOrderPackageDetail structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrderSn() != null) {
				
				oprot.WriteFieldBegin("orderSn");
				oprot.WriteString(structs.GetOrderSn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTransportNo() != null) {
				
				oprot.WriteFieldBegin("transportNo");
				oprot.WriteString(structs.GetTransportNo());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("transportNo can not be null!");
			}
			
			
			if(structs.GetCustBoxNo() != null) {
				
				oprot.WriteFieldBegin("custBoxNo");
				oprot.WriteString(structs.GetCustBoxNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetReceivingType() != null) {
				
				oprot.WriteFieldBegin("receivingType");
				oprot.WriteI32((int)structs.GetReceivingType()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("receivingType can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OutReturnOrderPackageDetail bean){
			
			
		}
		
	}
	
}