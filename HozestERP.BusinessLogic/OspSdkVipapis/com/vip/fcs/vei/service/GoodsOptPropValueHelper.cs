using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.fcs.vei.service{
	
	
	
	public class GoodsOptPropValueHelper : TBeanSerializer<GoodsOptPropValue>
	{
		
		public static GoodsOptPropValueHelper OBJ = new GoodsOptPropValueHelper();
		
		public static GoodsOptPropValueHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GoodsOptPropValue structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("attrCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAttrCode(value);
					}
					
					
					
					
					
					if ("extAttrValue".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetExtAttrValue(value);
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
		
		
		public void Write(GoodsOptPropValue structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetAttrCode() != null) {
				
				oprot.WriteFieldBegin("attrCode");
				oprot.WriteString(structs.GetAttrCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetExtAttrValue() != null) {
				
				oprot.WriteFieldBegin("extAttrValue");
				oprot.WriteString(structs.GetExtAttrValue());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GoodsOptPropValue bean){
			
			
		}
		
	}
	
}