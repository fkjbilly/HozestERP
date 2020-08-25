using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.haitao.loading.osp.service{
	
	
	
	public class OutLoadingReleaseOrderDetailHelper : TBeanSerializer<OutLoadingReleaseOrderDetail>
	{
		
		public static OutLoadingReleaseOrderDetailHelper OBJ = new OutLoadingReleaseOrderDetailHelper();
		
		public static OutLoadingReleaseOrderDetailHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OutLoadingReleaseOrderDetail structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("boxId".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBoxId(value);
					}
					
					
					
					
					
					if ("sizeSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSizeSn(value);
					}
					
					
					
					
					
					if ("customsNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCustomsNo(value);
					}
					
					
					
					
					
					if ("name".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetName(value);
					}
					
					
					
					
					
					if ("amount".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetAmount(value);
					}
					
					
					
					
					
					if ("price".Equals(schemeField.Trim())){
						
						needSkip = false;
						double value;
						value = iprot.ReadDouble();
						
						structs.SetPrice(value);
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
		
		
		public void Write(OutLoadingReleaseOrderDetail structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetBoxId() != null) {
				
				oprot.WriteFieldBegin("boxId");
				oprot.WriteString(structs.GetBoxId());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("boxId can not be null!");
			}
			
			
			if(structs.GetSizeSn() != null) {
				
				oprot.WriteFieldBegin("sizeSn");
				oprot.WriteString(structs.GetSizeSn());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("sizeSn can not be null!");
			}
			
			
			if(structs.GetCustomsNo() != null) {
				
				oprot.WriteFieldBegin("customsNo");
				oprot.WriteString(structs.GetCustomsNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetName() != null) {
				
				oprot.WriteFieldBegin("name");
				oprot.WriteString(structs.GetName());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("name can not be null!");
			}
			
			
			if(structs.GetAmount() != null) {
				
				oprot.WriteFieldBegin("amount");
				oprot.WriteI32((int)structs.GetAmount()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("amount can not be null!");
			}
			
			
			if(structs.GetPrice() != null) {
				
				oprot.WriteFieldBegin("price");
				oprot.WriteDouble((double)structs.GetPrice());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("price can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OutLoadingReleaseOrderDetail bean){
			
			
		}
		
	}
	
}