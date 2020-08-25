using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.marketplace.product{
	
	
	
	public class AppendSkusRequestHelper : TBeanSerializer<AppendSkusRequest>
	{
		
		public static AppendSkusRequestHelper OBJ = new AppendSkusRequestHelper();
		
		public static AppendSkusRequestHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(AppendSkusRequest structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("skus".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.marketplace.product.AddSkuItem> value;
						
						value = new List<vipapis.marketplace.product.AddSkuItem>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.marketplace.product.AddSkuItem elem0;
								
								elem0 = new vipapis.marketplace.product.AddSkuItem();
								vipapis.marketplace.product.AddSkuItemHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetSkus(value);
					}
					
					
					
					
					
					if ("color_images".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.marketplace.product.ColorImage> value;
						
						value = new List<vipapis.marketplace.product.ColorImage>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.marketplace.product.ColorImage elem2;
								
								elem2 = new vipapis.marketplace.product.ColorImage();
								vipapis.marketplace.product.ColorImageHelper.getInstance().Read(elem2, iprot);
								
								value.Add(elem2);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetColor_images(value);
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
		
		
		public void Write(AppendSkusRequest structs, Protocol oprot){
			
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
			
			
			if(structs.GetSkus() != null) {
				
				oprot.WriteFieldBegin("skus");
				
				oprot.WriteListBegin();
				foreach(vipapis.marketplace.product.AddSkuItem _item0 in structs.GetSkus()){
					
					
					vipapis.marketplace.product.AddSkuItemHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetColor_images() != null) {
				
				oprot.WriteFieldBegin("color_images");
				
				oprot.WriteListBegin();
				foreach(vipapis.marketplace.product.ColorImage _item0 in structs.GetColor_images()){
					
					
					vipapis.marketplace.product.ColorImageHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(AppendSkusRequest bean){
			
			
		}
		
	}
	
}