using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.stock{
	
	
	
	public class UpdateWarehouseInventoryResponseHelper : TBeanSerializer<UpdateWarehouseInventoryResponse>
	{
		
		public static UpdateWarehouseInventoryResponseHelper OBJ = new UpdateWarehouseInventoryResponseHelper();
		
		public static UpdateWarehouseInventoryResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(UpdateWarehouseInventoryResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("success_data".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.stock.UpdateWarehouseInventoryResult> value;
						
						value = new List<vipapis.stock.UpdateWarehouseInventoryResult>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.stock.UpdateWarehouseInventoryResult elem0;
								
								elem0 = new vipapis.stock.UpdateWarehouseInventoryResult();
								vipapis.stock.UpdateWarehouseInventoryResultHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetSuccess_data(value);
					}
					
					
					
					
					
					if ("fail_data".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.stock.UpdateWarehouseInventoryResult> value;
						
						value = new List<vipapis.stock.UpdateWarehouseInventoryResult>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.stock.UpdateWarehouseInventoryResult elem2;
								
								elem2 = new vipapis.stock.UpdateWarehouseInventoryResult();
								vipapis.stock.UpdateWarehouseInventoryResultHelper.getInstance().Read(elem2, iprot);
								
								value.Add(elem2);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetFail_data(value);
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
		
		
		public void Write(UpdateWarehouseInventoryResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSuccess_data() != null) {
				
				oprot.WriteFieldBegin("success_data");
				
				oprot.WriteListBegin();
				foreach(vipapis.stock.UpdateWarehouseInventoryResult _item0 in structs.GetSuccess_data()){
					
					
					vipapis.stock.UpdateWarehouseInventoryResultHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFail_data() != null) {
				
				oprot.WriteFieldBegin("fail_data");
				
				oprot.WriteListBegin();
				foreach(vipapis.stock.UpdateWarehouseInventoryResult _item0 in structs.GetFail_data()){
					
					
					vipapis.stock.UpdateWarehouseInventoryResultHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(UpdateWarehouseInventoryResponse bean){
			
			
		}
		
	}
	
}