using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.domain.inventory{
	
	
	
	public class GetPoItemResponseHelper : TBeanSerializer<GetPoItemResponse>
	{
		
		public static GetPoItemResponseHelper OBJ = new GetPoItemResponseHelper();
		
		public static GetPoItemResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetPoItemResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("total".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetTotal(value);
					}
					
					
					
					
					
					if ("poItemList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.domain.inventory.PoItemObject> value;
						
						value = new List<com.vip.domain.inventory.PoItemObject>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.domain.inventory.PoItemObject elem0;
								
								elem0 = new com.vip.domain.inventory.PoItemObject();
								com.vip.domain.inventory.PoItemObjectHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetPoItemList(value);
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
		
		
		public void Write(GetPoItemResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetTotal() != null) {
				
				oprot.WriteFieldBegin("total");
				oprot.WriteI32((int)structs.GetTotal()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("total can not be null!");
			}
			
			
			if(structs.GetPoItemList() != null) {
				
				oprot.WriteFieldBegin("poItemList");
				
				oprot.WriteListBegin();
				foreach(com.vip.domain.inventory.PoItemObject _item0 in structs.GetPoItemList()){
					
					
					com.vip.domain.inventory.PoItemObjectHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetPoItemResponse bean){
			
			
		}
		
	}
	
}