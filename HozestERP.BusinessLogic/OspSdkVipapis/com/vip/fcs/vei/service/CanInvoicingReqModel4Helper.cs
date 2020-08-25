using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.fcs.vei.service{
	
	
	
	public class CanInvoicingReqModel4Helper : TBeanSerializer<CanInvoicingReqModel4>
	{
		
		public static CanInvoicingReqModel4Helper OBJ = new CanInvoicingReqModel4Helper();
		
		public static CanInvoicingReqModel4Helper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(CanInvoicingReqModel4 structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("warehouse".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetWarehouse(value);
					}
					
					
					
					
					
					if ("province".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetProvince(value);
					}
					
					
					
					
					
					if ("city".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCity(value);
					}
					
					
					
					
					
					if ("goodsInfoList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.fcs.vei.service.GoodsInfoModel> value;
						
						value = new List<com.vip.fcs.vei.service.GoodsInfoModel>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.fcs.vei.service.GoodsInfoModel elem0;
								
								elem0 = new com.vip.fcs.vei.service.GoodsInfoModel();
								com.vip.fcs.vei.service.GoodsInfoModelHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetGoodsInfoList(value);
					}
					
					
					
					
					
					if ("sourceSystem".Equals(schemeField.Trim())){
						
						needSkip = false;
						int? value;
						value = iprot.ReadI32(); 
						
						structs.SetSourceSystem(value);
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
		
		
		public void Write(CanInvoicingReqModel4 structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetWarehouse() != null) {
				
				oprot.WriteFieldBegin("warehouse");
				oprot.WriteString(structs.GetWarehouse());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetProvince() != null) {
				
				oprot.WriteFieldBegin("province");
				oprot.WriteString(structs.GetProvince());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCity() != null) {
				
				oprot.WriteFieldBegin("city");
				oprot.WriteString(structs.GetCity());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetGoodsInfoList() != null) {
				
				oprot.WriteFieldBegin("goodsInfoList");
				
				oprot.WriteListBegin();
				foreach(com.vip.fcs.vei.service.GoodsInfoModel _item0 in structs.GetGoodsInfoList()){
					
					
					com.vip.fcs.vei.service.GoodsInfoModelHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSourceSystem() != null) {
				
				oprot.WriteFieldBegin("sourceSystem");
				oprot.WriteI32((int)structs.GetSourceSystem()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(CanInvoicingReqModel4 bean){
			
			
		}
		
	}
	
}