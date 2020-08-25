using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.marketplace.delivery{
	
	
	
	public class ShipResponseHelper : TBeanSerializer<ShipResponse>
	{
		
		public static ShipResponseHelper OBJ = new ShipResponseHelper();
		
		public static ShipResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ShipResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("success_num".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetSuccess_num(value);
					}
					
					
					
					
					
					if ("success_data".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.marketplace.delivery.ShipResult> value;
						
						value = new List<vipapis.marketplace.delivery.ShipResult>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.marketplace.delivery.ShipResult elem0;
								
								elem0 = new vipapis.marketplace.delivery.ShipResult();
								vipapis.marketplace.delivery.ShipResultHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetSuccess_data(value);
					}
					
					
					
					
					
					if ("fail_num".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetFail_num(value);
					}
					
					
					
					
					
					if ("fail_data".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.marketplace.delivery.ShipResult> value;
						
						value = new List<vipapis.marketplace.delivery.ShipResult>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.marketplace.delivery.ShipResult elem2;
								
								elem2 = new vipapis.marketplace.delivery.ShipResult();
								vipapis.marketplace.delivery.ShipResultHelper.getInstance().Read(elem2, iprot);
								
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
		
		
		public void Write(ShipResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSuccess_num() != null) {
				
				oprot.WriteFieldBegin("success_num");
				oprot.WriteI32((int)structs.GetSuccess_num()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSuccess_data() != null) {
				
				oprot.WriteFieldBegin("success_data");
				
				oprot.WriteListBegin();
				foreach(vipapis.marketplace.delivery.ShipResult _item0 in structs.GetSuccess_data()){
					
					
					vipapis.marketplace.delivery.ShipResultHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFail_num() != null) {
				
				oprot.WriteFieldBegin("fail_num");
				oprot.WriteI32((int)structs.GetFail_num()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFail_data() != null) {
				
				oprot.WriteFieldBegin("fail_data");
				
				oprot.WriteListBegin();
				foreach(vipapis.marketplace.delivery.ShipResult _item0 in structs.GetFail_data()){
					
					
					vipapis.marketplace.delivery.ShipResultHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(ShipResponse bean){
			
			
		}
		
	}
	
}