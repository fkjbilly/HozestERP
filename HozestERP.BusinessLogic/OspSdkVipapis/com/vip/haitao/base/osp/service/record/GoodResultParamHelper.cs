using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.haitao.base.osp.service.record{
	
	
	
	public class GoodResultParamHelper : TBeanSerializer<GoodResultParam>
	{
		
		public static GoodResultParamHelper OBJ = new GoodResultParamHelper();
		
		public static GoodResultParamHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GoodResultParam structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("goodResultAfterRecord".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.haitao.base.osp.service.record.GoodResultAfterRecord value;
						
						value = new com.vip.haitao.base.osp.service.record.GoodResultAfterRecord();
						com.vip.haitao.base.osp.service.record.GoodResultAfterRecordHelper.getInstance().Read(value, iprot);
						
						structs.SetGoodResultAfterRecord(value);
					}
					
					
					
					
					
					if ("htGoodRecordModel".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.haitao.base.osp.service.record.HtGoodRecordModel value;
						
						value = new com.vip.haitao.base.osp.service.record.HtGoodRecordModel();
						com.vip.haitao.base.osp.service.record.HtGoodRecordModelHelper.getInstance().Read(value, iprot);
						
						structs.SetHtGoodRecordModel(value);
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
		
		
		public void Write(GoodResultParam structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetGoodResultAfterRecord() != null) {
				
				oprot.WriteFieldBegin("goodResultAfterRecord");
				
				com.vip.haitao.base.osp.service.record.GoodResultAfterRecordHelper.getInstance().Write(structs.GetGoodResultAfterRecord(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetHtGoodRecordModel() != null) {
				
				oprot.WriteFieldBegin("htGoodRecordModel");
				
				com.vip.haitao.base.osp.service.record.HtGoodRecordModelHelper.getInstance().Write(structs.GetHtGoodRecordModel(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GoodResultParam bean){
			
			
		}
		
	}
	
}