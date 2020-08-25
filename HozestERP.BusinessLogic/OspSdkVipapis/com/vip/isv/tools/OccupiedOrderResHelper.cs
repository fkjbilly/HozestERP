using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.isv.tools{
	
	
	
	public class OccupiedOrderResHelper : TBeanSerializer<OccupiedOrderRes>
	{
		
		public static OccupiedOrderResHelper OBJ = new OccupiedOrderResHelper();
		
		public static OccupiedOrderResHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OccupiedOrderRes structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("occupiedOrderDos".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.isv.tools.OccupiedOrderDo> value;
						
						value = new List<com.vip.isv.tools.OccupiedOrderDo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.isv.tools.OccupiedOrderDo elem0;
								
								elem0 = new com.vip.isv.tools.OccupiedOrderDo();
								com.vip.isv.tools.OccupiedOrderDoHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOccupiedOrderDos(value);
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
		
		
		public void Write(OccupiedOrderRes structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOccupiedOrderDos() != null) {
				
				oprot.WriteFieldBegin("occupiedOrderDos");
				
				oprot.WriteListBegin();
				foreach(com.vip.isv.tools.OccupiedOrderDo _item0 in structs.GetOccupiedOrderDos()){
					
					
					com.vip.isv.tools.OccupiedOrderDoHelper.getInstance().Write(_item0, oprot);
					
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
		
		
		public void Validate(OccupiedOrderRes bean){
			
			
		}
		
	}
	
}