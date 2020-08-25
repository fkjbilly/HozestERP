using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.order.common.pojo.order.vo{
	
	
	
	public class OrderTransportDetailsAndPackageVOHelper : TBeanSerializer<OrderTransportDetailsAndPackageVO>
	{
		
		public static OrderTransportDetailsAndPackageVOHelper OBJ = new OrderTransportDetailsAndPackageVOHelper();
		
		public static OrderTransportDetailsAndPackageVOHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderTransportDetailsAndPackageVO structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("orderTransportPackage".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.order.common.pojo.order.vo.OrderTransportPackageVO value;
						
						value = new com.vip.order.common.pojo.order.vo.OrderTransportPackageVO();
						com.vip.order.common.pojo.order.vo.OrderTransportPackageVOHelper.getInstance().Read(value, iprot);
						
						structs.SetOrderTransportPackage(value);
					}
					
					
					
					
					
					if ("orderTransportDetailList".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<com.vip.order.common.pojo.order.vo.OrderTransportDetailVO> value;
						
						value = new List<com.vip.order.common.pojo.order.vo.OrderTransportDetailVO>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								com.vip.order.common.pojo.order.vo.OrderTransportDetailVO elem1;
								
								elem1 = new com.vip.order.common.pojo.order.vo.OrderTransportDetailVO();
								com.vip.order.common.pojo.order.vo.OrderTransportDetailVOHelper.getInstance().Read(elem1, iprot);
								
								value.Add(elem1);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrderTransportDetailList(value);
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
		
		
		public void Write(OrderTransportDetailsAndPackageVO structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrderTransportPackage() != null) {
				
				oprot.WriteFieldBegin("orderTransportPackage");
				
				com.vip.order.common.pojo.order.vo.OrderTransportPackageVOHelper.getInstance().Write(structs.GetOrderTransportPackage(), oprot);
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrderTransportDetailList() != null) {
				
				oprot.WriteFieldBegin("orderTransportDetailList");
				
				oprot.WriteListBegin();
				foreach(com.vip.order.common.pojo.order.vo.OrderTransportDetailVO _item0 in structs.GetOrderTransportDetailList()){
					
					
					com.vip.order.common.pojo.order.vo.OrderTransportDetailVOHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderTransportDetailsAndPackageVO bean){
			
			
		}
		
	}
	
}