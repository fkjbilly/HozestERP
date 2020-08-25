using System;
using System.Collections.Generic;
using System.Text;
using Osp.Sdk.Base;
using Osp.Sdk.Protocol;
using Osp.Sdk.Exception;
namespace vipapis.overseas{
	
	
	
	public class OrderOutGoodsInfoHelper : TBeanSerializer<OrderOutGoodsInfo>
	{
		
		public static OrderOutGoodsInfoHelper OBJ = new OrderOutGoodsInfoHelper();
		
		public static OrderOutGoodsInfoHelper getInstance() {
			
			return OBJ;
		}
		
		
		public void Read(OrderOutGoodsInfo structs, Protocol iprot){
			
			
			String schemeStruct = iprot.ReadStructBegin();
			if(schemeStruct != null){
				
				while(true){
					
					String schemeField = iprot.ReadFieldBegin();
					if (schemeField == null) break;
					bool needSkip = true;
					
					
					if ("id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetId(value);
					}
					
					
					
					
					
					if ("order_sn".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOrder_sn(value);
					}
					
					
					
					
					
					if ("weight".Equals(schemeField.Trim())){
						
						needSkip = false;
						double value;
						value = iprot.ReadDouble();
						
						structs.SetWeight(value);
					}
					
					
					
					
					
					if ("length".Equals(schemeField.Trim())){
						
						needSkip = false;
						double value;
						value = iprot.ReadDouble();
						
						structs.SetLength(value);
					}
					
					
					
					
					
					if ("width".Equals(schemeField.Trim())){
						
						needSkip = false;
						double value;
						value = iprot.ReadDouble();
						
						structs.SetWidth(value);
					}
					
					
					
					
					
					if ("height".Equals(schemeField.Trim())){
						
						needSkip = false;
						double value;
						value = iprot.ReadDouble();
						
						structs.SetHeight(value);
					}
					
					
					
					
					
					if ("volume".Equals(schemeField.Trim())){
						
						needSkip = false;
						double value;
						value = iprot.ReadDouble();
						
						structs.SetVolume(value);
					}
					
					
					
					
					
					if ("box_id".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetBox_id(value);
					}
					
					
					
					
					
					if ("creat_time".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCreat_time(value);
					}
					
					
					
					
					
					if ("cmd_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCmd_type(value);
					}
					
					
					
					
					
					if ("material_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetMaterial_code(value);
					}
					
					
					
					
					
					if ("box_num".Equals(schemeField.Trim())){
						
						needSkip = false;
						int value;
						value = iprot.ReadI32(); 
						
						structs.SetBox_num(value);
					}
					
					
					
					
					
					if ("cust_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetCust_code(value);
					}
					
					
					
					
					
					if ("transport_no".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetTransport_no(value);
					}
					
					
					
					
					
					if ("pick_code".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetPick_code(value);
					}
					
					
					
					
					
					if ("out_type".Equals(schemeField.Trim())){
						
						needSkip = false;
						string value;
						value = iprot.ReadString();
						
						structs.SetOut_type(value);
					}
					
					
					
					
					
					if ("order_detail_list".Equals(schemeField.Trim())){
						
						needSkip = false;
						List<vipapis.overseas.OrderOutDetail> value;
						
						value = new List<vipapis.overseas.OrderOutDetail>();
						iprot.ReadListBegin();
						while(true){
							
							try{
								
								vipapis.overseas.OrderOutDetail elem0;
								
								elem0 = new vipapis.overseas.OrderOutDetail();
								vipapis.overseas.OrderOutDetailHelper.getInstance().Read(elem0, iprot);
								
								value.Add(elem0);
							}
							catch(Exception e){
								
								
								break;
							}
						}
						
						iprot.ReadListEnd();
						
						structs.SetOrder_detail_list(value);
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
		
		
		public void Write(OrderOutGoodsInfo structs, Protocol oprot){
			
			Validate(structs);
			oprot.WriteStructBegin();
			
			if(structs.GetId() != null) {
				
				oprot.WriteFieldBegin("id");
				oprot.WriteString(structs.GetId());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("id can not be null!");
			}
			
			
			if(structs.GetOrder_sn() != null) {
				
				oprot.WriteFieldBegin("order_sn");
				oprot.WriteString(structs.GetOrder_sn());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("order_sn can not be null!");
			}
			
			
			if(structs.GetWeight() != null) {
				
				oprot.WriteFieldBegin("weight");
				oprot.WriteDouble((double)structs.GetWeight());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("weight can not be null!");
			}
			
			
			if(structs.GetLength() != null) {
				
				oprot.WriteFieldBegin("length");
				oprot.WriteDouble((double)structs.GetLength());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("length can not be null!");
			}
			
			
			if(structs.GetWidth() != null) {
				
				oprot.WriteFieldBegin("width");
				oprot.WriteDouble((double)structs.GetWidth());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("width can not be null!");
			}
			
			
			if(structs.GetHeight() != null) {
				
				oprot.WriteFieldBegin("height");
				oprot.WriteDouble((double)structs.GetHeight());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("height can not be null!");
			}
			
			
			if(structs.GetVolume() != null) {
				
				oprot.WriteFieldBegin("volume");
				oprot.WriteDouble((double)structs.GetVolume());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("volume can not be null!");
			}
			
			
			if(structs.GetBox_id() != null) {
				
				oprot.WriteFieldBegin("box_id");
				oprot.WriteString(structs.GetBox_id());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("box_id can not be null!");
			}
			
			
			if(structs.GetCreat_time() != null) {
				
				oprot.WriteFieldBegin("creat_time");
				oprot.WriteString(structs.GetCreat_time());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("creat_time can not be null!");
			}
			
			
			if(structs.GetCmd_type() != null) {
				
				oprot.WriteFieldBegin("cmd_type");
				oprot.WriteString(structs.GetCmd_type());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("cmd_type can not be null!");
			}
			
			
			if(structs.GetMaterial_code() != null) {
				
				oprot.WriteFieldBegin("material_code");
				oprot.WriteString(structs.GetMaterial_code());
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("material_code can not be null!");
			}
			
			
			if(structs.GetBox_num() != null) {
				
				oprot.WriteFieldBegin("box_num");
				oprot.WriteI32((int)structs.GetBox_num()); 
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("box_num can not be null!");
			}
			
			
			if(structs.GetCust_code() != null) {
				
				oprot.WriteFieldBegin("cust_code");
				oprot.WriteString(structs.GetCust_code());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetTransport_no() != null) {
				
				oprot.WriteFieldBegin("transport_no");
				oprot.WriteString(structs.GetTransport_no());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetPick_code() != null) {
				
				oprot.WriteFieldBegin("pick_code");
				oprot.WriteString(structs.GetPick_code());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOut_type() != null) {
				
				oprot.WriteFieldBegin("out_type");
				oprot.WriteString(structs.GetOut_type());
				
				oprot.WriteFieldEnd();
			}
			
			
			if(structs.GetOrder_detail_list() != null) {
				
				oprot.WriteFieldBegin("order_detail_list");
				
				oprot.WriteListBegin();
				foreach(vipapis.overseas.OrderOutDetail _item0 in structs.GetOrder_detail_list()){
					
					
					vipapis.overseas.OrderOutDetailHelper.getInstance().Write(_item0, oprot);
					
				}
				
				oprot.WriteListEnd();
				
				oprot.WriteFieldEnd();
			}
			
			else{
				throw new ArgumentException("order_detail_list can not be null!");
			}
			
			
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}
		
		
		public void Validate(OrderOutGoodsInfo bean){
			
			
		}
		
	}
	
}