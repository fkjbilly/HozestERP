using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.svip.osp.service{
	
	
	
	public class BrandGiftIdResultHelper : TBeanSerializer<BrandGiftIdResult>
	{
		
		public static BrandGiftIdResultHelper OBJ = new BrandGiftIdResultHelper();
		
		public static BrandGiftIdResultHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(BrandGiftIdResult structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("toOpen".Equals(schemeField.Trim())){
						
						needSkip = false;
						bool value;
						value = iprot.ReadBool();
						
						structs.SetToOpen(value);
					}
					
					
					
					
					
					if ("brandGiftIdList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.svip.osp.service.BrandGiftIdItem> value;
						
						value = new List<com.vip.svip.osp.service.BrandGiftIdItem>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.svip.osp.service.BrandGiftIdItem elem0;
								
								elem0 = new com.vip.svip.osp.service.BrandGiftIdItem();
								com.vip.svip.osp.service.BrandGiftIdItemHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetBrandGiftIdList(value);
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
		
		
		public void Write(BrandGiftIdResult structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetToOpen() != null) {
				
				oprot.WriteFieldBegin("toOpen");
				oprot.WriteBool((bool)structs.GetToOpen());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("toOpen can not be null!");
			}
			
			
			if(structs.GetBrandGiftIdList() != null) {
				
				oprot.WriteFieldBegin("brandGiftIdList");
				
				oprot.WriteListBegin();
				foreach(com.vip.svip.osp.service.BrandGiftIdItem _item0 in structs.GetBrandGiftIdList()){
					
					
					com.vip.svip.osp.service.BrandGiftIdItemHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(BrandGiftIdResult bean){
			
			
		}
		
	}
	
}