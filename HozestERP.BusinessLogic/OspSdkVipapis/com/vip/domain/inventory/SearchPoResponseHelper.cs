using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.domain.inventory{
	
	
	
	public class SearchPoResponseHelper : TBeanSerializer<SearchPoResponse>
	{
		
		public static SearchPoResponseHelper OBJ = new SearchPoResponseHelper();
		
		public static SearchPoResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(SearchPoResponse structs, Protocol iprot){
			
			
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
					
					
					
					
					
					if ("poList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.domain.inventory.PoObject> value;
						
						value = new List<com.vip.domain.inventory.PoObject>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.domain.inventory.PoObject elem0;
								
								elem0 = new com.vip.domain.inventory.PoObject();
								com.vip.domain.inventory.PoObjectHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetPoList(value);
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
		
		
		public void Write(SearchPoResponse structs, Protocol oprot){
			
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
			
			
			if(structs.GetPoList() != null) {
				
				oprot.WriteFieldBegin("poList");
				
				oprot.WriteListBegin();
				foreach(com.vip.domain.inventory.PoObject _item0 in structs.GetPoList()){
					
					
					com.vip.domain.inventory.PoObjectHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(SearchPoResponse bean){
			
			
		}
		
	}
	
}