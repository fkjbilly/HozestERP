using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.inventory{
	
	
	
	public class InventoryDeductOrderDetailResponseHelper : TBeanSerializer<InventoryDeductOrderDetailResponse>
	{
		
		public static InventoryDeductOrderDetailResponseHelper OBJ = new InventoryDeductOrderDetailResponseHelper();
		
		public static InventoryDeductOrderDetailResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(InventoryDeductOrderDetailResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("pick_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPick_no(value);
					}
					
					
					
					
					
					if ("has_next".Equals(schemeField.Trim())){
						
						needSkip = false;
						bool value;
						value = iprot.ReadBool();
						
						structs.SetHas_next(value);
					}
					
					
					
					
					
					if ("deduct_orders".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.inventory.DeductOrder> value;
						
						value = new List<vipapis.inventory.DeductOrder>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.inventory.DeductOrder elem0;
								
								elem0 = new vipapis.inventory.DeductOrder();
								vipapis.inventory.DeductOrderHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetDeduct_orders(value);
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
		
		
		public void Write(InventoryDeductOrderDetailResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetPick_no() != null) {
				
				oprot.WriteFieldBegin("pick_no");
				oprot.WriteString(structs.GetPick_no());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetHas_next() != null) {
				
				oprot.WriteFieldBegin("has_next");
				oprot.WriteBool((bool)structs.GetHas_next());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("has_next can not be null!");
			}
			
			
			if(structs.GetDeduct_orders() != null) {
				
				oprot.WriteFieldBegin("deduct_orders");
				
				oprot.WriteListBegin();
				foreach(vipapis.inventory.DeductOrder _item0 in structs.GetDeduct_orders()){
					
					
					vipapis.inventory.DeductOrderHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(InventoryDeductOrderDetailResponse bean){
			
			
		}
		
	}
	
}