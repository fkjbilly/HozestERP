using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.comment.api.admin.service{
	
	
	
	public class OrderCommentRecordHelper : TBeanSerializer<OrderCommentRecord>
	{
		
		public static OrderCommentRecordHelper OBJ = new OrderCommentRecordHelper();
		
		public static OrderCommentRecordHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderCommentRecord structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("ordersn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrdersn(value);
					}
					
					
					
					
					
					if ("custNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						long value;
						value = iprot.ReadI64(); 
						
						structs.SetCustNo(value);
					}
					
					
					
					
					
					if ("deliveryManNo".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetDeliveryManNo(value);
					}
					
					
					
					
					
					if ("deliveryManName".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetDeliveryManName(value);
					}
					
					
					
					
					
					if ("serviceStarScore".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.comment.api.admin.service.StarScore? value;
						
						value = com.vip.comment.api.admin.service.StarScoreUtil.FindByName(iprot.ReadString());
						
						structs.SetServiceStarScore(value);
					}
					
					
					
					
					
					if ("recetimeStarScore".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.comment.api.admin.service.StarScore? value;
						
						value = com.vip.comment.api.admin.service.StarScoreUtil.FindByName(iprot.ReadString());
						
						structs.SetRecetimeStarScore(value);
					}
					
					
					
					
					
					if ("packageStarScore".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.comment.api.admin.service.StarScore? value;
						
						value = com.vip.comment.api.admin.service.StarScoreUtil.FindByName(iprot.ReadString());
						
						structs.SetPackageStarScore(value);
					}
					
					
					
					
					
					if ("satisfaction".Equals(schemeField.Trim())){
						
						needSkip = false;
						com.vip.comment.api.admin.service.Satisfaction? value;
						
						value = com.vip.comment.api.admin.service.SatisfactionUtil.FindByName(iprot.ReadString());
						
						structs.SetSatisfaction(value);
					}
					
					
					
					
					
					if ("impressToDelivery".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetImpressToDelivery(value);
					}
					
					
					
					
					
					if ("feelings".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetFeelings(value);
					}
					
					
					
					
					
					if ("createTime".Equals(schemeField.Trim())){
						
						needSkip = false;
						long? value;
						value = iprot.ReadI64(); 
						
						structs.SetCreateTime(value);
					}
					
					
					
					
					
					if ("createBy".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCreateBy(value);
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
		
		
		public void Write(OrderCommentRecord structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetOrdersn() != null) {
				
				oprot.WriteFieldBegin("ordersn");
				oprot.WriteString(structs.GetOrdersn());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCustNo() != null) {
				
				oprot.WriteFieldBegin("custNo");
				oprot.WriteI64((long)structs.GetCustNo()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("custNo can not be null!");
			}
			
			
			if(structs.GetDeliveryManNo() != null) {
				
				oprot.WriteFieldBegin("deliveryManNo");
				oprot.WriteString(structs.GetDeliveryManNo());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetDeliveryManName() != null) {
				
				oprot.WriteFieldBegin("deliveryManName");
				oprot.WriteString(structs.GetDeliveryManName());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetServiceStarScore() != null) {
				
				oprot.WriteFieldBegin("serviceStarScore");
				oprot.WriteString(structs.GetServiceStarScore().ToString());  
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRecetimeStarScore() != null) {
				
				oprot.WriteFieldBegin("recetimeStarScore");
				oprot.WriteString(structs.GetRecetimeStarScore().ToString());  
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPackageStarScore() != null) {
				
				oprot.WriteFieldBegin("packageStarScore");
				oprot.WriteString(structs.GetPackageStarScore().ToString());  
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetSatisfaction() != null) {
				
				oprot.WriteFieldBegin("satisfaction");
				oprot.WriteString(structs.GetSatisfaction().ToString());  
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetImpressToDelivery() != null) {
				
				oprot.WriteFieldBegin("impressToDelivery");
				oprot.WriteString(structs.GetImpressToDelivery());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetFeelings() != null) {
				
				oprot.WriteFieldBegin("feelings");
				oprot.WriteString(structs.GetFeelings());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCreateTime() != null) {
				
				oprot.WriteFieldBegin("createTime");
				oprot.WriteI64((long)structs.GetCreateTime()); 
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetCreateBy() != null) {
				
				oprot.WriteFieldBegin("createBy");
				oprot.WriteString(structs.GetCreateBy());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderCommentRecord bean){
			
			
		}
		
	}
	
}