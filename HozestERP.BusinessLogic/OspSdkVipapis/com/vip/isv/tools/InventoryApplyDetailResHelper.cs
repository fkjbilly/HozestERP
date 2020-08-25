using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.isv.tools{
	
	
	
	public class InventoryApplyDetailResHelper : TBeanSerializer<InventoryApplyDetailRes>
	{
		
		public static InventoryApplyDetailResHelper OBJ = new InventoryApplyDetailResHelper();
		
		public static InventoryApplyDetailResHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(InventoryApplyDetailRes structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("inventoryApplyDetails".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.isv.tools.InventoryApplyDetailDo> value;
						
						value = new List<com.vip.isv.tools.InventoryApplyDetailDo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.isv.tools.InventoryApplyDetailDo elem0;
								
								elem0 = new com.vip.isv.tools.InventoryApplyDetailDo();
								com.vip.isv.tools.InventoryApplyDetailDoHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetInventoryApplyDetails(value);
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
		
		
		public void Write(InventoryApplyDetailRes structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetInventoryApplyDetails() != null) {
				
				oprot.WriteFieldBegin("inventoryApplyDetails");
				
				oprot.WriteListBegin();
				foreach(com.vip.isv.tools.InventoryApplyDetailDo _item0 in structs.GetInventoryApplyDetails()){
					
					
					com.vip.isv.tools.InventoryApplyDetailDoHelper.getInstance().Write(_item0, oprot);
					
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
		
		
		public void Validate(InventoryApplyDetailRes bean){
			
			
		}
		
	}
	
}