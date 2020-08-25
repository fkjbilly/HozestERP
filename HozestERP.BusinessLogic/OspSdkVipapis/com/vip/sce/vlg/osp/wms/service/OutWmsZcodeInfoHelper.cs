using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	public class OutWmsZcodeInfoHelper : TBeanSerializer<OutWmsZcodeInfo>
	{
		
		public static OutWmsZcodeInfoHelper OBJ = new OutWmsZcodeInfoHelper();
		
		public static OutWmsZcodeInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OutWmsZcodeInfo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("BATCH_NUM".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBATCH_NUM(value);
					}
					
					
					
					
					
					if ("APP_NUM".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetAPP_NUM(value);
					}
					
					
					
					
					
					if ("AMOUNT".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetAMOUNT(value);
					}
					
					
					
					
					
					if ("detail".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.sce.vlg.osp.wms.service.OutWmsZcodeDatailInfo> value;
						
						value = new List<com.vip.sce.vlg.osp.wms.service.OutWmsZcodeDatailInfo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.sce.vlg.osp.wms.service.OutWmsZcodeDatailInfo elem0;
								
								elem0 = new com.vip.sce.vlg.osp.wms.service.OutWmsZcodeDatailInfo();
								com.vip.sce.vlg.osp.wms.service.OutWmsZcodeDatailInfoHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetDetail(value);
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
		
		
		public void Write(OutWmsZcodeInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetBATCH_NUM() != null) {
				
				oprot.WriteFieldBegin("BATCH_NUM");
				oprot.WriteString(structs.GetBATCH_NUM());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("BATCH_NUM can not be null!");
			}
			
			
			if(structs.GetAPP_NUM() != null) {
				
				oprot.WriteFieldBegin("APP_NUM");
				oprot.WriteString(structs.GetAPP_NUM());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("APP_NUM can not be null!");
			}
			
			
			if(structs.GetAMOUNT() != null) {
				
				oprot.WriteFieldBegin("AMOUNT");
				oprot.WriteI32((int)structs.GetAMOUNT()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("AMOUNT can not be null!");
			}
			
			
			if(structs.GetDetail() != null) {
				
				oprot.WriteFieldBegin("detail");
				
				oprot.WriteListBegin();
				foreach(com.vip.sce.vlg.osp.wms.service.OutWmsZcodeDatailInfo _item0 in structs.GetDetail()){
					
					
					com.vip.sce.vlg.osp.wms.service.OutWmsZcodeDatailInfoHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("detail can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OutWmsZcodeInfo bean){
			
			
		}
		
	}
	
}