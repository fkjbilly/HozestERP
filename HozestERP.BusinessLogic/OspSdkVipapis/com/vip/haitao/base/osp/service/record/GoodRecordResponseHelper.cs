using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.haitao.base.osp.service.record{
	
	
	
	public class GoodRecordResponseHelper : TBeanSerializer<GoodRecordResponse>
	{
		
		public static GoodRecordResponseHelper OBJ = new GoodRecordResponseHelper();
		
		public static GoodRecordResponseHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(GoodRecordResponse structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("respCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRespCode(value);
					}
					
					
					
					
					
					if ("msg".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMsg(value);
					}
					
					
					
					
					
					if ("goodRecordList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.haitao.base.osp.service.record.HtGoodRecordModel> value;
						
						value = new List<com.vip.haitao.base.osp.service.record.HtGoodRecordModel>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.haitao.base.osp.service.record.HtGoodRecordModel elem0;
								
								elem0 = new com.vip.haitao.base.osp.service.record.HtGoodRecordModel();
								com.vip.haitao.base.osp.service.record.HtGoodRecordModelHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetGoodRecordList(value);
					}
					
					
					
					
					
					if ("sizeSnList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<string> value;
						
						value = new List<string>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								string elem2;
								elem2 = iprot.ReadString();
								
								value.Add(elem2);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetSizeSnList(value);
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
		
		
		public void Write(GoodRecordResponse structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetRespCode() != null) {
				
				oprot.WriteFieldBegin("respCode");
				oprot.WriteString(structs.GetRespCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetMsg() != null) {
				
				oprot.WriteFieldBegin("msg");
				oprot.WriteString(structs.GetMsg());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGoodRecordList() != null) {
				
				oprot.WriteFieldBegin("goodRecordList");
				
				oprot.WriteListBegin();
				foreach(com.vip.haitao.base.osp.service.record.HtGoodRecordModel _item0 in structs.GetGoodRecordList()){
					
					
					com.vip.haitao.base.osp.service.record.HtGoodRecordModelHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSizeSnList() != null) {
				
				oprot.WriteFieldBegin("sizeSnList");
				
				oprot.WriteListBegin();
				foreach(string _item0 in structs.GetSizeSnList()){
					
					oprot.WriteString(_item0);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(GoodRecordResponse bean){
			
			
		}
		
	}
	
}