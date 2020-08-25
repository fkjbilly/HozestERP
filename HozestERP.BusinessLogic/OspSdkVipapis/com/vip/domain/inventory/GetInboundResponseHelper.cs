using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.domain.inventory{
	
	
	
	public class GetInboundResponseHelper : TBeanSerializer<GetInboundResponse>
	{
		
		public static GetInboundResponseHelper OBJ = new GetInboundResponseHelper();
		
		public static GetInboundResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetInboundResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("detail_count".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetDetail_count(value);
					}
					
					
					
					
					
					if ("items".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.domain.inventory.InboundItemInfo> value;
						
						value = new List<com.vip.domain.inventory.InboundItemInfo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.domain.inventory.InboundItemInfo elem1;
								
								elem1 = new com.vip.domain.inventory.InboundItemInfo();
								com.vip.domain.inventory.InboundItemInfoHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetItems(value);
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
		
		
		public void Write(GetInboundResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetDetail_count() != null) {
				
				oprot.WriteFieldBegin("detail_count");
				oprot.WriteI32((int)structs.GetDetail_count()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("detail_count can not be null!");
			}
			
			
			if(structs.GetItems() != null) {
				
				oprot.WriteFieldBegin("items");
				
				oprot.WriteListBegin();
				foreach(com.vip.domain.inventory.InboundItemInfo _item0 in structs.GetItems()){
					
					
					com.vip.domain.inventory.InboundItemInfoHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("items can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetInboundResponse bean){
			
			
		}
		
	}
	
}