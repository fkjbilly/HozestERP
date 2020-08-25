using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.haitao.loading.osp.service{
	
	
	
	public class OutLoadingReleaseOrdersHelper : TBeanSerializer<OutLoadingReleaseOrders>
	{
		
		public static OutLoadingReleaseOrdersHelper OBJ = new OutLoadingReleaseOrdersHelper();
		
		public static OutLoadingReleaseOrdersHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OutLoadingReleaseOrders structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("orderSn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrderSn(value);
					}
					
					
					
					
					
					if ("boxId".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBoxId(value);
					}
					
					
					
					
					
					if ("boxNum".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetBoxNum(value);
					}
					
					
					
					
					
					if ("oqcDate".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOqcDate(value);
					}
					
					
					
					
					
					if ("height".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetHeight(value);
					}
					
					
					
					
					
					if ("volume".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetVolume(value);
					}
					
					
					
					
					
					if ("weight".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetWeight(value);
					}
					
					
					
					
					
					if ("width".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetWidth(value);
					}
					
					
					
					
					
					if ("weightUm".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWeightUm(value);
					}
					
					
					
					
					
					if ("length".Equals(schemeField.Trim())){
						
						needSkip = false;
						double? value;
						value = iprot.ReadDouble();
						
						structs.SetLength(value);
					}
					
					
					
					
					
					if ("dimensioUm".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetDimensioUm(value);
					}
					
					
					
					
					
					if ("volumeUm".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVolumeUm(value);
					}
					
					
					
					
					
					if ("userCode".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUserCode(value);
					}
					
					
					
					
					
					if ("userName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetUserName(value);
					}
					
					
					
					
					
					if ("orderDetails".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.haitao.loading.osp.service.OutLoadingReleaseOrderDetail> value;
						
						value = new List<com.vip.haitao.loading.osp.service.OutLoadingReleaseOrderDetail>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.haitao.loading.osp.service.OutLoadingReleaseOrderDetail elem0;
								
								elem0 = new com.vip.haitao.loading.osp.service.OutLoadingReleaseOrderDetail();
								com.vip.haitao.loading.osp.service.OutLoadingReleaseOrderDetailHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderDetails(value);
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
		
		
		public void Write(OutLoadingReleaseOrders structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrderSn() != null) {
				
				oprot.WriteFieldBegin("orderSn");
				oprot.WriteString(structs.GetOrderSn());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("orderSn can not be null!");
			}
			
			
			if(structs.GetBoxId() != null) {
				
				oprot.WriteFieldBegin("boxId");
				oprot.WriteString(structs.GetBoxId());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("boxId can not be null!");
			}
			
			
			if(structs.GetBoxNum() != null) {
				
				oprot.WriteFieldBegin("boxNum");
				oprot.WriteI32((int)structs.GetBoxNum()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("boxNum can not be null!");
			}
			
			
			if(structs.GetOqcDate() != null) {
				
				oprot.WriteFieldBegin("oqcDate");
				oprot.WriteString(structs.GetOqcDate());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("oqcDate can not be null!");
			}
			
			
			if(structs.GetHeight() != null) {
				
				oprot.WriteFieldBegin("height");
				oprot.WriteDouble((double)structs.GetHeight());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVolume() != null) {
				
				oprot.WriteFieldBegin("volume");
				oprot.WriteDouble((double)structs.GetVolume());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWeight() != null) {
				
				oprot.WriteFieldBegin("weight");
				oprot.WriteDouble((double)structs.GetWeight());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWidth() != null) {
				
				oprot.WriteFieldBegin("width");
				oprot.WriteDouble((double)structs.GetWidth());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetWeightUm() != null) {
				
				oprot.WriteFieldBegin("weightUm");
				oprot.WriteString(structs.GetWeightUm());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetLength() != null) {
				
				oprot.WriteFieldBegin("length");
				oprot.WriteDouble((double)structs.GetLength());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDimensioUm() != null) {
				
				oprot.WriteFieldBegin("dimensioUm");
				oprot.WriteString(structs.GetDimensioUm());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetVolumeUm() != null) {
				
				oprot.WriteFieldBegin("volumeUm");
				oprot.WriteString(structs.GetVolumeUm());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUserCode() != null) {
				
				oprot.WriteFieldBegin("userCode");
				oprot.WriteString(structs.GetUserCode());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetUserName() != null) {
				
				oprot.WriteFieldBegin("userName");
				oprot.WriteString(structs.GetUserName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderDetails() != null) {
				
				oprot.WriteFieldBegin("orderDetails");
				
				oprot.WriteListBegin();
				foreach(com.vip.haitao.loading.osp.service.OutLoadingReleaseOrderDetail _item0 in structs.GetOrderDetails()){
					
					
					com.vip.haitao.loading.osp.service.OutLoadingReleaseOrderDetailHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OutLoadingReleaseOrders bean){
			
			
		}
		
	}
	
}