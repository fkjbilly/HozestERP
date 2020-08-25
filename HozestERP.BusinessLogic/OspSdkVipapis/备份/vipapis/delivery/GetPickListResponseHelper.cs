using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.delivery{
	
	
	
	public class GetPickListResponseHelper : BeanSerializer<GetPickListResponse>
	{
		
		public static GetPickListResponseHelper OBJ = new GetPickListResponseHelper();
		
		public static GetPickListResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetPickListResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("picks".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.delivery.Pick> value;
						
						value = new List<vipapis.delivery.Pick>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.delivery.Pick elem0;
								
								elem0 = new vipapis.delivery.Pick();
								vipapis.delivery.PickHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetPicks(value);
					}
					
					
					
					
					
					if ("total".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetTotal(value);
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
		
		
		public void Write(GetPickListResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetPicks() != null) {
				
				oprot.WriteFieldBegin("picks");
				
				oprot.WriteListBegin();
				foreach(vipapis.delivery.Pick _item0 in structs.GetPicks()){
					
					
					vipapis.delivery.PickHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTotal() != null) {
				
				oprot.WriteFieldBegin("total");
				oprot.WriteI32((int)structs.GetTotal()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetPickListResponse bean){
			
			
		}
		
	}
	
}