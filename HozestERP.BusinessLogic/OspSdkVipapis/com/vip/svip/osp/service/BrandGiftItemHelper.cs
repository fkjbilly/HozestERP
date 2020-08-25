using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.svip.osp.service{
	
	
	
	public class BrandGiftItemHelper : TBeanSerializer<BrandGiftItem>
	{
		
		public static BrandGiftItemHelper OBJ = new BrandGiftItemHelper();
		
		public static BrandGiftItemHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(BrandGiftItem structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("brandLogo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBrandLogo(value);
					}
					
					
					
					
					
					if ("salesNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSalesNo(value);
					}
					
					
					
					
					
					if ("salesName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSalesName(value);
					}
					
					
					
					
					
					if ("tips".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTips(value);
					}
					
					
					
					
					
					if ("giftGoodsName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGiftGoodsName(value);
					}
					
					
					
					
					
					if ("giftGoodsImage".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetGiftGoodsImage(value);
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
		
		
		public void Write(BrandGiftItem structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetBrandLogo() != null) {
				
				oprot.WriteFieldBegin("brandLogo");
				oprot.WriteString(structs.GetBrandLogo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSalesNo() != null) {
				
				oprot.WriteFieldBegin("salesNo");
				oprot.WriteString(structs.GetSalesNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSalesName() != null) {
				
				oprot.WriteFieldBegin("salesName");
				oprot.WriteString(structs.GetSalesName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTips() != null) {
				
				oprot.WriteFieldBegin("tips");
				oprot.WriteString(structs.GetTips());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGiftGoodsName() != null) {
				
				oprot.WriteFieldBegin("giftGoodsName");
				oprot.WriteString(structs.GetGiftGoodsName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGiftGoodsImage() != null) {
				
				oprot.WriteFieldBegin("giftGoodsImage");
				oprot.WriteString(structs.GetGiftGoodsImage());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(BrandGiftItem bean){
			
			
		}
		
	}
	
}