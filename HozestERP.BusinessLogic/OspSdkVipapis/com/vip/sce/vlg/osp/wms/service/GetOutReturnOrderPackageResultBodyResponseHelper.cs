using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	public class GetOutReturnOrderPackageResultBodyResponseHelper : TBeanSerializer<GetOutReturnOrderPackageResultBodyResponse>
	{
		
		public static GetOutReturnOrderPackageResultBodyResponseHelper OBJ = new GetOutReturnOrderPackageResultBodyResponseHelper();
		
		public static GetOutReturnOrderPackageResultBodyResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GetOutReturnOrderPackageResultBodyResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("returnList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.sce.vlg.osp.wms.service.OutReturnOrderPackageResult> value;
						
						value = new List<com.vip.sce.vlg.osp.wms.service.OutReturnOrderPackageResult>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.sce.vlg.osp.wms.service.OutReturnOrderPackageResult elem0;
								
								elem0 = new com.vip.sce.vlg.osp.wms.service.OutReturnOrderPackageResult();
								com.vip.sce.vlg.osp.wms.service.OutReturnOrderPackageResultHelper.getInstance().Read(elem0, iprot);
								
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
		
		
		public void Write(GetOutReturnOrderPackageResultBodyResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetReturnList() != null) {
				
				oprot.WriteFieldBegin("returnList");
				
				oprot.WriteListBegin();
				foreach(com.vip.sce.vlg.osp.wms.service.OutReturnOrderPackageResult _item0 in structs.GetReturnList()){
					
					
					com.vip.sce.vlg.osp.wms.service.OutReturnOrderPackageResultHelper.getInstance().Write(_item0, oprot);
					
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
		
		
		public void Validate(GetOutReturnOrderPackageResultBodyResponse bean){
			
			
		}
		
	}
	
}