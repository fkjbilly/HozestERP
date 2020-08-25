using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.sce.vlg.osp.wms.service{
	
	
	
	public class ReturnOutInfoHelper : TBeanSerializer<ReturnOutInfo>
	{
		
		public static ReturnOutInfoHelper OBJ = new ReturnOutInfoHelper();
		
		public static ReturnOutInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(ReturnOutInfo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("transaction_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransaction_id(value);
					}
					
					
					
					
					
					if ("warehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouse(value);
					}
					
					
					
					
					
					if ("vendor_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVendor_code(value);
					}
					
					
					
					
					
					if ("return_sn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReturn_sn(value);
					}
					
					
					
					
					
					if ("out_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOut_time(value);
					}
					
					
					
					
					
					if ("total_cases".Equals(schemeField.Trim())){
						
						needSkip = false;
						double value;
						value = iprot.ReadDouble();
						
						structs.SetTotal_cases(value);
					}
					
					
					
					
					
					if ("total_skus".Equals(schemeField.Trim())){
						
						needSkip = false;
						double value;
						value = iprot.ReadDouble();
						
						structs.SetTotal_skus(value);
					}
					
					
					
					
					
					if ("total_qtys".Equals(schemeField.Trim())){
						
						needSkip = false;
						double value;
						value = iprot.ReadDouble();
						
						structs.SetTotal_qtys(value);
					}
					
					
					
					
					
					if ("return_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetReturn_type(value);
					}
					
					
					
					
					
					if ("sub_return_sn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSub_return_sn(value);
					}
					
					
					
					
					
					if ("sub_return_flag".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetSub_return_flag(value);
					}
					
					
					
					
					
					if ("detail".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.sce.vlg.osp.wms.service.ReturnOutDetailInfo> value;
						
						value = new List<com.vip.sce.vlg.osp.wms.service.ReturnOutDetailInfo>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.sce.vlg.osp.wms.service.ReturnOutDetailInfo elem1;
								
								elem1 = new com.vip.sce.vlg.osp.wms.service.ReturnOutDetailInfo();
								com.vip.sce.vlg.osp.wms.service.ReturnOutDetailInfoHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
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
		
		
		public void Write(ReturnOutInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetTransaction_id() != null) {
				
				oprot.WriteFieldBegin("transaction_id");
				oprot.WriteString(structs.GetTransaction_id());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("transaction_id can not be null!");
			}
			
			
			if(structs.GetWarehouse() != null) {
				
				oprot.WriteFieldBegin("warehouse");
				oprot.WriteString(structs.GetWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("warehouse can not be null!");
			}
			
			
			if(structs.GetVendor_code() != null) {
				
				oprot.WriteFieldBegin("vendor_code");
				oprot.WriteString(structs.GetVendor_code());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("vendor_code can not be null!");
			}
			
			
			if(structs.GetReturn_sn() != null) {
				
				oprot.WriteFieldBegin("return_sn");
				oprot.WriteString(structs.GetReturn_sn());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("return_sn can not be null!");
			}
			
			
			if(structs.GetOut_time() != null) {
				
				oprot.WriteFieldBegin("out_time");
				oprot.WriteString(structs.GetOut_time());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("out_time can not be null!");
			}
			
			
			if(structs.GetTotal_cases() != null) {
				
				oprot.WriteFieldBegin("total_cases");
				oprot.WriteDouble((double)structs.GetTotal_cases());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("total_cases can not be null!");
			}
			
			
			if(structs.GetTotal_skus() != null) {
				
				oprot.WriteFieldBegin("total_skus");
				oprot.WriteDouble((double)structs.GetTotal_skus());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("total_skus can not be null!");
			}
			
			
			if(structs.GetTotal_qtys() != null) {
				
				oprot.WriteFieldBegin("total_qtys");
				oprot.WriteDouble((double)structs.GetTotal_qtys());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("total_qtys can not be null!");
			}
			
			
			if(structs.GetReturn_type() != null) {
				
				oprot.WriteFieldBegin("return_type");
				oprot.WriteString(structs.GetReturn_type());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("return_type can not be null!");
			}
			
			
			if(structs.GetSub_return_sn() != null) {
				
				oprot.WriteFieldBegin("sub_return_sn");
				oprot.WriteString(structs.GetSub_return_sn());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("sub_return_sn can not be null!");
			}
			
			
			if(structs.GetSub_return_flag() != null) {
				
				oprot.WriteFieldBegin("sub_return_flag");
				oprot.WriteString(structs.GetSub_return_flag());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("sub_return_flag can not be null!");
			}
			
			
			if(structs.GetDetail() != null) {
				
				oprot.WriteFieldBegin("detail");
				
				oprot.WriteListBegin();
				foreach(com.vip.sce.vlg.osp.wms.service.ReturnOutDetailInfo _item0 in structs.GetDetail()){
					
					
					com.vip.sce.vlg.osp.wms.service.ReturnOutDetailInfoHelper.getInstance().Write(_item0, oprot);
					
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
		
		
		public void Validate(ReturnOutInfo bean){
			
			
		}
		
	}
	
}