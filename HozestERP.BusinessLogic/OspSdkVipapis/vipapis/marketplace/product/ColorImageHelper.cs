using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.marketplace.product{
	
	
	
	public class ColorImageHelper : TBeanSerializer<ColorImage>
	{
		
		public static ColorImageHelper OBJ = new ColorImageHelper();
		
		public static ColorImageHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ColorImage structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("color".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetColor(value);
					}
					
					
					
					
					
					if ("images".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.marketplace.product.Image> value;
						
						value = new List<vipapis.marketplace.product.Image>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.marketplace.product.Image elem1;
								
								elem1 = new vipapis.marketplace.product.Image();
								vipapis.marketplace.product.ImageHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetImages(value);
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
		
		
		public void Write(ColorImage structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetColor() != null) {
				
				oprot.WriteFieldBegin("color");
				oprot.WriteString(structs.GetColor());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("color can not be null!");
			}
			
			
			if(structs.GetImages() != null) {
				
				oprot.WriteFieldBegin("images");
				
				oprot.WriteListBegin();
				foreach(vipapis.marketplace.product.Image _item0 in structs.GetImages()){
					
					
					vipapis.marketplace.product.ImageHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("images can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ColorImage bean){
			
			
		}
		
	}
	
}