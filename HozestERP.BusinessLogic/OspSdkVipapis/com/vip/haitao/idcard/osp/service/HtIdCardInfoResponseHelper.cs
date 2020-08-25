using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.haitao.idcard.osp.service{
	
	
	
	public class HtIdCardInfoResponseHelper : TBeanSerializer<HtIdCardInfoResponse>
	{
		
		public static HtIdCardInfoResponseHelper OBJ = new HtIdCardInfoResponseHelper();
		
		public static HtIdCardInfoResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(HtIdCardInfoResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("head".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.haitao.idcard.osp.service.Head value;
						
						value = new com.vip.haitao.idcard.osp.service.Head();
						com.vip.haitao.idcard.osp.service.HeadHelper.getInstance().Read(value, iprot);
						
						structs.SetHead(value);
					}
					
					
					
					
					
					if ("idCardInfo".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.haitao.idcard.osp.service.HtIdCardInfo value;
						
						value = new com.vip.haitao.idcard.osp.service.HtIdCardInfo();
						com.vip.haitao.idcard.osp.service.HtIdCardInfoHelper.getInstance().Read(value, iprot);
						
						structs.SetIdCardInfo(value);
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
		
		
		public void Write(HtIdCardInfoResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetHead() != null) {
				
				oprot.WriteFieldBegin("head");
				
				com.vip.haitao.idcard.osp.service.HeadHelper.getInstance().Write(structs.GetHead(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetIdCardInfo() != null) {
				
				oprot.WriteFieldBegin("idCardInfo");
				
				com.vip.haitao.idcard.osp.service.HtIdCardInfoHelper.getInstance().Write(structs.GetIdCardInfo(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(HtIdCardInfoResponse bean){
			
			
		}
		
	}
	
}