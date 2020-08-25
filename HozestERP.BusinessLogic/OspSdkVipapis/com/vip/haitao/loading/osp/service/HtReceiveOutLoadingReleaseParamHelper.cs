using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.haitao.loading.osp.service{
	
	
	
	public class HtReceiveOutLoadingReleaseParamHelper : TBeanSerializer<HtReceiveOutLoadingReleaseParam>
	{
		
		public static HtReceiveOutLoadingReleaseParamHelper OBJ = new HtReceiveOutLoadingReleaseParamHelper();
		
		public static HtReceiveOutLoadingReleaseParamHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(HtReceiveOutLoadingReleaseParam structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("userId".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUserId(value);
					}
					
					
					
					
					
					if ("listNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetListNo(value);
					}
					
					
					
					
					
					if ("idAuditDate".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetIdAuditDate(value);
					}
					
					
					
					
					
					if ("carNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCarNo(value);
					}
					
					
					
					
					
					if ("sumWeight".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetSumWeight(value);
					}
					
					
					
					
					
					if ("totalCount".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetTotalCount(value);
					}
					
					
					
					
					
					if ("cmdType".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCmdType(value);
					}
					
					
					
					
					
					if ("orders".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.haitao.loading.osp.service.OutLoadingReleaseOrders> value;
						
						value = new List<com.vip.haitao.loading.osp.service.OutLoadingReleaseOrders>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.haitao.loading.osp.service.OutLoadingReleaseOrders elem1;
								
								elem1 = new com.vip.haitao.loading.osp.service.OutLoadingReleaseOrders();
								com.vip.haitao.loading.osp.service.OutLoadingReleaseOrdersHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrders(value);
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
		
		
		public void Write(HtReceiveOutLoadingReleaseParam structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetUserId() != null) {
				
				oprot.WriteFieldBegin("userId");
				oprot.WriteString(structs.GetUserId());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("userId can not be null!");
			}
			
			
			if(structs.GetListNo() != null) {
				
				oprot.WriteFieldBegin("listNo");
				oprot.WriteString(structs.GetListNo());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("listNo can not be null!");
			}
			
			
			if(structs.GetIdAuditDate() != null) {
				
				oprot.WriteFieldBegin("idAuditDate");
				oprot.WriteString(structs.GetIdAuditDate());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("idAuditDate can not be null!");
			}
			
			
			if(structs.GetCarNo() != null) {
				
				oprot.WriteFieldBegin("carNo");
				oprot.WriteString(structs.GetCarNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSumWeight() != null) {
				
				oprot.WriteFieldBegin("sumWeight");
				oprot.WriteDouble((double)structs.GetSumWeight());
				
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
			
			
			if(structs.GetCmdType() != null) {
				
				oprot.WriteFieldBegin("cmdType");
				oprot.WriteString(structs.GetCmdType());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("cmdType can not be null!");
			}
			
			
			if(structs.GetOrders() != null) {
				
				oprot.WriteFieldBegin("orders");
				
				oprot.WriteListBegin();
				foreach(com.vip.haitao.loading.osp.service.OutLoadingReleaseOrders _item0 in structs.GetOrders()){
					
					
					com.vip.haitao.loading.osp.service.OutLoadingReleaseOrdersHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("orders can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(HtReceiveOutLoadingReleaseParam bean){
			
			
		}
		
	}
	
}