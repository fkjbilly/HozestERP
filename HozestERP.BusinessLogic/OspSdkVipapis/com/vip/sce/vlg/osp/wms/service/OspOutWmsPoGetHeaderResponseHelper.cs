using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	public class OspOutWmsPoGetHeaderResponseHelper : TBeanSerializer<OspOutWmsPoGetHeaderResponse>
	{
		
		public static OspOutWmsPoGetHeaderResponseHelper OBJ = new OspOutWmsPoGetHeaderResponseHelper();
		
		public static OspOutWmsPoGetHeaderResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OspOutWmsPoGetHeaderResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("header".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.sce.vlg.osp.wms.service.GetHeader value;
						
						value = new com.vip.sce.vlg.osp.wms.service.GetHeader();
						com.vip.sce.vlg.osp.wms.service.GetHeaderHelper.getInstance().Read(value, iprot);
						
						structs.SetHeader(value);
					}
					
					
					
					
					
					if ("body".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.sce.vlg.osp.wms.service.OspOutWmsPoGetBodyResponse value;
						
						value = new com.vip.sce.vlg.osp.wms.service.OspOutWmsPoGetBodyResponse();
						com.vip.sce.vlg.osp.wms.service.OspOutWmsPoGetBodyResponseHelper.getInstance().Read(value, iprot);
						
						structs.SetBody(value);
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
		
		
		public void Write(OspOutWmsPoGetHeaderResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetHeader() != null) {
				
				oprot.WriteFieldBegin("header");
				
				com.vip.sce.vlg.osp.wms.service.GetHeaderHelper.getInstance().Write(structs.GetHeader(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("header can not be null!");
			}
			
			
			if(structs.GetBody() != null) {
				
				oprot.WriteFieldBegin("body");
				
				com.vip.sce.vlg.osp.wms.service.OspOutWmsPoGetBodyResponseHelper.getInstance().Write(structs.GetBody(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OspOutWmsPoGetHeaderResponse bean){
			
			
		}
		
	}
	
}