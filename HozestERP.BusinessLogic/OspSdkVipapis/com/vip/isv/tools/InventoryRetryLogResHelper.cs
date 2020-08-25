using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.isv.tools{
	
	
	
	public class InventoryRetryLogResHelper : TBeanSerializer<InventoryRetryLogRes>
	{
		
		public static InventoryRetryLogResHelper OBJ = new InventoryRetryLogResHelper();
		
		public static InventoryRetryLogResHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(InventoryRetryLogRes structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("inventoryRetryLogDos".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.isv.tools.InventoryRetryLogDo> value;
						
						value = new List<com.vip.isv.tools.InventoryRetryLogDo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.isv.tools.InventoryRetryLogDo elem0;
								
								elem0 = new com.vip.isv.tools.InventoryRetryLogDo();
								com.vip.isv.tools.InventoryRetryLogDoHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetInventoryRetryLogDos(value);
					}
					
					
					
					
					
					if ("totalCount".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetTotalCount(value);
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
		
		
		public void Write(InventoryRetryLogRes structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetInventoryRetryLogDos() != null) {
				
				oprot.WriteFieldBegin("inventoryRetryLogDos");
				
				oprot.WriteListBegin();
				foreach(com.vip.isv.tools.InventoryRetryLogDo _item0 in structs.GetInventoryRetryLogDos()){
					
					
					com.vip.isv.tools.InventoryRetryLogDoHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTotalCount() != null) {
				
				oprot.WriteFieldBegin("totalCount");
				oprot.WriteI32((int)structs.GetTotalCount()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("totalCount can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(InventoryRetryLogRes bean){
			
			
		}
		
	}
	
}