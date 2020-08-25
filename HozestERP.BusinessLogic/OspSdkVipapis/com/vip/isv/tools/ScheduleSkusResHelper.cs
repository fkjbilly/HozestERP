using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.isv.tools{
	
	
	
	public class ScheduleSkusResHelper : TBeanSerializer<ScheduleSkusRes>
	{
		
		public static ScheduleSkusResHelper OBJ = new ScheduleSkusResHelper();
		
		public static ScheduleSkusResHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ScheduleSkusRes structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("scheduleSkusDos".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.isv.tools.ScheduleSkusDo> value;
						
						value = new List<com.vip.isv.tools.ScheduleSkusDo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.isv.tools.ScheduleSkusDo elem0;
								
								elem0 = new com.vip.isv.tools.ScheduleSkusDo();
								com.vip.isv.tools.ScheduleSkusDoHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetScheduleSkusDos(value);
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
		
		
		public void Write(ScheduleSkusRes structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetScheduleSkusDos() != null) {
				
				oprot.WriteFieldBegin("scheduleSkusDos");
				
				oprot.WriteListBegin();
				foreach(com.vip.isv.tools.ScheduleSkusDo _item0 in structs.GetScheduleSkusDos()){
					
					
					com.vip.isv.tools.ScheduleSkusDoHelper.getInstance().Write(_item0, oprot);
					
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
		
		
		public void Validate(ScheduleSkusRes bean){
			
			
		}
		
	}
	
}