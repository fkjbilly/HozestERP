using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.svip.osp.service{
	
	
	
	public class BrandGiftDetailRequestHelper : TBeanSerializer<BrandGiftDetailRequest>
	{
		
		public static BrandGiftDetailRequestHelper OBJ = new BrandGiftDetailRequestHelper();
		
		public static BrandGiftDetailRequestHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(BrandGiftDetailRequest structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("userId".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetUserId(value);
					}
					
					
					
					
					
					if ("warehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouse(value);
					}
					
					
					
					
					
					if ("bizType".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBizType(value);
					}
					
					
					
					
					
					if ("idList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.svip.osp.service.BrandGiftIdReqItem> value;
						
						value = new List<com.vip.svip.osp.service.BrandGiftIdReqItem>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.svip.osp.service.BrandGiftIdReqItem elem0;
								
								elem0 = new com.vip.svip.osp.service.BrandGiftIdReqItem();
								com.vip.svip.osp.service.BrandGiftIdReqItemHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetIdList(value);
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
		
		
		public void Write(BrandGiftDetailRequest structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetUserId() != null) {
				
				oprot.WriteFieldBegin("userId");
				oprot.WriteI64((long)structs.GetUserId()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWarehouse() != null) {
				
				oprot.WriteFieldBegin("warehouse");
				oprot.WriteString(structs.GetWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBizType() != null) {
				
				oprot.WriteFieldBegin("bizType");
				oprot.WriteString(structs.GetBizType());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIdList() != null) {
				
				oprot.WriteFieldBegin("idList");
				
				oprot.WriteListBegin();
				foreach(com.vip.svip.osp.service.BrandGiftIdReqItem _item0 in structs.GetIdList()){
					
					
					com.vip.svip.osp.service.BrandGiftIdReqItemHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(BrandGiftDetailRequest bean){
			
			
		}
		
	}
	
}