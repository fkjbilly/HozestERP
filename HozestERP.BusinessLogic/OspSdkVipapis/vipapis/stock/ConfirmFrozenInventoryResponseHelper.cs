using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.stock{
	
	
	
	public class ConfirmFrozenInventoryResponseHelper : TBeanSerializer<ConfirmFrozenInventoryResponse>
	{
		
		public static ConfirmFrozenInventoryResponseHelper OBJ = new ConfirmFrozenInventoryResponseHelper();
		
		public static ConfirmFrozenInventoryResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ConfirmFrozenInventoryResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("success_data".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.stock.ConfirmFrozenInventoryResult> value;
						
						value = new List<vipapis.stock.ConfirmFrozenInventoryResult>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.stock.ConfirmFrozenInventoryResult elem0;
								
								elem0 = new vipapis.stock.ConfirmFrozenInventoryResult();
								vipapis.stock.ConfirmFrozenInventoryResultHelper.getInstance().Read(elem0, iprot);
								
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
						List<vipapis.stock.ConfirmFrozenInventoryResult> value;
						
						value = new List<vipapis.stock.ConfirmFrozenInventoryResult>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.stock.ConfirmFrozenInventoryResult elem2;
								
								elem2 = new vipapis.stock.ConfirmFrozenInventoryResult();
								vipapis.stock.ConfirmFrozenInventoryResultHelper.getInstance().Read(elem2, iprot);
								
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
		
		
		public void Write(ConfirmFrozenInventoryResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSuccess_data() != null) {
				
				oprot.WriteFieldBegin("success_data");
				
				oprot.WriteListBegin();
				foreach(vipapis.stock.ConfirmFrozenInventoryResult _item0 in structs.GetSuccess_data()){
					
					
					vipapis.stock.ConfirmFrozenInventoryResultHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFail_data() != null) {
				
				oprot.WriteFieldBegin("fail_data");
				
				oprot.WriteListBegin();
				foreach(vipapis.stock.ConfirmFrozenInventoryResult _item0 in structs.GetFail_data()){
					
					
					vipapis.stock.ConfirmFrozenInventoryResultHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ConfirmFrozenInventoryResponse bean){
			
			
		}
		
	}
	
}