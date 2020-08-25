using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.inventory{
	
	
	
	public class DeductOrderHelper : TBeanSerializer<DeductOrder>
	{
		
		public static DeductOrderHelper OBJ = new DeductOrderHelper();
		
		public static DeductOrderHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(DeductOrder structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("occupied_order_sn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOccupied_order_sn(value);
					}
					
					
					
					
					
					if ("barcodes".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.inventory.DeductOrderDetail> value;
						
						value = new List<vipapis.inventory.DeductOrderDetail>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.inventory.DeductOrderDetail elem0;
								
								elem0 = new vipapis.inventory.DeductOrderDetail();
								vipapis.inventory.DeductOrderDetailHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetBarcodes(value);
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
		
		
		public void Write(DeductOrder structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOccupied_order_sn() != null) {
				
				oprot.WriteFieldBegin("occupied_order_sn");
				oprot.WriteString(structs.GetOccupied_order_sn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBarcodes() != null) {
				
				oprot.WriteFieldBegin("barcodes");
				
				oprot.WriteListBegin();
				foreach(vipapis.inventory.DeductOrderDetail _item0 in structs.GetBarcodes()){
					
					
					vipapis.inventory.DeductOrderDetailHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(DeductOrder bean){
			
			
		}
		
	}
	
}