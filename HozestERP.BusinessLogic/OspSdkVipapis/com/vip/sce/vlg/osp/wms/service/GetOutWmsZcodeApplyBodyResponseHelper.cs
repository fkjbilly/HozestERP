using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	public class GetOutWmsZcodeApplyBodyResponseHelper : TBeanSerializer<GetOutWmsZcodeApplyBodyResponse>
	{
		
		public static GetOutWmsZcodeApplyBodyResponseHelper OBJ = new GetOutWmsZcodeApplyBodyResponseHelper();
		
		public static GetOutWmsZcodeApplyBodyResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetOutWmsZcodeApplyBodyResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("returnList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.sce.vlg.osp.wms.service.OutWmsZcodeApplyInfo> value;
						
						value = new List<com.vip.sce.vlg.osp.wms.service.OutWmsZcodeApplyInfo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.sce.vlg.osp.wms.service.OutWmsZcodeApplyInfo elem0;
								
								elem0 = new com.vip.sce.vlg.osp.wms.service.OutWmsZcodeApplyInfo();
								com.vip.sce.vlg.osp.wms.service.OutWmsZcodeApplyInfoHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetReturnList(value);
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
		
		
		public void Write(GetOutWmsZcodeApplyBodyResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetReturnList() != null) {
				
				oprot.WriteFieldBegin("returnList");
				
				oprot.WriteListBegin();
				foreach(com.vip.sce.vlg.osp.wms.service.OutWmsZcodeApplyInfo _item0 in structs.GetReturnList()){
					
					
					com.vip.sce.vlg.osp.wms.service.OutWmsZcodeApplyInfoHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("returnList can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GetOutWmsZcodeApplyBodyResponse bean){
			
			
		}
		
	}
	
}