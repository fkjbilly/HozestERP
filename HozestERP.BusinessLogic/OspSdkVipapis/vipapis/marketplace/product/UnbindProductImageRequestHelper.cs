using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.marketplace.product{
	
	
	
	public class UnbindProductImageRequestHelper : TBeanSerializer<UnbindProductImageRequest>
	{
		
		public static UnbindProductImageRequestHelper OBJ = new UnbindProductImageRequestHelper();
		
		public static UnbindProductImageRequestHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(UnbindProductImageRequest structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("spu_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSpu_id(value);
					}
					
					
					
					
					
					if ("index".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetIndex(value);
					}
					
					
					
					
					
					if ("color".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetColor(value);
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
		
		
		public void Write(UnbindProductImageRequest structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSpu_id() != null) {
				
				oprot.WriteFieldBegin("spu_id");
				oprot.WriteString(structs.GetSpu_id());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("spu_id can not be null!");
			}
			
			
			if(structs.GetIndex() != null) {
				
				oprot.WriteFieldBegin("index");
				oprot.WriteI32((int)structs.GetIndex()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("index can not be null!");
			}
			
			
			if(structs.GetColor() != null) {
				
				oprot.WriteFieldBegin("color");
				oprot.WriteString(structs.GetColor());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(UnbindProductImageRequest bean){
			
			
		}
		
	}
	
}