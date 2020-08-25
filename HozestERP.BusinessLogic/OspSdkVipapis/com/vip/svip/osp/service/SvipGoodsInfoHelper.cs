using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace com.vip.svip.osp.service{
	
	
	
	public class SvipGoodsInfoHelper : TBeanSerializer<SvipGoodsInfo>
	{
		
		public static SvipGoodsInfoHelper OBJ = new SvipGoodsInfoHelper();
		
		public static SvipGoodsInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(SvipGoodsInfo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("level".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetLevel(value);
					}
					
					
					
					
					
					if ("bizType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetBizType(value);
					}
					
					
					
					
					
					if ("goodsType".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetGoodsType(value);
					}
					
					
					
					
					
					if ("vpid".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetVpid(value);
					}
					
					
					
					
					
					if ("price".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPrice(value);
					}
					
					
					
					
					
					if ("remark".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetRemark(value);
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
		
		
		public void Write(SvipGoodsInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetLevel() != null) {
				
				oprot.WriteFieldBegin("level");
				oprot.WriteString(structs.GetLevel());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetBizType() != null) {
				
				oprot.WriteFieldBegin("bizType");
				oprot.WriteI32((int)structs.GetBizType()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("bizType can not be null!");
			}
			
			
			if(structs.GetGoodsType() != null) {
				
				oprot.WriteFieldBegin("goodsType");
				oprot.WriteI32((int)structs.GetGoodsType()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("goodsType can not be null!");
			}
			
			
			if(structs.GetVpid() != null) {
				
				oprot.WriteFieldBegin("vpid");
				oprot.WriteString(structs.GetVpid());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPrice() != null) {
				
				oprot.WriteFieldBegin("price");
				oprot.WriteString(structs.GetPrice());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetRemark() != null) {
				
				oprot.WriteFieldBegin("remark");
				oprot.WriteString(structs.GetRemark());
				
				oprot.WriteFieldEnd();
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(SvipGoodsInfo bean){
			
			
		}
		
	}
	
}