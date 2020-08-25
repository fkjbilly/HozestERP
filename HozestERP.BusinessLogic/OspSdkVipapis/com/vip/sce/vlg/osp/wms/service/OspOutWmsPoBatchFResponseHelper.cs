using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	public class OspOutWmsPoBatchFResponseHelper : TBeanSerializer<OspOutWmsPoBatchFResponse>
	{
		
		public static OspOutWmsPoBatchFResponseHelper OBJ = new OspOutWmsPoBatchFResponseHelper();
		
		public static OspOutWmsPoBatchFResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OspOutWmsPoBatchFResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("total".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetTotal(value);
					}
					
					
					
					
					
					if ("po_batch_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.sce.vlg.osp.wms.service.OspOutWmsPoBatchFModel> value;
						
						value = new List<com.vip.sce.vlg.osp.wms.service.OspOutWmsPoBatchFModel>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.sce.vlg.osp.wms.service.OspOutWmsPoBatchFModel elem1;
								
								elem1 = new com.vip.sce.vlg.osp.wms.service.OspOutWmsPoBatchFModel();
								com.vip.sce.vlg.osp.wms.service.OspOutWmsPoBatchFModelHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetPo_batch_list(value);
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
		
		
		public void Write(OspOutWmsPoBatchFResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetTotal() != null) {
				
				oprot.WriteFieldBegin("total");
				oprot.WriteI32((int)structs.GetTotal()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("total can not be null!");
			}
			
			
			if(structs.GetPo_batch_list() != null) {
				
				oprot.WriteFieldBegin("po_batch_list");
				
				oprot.WriteListBegin();
				foreach(com.vip.sce.vlg.osp.wms.service.OspOutWmsPoBatchFModel _item0 in structs.GetPo_batch_list()){
					
					
					com.vip.sce.vlg.osp.wms.service.OspOutWmsPoBatchFModelHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("po_batch_list can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OspOutWmsPoBatchFResponse bean){
			
			
		}
		
	}
	
}