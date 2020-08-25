using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.inventory{
	
	
	
	public class GetScheduleSkuListResultHelper : TBeanSerializer<GetScheduleSkuListResult>
	{
		
		public static GetScheduleSkuListResultHelper OBJ = new GetScheduleSkuListResultHelper();
		
		public static GetScheduleSkuListResultHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetScheduleSkuListResult structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("has_next".Equals(schemeField.Trim())){
						
						needSkip = false;
						bool? value;
						value = iprot.ReadBool();
						
						structs.SetHas_next(value);
					}
					
					
					
					
					
					if ("list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.inventory.ScheduleSku> value;
						
						value = new List<vipapis.inventory.ScheduleSku>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.inventory.ScheduleSku elem0;
								
								elem0 = new vipapis.inventory.ScheduleSku();
								vipapis.inventory.ScheduleSkuHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetList(value);
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
		
		
		public void Write(GetScheduleSkuListResult structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetHas_next() != null) {
				
				oprot.WriteFieldBegin("has_next");
				oprot.WriteBool((bool)structs.GetHas_next());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetList() != null) {
				
				oprot.WriteFieldBegin("list");
				
				oprot.WriteListBegin();
				foreach(vipapis.inventory.ScheduleSku _item0 in structs.GetList()){
					
					
					vipapis.inventory.ScheduleSkuHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetScheduleSkuListResult bean){
			
			
		}
		
	}
	
}