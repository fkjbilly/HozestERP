using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.schedule{
	
	
	
	public class GetScheduleListResponseHelper : BeanSerializer<GetScheduleListResponse>
	{
		
		public static GetScheduleListResponseHelper OBJ = new GetScheduleListResponseHelper();
		
		public static GetScheduleListResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetScheduleListResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("schedules".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.schedule.Schedule> value;
						
						value = new List<vipapis.schedule.Schedule>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.schedule.Schedule elem1;
								
								elem1 = new vipapis.schedule.Schedule();
								vipapis.schedule.ScheduleHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetSchedules(value);
					}
					
					
					
					
					
					if ("total".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
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
		
		
		public void Write(GetScheduleListResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetSchedules() != null) {
				
				oprot.WriteFieldBegin("schedules");
				
				oprot.WriteListBegin();
				foreach(vipapis.schedule.Schedule _item0 in structs.GetSchedules()){
					
					
					vipapis.schedule.ScheduleHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("schedules can not be null!");
			}
			
			
			if(structs.GetTotal() != null) {
				
				oprot.WriteFieldBegin("total");
				oprot.WriteI32((int)structs.GetTotal()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("total can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetScheduleListResponse bean){
			
			
		}
		
	}
	
}